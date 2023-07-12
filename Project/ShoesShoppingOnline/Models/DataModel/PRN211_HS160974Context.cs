using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShoesShoppingOnline.Models.DataModel
{
    public partial class PRN211_HS160974Context : DbContext
    {
        public PRN211_HS160974Context()
        {
        }

        public PRN211_HS160974Context(DbContextOptions<PRN211_HS160974Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountHs160974> AccountHs160974s { get; set; } = null!;
        public virtual DbSet<BrandHs160974> BrandHs160974s { get; set; } = null!;
        public virtual DbSet<CategoryHs160974> CategoryHs160974s { get; set; } = null!;
        public virtual DbSet<CustomersHs160974> CustomersHs160974s { get; set; } = null!;
        public virtual DbSet<OrderDetailsHs160974> OrderDetailsHs160974s { get; set; } = null!;
        public virtual DbSet<OrdersHs160974> OrdersHs160974s { get; set; } = null!;
        public virtual DbSet<ProductHs160974> ProductHs160974s { get; set; } = null!;
        public virtual DbSet<SizeHs160974> SizeHs160974s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2DM4KKN;Initial Catalog=PRN211_HS160974;Persist Security Info=True;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountHs160974>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("Account_HS160974");

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(11)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Role).HasColumnName("role");
            });

            modelBuilder.Entity<BrandHs160974>(entity =>
            {
                entity.ToTable("Brand_HS160974");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CategoryHs160974>(entity =>
            {
                entity.ToTable("Category_HS160974");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CustomersHs160974>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_Customers_HS160974_1");

                entity.ToTable("Customers_HS160974");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.FullName)
                    .HasMaxLength(30)
                    .HasColumnName("fullName");

                entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .HasColumnName("phoneNumber");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.CustomersHs160974s)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers_HS160974_Account_HS160974");
            });

            modelBuilder.Entity<OrderDetailsHs160974>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.SizeId });

                entity.ToTable("OrderDetails_HS160974");

                entity.Property(e => e.SizeId).HasColumnName("sizeID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetailsHs160974s)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_HS160974_Orders_HS160974");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.OrderDetailsHs160974s)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_HS160974_Size_HS160974");
            });

            modelBuilder.Entity<OrdersHs160974>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Orders_HS160974");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.TotalMoney)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total_money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrdersHs160974s)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_HS160974_Customers_HS160974");
            });

            modelBuilder.Entity<ProductHs160974>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Product_HS160974");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductHs160974s)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_HS160974_Brand_HS160974");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductHs160974s)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_HS160974_Category_HS160974");
            });

            modelBuilder.Entity<SizeHs160974>(entity =>
            {
                entity.HasKey(e => e.SizeId);

                entity.ToTable("Size_HS160974");

                entity.Property(e => e.SizeId).HasColumnName("sizeID");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SizeName).HasColumnName("sizeName");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.SizeHs160974s)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Size_HS160974_Product_HS160974");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
