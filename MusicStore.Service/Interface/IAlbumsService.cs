using MusicStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Service.Interface
{
    public interface IAlbumsService
    {
        Albums GetDetailsForAlbum(Guid id);
        List<Albums> GetAllAlbums();
        void CreateNewAlbum(Albums album);
        void UpdateAlbum(Albums album);
        void DeleteAlbum(Guid id);
    }
}
