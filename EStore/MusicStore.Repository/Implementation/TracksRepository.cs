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
    public class TracksRepository : ITracksRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Tracks> entities;
        string errorMessage = string.Empty;

        public TracksRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Tracks>();
        }

        public void DeleteTrack(Tracks entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public Tracks GetDetailsForTrack(Guid id)
        {
            return entities
                .Include(t => t.Album)
                .First(t => t.Id == id);
        }

        public IEnumerable<Tracks> GetAllTracks()
        {
            return entities
                .Include(t => t.Album)
                .AsEnumerable();
        }

        public void InsertNewTrack(Tracks entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void UpdateTrack(Tracks entity)
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
