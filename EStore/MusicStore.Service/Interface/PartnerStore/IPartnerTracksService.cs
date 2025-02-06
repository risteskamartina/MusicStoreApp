using MusicStore.Domain.Domain;
using MusicStore.Domain.Domain.PartnerDomain;
using MusicStore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Service.Interface.PartnerStore
{
    public interface IPartnerTracksService
    {
       // List<PartnerTracks> getAllTracks();
        Task<IEnumerable<Track>> GetAll();
        Task<IEnumerable<Track>> GetAllByAlbum(Guid albumId);
        Task<IEnumerable<Track>> GetAllByIds(IEnumerable<Guid> trackIds);
        Task<Track?> GetById(Guid id);
        Task<Track> Create(Track track);
        Task<Track> Update(Track track);
        Task<Track?> Delete(Guid trackId);
    }
}
