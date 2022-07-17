using Catalogue.Server.Infrastructure.Interfaces;
using Catalogue.Shared.Models;

namespace Catalogue.Server.GraphQL
{
    [ExtendObjectType(typeof(CatalogueQueryResolver))]
    public class SchoolQueryResolver
    {
        readonly ISchool _schoolService;

        public SchoolQueryResolver(ISchool schoolService)
        {
            _schoolService = schoolService;
        }

        

        [GraphQLDescription("Gets the list of School.")]
        [UseSorting]
        [UseFiltering]
        public IQueryable<School> GetAllSchools()
        {
            IQueryable<School> schools = _schoolService.GetSchools();
            return schools;
        }

        [GraphQLDescription("Gets the School.")]
        public async Task<School> GetSchoolById(int id)
        {
            return await _schoolService.GetSchool(id);
        }
    }
}
