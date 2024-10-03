using MusicStore.Domain.Domain;
using MusicStore.Repository.Interface;
using MusicStore.Service.Interface;

namespace MusicStore.Service.Implementation
{
    public class UserPlaylistsService : IUserPlaylistsService
    {
        private readonly IUserPlaylistsRepository _userPlaylistsRepository;
        private readonly IUserRepository _userRepository;

        public UserPlaylistsService(IUserPlaylistsRepository userPlaylistsRepository, IUserRepository userRepository)
        {
            _userPlaylistsRepository = userPlaylistsRepository;
            _userRepository = userRepository;
        }

        public void CreateNewUserPlaylist(UserPlaylists playlists)
        {
            _userPlaylistsRepository.InsertNewUserPlaylist(playlists);
        }

        public void DeleteUserPlaylist(Guid id)
        {
            var userPlaylist = _userPlaylistsRepository.GetDetailsForUserPlaylist(id);
            _userPlaylistsRepository.DeleteUserPlaylist(userPlaylist);
        }

        public List<UserPlaylists> GetAllUserPlaylists(string userId)
        {
            var user = _userRepository.Get(userId);
            return _userPlaylistsRepository.GetAllUserPlaylists().Where(z => z.User == user).ToList();
        }

        public UserPlaylists GetDetailsForUserPlaylist(Guid id)
        {
            return _userPlaylistsRepository.GetDetailsForUserPlaylist(id);
        }

        public void UpdateUserPlaylist(UserPlaylists playlists)
        {
            _userPlaylistsRepository.UpdateUserPlaylist(playlists);
        }
    }
}
