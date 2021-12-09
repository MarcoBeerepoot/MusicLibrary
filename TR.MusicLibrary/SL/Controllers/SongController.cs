using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TR.MusicLibrary.DTO;
using TR.MusicLibrary.Interfaces;
using TR.MusicLibrary.Models;
using TR.MusicLibrary.Services.Interfaces;

namespace TR.MusicLibrary.SL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private const string GenreSeperator = "/";
        private readonly ILogger<SongController> _logger;
        private readonly ISongService _service;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SongController(ILogger<SongController> logger, ISongService service, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieve a specific song by unique id
        /// </summary>
        /// <param name="id">The song id.</param>
        /// <response code="200">Retrieved song</response>
        /// <response code="404">No song found for this id</response>
        /// <response code="500">Unknown error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<SongDTO>> Get(int id)
        {
            try
            {
                var song = await _service.Get(id);
                return song == null ? NotFound() : Ok(_mapper.Map<SongDTO>(song));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Get for id {id}.", id);
                return Problem();
            }
        }

        /// <summary>
        /// Add a new song
        /// </summary>
        /// <response code="200">Song added</response>
        /// <response code="500">Unknown error</response>
        [HttpPost()]
        public async Task<ActionResult<SongDTO>> Post(SongDTO dto)
        {
            try
            {
                var song = await Add(dto);
                song = await _service.Get(song.Id);
                dto = _mapper.Map<SongDTO>(song);
                return Ok(CreatedAtAction(nameof(Get), new { id = dto.Id }, dto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in post for songs.");
                return Problem();
            }
        }

        private async Task<Song> Add(SongDTO dto)
        {
            Song song = CreateFromDTO(dto);
            var genres = dto.Genre.Split(GenreSeperator);
            await _service.Add(song, genres, artistName: dto.Artist, albumName: dto.Album);
            await _unitOfWork.CommitAsync();
            return song;
        }

        private static Song CreateFromDTO(SongDTO dto)
        {
            return new Song
            {
                Name = dto.Name,
                Year = dto.Year,
                Shortname = dto.Shortname,
                Bpm = dto.Bpm,
                Duration = dto.Duration,
                SpotifyId = dto.SpotifyId
            };
        }
    }
}
