using FilmsApi.DTOs.Film;
using FilmsApi.Interfaces;
using FilmsApi.Models;

namespace FilmsApi.Service;

public class FilmService : IFilmService
{
    private readonly List<Film > _films = [];

    public IEnumerable<Film> GetAll()
    {
        return _films;
    }

    public Film? GetById(int id)
    {
        return _films.FirstOrDefault(f => f.Id == id);
    }

    public Film Create(FilmCreateDto filmDto)
    {
        var newFilm = new Film
        {
            Id = _films.Count > 0 ? _films.Max(f => f.Id) + 1 : 1,
            Title = filmDto.Title,
            Director = filmDto.Director,
            Genre = filmDto.Genre,
            Duration = filmDto.Duration,
            IsForAdultsOnly = filmDto.IsForAdultsOnly
        };

        _films.Add(newFilm);
        return newFilm;
    }

    public bool Update(int id, FilmUpdateDto filmDto)
    {
        var film = GetById(id);

        if (film is null)
        {
            return false;
        }

        film.Title = filmDto.Title;
        film.Director = filmDto.Director;
        film.Genre = filmDto.Genre;
        film.Duration = filmDto.Duration;
        film.IsForAdultsOnly = filmDto.IsForAdultsOnly;

        return true;
    }

    public bool Delete(int id)
    {
        var film = GetById(id);

        if (film is null)
        {
            return false;
        }

        _films.Remove(film);
        return true;
    }
} 