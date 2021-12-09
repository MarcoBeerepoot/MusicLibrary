using Microsoft.EntityFrameworkCore;
using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL
{
    public class ArtistRepository : IArtistRepository
    {
        private DbSet<Artist> DbSet { get; }

        public ArtistRepository(DbContext context)
        {
            DbSet = context.Set<Artist>();
        }

        public Task<Artist> Get(int id)
        {
            return DbSet.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task Add(Artist artist)
        {
            DbSet.Add(artist);
            return Task.CompletedTask;
        }
    }
}
