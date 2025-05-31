using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositories.Entities
{
	public partial class Sp25PharmaceuticalDBContext : DbContext
	{
		public Sp25PharmaceuticalDBContext()
		{
		}

		public Sp25PharmaceuticalDBContext(DbContextOptions<Sp25PharmaceuticalDBContext> options) : base(options)
		{
		}

		public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;

		public virtual DbSet<MedicineInformation> MedicineInformations { get; set; } = null!;

		public virtual DbSet<StoreAccount> StoreAccounts { get; set; } = null!;

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
			modelBuilder.Entity<StoreAccount>(entity =>
			{
				entity.ToTable("StoreAccount");

				entity.HasKey(e => e.StoreAccountId).HasName("PK__StoreA__0CF04B38B0A5ED78");
				entity.Property(e => e.StoreAccountId).HasColumnName("StoreAccountID");
				entity.Property(e => e.StoreAccountPassword).HasMaxLength(90);

				entity.Property(e => e.EmailAddress).HasMaxLength(90).HasColumnName("EmailAddress");
				entity.HasIndex(e => e.EmailAddress).IsUnique();

				entity.Property(e => e.StoreAccountDescription).HasMaxLength(140);

			});

			modelBuilder.Entity<Manufacturer>(entity =>
			{
				entity.ToTable("Manufacturer");

				entity.HasKey(e => e.ManufacturerID).HasName("PK__Manufacture__19093A2BEBA2D766");
				entity.Property(e => e.ManufacturerID).HasMaxLength(20).HasColumnName("ManufacturerID");

				entity.Property(e => e.ManufacturerName).HasMaxLength(100);
				entity.Property(e => e.ShortDescription).HasMaxLength(400);
				entity.Property(e => e.ContactInformation).HasMaxLength(120);
				entity.Property(e => e.CountryofOrigin).HasMaxLength(250);
			});

			modelBuilder.Entity<MedicineInformation>(entity =>
			{
				entity.ToTable("MedicineInformation");

				entity.HasKey(e => e.MedicineID).HasName("PK__MedicineI__B40CC6EDB30C819E");
				entity.Property(e => e.MedicineID).HasMaxLength(30).HasColumnName("MedicineID");

				entity.Property(e => e.MedicineName).HasMaxLength(160);
				entity.Property(e => e.ActiveIngredients).HasMaxLength(200);
				entity.Property(e => e.ExpirationDate).HasMaxLength(120);
				entity.Property(e => e.DosageForm).HasMaxLength(400);
				entity.Property(e => e.WarningsAndPrecautions).HasMaxLength(400);

				entity.HasOne(d => d.Manufacturer).WithMany(p => p.MedicineInformations)
					.HasForeignKey(d => d.ManufacturerID)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK__MedicineIn__Manufacturer__4D94879B");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
