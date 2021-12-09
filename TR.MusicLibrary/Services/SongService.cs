using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Models;
using TR.MusicLibrary.Services.Interfaces;

namespace TR.MusicLibrary.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _repository;
        private readonly IGenreService _genreService;
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;

        public SongService(ISongRepository repository, IGenreService genreService, IArtistService artistService, IAlbumService albumService)
        {
            _repository = repository;
            _genreService = genreService;
            _artistService = artistService;
            _albumService = albumService;
        }

        public Task<Song> Get(int id) => _repository.Get(id);

        public async Task Add(Song song, IEnumerable<string> genreNames, string artistName, string albumName)
        {
            song.Genres = await GetGenres(genreNames);
            song.Artist = await _artistService.GetOrCreate(artistName);
            song.Album = await _albumService.GetOrCreate(albumName, song.Artist);
            await _repository.Add(song);
        }

        private async Task<ICollection<Genre>> GetGenres(IEnumerable<string> genreNames)
        {
            var genres = new List<Genre>();
            foreach (var name in genreNames)
            {
                var genre = await _genreService.GetOrCreate(name);
                genres.Add(genre);
            }
            return genres;
        }
    }
}
