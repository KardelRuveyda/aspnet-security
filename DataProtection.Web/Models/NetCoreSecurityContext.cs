using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataProtection.Web.Models
{
    public partial class NetCoreSecurityContext : DbContext
    {
        public NetCoreSecurityContext()
        {
        }

        public NetCoreSecurityContext(DbContextOptions<NetCoreSecurityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
