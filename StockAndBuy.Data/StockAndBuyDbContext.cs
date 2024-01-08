using Microsoft.EntityFrameworkCore;
using StockAndBuy.Core.Models;
using System;

namespace StockAndBuy.Data
{
    public class StockAndBuyDbContext : DbContext
    {
        public StockAndBuyDbContext(DbContextOptions<StockAndBuyDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Bundle> Bundles { get; set; }
        public virtual DbSet<SparePart> SpareParts { get; set; }
        public virtual DbSet<BundleParts> BundleParts { get; set; }
        public virtual DbSet<BundleSpareParts> BundleSpareParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedBundle();
            modelBuilder.Entity<Bundle>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();

            });

            modelBuilder.Entity<SparePart>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<BundleParts>(entity =>
            {
                entity.HasIndex(e => new { e.BundleId, e.BundlePartId }).IsUnique();
                entity.HasOne(e => e.Bundle).WithMany(x => x.BundleParts).HasForeignKey(cr => cr.BundleId).OnDelete(DeleteBehavior.Restrict); ;
                entity.HasOne(e => e.BundlePart);
            });

            modelBuilder.Entity<BundleSpareParts>(entity =>
            {
                entity.HasIndex(e => new { e.BundleId, e.SparePartId }).IsUnique();
            });
        }

    }
}