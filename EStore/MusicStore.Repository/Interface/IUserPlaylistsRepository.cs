using MusicStore.Domain.Domain;
using MusicStore.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository.Interface
{
    public interface IUserPlaylistsRepository
    {
        UserPlaylists GetDetailsForUserPlaylist(Guid id);
        IEnumerable<UserPlaylists> GetAllUserPlaylists();
        void InsertNewUserPlaylist(UserPlaylists entity);
        void UpdateUserPlaylist(UserPlaylists entity);
        void DeleteUserPlaylist(UserPlaylists entity);
        public void SaveChangesInUserPlaylist();
    }
}
