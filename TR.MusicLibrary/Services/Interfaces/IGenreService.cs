using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.Services.Interfaces
{
    public interface IGenreService
    {
        Task<Genre> GetOrCreate(string name);
    }
}
