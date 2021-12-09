using Microsoft.EntityFrameworkCore;
using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL
{
    public class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
    {
        public AlbumRepository(DbContext context) : base(context)
        {
        }

        public Task<Album> Get(string name)
        {
            return DbSet.FirstOrDefaultAsync(a => a.Name == name);
        }
    }
}
