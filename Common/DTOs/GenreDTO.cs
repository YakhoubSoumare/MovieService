using System.ComponentModel.DataAnnotations;

namespace Common.DTOs;

public class GenreDTO : BaseGenreDTO
{
	public List<FilmDTO>? Films { get; set; }
}

public class CreateGenreDTO
{
	public string? Name { get; set; }
}

public class EditGenreDTO : CreateGenreDTO
{
	public int Id { get; set; }
}

//To avoid Circular references when loading a genre. Otherwise loads films that loads genre bis...
//This is another option instead of OnDelete(DeleteBehavior.ClientSetNull in OnModelCreating
public class BaseGenreDTO
{
	public int Id { get; set; }
	public string? Name { get; set; }
}