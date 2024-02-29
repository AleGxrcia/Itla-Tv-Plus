using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Productora> Productoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API
            #region tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Serie>().HasKey(s => s.Id);
            modelBuilder.Entity<Genre>().HasKey(g => g.Id);
            modelBuilder.Entity<Productora>().HasKey(p => p.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Genre>()
                .HasMany<Serie>(g => g.Series)
                .WithOne(s => s.PrimaryGenre)
                .HasForeignKey(s => s.PrimaryGenreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Genre>()
                .HasMany<Serie>(g => g.AltSeries)
                .WithOne(s => s.SecondaryGenre)
                .HasForeignKey(s => s.SecondaryGenreId);

            modelBuilder.Entity<Productora>()
                .HasMany<Serie>(p => p.Series)
                .WithOne(s => s.Productora)
                .HasForeignKey(sp => sp.ProductoraId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "property configuration"

            #region serie
            modelBuilder.Entity<Serie>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Serie>()
                .Property(s => s.ImagePath)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Serie>()
                .Property(s => s.Url)
                .IsRequired()
                .IsUnicode(false);

            #endregion

            #region genero
            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion

            #region productora
            modelBuilder.Entity<Productora>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);
            #endregion

            #endregion
        }
    }
}
