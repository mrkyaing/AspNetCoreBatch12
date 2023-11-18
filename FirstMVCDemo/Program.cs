var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//register all of the controllers and views files 
var app = builder.Build();
//app.MapGet("/", () => "Hello World!");//home url 
//app.MapDefaultControllerRoute();//config the default routing pattern for all controllers methods
app.MapControllerRoute(name:"default",pattern: "{controller=home}/{action=index}/{id?}");
app.Run();
