namespace MusicStore.Domain.Domain
{
    public class UserPlaylistTrack : BaseEntity
    {
        public Guid UserPlaylistId { get; set; }
        public UserPlaylists? UserPlaylist { get; set; }
        public Guid TrackId { get; set; }
        public Tracks? Track { get; set; }
    }
}
