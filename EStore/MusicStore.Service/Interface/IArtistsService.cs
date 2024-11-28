using MusicStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Service.Interface
{
    public interface IArtistsService
    {
        Artists GetDetailsForArtist(Guid id);
        List<Artists> GetAllArtists();
        void CreateNewArtist(Artists artist);
        void UpdateArtist(Artists artist);
        void DeleteArtist(Guid id);
    }
}
