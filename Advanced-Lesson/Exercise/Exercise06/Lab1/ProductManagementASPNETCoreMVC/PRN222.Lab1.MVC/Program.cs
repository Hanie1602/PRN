using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Repositories;
using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Services;

namespace PRN222.Lab1.MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<MyStoreDbContext>(options => options.UseSqlServer("DefaultConnectionString"));

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddScoped<IAccountService, AccountService>();
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			//builder.Services.AddSession(options =>
			//{
			//	options.IdleTimeout = TimeSpan.FromMinutes(20); // Set sesion timeout
			//	options.Cookie.HttpOnly = true; // For security
			//	options.Cookie.IsEssential = true; //Ensure sesion cookie is always created
			//});

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

			//app.UseSession();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
