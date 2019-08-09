using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Model
{
    public partial class Mee_MeeContext : DbContext
    {
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Video> Video { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:mee-mee.database.windows.net,1433;Initial Catalog=Mee-Mee;Persist Security Info=False;User ID=skmu104;Password=Password24;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.VThumb).IsUnicode(false);

                entity.Property(e => e.VUrl).IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Video)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("clientId");
            });
        }
    }
}
