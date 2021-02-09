using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mailjet.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
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
            //builder.Services.AddHttpClient<IMailjetClient, MailjetClient>(client =>
            //{
            //    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            //    client.SetDefaultSettings();
            //    client.UseBasicAuthentication("b13f92a47060e40650e90fca1716fe85", "0271d2f81f7aeb11cdd055b1d9b4f53f");
            //});
            await builder.Build().RunAsync();
        }


       
    }
}
