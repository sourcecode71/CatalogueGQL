using CatalogueGQL.Client.GraphQLAPIClient;
using CatalogueGQL.Shared.Models;

namespace CatalogueGQL.Client.Shared
{
    public class AppStateContainer
    {
        private readonly CatalogueGQLClient _catalogueGQLClient;
        public List<Major> AvailableMajor = new();
        public List<Courses> AvialableCourse = new();

        public AppStateContainer(CatalogueGQLClient catalogueGQLClient)
        {
            _catalogueGQLClient = catalogueGQLClient;
        }
        public async Task GetAvailableMajor()
        {
            var results = await _catalogueGQLClient.FetchMajorList.ExecuteAsync();
            if (results.Data is not null)
            {
                AvailableMajor = results.Data.Major.Select(x => new Major
                {
                    Code = x.Code,
                    Id = x.Id,
                    Title = x.Title,
                    MinCreditHours = x.MinCreditHours,
                    Courses = x.Courses.Select( x=>new Courses {Code = x.Code,Title = x.Title,Id=x.Id } ).ToList(),
                }).ToList();
            }
        }

        public async Task GetAvailableCourse()
        {
            var results = await _catalogueGQLClient.FetchCourseList.ExecuteAsync();
            if(results.Data is not null)
            {
                AvialableCourse = results.Data.Course.Select(x => new Courses
                {
                    Code=x.Code,
                    CreditHours=x.CreditHours,
                    Title=x.Title
                }).ToList();
            }
        }

        public async Task AddCourse(Courses addCourse)
        {
           // var results = await _catalogueGQLClient.Add
        }
    }
}
