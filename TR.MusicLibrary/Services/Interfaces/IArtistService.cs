using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.Services.Interfaces
{
    public interface IArtistService
    {
        Task<Artist> Get(int id);
        Task<Artist> GetOrCreate(string name);
        Task Add(Artist artist);
    }
}
