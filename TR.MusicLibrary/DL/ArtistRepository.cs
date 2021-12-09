using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        public ArtistRepository(DbContext context) : base(context)
        {
        }
    }
}
