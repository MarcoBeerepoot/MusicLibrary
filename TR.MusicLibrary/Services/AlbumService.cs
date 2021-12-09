using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Models;
using TR.MusicLibrary.Services.Interfaces;

namespace TR.MusicLibrary.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repository;

        public AlbumService(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public async Task<Album> GetOrCreate(string name, Artist artist)
        {
            var album = await _repository.Get(name);
            if (album == null)
            {
                album = new Album(name, artist);
                await Add(album);
            }
            return album;
        }

        public Task Add(Album album) => _repository.Add(album);
    }
}
