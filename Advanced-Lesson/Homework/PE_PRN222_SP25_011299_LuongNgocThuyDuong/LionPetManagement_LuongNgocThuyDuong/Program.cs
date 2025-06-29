using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.GenericRepositories;
using Repositories.UOW;
using Services.IService;
using Services.Service;

namespace LionPetManagement_LuongNgocThuyDuong
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<SP25LionDBContext>(options => options.UseSqlServer("DefaultConnectionString"));

			// Add services to the container.
			builder.Services.AddRazorPages();

			builder.Services.AddScoped<ILionAccountService, LionAccountService>();
			builder.Services.AddScoped<ILionProfileService, LionProfileService>();
			builder.Services.AddScoped<ILionTypeService, LionTypeService>();
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

			app.MapRazorPages();

			app.Run();
		}
	}
}