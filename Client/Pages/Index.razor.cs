using CatalogueGQL.Client.GraphQLAPIClient;
using CatalogueGQL.Client.Shared;
using CatalogueGQL.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace CatalogueGQL.Client.Pages
{
  
    partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        [Inject]
        AppStateContainer AppStateContainer { get; set; } = default!;
        protected List<Major> lstMajor = new();
        protected List<Courses> lstCourse = new();
        [Parameter]
        public string SelectedMajor { get; set; } = string.Empty;

        protected override async Task<List<Major>> OnInitializedAsync()
        {
              await AppStateContainer.GetAvailableMajor();
              lstMajor = AppStateContainer.AvailableMajor;
              return lstMajor;
        }

        protected void AddMajor()
        {
            NavigationManager.NavigateTo("/major");
        }

    }
}
