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
    public class AlbumsRepository : IAlbumsRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Albums> entities;
        string errorMessage = string.Empty;

        public AlbumsRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Albums>();
        }

        public void DeleteAlbum(Albums entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public Albums GetDetailsForAlbum(Guid id)
        {
            return entities
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .First(a => a.Id == id);
        }

        public IEnumerable<Albums> GetAllAlbums()
        {
            return entities.
                Include(a => a.Artist)
                .AsEnumerable();
        }

        public void InsertNewAlbum(Albums entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void UpdateAlbum(Albums entity)
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
