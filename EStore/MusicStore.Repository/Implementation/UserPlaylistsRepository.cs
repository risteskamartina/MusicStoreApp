using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Domain;
using MusicStore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository.Implementation
{
    public class UserPlaylistsRepository : IUserPlaylistsRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<UserPlaylists> entities;
        string errorMessage = string.Empty;

        public UserPlaylistsRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<UserPlaylists>();
        }

        public void DeleteUserPlaylist(UserPlaylists entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public UserPlaylists GetDetailsForUserPlaylist(Guid id)
        {
            return entities
                .Include("User")
                .Include("UserPlaylistTracks")
                .Include("UserPlaylistTracks.Track")
                .Include("UserPlaylistTracks.Track.Album")
                .Include("UserPlaylistTracks.Track.Album.Artist")
                .First(up => up.Id == id);
        }

        public IEnumerable<UserPlaylists> GetAllUserPlaylists()
        {
            return entities
                .Include("User")
                .Include("UserPlaylistTracks")
                .Include("UserPlaylistTracks.Track")
                .Include("UserPlaylistTracks.Track.Album")
                .Include("UserPlaylistTracks.Track.Album.Artist")
                .AsEnumerable();
        }

        public void InsertNewUserPlaylist(UserPlaylists entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void SaveChangesInUserPlaylist()
        {
            context.SaveChanges();
        }

        public void UpdateUserPlaylist(UserPlaylists entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
