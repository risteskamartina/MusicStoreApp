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
    public class UserPlaylistTrackRepository : IUserPlaylistTrackRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<UserPlaylistTrack> entities;
        string errorMessage = string.Empty;

        public UserPlaylistTrackRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<UserPlaylistTrack>();
        }

        public void DeleteTrackInUserPlaylist(UserPlaylistTrack track)
        {
            if (track == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(track);
            context.SaveChanges();
        }

        public UserPlaylistTrack GetDetailsForTrackInUserPlaylist(Guid id)
        {
            return entities
                .Include("UserPlaylist")
                .First(t => t.Id == id);
        }

        public void InsertTrackInUserPlaylist(UserPlaylistTrack track)
        {
            if (track == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(track);
            context.SaveChanges();
        }
    }
}
