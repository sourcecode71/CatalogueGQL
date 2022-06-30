using CatalogueGQL.Server.GraphQL;
using CatalogueGQL.Server.GraphQL.Course;
using CatalogueGQL.Server.GraphQL.Majors;
using CatalogueGQL.Server.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CatalogueGQL.Server.Ioc
{
    internal static class ContainerSetup
    {
        internal static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureGraphQL(services,configuration);
            ConfigureInject(services);
        }

       

        private static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Data:main"];
            services.AddEntityFrameworkSqlServer();
            services.AddPooledDbContextFactory<CatalogueDBContext>(options =>
                options.UseSqlServer(connectionString));
        }

        private static void ConfigureGraphQL(IServiceCollection services, IConfiguration configuration)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddType<MajorType>()
                .AddType<CourseType>()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();
        }

        private static void ConfigureInject(IServiceCollection services)
        {

        }
    }
}
