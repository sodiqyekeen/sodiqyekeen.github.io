using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace SodiqYekeen.Site.Models
{
    public class PostResponse
    {
        [JsonPropertyName("objects")]
        public Post[] Posts { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }
    }

    public class Post
    {
        public Post() => Metadata = new PostMetadata();

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime Date { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("metadata")]
        public PostMetadata Metadata { get; set; }

        [JsonIgnore]
        public string Excerpt => GetExcerpt();

        private string GetExcerpt()
        {
            string _excerpt = Content?.Substring(0, 200);
            List<string> patterns = new List<string>() { @"<script.+?>", @"<video.+?video>", @"<.+?>" };
            patterns.ForEach(p => _excerpt = Regex.Replace(_excerpt, p, ""));
            return _excerpt.Substring(0, 100) + "...";
        }
    }

    public class PostMetadata
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }
    }

    public class PostDetail
    {
        [JsonPropertyName("object")]
        public Post Post { get; set; }
    }
}
