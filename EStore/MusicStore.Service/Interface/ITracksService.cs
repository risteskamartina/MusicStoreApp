using MusicStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Service.Interface
{
    public interface ITracksService
    {
        Tracks GetDetailsForTrack(Guid id);
        List<Tracks> GetAllTracks();
        void CreateNewTrack(Tracks track);
        void UpdateTrack(Tracks track);
        void DeleteTrack(Guid id);
        void AddTrackToUserPlaylist(UserPlaylists playlist, Tracks track);
        void DeleteTrackFromUserPlaylist(Guid id);
        public void updateAllTracks();
    }
}
