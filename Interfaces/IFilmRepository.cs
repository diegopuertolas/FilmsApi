using FilmsApi.Models;

namespace FilmsApi.Interfaces;

public interface IFilmRepository
{
    IEnumerable<Film> GetAll();
    Film? GetById(int id);
    Film Create(Film film);
    bool Update(int id, Film film);
    bool Delete(int id);
}