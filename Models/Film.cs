namespace FilmsApi.Models;

public class Film
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Director { get; set; }
    public required string Genre { get; set; }
    public required int Duration { get; set; }
    public bool IsForAdultsOnly { get; set; }
}