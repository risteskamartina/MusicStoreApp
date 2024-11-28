using MusicStore.Domain.Domain;
using MusicStore.Repository.Implementation;
using MusicStore.Repository.Interface;
using MusicStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Service.Implementation
{
    public class TracksService : ITracksService
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IUserPlaylistTrackRepository _userPlaylistTrackRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserPlaylistsRepository _userPlaylistsRepository;

        public TracksService(ITracksRepository tracksRepository, IUserPlaylistTrackRepository userPlaylistTrackRepository, IUserRepository userRepository, IUserPlaylistsRepository userPlaylistsRepository)
        {
            _tracksRepository = tracksRepository;
            _userPlaylistTrackRepository = userPlaylistTrackRepository;
            _userRepository = userRepository;
            _userPlaylistsRepository = userPlaylistsRepository;
        }

        public void AddTrackToUserPlaylist(UserPlaylists playlist, Tracks track)
        {
            if (playlist != null && track != null)
            {
                if (playlist.UserPlaylistTracks == null)
                {
                    playlist.UserPlaylistTracks = new List<UserPlaylistTrack>();
                }
                if (!playlist.UserPlaylistTracks.Any(t => t.TrackId == track.Id))
                {
                    var userPlaylistTrack = new UserPlaylistTrack
                    {
                        TrackId = track.Id,
                        UserPlaylistId = playlist.Id,
                        Track = track,
                        UserPlaylist = playlist,
                        Id = Guid.NewGuid()
                    };
                    playlist.NumOfTracks += 1;
                    _userPlaylistTrackRepository.InsertTrackInUserPlaylist(userPlaylistTrack);
                    _userPlaylistsRepository.UpdateUserPlaylist(playlist);
                }
            }
        }

        public void CreateNewTrack(Tracks track)
        {
            _tracksRepository.InsertNewTrack(track);
        }

        public void DeleteTrack(Guid id)
        {
            var track = _tracksRepository.GetDetailsForTrack(id);
            _tracksRepository.DeleteTrack(track);
            updateAllTracks();
        }

        public void DeleteTrackFromUserPlaylist(Guid id)
        {
            var track = _userPlaylistTrackRepository.GetDetailsForTrackInUserPlaylist(id);
            var playlist = track.UserPlaylist;
            if (track != null)
            {
                playlist.NumOfTracks -= 1;
                _userPlaylistTrackRepository.DeleteTrackInUserPlaylist(track);
                _userPlaylistsRepository.UpdateUserPlaylist(playlist);
            }
        }

        public List<Tracks> GetAllTracks()
        {
            return _tracksRepository.GetAllTracks().ToList();
        }

        public Tracks GetDetailsForTrack(Guid id)
        {
            return _tracksRepository.GetDetailsForTrack(id);
        }

        public void updateAllTracks()
        {
            var userPlaylists = _userPlaylistsRepository.GetAllUserPlaylists().ToList();

            foreach (var userPlaylist in userPlaylists)
            {
                userPlaylist.NumOfTracks = userPlaylist.UserPlaylistTracks.Count;
            }

            _userPlaylistsRepository.SaveChangesInUserPlaylist();
        }

        public void UpdateTrack(Tracks track)
        {
            _tracksRepository.UpdateTrack(track);
        }
    }
}
