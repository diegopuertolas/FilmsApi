using FilmsApi.DTOs.Film;
using FilmsApi.Interfaces;
using FilmsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IFilmService _filmService;
    private readonly ILogger<FilmsController> _logger;

    public FilmsController(IFilmService filmService, ILogger<FilmsController> logger)
    {
        _filmService = filmService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FilmReadDto>> GetAll()
    {
        return Ok(_filmService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<FilmReadDto> GetById(int id)
    {
        var film = _filmService.GetById(id);

        if (film is null)
        {
            _logger.LogWarning($"Petición GET fallida: No existe la película {id}");
            return NotFound();
        }

        return Ok(film);
    }

    [HttpPost]
    public ActionResult<FilmReadDto> Post([FromBody] FilmCreateDto filmDto)
    {
        var newFilm = _filmService.Create(filmDto);

        return CreatedAtAction(nameof(GetById), new { id = newFilm.Id }, newFilm);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] FilmUpdateDto filmDto)
    {
        var updatedFilm = _filmService.Update(id, filmDto);

        if (!updatedFilm)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deletedFilm = _filmService.Delete(id);

        if (!deletedFilm)
        {
            return NotFound();
        }

        return NoContent();
    }
}