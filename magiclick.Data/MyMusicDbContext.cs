using Microsoft.EntityFrameworkCore;
using magiclick.Core.Models;
using magiclick.Data.Configurations;

namespace magiclick.Data
{
    public class magiclickDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public magiclickDbContext(DbContextOptions<magiclickDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new MusicConfiguration());

            builder
                .ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
