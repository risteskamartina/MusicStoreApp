using MusicStore.Domain.Identity;

namespace MusicStore.Domain.Domain
{
    public class UserPlaylists : BaseEntity
    {
        public string Name { get; set; }
        public int? NumOfTracks { get; set; } = 0;
        public virtual ICollection<UserPlaylistTrack>? UserPlaylistTracks { get; set; }
        public EShopApplicationUser? User { get; set; }

    }
}
