using FlexyBoxProject.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.ViewModels;

namespace FlexyBoxProject.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddHttpClient<ApiClient>(client =>
            {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });

            builder.Services.AddScoped<IUser,User>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            await builder.Build().RunAsync();
        }
    }
}
