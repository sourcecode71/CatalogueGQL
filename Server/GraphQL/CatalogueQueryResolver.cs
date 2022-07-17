using Catalogue.Server.Infrastructure.Interfaces;
using Catalogue.Shared.Models;

namespace Catalogue.Server.GraphQL
{
    public class CatalogueQueryResolver
    {
        readonly ICourse _courseService;
        readonly ISchool _schoolService;

        public CatalogueQueryResolver(ICourse courseService, ISchool schoolService)
        {
            _courseService = courseService;
            _schoolService = schoolService;
        }

        [GraphQLDescription("Gets the list of Course.")]
        [UseSorting]
        [UseFiltering]
        public async Task<IQueryable<Course>> GetCourseList()
        {
            List<Course> availableMovies = await _courseService.GetAllCourse();
            return availableMovies.AsQueryable();
        }

        
    }
}
