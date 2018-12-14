using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(T3.Web.Areas.Identity.IdentityHostingStartup))]
namespace T3.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}