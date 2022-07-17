using Catalogue.Server.Infrastructure.Interfaces;
using Catalogue.Shared.Dto;
using Catalogue.Shared.Models;

namespace Catalogue.Server.GraphQL
{
    public class CourseMutationResolver
    {
        public record AddCoursePayload(CourseDto course);

        readonly IWebHostEnvironment _hostingEnvironment;
        readonly ICourse _courseService;
        readonly IConfiguration _config;
        readonly string posterFolderPath = string.Empty;

        public CourseMutationResolver(IConfiguration config, ICourse courseService, IWebHostEnvironment hostingEnvironment)
        {
            _config = config;
            _courseService = courseService;
            _hostingEnvironment = hostingEnvironment;
            posterFolderPath = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "Poster");
        }


        [GraphQLDescription("Add a new course data.")]
        public AddCoursePayload AddCourse(CourseDto course)
        {
            Course course1 = new Course
            {
                Code = course.Code,
                CreditHours = course.CreditHours,
                Title = course.Title
            };

            _courseService.AddCourse(course1);
            return new AddCoursePayload(course);
        }

        [GraphQLDescription("Course Update")]
        public AddCoursePayload UpdateCourse(CourseDto course)
        {
            Course course1 = new Course
            {
                Code = course.Code,
                CreditHours = course.CreditHours,
                Title = course.Title
            };

           _courseService.UpdateCourse(course1);
            return new AddCoursePayload(course);

        }



    }
}
