using Microsoft.EntityFrameworkCore;
using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL
{
    public class SongRepository : RepositoryBase<Song>, ISongRepository
    {
        private IQueryable<Song> FullDbSet => DbSet.Include(s => s.Artist).Include(s => s.Album).Include(s => s.Genres);

        public SongRepository(DbContext context) : base(context)
        {
        }

        public override Task<Song> Get(int id)
        {
            return FullDbSet.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
