using System.ComponentModel.DataAnnotations;

namespace FilmsApi.DTOs.Film;

public class FilmCreateDto
{   
    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El título debe tener entre 2 y 100 caracteres.")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "El director es obligatorio.")]
    [StringLength(50,  ErrorMessage = "El nombre del director no puede exceder los 50 caracteres.")]
    public required string Director { get; set; }
    [StringLength(30, ErrorMessage = "El nombre del género no puede exceder los 30 caracteres.")]
    [Required(ErrorMessage = "El genero es obligatorio.")]

    public required string Genre { get; set; }
    
    [Required(ErrorMessage = "La duración es obligatoria.")]
    [Range(1, 1000, ErrorMessage = "La duración debe estar entre 1 y 1000 minutos.")]
    public required int Duration { get; set; }
    
    [Required(ErrorMessage = "Debe asignar si la película es +18 o no.")]
    public required bool IsForAdultsOnly { get; set; }
}