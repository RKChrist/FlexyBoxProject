using Application;
using Azure.Core;
using FlexyBoxProject.Client.Pages;
using FlexyBoxProject.Client.Services;
using FlexyBoxProject.Components;
using Infrastructure;

namespace FlexyBoxProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();

            //Add Customs Dependencies
            var constring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddApplicationDependencies()
                            .AddInfrastructureDependencies(constring);

            var baseAddress = builder.Configuration.GetValue<string>("BaseUrl");
            builder.Services.AddScoped<ApiClient>();
            builder.Services.AddHttpClient<ApiClient>(client =>
            {
                client.BaseAddress = new(baseAddress);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.MapControllers();
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
