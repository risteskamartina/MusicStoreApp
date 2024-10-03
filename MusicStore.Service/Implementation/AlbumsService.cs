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
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsRepository _albumsRepository;
        private readonly IUserPlaylistsRepository _userPlaylistsRepository;

        public AlbumsService(IAlbumsRepository albumsRepository, IUserPlaylistsRepository userPlaylistsRepository)
        {
            _albumsRepository = albumsRepository;
            _userPlaylistsRepository = userPlaylistsRepository;
        }

        public void CreateNewAlbum(Albums album)
        {
            _albumsRepository.InsertNewAlbum(album);
        }

        public void DeleteAlbum(Guid id)
        {
            var album = _albumsRepository.GetDetailsForAlbum(id);
            _albumsRepository.DeleteAlbum(album);
        }

        public List<Albums> GetAllAlbums()
        {
            return _albumsRepository.GetAllAlbums().ToList();
        }

        public Albums GetDetailsForAlbum(Guid id)
        {
            return _albumsRepository.GetDetailsForAlbum(id);
        }

        public void UpdateAlbum(Albums album)
        {
            _albumsRepository.UpdateAlbum(album);
        }
    }
}
