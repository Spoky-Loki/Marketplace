using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// getting the connection string from the configuration file
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Adding the ApplicationContext context as a service to the application
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Interfaces and realisation
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using(var scope = app.Services.CreateScope())
{
	ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
	DBSeeds.initial(context);
}

app.Run();
