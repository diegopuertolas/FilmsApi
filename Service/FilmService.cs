using AutoMapper;
using FilmsApi.DTOs.Film;
using FilmsApi.Interfaces;
using FilmsApi.Models;

namespace FilmsApi.Service;

public class FilmService : IFilmService
{
    private readonly List<Film> _films = [];
    private readonly IMapper _mapper;
    private readonly ILogger<FilmService> _logger;

    public FilmService(IMapper mapper, ILogger<FilmService> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public IEnumerable<FilmReadDto> GetAll()
    {
        return _mapper.Map<IEnumerable<FilmReadDto>>(_films);
    }

    public FilmReadDto? GetById(int id)
    {
        var film = _films.FirstOrDefault(f => f.Id == id);
        
        if (film is null)
        {
            _logger.LogWarning($"Intento de busqueda fallido. Película {id} no encontrada.");
            return null;
        }

        return _mapper.Map<FilmReadDto>(film);
    }

    public FilmReadDto Create(FilmCreateDto filmDto)
    {
        _logger.LogInformation($"Creando nueva película: {filmDto.Title}");

        var newFilm = _mapper.Map<Film>(filmDto);
        newFilm.Id = _films.Count > 0 ? _films.Max(f => f.Id) + 1 : 1;

        _films.Add(newFilm);

        return _mapper.Map<FilmReadDto>(newFilm);
    }

    public bool Update(int id, FilmUpdateDto filmDto)
    {
        var film = _films.FirstOrDefault(f => f.Id == id);

        if (film is null)
        {
            _logger.LogWarning($"Intento de actualización fallido. Película {id} no encontrada.");
            return false;
        }

        _mapper.Map(filmDto, film);
        
        return true;
    }

    public bool Delete(int id)
    {
        var film = _films.FirstOrDefault(f => f.Id == id);

        if (film is null)
        {
            _logger.LogWarning($"Intento de borrado fallido. Película {id} no encontrada.");
            return false;
        }

        _films.Remove(film);
        _logger.LogInformation($"Película {id} eliminada correctamente.");
        return true;
    }
} 