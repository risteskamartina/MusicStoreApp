using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicStore.Domain.Domain.PartnerDomain
{
    public class Artist
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Biography { get; set; } = String.Empty;
        public string? Image { get; set; } = String.Empty;
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; } = new HashSet<Album>();
        [JsonIgnore]
        public virtual ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
