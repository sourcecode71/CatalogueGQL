using CatalogueGQL.Server.Infrastructure;
using CatalogueGQL.Server.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CatalogueGQL.Server.GraphQL.Majors
{
    public class MajorType : ObjectType<Major>
    {
        protected override void Configure(IObjectTypeDescriptor<Major> descriptor)
        {
            descriptor.Description("Offer Degree from the university");
            descriptor.Field(p => p.MinCreditHours).Description("Minimum credit hours for the degree");
            descriptor.Field(p => p.SetUser).Ignore();
            descriptor.Field(p => p.SetDate).Ignore();
            descriptor.Field(p => p.IsDeleted).Ignore();
          
            descriptor.Field(p=>p.Courses)
                .UseDbContext<CatalogueDBContext>()
                .ResolveWith<Resolvers>(p=>p.GetCourse(default!,default!))
                .Description("Avialable coures for the specific major");
        }
        private class Resolvers 
        {
            public IQueryable<Courses> GetCourse([Parent] Major major, [ScopedService] CatalogueDBContext context)
            {
                return context.Courses.Where(c=>c.MajorId == major.Id);
            }
        }
    }
}
