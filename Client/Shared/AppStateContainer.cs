using Catalogue.Shared.Dto;
using Catalogue.Shared.Models;

namespace Catalogue.Client.Shared
{
    public class AppStateContainer
    {
        private readonly CatalogueClient _catalogueClient;

        public AppStateContainer(CatalogueClient catalogueClient)
        {
            _catalogueClient = catalogueClient;
        }

        public List<Course> courselist = new();
        public List<School> schoolList = new();

        public async Task GetAvailableCourse()
        {
            var results = await _catalogueClient.GetCourseList.ExecuteAsync();

            if (results.Data is not null)
            {
                courselist = results.Data.CourseList.Select(x => new Course
                {
                    Id = x.Id,
                    Title = x.Title,
                    Code = x.Code,
                    CreditHours = x.CreditHours
                }).ToList();
            }
        }

        public async Task<List<School>> GetAvialableSchool()
        {
            var results = await _catalogueClient.GetSchoolList.ExecuteAsync();

            if(results.Data is not null)
            {
                schoolList = results.Data.AllSchools.Select(x => new School
                {
                    Id = x.Id,
                    Title = x.Title,
                    Name = x.Name
                }).ToList();

                return schoolList;
            }

            return schoolList;

        }

        public async Task CreateSchool(SchoolDtoInput schoolDto)
        {
            await _catalogueClient.AddSchoolData.ExecuteAsync(schoolDto);
        }

        public async Task AddCourseData(CourseDtoInput courseDto)
        {
            await _catalogueClient.AddCourseData.ExecuteAsync(courseDto);
        }

        public async Task UpdateCourseData(CourseDtoInput courseDto)
        {
           await _catalogueClient.UpdateCourseData.ExecuteAsync(courseDto);
        }

        public async Task UpdateSchool(SchoolDtoInput schoolDto)
        {
            await _catalogueClient.UpdateSchoolData.ExecuteAsync(schoolDto);
        }

    }
}
