using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositories.Entities
{
	public partial class Equipments2024DBContext : DbContext
	{
		public Equipments2024DBContext()
		{
		}

		public Equipments2024DBContext(DbContextOptions<Equipments2024DBContext> options) : base(options)
		{
		}

		public virtual DbSet<Account> Accounts { get; set; } = null!;

		public virtual DbSet<Equipment> Equipments { get; set; } = null!;

		public virtual DbSet<Room> Rooms { get; set; } = null!;

		string GetConnectionString()
		{
			IConfiguration configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", true, true).Build();
			return configuration["ConnectionStrings:DefaultConnectionString"];
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer(GetConnectionString());

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>(entity =>
			{
				entity.ToTable("Accounts");

				entity.HasKey(e => e.Email);
				entity.Property(e => e.Email).HasMaxLength(50);

				entity.Property(e => e.UserName).HasMaxLength(100);
				entity.Property(e => e.Password).HasMaxLength(50);
				entity.Property(e => e.FullName).HasMaxLength(50);
				entity.Property(e => e.Status).HasMaxLength(10);

			});

			modelBuilder.Entity<Equipment>(entity =>
			{
				entity.ToTable("Equipments");

				entity.HasKey(e => e.EqID);

				entity.Property(e => e.EqName).HasMaxLength(150);
				entity.Property(e => e.Description).HasMaxLength(200);
				entity.Property(e => e.Model).HasMaxLength(50);
				entity.Property(e => e.SupplierName).HasMaxLength(50);

				entity.HasOne(d => d.Rooms).WithMany(p => p.Equipments)
					.HasForeignKey(d => d.RoomID)
					.OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<Room>(entity =>
			{
				entity.ToTable("Rooms");

				entity.HasKey(e => e.RoomID);

				entity.Property(e => e.RoomName).HasMaxLength(50);
				entity.Property(e => e.Location).HasMaxLength(150);
				entity.Property(e => e.Status).HasMaxLength(10);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
