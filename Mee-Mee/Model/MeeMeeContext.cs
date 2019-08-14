using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mee_Mee.Model
{
    public partial class MeeMeeContext : DbContext
    {
        public MeeMeeContext()
        {
        }

        public MeeMeeContext(DbContextOptions<MeeMeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Video> Video { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:mee-mee.database.windows.net,1433;Initial Catalog=Mee-Mee;Persist Security Info=False;User ID=skmu104;Password=Password24;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK__clients__81A2CBE135D16668");

                entity.Property(e => e.ClientDp).IsUnicode(false);

                entity.Property(e => e.ClientName).IsUnicode(false);
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(e => e.VId)
                    .HasName("PK__video__AD3D84413D3CE073");

                entity.Property(e => e.VThumb).IsUnicode(false);

                entity.Property(e => e.VTitle).IsUnicode(false);

                entity.Property(e => e.VUrl).IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Video)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("clientId");
            });
        }
    }
}
