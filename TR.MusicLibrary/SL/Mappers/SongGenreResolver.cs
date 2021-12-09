using AutoMapper;
using TR.MusicLibrary.DTO;
using TR.MusicLibrary.Model;

namespace TR.MusicLibrary.SL.Mappers
{
    public class SongGenreResolver : IValueResolver<Song, SongDTO, string>
    {
        public string Resolve(Song source, SongDTO destination, string destMember, ResolutionContext context)
        {
            return string.Join("/", source.Genres.Select(g => g.Name));
        }
    }
}
