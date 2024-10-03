using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Identity;
using MusicStore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<EShopApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<EShopApplicationUser>();
        }

        public void Delete(EShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public EShopApplicationUser Get(string id)
        {
            var strGuid = id.ToString();
            return entities.Include("UserPlaylists")
                .Include("UserPlaylists.UserPlaylistTracks")
                .Include("UserPlaylists.UserPlaylistTracks.Track")
                .Include("UserPlaylists.UserPlaylistTracks.Track.Album")
                .Include("UserPlaylists.UserPlaylistTracks.Track.Album.Artist")
                .First(z => z.Id == strGuid);
        }

        public IEnumerable<EShopApplicationUser> GetAll()
        {
            return entities
                .AsEnumerable();
        }

        public void Insert(EShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(EShopApplicationUser entity)
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
