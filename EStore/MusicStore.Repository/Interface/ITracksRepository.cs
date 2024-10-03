using MusicStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository.Interface
{
    public interface ITracksRepository
    {
        Tracks GetDetailsForTrack(Guid id);
        IEnumerable<Tracks> GetAllTracks();
        void InsertNewTrack(Tracks entity);
        void UpdateTrack(Tracks entity);
        void DeleteTrack(Tracks entity);
    }
}
