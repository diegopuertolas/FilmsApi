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
    public ActionResult<Film> Post(Film film)
    {
        films.Add(film);

        film.Id = films.Count > 0 ? films.Max(f => f.Id) + 1 : 1;

        return CreatedAtAction(nameof(GetById), new { id = film.Id }, film);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Film updatedFilm)
    {
        var film = films.FirstOrDefault(f => f.Id == id);

        if (film is null)
        {
            return NotFound();
        }

        film.Title = updatedFilm.Title;
        film.Director = updatedFilm.Director;
        film.Genre = updatedFilm.Genre;
        film.Duration = updatedFilm.Duration;
        film.IsForAdultsOnly = updatedFilm.IsForAdultsOnly;

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