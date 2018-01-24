using Microsoft.EntityFrameworkCore;
using MusicHistoryApi.Models;

namespace MusicHistoryApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<Genre> Genre { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Song> Song { get; set; }
    }
}