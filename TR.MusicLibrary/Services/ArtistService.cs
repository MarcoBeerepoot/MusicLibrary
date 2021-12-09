using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Models;
using TR.MusicLibrary.Services.Interfaces;

namespace TR.MusicLibrary.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _repository;

        public ArtistService(IArtistRepository repository)
        {
            _repository = repository;
        }

        public Task Add(Artist artist) => _repository.Add(artist);

        public Task<Artist> Get(int id) => _repository.Get(id);

        public async Task<Artist> GetOrCreate(string name)
        {
            var artist = await _repository.Get(name);
            if (artist == null)
            {
                artist = new Artist(name);
                await Add(artist);
            }
            return artist;
        }
    }
}
