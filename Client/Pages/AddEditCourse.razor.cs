using Catalogue.Client.Shared;
using Catalogue.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Catalogue.Client.Pages
{
    partial class AddEditCourse
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        AppStateContainer AppStateContainer { get; set; } = default!;
        private string BtnText { get; set; } = "Submit";
        protected List<Course> lstCourse = new();
        protected List<SchoolDtoInput> schoolList = new();

        public CourseDtoInput courseModel = new CourseDtoInput();

        protected override async Task OnInitializedAsync()
        {
            await AppStateContainer.GetAvailableCourse();
            lstCourse = AppStateContainer.courselist;
            await this.LoadIntialLoadData();
        }


        protected async Task InvalidFormSubmitted()
        {

        }

        protected async Task ValidFormSubmitted()
        {
            if (this.BtnText == "Submit")
            {
                await AppStateContainer.AddCourseData(courseModel);
            }
            else
            {
                await AppStateContainer.UpdateCourseData(courseModel);
            }

            courseModel = new CourseDtoInput();
        }

        protected void EditCourse(Course course)
        {
            if(course is not null)
            {
                courseModel.Title = course.Title;
                courseModel.Code = course.Code;
            }
        }

        private async Task LoadIntialLoadData()
        {
            await AppStateContainer.GetAvialableSchool();
            schoolList = AppStateContainer.schoolList.Select(x => new SchoolDtoInput
            {
                Id = x.Id,
                Name = x.Name,
                Title = x.Title,
            }).ToList();
        }
    }
}
