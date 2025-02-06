using MusicStore.Domain.Domain;
using MusicStore.Domain.Domain.PartnerDomain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStore.Repository.Interface.PartnerRepository
{
    public interface IPartnerTracksRepository
    {
        public Task<IEnumerable<Track>> GetTracks();
        public Task<Track?> GetTrackById(Guid trackId);
        public Task<IEnumerable<Track>> GetAllTracksByIds(IEnumerable<Guid> trackIds);
        public Task<IEnumerable<Track>> GetTrackByAlbum(Guid albumId);
        public Task<Track> Create(Track track);
        public Task<Track> Update(Track track);
        public Task<Track> Delete(Track track);
    }
}
