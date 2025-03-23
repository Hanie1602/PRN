using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement.Signalr;
using Repositories.Entities;
using Repositories.Generic_Repositories;
using Repositories.UOW;
using Services.IService;
using Services.Service;

namespace PharmaceuticalManagement
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<Sp25PharmaceuticalDBContext>(options => options.UseSqlServer("DefaultConnectionString"));

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddSignalR();

			builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
			builder.Services.AddScoped<IMedicineInformationService, MedicineInformationService>();
			builder.Services.AddScoped<IStoreAccountService, StoreAccountService>();
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