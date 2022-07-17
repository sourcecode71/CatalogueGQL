using Catalogue.Client;
using Catalogue.Client.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string graphQLServerPath = "https://localhost:7017/" + "graphql";
builder.Services.AddCatalogueClient()
   .ConfigureHttpClient(client =>
   {
       client.BaseAddress = new Uri(graphQLServerPath);
   }
);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AppStateContainer>();

await builder.Build().RunAsync();
