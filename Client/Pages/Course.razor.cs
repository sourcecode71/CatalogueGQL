using CatalogueGQL.Client.Shared;
using CatalogueGQL.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CatalogueGQL.Client.Pages
{
    partial class Course
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        AppStateContainer AppStateContainer { get; set; } = default!;
        private string TitleText { get; set; }
        private string BtnText { get; set; } = "Submit";
        protected List<Courses> lstCourse = new();

        public Courses courseModel = new Courses();


        protected override async Task OnInitializedAsync()
        {
            await AppStateContainer.GetAvailableCourse();
            lstCourse = AppStateContainer.AvialableCourse;
        }

        protected void EditCourse(Courses course)
        {
            if (course != null)
            {
                courseModel.Code = course.Code;
                courseModel.Title = course.Title;
                courseModel.CreditHours =course.CreditHours;
                this.BtnText = "Edit";
            }
        }

        protected  async Task ValidFormSubmitted()
        {
            if(courseModel != null)
            {
            }
        }

        protected void InvalidFormSubmitted(EditContext editContext)
        {

        }

        protected void ResetForm()
        {
            courseModel = new Courses();
        }

    }
}
