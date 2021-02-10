using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Mailjet.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SodiqYekeen.Site.Services;

namespace SodiqYekeen.Site
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ContactService>();
            builder.Services.AddScoped<CosmicService>();
            builder.Services.AddBlazoredLocalStorage();

            var config = new Dictionary<string, string>()
            {
                {"cosmic_slug","mysite-blog-testing" },
                {"cosmic_readKey","hMMgG6PocvEkP0462EBeyL4qU29vqtkoeG7JXnj3V5fieVaHNl" },
                //{"","" },
                //{"","" },
            };
            var memoryConfig = new MemoryConfigurationSource { InitialData = config };
            builder.Configuration.Add(memoryConfig);
            await builder.Build().RunAsync();
        }



    }
}
