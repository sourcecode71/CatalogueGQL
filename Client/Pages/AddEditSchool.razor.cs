using Catalogue.Client.Shared;
using Catalogue.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace Catalogue.Client.Pages
{
    partial class AddEditSchool
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        [Inject]
        AppStateContainer AppStateContainer { get; set; } = default!;
        protected List<SchoolDtoInput> schoolList = new(); 
        SchoolDtoInput scVm = new SchoolDtoInput();
        private string BtnText { get; set; } = "Submit";

        protected override async Task OnInitializedAsync()
        {
            await this.LoadIntialLoadData();
            BtnText = "Submit";
        }

        protected void EditSchool(SchoolDtoInput school)
        {
            scVm.Id = school.Id;
            scVm.Title = school.Title;
            scVm.Name = school.Name;
            BtnText = "Update";
        }

        protected async Task InvalidFormSubmitted()
        {

        }

        protected async Task ValidFormSubmitted()
        {
            if(this.BtnText == "Submit")
            {
                await AppStateContainer.CreateSchool(scVm);
            }
            else
            {
                await AppStateContainer.UpdateSchool(scVm);
            }

            scVm = new SchoolDtoInput();
            await this.LoadIntialLoadData();
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
