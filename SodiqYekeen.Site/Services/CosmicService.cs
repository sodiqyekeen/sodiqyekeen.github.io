using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SodiqYekeen.Site.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace SodiqYekeen.Site.Services
{
    public class CosmicService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        //private readonly string _bucketSlug;
        private readonly string _readKey;
        private readonly string _baseUrl;

        public CosmicService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            string _bucketSlug = _configuration["cosmic_slug"];
            _readKey = _configuration["cosmic_readKey"];
            _baseUrl = $"https://api.cosmicjs.com/v1/{_bucketSlug}/";
        }

        public async Task<IEnumerable<Post>> GetTopPosts()
        {
            string url = $"{_baseUrl}objects?pretty=true&hide_metafields=true&type=posts&read_key={_readKey}&limit=6&props=slug,title,thumbnail";
            var postResponse = await _httpClient.GetFromJsonAsync<PostResponse>(url);
            return postResponse.Posts;
        }

        public async Task<(Post post, bool notFound)> GetPostBySlug(string slug)
        {
            var url = $"{_baseUrl}object/{slug}?pretty=true&hide_metafields=true&read_key={_readKey}&props=slug,title,content,thumbnail,metadata,created_at";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var _post = JsonSerializer.Deserialize<PostDetail>(await response.Content.ReadAsStringAsync());
                return (_post.Post, false);
            }
            return (null, true);
        }

        public async Task<PostResponse> GetPosts()
        {
            var url = $"{_baseUrl}objects?pretty=true&hide_metafields=true&type=posts&read_key={_readKey}&limit=20&props=slug,title,content,thumbnail";
            var postResponse = await _httpClient.GetFromJsonAsync<PostResponse>(url);
            return postResponse;
        }
    }
}
