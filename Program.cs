using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Repository;
using Shop.Models;

var builder = WebApplication.CreateBuilder(args);

// getting the connection string from the configuration file
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

// Adding the ApplicationContext context as a service to the application
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => Cart.GetCart(sp));

builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Interfaces and realisation
builder.Services.AddTransient<ICategories, CategoryRepository>();
builder.Services.AddTransient<IProducts, ProductRepository>();

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

//Exception
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();

app.UseSession();

app.MapControllerRoute(
	name: "categoryFilter",
	pattern: "Products/List/{*category}",
	defaults: new { controller = "Products", action = "List" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
	ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
	DBSeeds.initial(context);
}

app.Run();
