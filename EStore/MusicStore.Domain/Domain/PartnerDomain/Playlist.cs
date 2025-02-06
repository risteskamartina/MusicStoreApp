using MusicStore.Domain.Domain.PartnerDomain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Domain.PartnerDomain
{
    public class Playlist
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string PlaylistName { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public PlaylistType PlaylistType { get; set; }

        public string UserId { get; set; }
        public MusicStoreUser? User { get; set; }

        public virtual ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
