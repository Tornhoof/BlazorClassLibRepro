using BlazorApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Runner
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }


        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddApp();
            services.AddLogging();
            services.AddHttpLogging();
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseApp(); // the actual Blazor App
        }
    }
}