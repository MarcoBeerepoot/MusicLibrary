using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.DL.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<Genre> Get(string name);
    }
}
