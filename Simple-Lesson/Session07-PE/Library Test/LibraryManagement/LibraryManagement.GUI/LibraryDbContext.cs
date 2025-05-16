using System;
using System.Collections.Generic;
using System.IO;
using LibraryManagement.GUI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryManagement.GUI;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        optionsBuilder.UseSqlServer(GetConnectionString());
	}

	private string GetConnectionString()
	{
		IConfiguration config = new ConfigurationBuilder()
			 .SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", true, true)
					.Build();
		var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

		return strConn;
	}


	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__3DE0C20757F39E49");

            entity.ToTable("Book");

            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.BookName).HasMaxLength(100);
            entity.Property(e => e.PublicationDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
