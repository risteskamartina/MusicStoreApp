using MusicStore.Domain.Domain;

namespace MusicStore.Service.Interface
{
    public interface IUserPlaylistsService
    {
        UserPlaylists GetDetailsForUserPlaylist(Guid id);
        List<UserPlaylists> GetAllUserPlaylists(string userId);
        void CreateNewUserPlaylist(UserPlaylists playlists);
        void UpdateUserPlaylist(UserPlaylists playlists);
        void DeleteUserPlaylist(Guid id);
    }
}
