using AutoMapper;
using FilmsApi.DTOs.Film;
using FilmsApi.Models;

namespace FilmsApi.Profiles;

public class FilmProfile : Profile
{
    public FilmProfile()
    {
        // Origen --> Destino
        CreateMap<Film, FilmReadDto>();
        CreateMap<FilmCreateDto, Film>();
        CreateMap<FilmUpdateDto, Film>();
    }
}