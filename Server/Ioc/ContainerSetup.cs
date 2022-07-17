using Catalogue.Server.GraphQL;
using Catalogue.Server.Infrastructure;
using Catalogue.Server.Infrastructure.DataAccess;
using Catalogue.Server.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.Server.Ioc
{
    internal static class ContainerSetup
    {
        internal static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureGraphQL(services, configuration);
           // ConfigureInject(services);
        }
        private static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Data:main"];
            services.AddEntityFrameworkSqlServer();
            services.AddPooledDbContextFactory<CatalogueDBContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ICourse, CourseDataAccessLayer>();
            services.AddScoped<ISchool, SchoolDataAccessLayer>();
        }

        private static void ConfigureGraphQL(IServiceCollection services, IConfiguration configuration)
        {
            services.AddGraphQLServer()
                .AddDefaultTransactionScopeHandler()
                .AddQueryType<CatalogueQueryResolver>()
                .AddMutationType<CourseMutationResolver>()
                .AddTypeExtension<SchoolQueryResolver>()
                .AddTypeExtension<SchoolMutationResolver>()
                .AddFiltering()
                .AddSorting();
        }

      

    }
}
