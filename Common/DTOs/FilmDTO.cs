namespace Common.DTOs;

public class FilmDTO
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public DateTime? Released { get; set; }
	public int DirectorId { get; set; }
	public virtual DirectorDTO? Director { get; set; }
	public string? Description { get; set; }
	public string? FilmUrl { get; set; }

	public List<BaseGenreDTO>? Genres { get; set; }
	public List<SimilarFilmDTO>? SimilarFilms { get; set; }
}

public class CreateFilmDTO
{
	public string? Title { get; set; }
	public int DirectorId { get; set; }
	public string? Description { get; set; }
	public string? FilmUrl { get; set; }
	public DateTime? Released { get; set; }
}

public class EditFilmDTO : CreateFilmDTO
{
	public int Id { get; set; }
	
}

public class BaseFilmDTO : CreateFilmDTO
{
	public int Id { get; set; }

}