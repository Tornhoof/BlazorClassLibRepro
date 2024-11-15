using System.Threading.Tasks;
using BlazorApp.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp
{
    public static class Extensions
    {
        public static void AddApp(this IServiceCollection collection)
        {
            collection.AddRazorComponents().AddInteractiveServerComponents();
            collection.AddMvc().AddApplicationPart(typeof(Extensions).Assembly);
        }

        public static void UseApp(this IApplicationBuilder builder)
        {
            builder.Map("/app", a =>
            {
                a.UseRouting();
                a.UseAuthorization();
                a.UseAntiforgery();
                a.UseEndpoints(endpoints =>
                {
                    // specifying this "loads" the files specified in the static web assets, but they are 0 length
                    const string manifest = "BlazorApp.staticwebassets.endpoints.json";
                    endpoints.MapStaticAssets(manifest);
                    endpoints.MapRazorComponents<App>().AddInteractiveServerRenderMode().WithStaticAssets(manifest);
                });
            });
        }
    }
}