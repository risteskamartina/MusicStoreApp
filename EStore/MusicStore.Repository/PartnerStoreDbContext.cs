using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Domain.PartnerDomain;
using MusicStore.Domain.Identity;


namespace MusicStore.Repository
{
    public class PartnerStoreDbContext : IdentityDbContext<MusicStoreUser>
    {
        public PartnerStoreDbContext(DbContextOptions<PartnerStoreDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
    }
}
