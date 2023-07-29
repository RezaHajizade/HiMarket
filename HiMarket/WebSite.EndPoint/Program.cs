using Application.BasketService;
using Application.Catalogs.CatalogItems.CatalogItemServices;
using Application.Catalogs.CatalogItems.GetCatalogItemPDP;
using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Catalogs.CatalogTypes;
using Application.Catalogs.GetMenuItem;
using Application.HomePageService;
using Application.Interfase.Context;
using Application.Orders;
using Application.Orders.CustomerOrderService;
using Application.Payments;
using Application.Services.Email;
using Application.UriComposer;
using Application.Users;
using Application.Visitors.SaveVisitorInfo;
using Application.Visitors.VisitorOnline;
using Infrastructure.IdentityConfigs;
using Infrastructure.MappingProfile;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.MongoContext;
using System.Configuration;
using WebSite.EndPoint.Hubs;
using WebSite.EndPoint.Utilities.Filters;
using WebSite.EndPoint.Utilities.Middelwares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
builder.Services.AddTransient<IVisitorOnlineService, VisitorOnlineService>();
builder.Services.AddTransient<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddTransient<IUriComposerService, UriComposerService>();
builder.Services.AddTransient<IGetCatalogItemPLPService, GetCatalogItemPLPService>();
builder.Services.AddTransient<IGetCatalogItemPDPService, GetCatalogItemPDPService>();
builder.Services.AddTransient<IBasketService, BasketService>();
builder.Services.AddTransient<IUserAddressService, UserAddressService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();
builder.Services.AddTransient<ICustomerOrderService, CustomerOrderService>();
builder.Services.AddTransient<IHomePageService, HomePageService>();

builder.Services.AddScoped<SaveVisitorFilter>();
builder.Services.AddSignalR();

//mapper
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));
builder.Services.AddAutoMapper(typeof(UserMappingProfile));


#region Connection String

builder.Services.AddTransient<IDataBaseContext, DataBaseContext>();
builder.Services.AddTransient<IIdentityDataBaseContext, IdentityDataBaseContext>();
 
string connection = builder.Configuration["ConnectionString:SqlServer"];
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));
builder.Services.AddIdentityService(builder.Configuration);

builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/account/Login";   
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSetVisitorId();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
         name: "areas",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<OnlineVisitorHub>("/chathub");
app.Run();
