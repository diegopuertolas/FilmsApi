using FilmsApi.DTOs.Film;
using FilmsApi.Models;

namespace FilmsApi.Interfaces;

public interface IFilmService
{
    IEnumerable<Film> GetAll();
    Film? GetById(int id);
    Film Create(FilmCreateDto filmDto);
    bool Update(int id, FilmUpdateDto filmDto);
    bool Delete(int id);
}