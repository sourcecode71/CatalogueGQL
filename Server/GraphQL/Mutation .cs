using CatalogueGQL.Server.GraphQL.Course;
using CatalogueGQL.Server.GraphQL.Majors;
using CatalogueGQL.Server.Infrastructure;
using CatalogueGQL.Server.Models;
using HotChocolate.Subscriptions;

namespace CatalogueGQL.Server.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(CatalogueDBContext))]
        public async Task<AddMajorPayload> AddMajorAsync(AddMajorInputs addMajor,
            [ScopedService] CatalogueDBContext dBContext)
        {
            try
            {
                var major = new Major
                {
                    Code = addMajor.Code,
                    Title = addMajor.Title,
                    MinCreditHours = addMajor.MinCreditHours,
                    SetDate = DateTime.Now,
                    SetUser ="Admin"
                };

                dBContext.Major.Add(major);
                await dBContext.SaveChangesAsync();
                return new AddMajorPayload(major);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [UseDbContext(typeof(CatalogueDBContext))]
        public async Task<AddCourseInputPayload> AddCourses(AddCourseInputs inputs,
            [ScopedService] CatalogueDBContext dBContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            try
            {
                var course = new Courses
                {
                    Code = inputs.Code,
                    CreditHours = inputs.CreditHours,
                    Title = inputs.Title,
                    MajorId = inputs.MajorId,
                    SetDate = DateTime.Now,
                    SetUser = "Admin"

                };

                dBContext.Courses.Add(course);
                await dBContext.SaveChangesAsync();
                return new AddCourseInputPayload(course);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
                
        }
    }
}
