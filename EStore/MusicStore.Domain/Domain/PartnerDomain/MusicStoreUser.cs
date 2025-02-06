using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Domain.PartnerDomain
{

    public class MusicStoreUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        // Ids of all Albums/Tracks purchased by the user
        public virtual List<Guid> PurchasedItems { get; set; } = new();
        public virtual ICollection<Playlist> Playlists { get; set; } = new HashSet<Playlist>();

    }
}
