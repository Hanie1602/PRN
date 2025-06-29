using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositories.Entities
{
	public partial class SP25LionDBContext : DbContext
	{
		public SP25LionDBContext()
		{
		}

		public SP25LionDBContext(DbContextOptions<SP25LionDBContext> options) : base(options)
		{
		}

		public virtual DbSet<LionAccount> LionAccounts { get; set; } = null!;

		public virtual DbSet<LionProfile> LionProfiles { get; set; } = null!;

		public virtual DbSet<LionType> LionTypes { get; set; } = null!;

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
			modelBuilder.Entity<LionAccount>(entity =>
			{
				entity.ToTable("LionAccount");

				entity.HasKey(l => l.AccountID);
				entity.Property(l => l.UserName).HasMaxLength(50);

				entity.Property(l => l.Password).HasMaxLength(100);
				entity.Property(l => l.FullName).HasMaxLength(50);
				entity.Property(l => l.Email).HasMaxLength(150);
				entity.Property(l => l.Phone).HasMaxLength(50);

			});

			modelBuilder.Entity<LionProfile>(entity =>
			{
				entity.ToTable("LionProfile");

				entity.HasKey(l => l.LionProfileId);

				entity.Property(l => l.LionName).HasMaxLength(150);
				entity.Property(l => l.Characteristics).HasMaxLength(2000);
				entity.Property(l => l.Warning).HasMaxLength(1500);

				entity.HasOne(lp => lp.LionType).WithMany(lt => lt.LionProfile)
					.HasForeignKey(lp => lp.LionTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull);
			});

			modelBuilder.Entity<LionType>(entity =>
			{
				entity.ToTable("LionType");

				entity.HasKey(l => l.LionTypeId);

				entity.Property(l => l.LionTypeName).HasMaxLength(250);
				entity.Property(l => l.Origin).HasMaxLength(250);
				entity.Property(l => l.Description).HasMaxLength(1000);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
