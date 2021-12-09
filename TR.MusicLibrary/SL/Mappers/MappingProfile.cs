using AutoMapper;
using TR.MusicLibrary.DTO;
using TR.MusicLibrary.Model;

namespace TR.MusicLibrary.SL.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Artist, ArtistDTO>();
            CreateMap<Song, SongDTO>()
                .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album.Name))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Artist.Name))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom<SongGenreResolver>());
        }
    }
}
