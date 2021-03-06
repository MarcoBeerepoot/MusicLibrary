using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL.Interfaces
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist> Get(string name);
    }
}
