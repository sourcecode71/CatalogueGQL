using CatalogueGQL.Server.Infrastructure;
using CatalogueGQL.Server.Models;


namespace CatalogueGQL.Server.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(CatalogueDBContext))]
        public IQueryable<Major> GetMajor([ScopedService] CatalogueDBContext dBContext) => dBContext.Major;

        [UseDbContext(typeof (CatalogueDBContext))]
        public IQueryable<Courses> GetCourse([ScopedService] CatalogueDBContext catalogueDB) => catalogueDB.Courses;
       
    }
}
