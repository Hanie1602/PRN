using Microsoft.EntityFrameworkCore;
using PRN222.Lab2.RazorPages.Hubs;
using PRN222.Lab2.Repositories.Data;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;
using PRN222.Lab2.Services.Service;

namespace PRN222.Lab2.RazorPages
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<MyStoreDbContext>(options => options.UseSqlServer("DefaultConnectionString"));

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddSignalR();

			builder.Services.AddScoped<IAccountService, AccountService>();
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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

			app.MapHub<SignalrServer>("/signalRServer");

			app.MapRazorPages();

			app.Run();
		}
	}
}