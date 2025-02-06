using MusicStore.Domain.Domain.PartnerDomain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Domain.Domain.PartnerDomain
{
    public class Track
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public double Price { get; set; }

        public string? FileUrl { get; set; }

        public virtual List<Enum.MusicGenre> Genres { get; set; } = new List<MusicGenre>();

        public Guid? AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public virtual Album? Album { get; set; }

        public Guid ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist? Artist { get; set; }
    }
}
