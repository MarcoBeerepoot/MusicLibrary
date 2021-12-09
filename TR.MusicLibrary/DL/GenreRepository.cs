using Microsoft.EntityFrameworkCore;
using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(DbContext context) : base(context)
        {
        }

        public Task<Genre> Get(string name)
        {
            return DbSet.FirstOrDefaultAsync(g => g.Name == name);
        }
    }
}
