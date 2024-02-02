using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TOMS.DAO;
using TOMS.Services.Domains;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();//for identity razor page
builder.Services.AddSession();//for storing data selected Seats Ticekt Infos
//declare the configration
var config = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(config.GetConnectionString("TOMSConnectionString")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(o =>
{
    o.SignIn.RequireConfirmedAccount = false;
    o.Password.RequireDigit = true;
    o.Password.RequiredLength = 8;
    o.Password.RequireUppercase = true;
    o.Password.RequireLowercase = true;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI().AddDefaultTokenProviders();
//add and connect the connectiong from the appSettings.json
//register all of the domain services
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IBusLineService, BusLineService>();
builder.Services.AddScoped<IPaymentTypeService, PaymentTypeService>();
builder.Services.AddScoped<ITicketOrderService, TicketOrderService>();
builder.Services.AddScoped<ITicketOrderTransactionService, TicketOrderTransactionService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();//enable for session to store the selected Seats Ticekt Infos
app.UseRouting();
app.UseAuthentication();//enable authentication before authorization
app.UseAuthorization();//enable authorization 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//register routes for identity endpoints
app.UseEndpoints(endponts =>
{
    endponts.MapRazorPages();
});
app.Run();
