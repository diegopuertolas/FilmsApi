using FilmsApi.DTOs.Film;
using FilmsApi.Models;

namespace FilmsApi.Interfaces;

public interface IFilmService
{
    IEnumerable<FilmReadDto> GetAll();
    FilmReadDto? GetById(int id);
    FilmReadDto Create(FilmCreateDto filmDto);
    bool Update(int id, FilmUpdateDto filmDto);
    bool Delete(int id);
}