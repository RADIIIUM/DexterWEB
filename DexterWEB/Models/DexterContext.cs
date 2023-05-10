using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DexterWEB.Models;

public partial class DexterContext : DbContext
{
    public DexterContext()
    {
    }

    public DexterContext(DbContextOptions<DexterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<HistoryOfUser> HistoryOfUsers { get; set; }

    public virtual DbSet<ImagesOfProduct> ImagesOfProducts { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Privilege> Privileges { get; set; }

    public virtual DbSet<PrivilegeUser> PrivilegeUsers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TypesOfProduct> TypesOfProducts { get; set; }

    public virtual DbSet<TypesProduct> TypesProducts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DQMOMS7;Database=Dexter; User Id = radmir ; Password = 123456 ;Trusted_Connection=True; Integrated Security=False; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.IdComment).HasName("PK__Comments__E19B6D4C25B196CC");

            entity.Property(e => e.IdComment).HasColumnName("ID_Comment");
            entity.Property(e => e.DescriptionOfComment).IsUnicode(false);
            entity.Property(e => e.LoginOfUser)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.ParagraphOfComment).IsUnicode(false);
        });

        modelBuilder.Entity<HistoryOfUser>(entity =>
        {
            entity.HasKey(e => e.IdHistory).HasName("PK__HistoryO__F51C56DC6839B227");

            entity.ToTable("HistoryOfUser");

            entity.Property(e => e.IdHistory).HasColumnName("ID_History");
            entity.Property(e => e.ActionOfUser).IsUnicode(false);
            entity.Property(e => e.DateOfAction).HasColumnType("datetime");
        });

        modelBuilder.Entity<ImagesOfProduct>(entity =>
        {
            entity.HasKey(e => e.IdImages).HasName("PK__ImagesOf__5A31EE77013229CA");

            entity.ToTable("ImagesOfProduct");

            entity.Property(e => e.IdImages).HasColumnName("ID_Images");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.IdNew).HasName("PK__News__253A4269E9656429");

            entity.Property(e => e.IdNew).HasColumnName("ID_New");
            entity.Property(e => e.DescriptionOfNews).IsUnicode(false);
            entity.Property(e => e.Paragraph)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Privilege>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Privileg__5AC2A73423CC8558");

            entity.ToTable("Privilege");

            entity.Property(e => e.IdStatus).HasColumnName("ID_Status");
            entity.Property(e => e.NameOfStatus)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PrivilegeUser>(entity =>
        {
            entity.HasKey(e => e.IdPrivilegeUsers).HasName("PK__Privileg__700D681C3985C570");

            entity.ToTable("Privilege_Users");

            entity.Property(e => e.IdPrivilegeUsers).HasColumnName("ID_PrivilegeUsers");
            entity.Property(e => e.IdProvolege).HasColumnName("ID_Provolege");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProvolegeNavigation).WithMany(p => p.PrivilegeUsers)
                .HasForeignKey(d => d.IdProvolege)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Privilege__ID_Pr__440B1D61");

            entity.HasOne(d => d.LoginUserNavigation).WithMany(p => p.PrivilegeUsers)
                .HasForeignKey(d => d.LoginUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Privilege__Login__44FF419A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Products__522DE4962B934FF0");

            entity.Property(e => e.IdProduct).HasColumnName("ID_Product");
            entity.Property(e => e.DescriptionOfProduct).IsUnicode(false);
            entity.Property(e => e.NameOfProduct)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Specifications).IsUnicode(false);

            entity.HasOne(d => d.CommentsNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Comments)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Products__Commen__29572725");

            entity.HasOne(d => d.ImagesOfProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ImagesOfProduct)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Products__Images__286302EC");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__Roles__43DCD32D2EAA77F2");

            entity.Property(e => e.IdRole).HasColumnName("ID_Role");
            entity.Property(e => e.LoginOfUsers)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.NameOfRole)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.LoginOfUsersNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.LoginOfUsers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Roles__LoginOfUs__45F365D3");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Statuses__5AC2A7343B94B7F9");

            entity.Property(e => e.IdStatus).HasColumnName("ID_Status");
            entity.Property(e => e.NameOfStatus)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("PK__Supplier__408B7094C4CDB28B");

            entity.Property(e => e.IdSupplier).HasColumnName("ID_Supplier");
            entity.Property(e => e.IdProduct).HasColumnName("ID_Product");
            entity.Property(e => e.NameOfSupplier)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Suppliers__ID_Pr__2F10007B");
        });

        modelBuilder.Entity<TypesOfProduct>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PK__TypesOfP__DF519A38D96A00E0");

            entity.Property(e => e.IdType).HasColumnName("ID_Type");
            entity.Property(e => e.NameOfType)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TypesProduct>(entity =>
        {
            entity.HasKey(e => e.IdTp).HasName("PK__Types_Pr__8B63B1AE23AE3F43");

            entity.ToTable("Types_Products");

            entity.Property(e => e.IdTp).HasColumnName("ID_TP");
            entity.Property(e => e.IdProduct).HasColumnName("ID_Product");
            entity.Property(e => e.IdType).HasColumnName("ID_Type");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.TypesProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Types_Pro__ID_Pr__5FB337D6");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.TypesProducts)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Types_Pro__ID_Ty__5EBF139D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.LoginOfUser).HasName("PK__Users__4855D03EED3D3554");

            entity.Property(e => e.LoginOfUser)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.AddressOfUser)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BankCard)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionOfUser).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdHistoryOfUser).HasColumnName("ID_HistoryOfUser");
            entity.Property(e => e.Inn)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("INN");
            entity.Property(e => e.NameOfUser)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Passport)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.PasswordOfUser)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Telephone)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.IdHistoryOfUserNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdHistoryOfUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Users__ID_Histor__3D5E1FD2");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.IdCell).HasName("PK__Warehous__731C3D4BED23AF5D");

            entity.Property(e => e.IdCell).HasColumnName("ID_Cell");
            entity.Property(e => e.IdProduct).HasColumnName("ID_Product");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Warehouse__ID_Pr__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
