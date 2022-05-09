using CatalogueGQL.Server.Infrastructure;
using CatalogueGQL.Server.Ioc;
using Microsoft.EntityFrameworkCore;

namespace CatalogueGQL.Server
{
    internal class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        internal IConfiguration Configuration { get;}

        internal void ConfigureServices(IServiceCollection services)
        {
            ContainerSetup.Setup(services, Configuration);
        }


        internal void InitDatabase(WebApplication application)
        {

            IApplicationBuilder app = application;
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CatalogueDBContext>();
                if (context != null)
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
