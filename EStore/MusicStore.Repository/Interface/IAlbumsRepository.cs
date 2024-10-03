using MusicStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository.Interface
{
    public interface IAlbumsRepository
    {
        Albums GetDetailsForAlbum(Guid id);
        IEnumerable<Albums> GetAllAlbums();
        void InsertNewAlbum(Albums entity);
        void UpdateAlbum(Albums entity);
        void DeleteAlbum(Albums entity);
    }
}
