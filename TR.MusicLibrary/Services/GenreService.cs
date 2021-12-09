using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Models;
using TR.MusicLibrary.Services.Interfaces;

namespace TR.MusicLibrary.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<Genre> GetOrCreate(string name)
        {
            var genre = await _repository.Get(name);
            if (genre == null)
            {
                genre = new Genre(name);
                await Add(genre);
            }
            return genre;
        }

        public Task Add(Genre genre) => _repository.Add(genre);
    }
}
