using System.ComponentModel.DataAnnotations;

namespace MusicStore.Domain.Domain
{
    public class Tracks : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        public Albums? Album { get; set; }
        public Guid AlbumId { get; set; }
        public virtual ICollection<UserPlaylistTrack>? UserPlaylistTracks { get; set; }
    }
}