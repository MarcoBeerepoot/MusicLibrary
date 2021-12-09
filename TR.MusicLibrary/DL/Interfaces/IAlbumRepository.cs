using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL.Interfaces
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<Album> Get(string name);
    }
}
