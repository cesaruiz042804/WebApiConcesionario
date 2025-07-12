using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiConcesionario.Models;

public partial class DbConcesionarioContext : DbContext
{
    public DbConcesionarioContext()
    {
    }

    public DbConcesionarioContext(DbContextOptions<DbConcesionarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }

    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    public virtual DbSet<Facturaciones> Facturaciones { get; set; }

    public virtual DbSet<RegistroVehiculares> RegistroVehiculares { get; set; }

    public virtual DbSet<Tarifas> Tarifas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-FA303IOL\\SQLEXPRESS;Database=DbConcesionario;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRoleClaims>(entity =>
        {
            entity.Property(e => e.RoleId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetRoles>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUserClaims>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogins>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserTokens>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUsers>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Role).WithMany(p => p.User)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRoles",
                    r => r.HasOne<AspNetRoles>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUsers>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                    });
        });

        modelBuilder.Entity<Facturaciones>(entity =>
        {
            entity.ToTable("facturaciones");

            entity.Property(e => e.FechaEntrada).HasColumnName("Fecha_entrada");
            entity.Property(e => e.FechaSalida).HasColumnName("Fecha_salida");
            entity.Property(e => e.IdTarifa).HasColumnName("Id_tarifa");
            entity.Property(e => e.IdVehicular).HasColumnName("Id_vehicular");

            entity.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.Facturaciones).HasForeignKey(d => d.IdTarifa);

            entity.HasOne(d => d.IdVehicularNavigation).WithMany(p => p.Facturaciones).HasForeignKey(d => d.IdVehicular);
        });

        modelBuilder.Entity<RegistroVehiculares>(entity =>
        {
            entity.Property(e => e.Email).HasDefaultValue("");
            entity.Property(e => e.FacturacionId).HasColumnName("facturacionId");
            entity.Property(e => e.Placa).HasDefaultValue("");

            entity.HasOne(d => d.Facturacion).WithMany(p => p.RegistroVehiculares).HasForeignKey(d => d.FacturacionId);
        });

        modelBuilder.Entity<Tarifas>(entity =>
        {
            entity.ToTable("tarifas");

            entity.Property(e => e.FacturacionId).HasColumnName("facturacionId");

            entity.HasOne(d => d.Facturacion).WithMany(p => p.Tarifas).HasForeignKey(d => d.FacturacionId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
