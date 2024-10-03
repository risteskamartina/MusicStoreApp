using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Domain;
using MusicStore.Domain.Identity;

namespace MusicStore.Repository
{
    public class ApplicationDbContext : IdentityDbContext<EShopApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        public virtual DbSet<UserPlaylists> UserPlaylists { get; set; }
        public virtual DbSet<UserPlaylistTrack> UserPlaylistTracks { get; set; }
    }
}
