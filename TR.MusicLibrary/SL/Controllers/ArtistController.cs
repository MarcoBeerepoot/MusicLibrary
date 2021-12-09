using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.DTO;
using TR.MusicLibrary.Models;

namespace TR.MusicLibrary.SL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly IArtistRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ArtistController(ILogger<ArtistController> logger, IArtistRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieve a specific artist by unique id
        /// </summary>
        /// <param name="id">The artist id.</param>
        /// <response code="200">Retrieved artist</response>
        /// <response code="404">No artist found for this id</response>
        /// <response code="500">Unknown error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDTO>> Get(int id)
        {
            try
            {
                var artist = await _repository.Get(id);
                return artist == null ? NotFound() : Ok(_mapper.Map<ArtistDTO>(artist));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Get for id {id}.", id);
                return Problem();
            }
        }

        /// <summary>
        /// Add a new artist
        /// </summary>
        /// <response code="200">Artist added</response>
        /// <response code="500">Unknown error</response>
        [HttpPost()]
        public async Task<ActionResult<ArtistDTO>> Post(ArtistDTO dto)
        {
            try
            {
                var artist = new Artist(dto.Name);
                await _repository.Add(artist);
                await _unitOfWork.CommitAsync();
                artist = await _repository.Get(artist.Id);
                dto = _mapper.Map<ArtistDTO>(artist);
                return Ok(CreatedAtAction(nameof(Get), new { id = dto.Id }, dto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in post for artist.");
                return Problem();
            }
        }
    }
}