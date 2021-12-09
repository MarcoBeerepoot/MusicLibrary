using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.Services.Interfaces
{
    public interface ISongService
    {
        Task<Song> Get(int id);
        Task Add(Song song, IEnumerable<string> genreNames, string artistName, string albumName);
    }
}
