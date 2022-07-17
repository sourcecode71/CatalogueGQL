using Catalogue.Server.Infrastructure.Interfaces;
using Catalogue.Shared.Dto;
using Catalogue.Shared.Models;

namespace Catalogue.Server.GraphQL
{
    [ExtendObjectType(typeof(CourseMutationResolver))]
    public class SchoolMutationResolver
    {
         public record AddEditSchoolPayload(SchoolDto school);
         private readonly ISchool _schoolService;

        public SchoolMutationResolver(ISchool school)
        {
            _schoolService = school;
        }

        [GraphQLDescription("Create the School.")]
        public async Task<AddEditSchoolPayload> CreateSchool(SchoolDto school)
        {
            // TODO: Use AutoMapper
            School schoolDto = new School { 
              SetUser = 1, // Take from token
              Name= school.Name,
              Title = school.Title,
            };


            var result = await _schoolService.CreateSchool(schoolDto);
            return new AddEditSchoolPayload(school);
        }

        [GraphQLDescription("Delete the School.")]
        public async Task<int> DeleteSchool(int id)
        {
            int schoolId = await _schoolService.DeleteSchool(id);
            return schoolId;
        }


        [GraphQLDescription("Update the School.")]
        public async Task<AddEditSchoolPayload> UpdateSchool(SchoolDto school)
        {
            // TODO: Use AutoMapper
            School schoolDto = new School
            {
                Id = (int)school.Id,
                SetUser = 1, // Take from token
                Name = school.Name,
                Title = school.Title,
            };

            var result = await _schoolService.UpdateSchool(schoolDto);
            return new AddEditSchoolPayload(school);
        }


    }
}
