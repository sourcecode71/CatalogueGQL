using Catalogue.Server;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
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
