using Microsoft.AspNetCore.Identity;
using MusicStore.Domain.Domain;

namespace MusicStore.Domain.Identity
{
    public class EShopApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public ICollection<UserPlaylists>? UserPlaylists { get; set; }
    }
}
