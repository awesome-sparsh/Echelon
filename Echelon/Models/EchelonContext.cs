using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Echelon.Models;

public partial class EchelonContext : DbContext
{
    public EchelonContext()
    {
    }

    public EchelonContext(DbContextOptions<EchelonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<ProductMaster> ProductMasters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=sorter.in;Database=echelon;User Id=sortersaas;Password=Trubros!123&;");
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inventory");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("Manufacturer_code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("Product_name");
            entity.Property(e => e.PurchaseFrom)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("Purchase_from");
            entity.Property(e => e.PurchasePrice)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("Purchase_price");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SerialNo)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("Serial_no");
        });

        modelBuilder.Entity<ProductMaster>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("product_master");

            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("Product_id");
            entity.Property(e => e.ListPrice)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("List_price");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("Manufacturer_code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("Product_name");
            entity.Property(e => e.PurchasePrice)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("Purchase_price");
            entity.Property(e => e.Specifications)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Uid)
                .HasColumnType("int(11)")
                .HasColumnName("uid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("name");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("role");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
