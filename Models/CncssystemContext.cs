using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CNCSproject.Models;

public partial class CncssystemContext : DbContext
{
    public CncssystemContext(DbContextOptions<CncssystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLog { get; set; }

    public virtual DbSet<Descriptions> Descriptions { get; set; }

    public virtual DbSet<ProdDescLog> ProdDescLog { get; set; }

    public virtual DbSet<ProductVendor> ProductVendor { get; set; }

    public virtual DbSet<TransactionLogs> TransactionLogs { get; set; }

    public virtual DbSet<Transactions> Transactions { get; set; }

    public virtual DbSet<UserAccount> UserAccount { get; set; }
  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblActivityLog");

            entity.Property(e => e.LogActivity).HasMaxLength(50);
            entity.Property(e => e.LogLocation).HasMaxLength(20);
            entity.Property(e => e.LogTime).HasPrecision(0);
            entity.Property(e => e.LogUser).HasMaxLength(50);
            entity.Property(e => e.UserGroup).HasMaxLength(20);
        });

        modelBuilder.Entity<Descriptions>(entity =>
        {
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.ProductVendorId).HasColumnName("ProductVendorID");
        });

        modelBuilder.Entity<ProdDescLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Logs");

            entity.Property(e => e.LogActivity).HasMaxLength(10);
            entity.Property(e => e.LogDate).HasPrecision(0);
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.LogUser).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<ProductVendor>(entity =>
        {
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.ProductVendor1)
                .HasMaxLength(50)
                .HasColumnName("ProductVendor");
        });

        modelBuilder.Entity<TransactionLogs>(entity =>
        {
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            entity.Property(e => e.LogBy).HasMaxLength(50);
            entity.Property(e => e.LogDate).HasPrecision(0);
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.LogType).HasMaxLength(20);
            entity.Property(e => e.PickUpDate).HasPrecision(0);
            entity.Property(e => e.ProductVenderId).HasColumnName("ProductVenderID");
            entity.Property(e => e.RepliedBy).HasMaxLength(50);
            entity.Property(e => e.Shift).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TakeOffDate).HasPrecision(0);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("TransactionID");
            entity.Property(e => e.TransactionType).HasMaxLength(20);
        });

        modelBuilder.Entity<Transactions>(entity =>
        {
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.DescriptionId).HasColumnName("DescriptionID");
            entity.Property(e => e.LogId)
                .HasMaxLength(20)
                .HasColumnName("LogID");
            entity.Property(e => e.PickUpDate).HasPrecision(0);
            entity.Property(e => e.ProductVenderId).HasColumnName("ProductVenderID");
            entity.Property(e => e.RepliedBy).HasMaxLength(50);
            entity.Property(e => e.Shift).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TakeOffDate).HasPrecision(0);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("TransactionID");
            entity.Property(e => e.TransactionType).HasMaxLength(20);
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.DateAdded).HasPrecision(0);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LogId).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.UserGroup).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
