using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL.Interfaces
{
    public interface IArtistRepository
    {
        Task<Artist> Get(int id);
        Task Add(Artist artist);
    }
}
