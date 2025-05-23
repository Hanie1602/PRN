﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Repositories.DuongLNT.DBContext;

public partial class SU25_PRN232_SE1731_G6_SmokeQuitContext : DbContext
{
    public SU25_PRN232_SE1731_G6_SmokeQuitContext()
    {
    }

    public SU25_PRN232_SE1731_G6_SmokeQuitContext(DbContextOptions<SU25_PRN232_SE1731_G6_SmokeQuitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AchievementNhuNq> AchievementNhuNqs { get; set; }

    public virtual DbSet<BlogPostsAnVt> BlogPostsAnVts { get; set; }

    public virtual DbSet<ChatsLocDpx> ChatsLocDpxes { get; set; }

    public virtual DbSet<CoachesLocDpx> CoachesLocDpxes { get; set; }

    public virtual DbSet<LeaderboardsDuongLnt> LeaderboardsDuongLnts { get; set; }

    public virtual DbSet<MembershipPlansAnhDtn> MembershipPlansAnhDtns { get; set; }

    public virtual DbSet<ProgressRecordsHoangPx> ProgressRecordsHoangPxes { get; set; }

    public virtual DbSet<QuitPlansAnhDtn> QuitPlansAnhDtns { get; set; }

    public virtual DbSet<SupportMethodsHoangPx> SupportMethodsHoangPxes { get; set; }

    public virtual DbSet<SystemUserAccount> SystemUserAccounts { get; set; }

    public virtual DbSet<UserAchievementNhuNq> UserAchievementNhuNqs { get; set; }


	public static string GetConnectionString(string connectionStringName)
	{
		var config = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();

		string connectionString = config.GetConnectionString(connectionStringName);
		return connectionString;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

	//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
	//        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-9HDJDBQK\\THUYDUONG;Initial Catalog=SU25_PRN232_SE1731_G6_SmokeQuit;Persist Security Info=True;User ID=sa;Password=1234567890");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AchievementNhuNq>(entity =>
        {
            entity.HasKey(e => e.AchievementNhuNqid).HasName("PK__Achievem__E78F08042D8E31DC");

            entity.ToTable("AchievementNhuNQ");

            entity.Property(e => e.AchievementNhuNqid).HasColumnName("AchievementNhuNQID");
            entity.Property(e => e.AchievementName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CriteriaType)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<BlogPostsAnVt>(entity =>
        {
            entity.HasKey(e => e.BlogPostsAnVtid).HasName("PK__BlogPost__837415F83DD2BC80");

            entity.ToTable("BlogPostsAnVT");

            entity.Property(e => e.BlogPostsAnVtid).HasColumnName("BlogPostsAnVTID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Tags).HasMaxLength(255);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Plan).WithMany(p => p.BlogPostsAnVts)
                .HasForeignKey(d => d.PlanId)
                .HasConstraintName("FK__BlogPosts__PlanI__37A5467C");

            entity.HasOne(d => d.User).WithMany(p => p.BlogPostsAnVts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BlogPosts__UserI__38996AB5");
        });

        modelBuilder.Entity<ChatsLocDpx>(entity =>
        {
            entity.HasKey(e => e.ChatsLocDpxid).HasName("PK__ChatsLoc__27DEBDA0D57C3292");

            entity.ToTable("ChatsLocDPX");

            entity.Property(e => e.ChatsLocDpxid).HasColumnName("ChatsLocDPXID");
            entity.Property(e => e.AttachmentUrl).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Message).IsRequired();
            entity.Property(e => e.MessageType)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.ResponseTime).HasColumnType("datetime");
            entity.Property(e => e.SentBy)
                .IsRequired()
                .HasMaxLength(10);

            entity.HasOne(d => d.Coach).WithMany(p => p.ChatsLocDpxes)
                .HasForeignKey(d => d.CoachId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChatsLocD__Coach__3B75D760");

            entity.HasOne(d => d.User).WithMany(p => p.ChatsLocDpxes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChatsLocD__UserI__3C69FB99");
        });

        modelBuilder.Entity<CoachesLocDpx>(entity =>
        {
            entity.HasKey(e => e.CoachesLocDpxid).HasName("PK__CoachesL__24751D181D97254D");

            entity.ToTable("CoachesLocDPX");

            entity.HasIndex(e => e.Email, "UQ__CoachesL__A9D105345F52E2B5").IsUnique();

            entity.Property(e => e.CoachesLocDpxid).HasColumnName("CoachesLocDPXID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LeaderboardsDuongLnt>(entity =>
        {
            entity.HasKey(e => e.LeaderboardsDuongLntid).HasName("PK__Leaderbo__347F6678B91580C9");

            entity.ToTable("LeaderboardsDuongLNT");

            entity.Property(e => e.LeaderboardsDuongLntid).HasColumnName("LeaderboardsDuongLNTID");
            entity.Property(e => e.CommunityContribution).HasDefaultValue(0);
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsTopRanked).HasDefaultValue(false);
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.MoneySave).HasDefaultValue(0.0);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.StreakCount).HasDefaultValue(0);
            entity.Property(e => e.TotalAchievements).HasDefaultValue(0);

            entity.HasOne(d => d.Plan).WithMany(p => p.LeaderboardsDuongLnts)
                .HasForeignKey(d => d.PlanId)
                .HasConstraintName("FK__Leaderboa__PlanI__48CFD27E");

            entity.HasOne(d => d.User).WithMany(p => p.LeaderboardsDuongLnts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Leaderboa__UserI__49C3F6B7");
        });

        modelBuilder.Entity<MembershipPlansAnhDtn>(entity =>
        {
            entity.HasKey(e => e.MembershipPlansAnhDtnid).HasName("PK__Membersh__66D9431BEA857AD0");

            entity.ToTable("MembershipPlansAnhDTN");

            entity.Property(e => e.MembershipPlansAnhDtnid).HasColumnName("MembershipPlansAnhDTNID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PlanName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<ProgressRecordsHoangPx>(entity =>
        {
            entity.HasKey(e => e.ProgressRecordsHoangPxid).HasName("PK__Progress__7342863CC7F42EFD");

            entity.ToTable("ProgressRecordsHoangPX");

            entity.Property(e => e.ProgressRecordsHoangPxid).HasColumnName("ProgressRecordsHoangPXID");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Mood).HasMaxLength(50);
            entity.Property(e => e.RecordedAt).HasColumnType("datetime");

            entity.HasOne(d => d.SupportMethod).WithMany(p => p.ProgressRecordsHoangPxes)
                .HasForeignKey(d => d.SupportMethodId)
                .HasConstraintName("FK__ProgressR__Suppo__33D4B598");

            entity.HasOne(d => d.User).WithMany(p => p.ProgressRecordsHoangPxes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProgressR__UserI__34C8D9D1");
        });

        modelBuilder.Entity<QuitPlansAnhDtn>(entity =>
        {
            entity.HasKey(e => e.QuitPlansAnhDtnid).HasName("PK__QuitPlan__F0642CC4F48A8278");

            entity.ToTable("QuitPlansAnhDTN");

            entity.Property(e => e.QuitPlansAnhDtnid).HasColumnName("QuitPlansAnhDTNID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpectedQuitDate).HasColumnType("datetime");
            entity.Property(e => e.Reason).IsRequired();
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.MembershipPlan).WithMany(p => p.QuitPlansAnhDtns)
                .HasForeignKey(d => d.MembershipPlanId)
                .HasConstraintName("FK__QuitPlans__Membe__2F10007B");

            entity.HasOne(d => d.User).WithMany(p => p.QuitPlansAnhDtns)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuitPlans__UserI__300424B4");
        });

        modelBuilder.Entity<SupportMethodsHoangPx>(entity =>
        {
            entity.HasKey(e => e.SupportMethodsHoangPxid).HasName("PK__SupportM__C1A8BEAB798DB2F6");

            entity.ToTable("SupportMethodsHoangPX");

            entity.Property(e => e.SupportMethodsHoangPxid).HasColumnName("SupportMethodsHoangPXID");
            entity.Property(e => e.MethodName)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<SystemUserAccount>(entity =>
        {
            entity.HasKey(e => e.UserAccountId);

            entity.ToTable("System.UserAccount");

            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.ApplicationCode).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.EmployeeCode)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.RequestCode).HasMaxLength(50);
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<UserAchievementNhuNq>(entity =>
        {
            entity.HasKey(e => e.UserAchievementNhuNqid).HasName("PK__UserAchi__C3D014621BCE6124");

            entity.ToTable("UserAchievementNhuNQ");

            entity.Property(e => e.UserAchievementNhuNqid).HasColumnName("UserAchievementNhuNQID");
            entity.Property(e => e.AchievedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Achievement).WithMany(p => p.UserAchievementNhuNqs)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserAchie__Achie__3F466844");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchievementNhuNqs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserAchie__UserI__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}