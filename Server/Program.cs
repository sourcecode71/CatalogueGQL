using CatalogueGQL.Server;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);




var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
startup.InitDatabase(app);
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
    endpoints.MapGraphQLVoyager();

});

app.UseGraphQLVoyager();

//app.MapRazorPages();
//app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
