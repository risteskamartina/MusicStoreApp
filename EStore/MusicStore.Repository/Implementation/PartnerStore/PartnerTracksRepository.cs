using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Domain;
using MusicStore.Domain.Domain.PartnerDomain;
using MusicStore.Repository.Interface.PartnerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Repository.Implementation.PartnerStore
{
    public class PartnerTracksRepository : IPartnerTracksRepository
    {
        private readonly PartnerStoreDbContext _context;
        private DbSet<Track> _tracks;

        public PartnerTracksRepository(PartnerStoreDbContext context)
        {
            _context = context;
            _tracks = context.Set<Track>();
        }
        public async Task<IEnumerable<Track>> GetTracks()
        {
            return await _tracks
                .Include(track => track.Album)
                .Include(track => track.Artist)
                .ToListAsync();
        }

        public async Task<Track?> GetTrackById(Guid trackId)
        {
            return await _tracks.Include(track => track.Album).Include(track => track.Artist).FirstOrDefaultAsync(track => track.Id == trackId);
        }

        public async Task<IEnumerable<Track>> GetAllTracksByIds(IEnumerable<Guid> ids)
        {
            return await _tracks.Include(track => track.Album).Include(track => track.Artist).Where(track => ids.Contains(track.Id)).ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetTrackByAlbum(Guid albumId)
        {
            return await _tracks.Where(t => t.AlbumId == albumId).ToListAsync();
        }

        public async Task<Track> Create(Track track)
        {
            await _tracks.AddAsync(track);
            await _context.SaveChangesAsync();
            return track;
        }

        public async Task<Track> Update(Track track)
        {
            _tracks.Update(track);
            await _context.SaveChangesAsync();
            return track;
        }

        public async Task<Track> Delete(Track track)
        {
            _tracks.Remove(track);
            await _context.SaveChangesAsync();
            return track;
        }
    }
}
