using ECommerceProject.Business.Abstract;
using ECommerceProject.Business.Concrete;
using ECommerceProject.DataAccess.Abstraction;
using ECommerceProject.DataAccess.Concrete.EFEntityFramework;
using ECommerceProject.Entities.Models;
using ECommerceProject.WebUI.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conn = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<NorthwindContext>(opt =>
{
    opt.UseSqlServer(conn);
});

builder.Services.AddScoped<IProductDal, EFProductDal>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<ICategoryService,CategoryService>();

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<ICartSessionService,CartSessionService>();

builder.Services.AddSession();

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

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
