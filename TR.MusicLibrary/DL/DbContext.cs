using Microsoft.EntityFrameworkCore;
using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Song>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<Artist>().HasIndex(s => s.Name).IsUnique();
        }
    }
}
