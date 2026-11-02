using FilmsApi.DTOs.Film;
using FilmsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private static List<Film> films = new List<Film>();

    [HttpGet]
    public ActionResult<IEnumerable<Film>> GetAll()
    {
        return Ok(films);
    }

    [HttpGet("{id}")]
    public ActionResult<Film> GetById(int id)
    {
        var film = films.FirstOrDefault(f => f.Id == id);

        if (film is null)
        {
            return NotFound();
        }

        return Ok(film);
    }

    [HttpPost]
    public ActionResult<Film> Post([FromBody] FilmCreateDTO filmDTO)
    {
        var newFilm = new Film
        {
            Id = films.Count > 0 ? films.Max(f => f.Id) + 1 : 1,
            Title = filmDTO.Title,
            Director = filmDTO.Director,
            Genre = filmDTO.Genre,
            Duration = filmDTO.Duration,
            IsForAdultsOnly = filmDTO.IsForAdultsOnly
        };

        films.Add(newFilm);

        return CreatedAtAction(nameof(GetById), new { id = newFilm.Id }, newFilm);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] FilmUpdateDTO filmDTO)
    {
        var film = films.FirstOrDefault(f => f.Id == id);

        if (film is null)
        {
            return NotFound();
        }

        film.Title = filmDTO.Title;
        film.Director = filmDTO.Director;
        film.Genre = filmDTO.Genre;
        film.Duration = filmDTO.Duration;
        film.IsForAdultsOnly = filmDTO.IsForAdultsOnly;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var film = films.FirstOrDefault(f => f.Id == id);

        if (film is null)
        {
            return NotFound();
        }

        films.Remove(film);

        return NoContent();
    }
}