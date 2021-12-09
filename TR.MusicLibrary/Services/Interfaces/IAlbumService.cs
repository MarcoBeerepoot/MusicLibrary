using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<Album> GetOrCreate(string albumName, Artist artist);
    }
}
