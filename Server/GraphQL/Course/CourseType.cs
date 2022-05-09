using CatalogueGQL.Server.Infrastructure;
using CatalogueGQL.Server.Models;



namespace CatalogueGQL.Server.GraphQL.Course
{
    public class CourseType :ObjectType<Courses>
    {
        protected override void Configure(IObjectTypeDescriptor<Courses> descriptor)
        {
            descriptor.Description("Offer courses from university for a major");
            descriptor.Field(p => p.Title).Description("Course Title");
            descriptor.Field(p => p.Code).Description("Course Code");
            descriptor.Field(p => p.SetUser).Ignore();
            descriptor.Field(p => p.SetDate).Ignore();
            descriptor.Field(p => p.IsDeleted).Ignore();

            descriptor.Field(p => p.Major)
                .UseDbContext<CatalogueDBContext>()
                .ResolveWith<ResolversCourse>(p => p.GetMajor(default!,default!))
                .Description("Avilable Major for the course");

        }

        private class ResolversCourse
        {
            public Major GetMajor([Parent] Courses courses, [ScopedService]  CatalogueDBContext context)
            {
               
                return context.Major.FirstOrDefault(c => c.Id == courses.MajorId);
            }
        }
    }
}
