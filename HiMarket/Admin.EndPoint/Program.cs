using Admin.EndPoint.MappingProfiles;
using Application.Catalogs.CatalogTypes;
using Application.Interfase.Context;
using Application.Visitors.GetTodayReport;
using Infrastructure.MappingProfile;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.MongoContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IGetTodayReportService, GetTodayReportService>();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();

#region connection String SqlServer

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
//string connection = builder.Configuration["ConnectionString:SqlServer"];
var connection= builder.Configuration["ConnectionString:SqlServer"];
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));

#endregion

//mapper
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));
builder.Services.AddAutoMapper(typeof(CatalogVMMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
