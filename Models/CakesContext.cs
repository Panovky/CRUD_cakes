using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_cakes.Models;

public partial class CakesContext : DbContext
{
    public CakesContext()
    {
    }

    public CakesContext(DbContextOptions<CakesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cake> Cakes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=cakes;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cake>(entity =>
        {
            entity.HasKey(e => e.CakeId).HasName("cake_pkey");

            entity.ToTable("cake");

            entity.Property(e => e.CakeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("cake_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(30)
                .HasColumnName("brand_name");
            entity.Property(e => e.CakeName)
                .HasMaxLength(30)
                .HasColumnName("cake_name");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Gluten).HasColumnName("gluten");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
