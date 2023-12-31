using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Services;
using BiahsJewels.Mvc.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddUserManager<UserManager<ApplicationUser>>();

//Services configuration
builder.Services.AddScoped<IProductService,ProductServices>();
builder.Services.AddScoped<IInventoryService,InventoryService>();
builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<IConsumerService,ConsumerService>();
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IShoppingCartService,ShoppingCartService>();

builder.Services.AddSession(options =>
{
    // Set session timeout (optional)
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Store}/{action=Index}/{id?}");

app.UseSession();

app.Run();
