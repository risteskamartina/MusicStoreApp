using MusicStore.Domain.Domain;
using MusicStore.Repository.Interface;
using MusicStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Service.Implementation
{
    public class ArtistsService : IArtistsService
    {
        private readonly IRepository<Artists> _artistRepository;

        public ArtistsService(IRepository<Artists> _artistRepository)
        {
            this._artistRepository = _artistRepository;
        }

        public void CreateNewArtist(Artists artist)
        {
            if (!_artistRepository.GetAll().Any(z => z.StageName.Equals(artist.StageName) && z.FirstName.Equals(artist.FirstName) && z.LastName.Equals(artist.LastName)))
            {
                _artistRepository.Insert(artist);
            }
        }

        public void DeleteArtist(Guid id)
        {
            Artists artist = _artistRepository.Get(id);
            _artistRepository.Delete(artist);
        }

        public List<Artists> GetAllArtists()
        {
            return _artistRepository.GetAll().ToList();
        }

        public Artists GetDetailsForArtist(Guid id)
        {
            return _artistRepository.Get(id);
        }

        public void UpdateArtist(Artists artist)
        {
            _artistRepository.Update(artist);
        }
    }
}
