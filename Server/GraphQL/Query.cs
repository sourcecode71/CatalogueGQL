using CatalogueGQL.Server.Infrastructure;
using CatalogueGQL.Server.Models;


namespace CatalogueGQL.Server.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(CatalogueDBContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Major> GetMajor([ScopedService] CatalogueDBContext dBContext) 
        {
            var majorlist = dBContext.Major;
            return dBContext.Major;
        }

        [UseDbContext(typeof (CatalogueDBContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Courses> GetCourse([ScopedService] CatalogueDBContext catalogueDB) => catalogueDB.Courses;
       
    }
}
