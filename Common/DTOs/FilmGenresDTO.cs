namespace Common.DTOs;

public class FilmGenresDTO
{
	public int FilmId { get; set; }
	public int GenreId { get; set; }

	public FilmGenresDTO(int filmId, int genreId)
	{
		FilmId = filmId;
		GenreId = genreId;
	}

	public FilmDTO? Film { get; set; }
	public GenreDTO? Genre { get; set; }

}

public class BaseFilmGenresDTO
{
	public int FilmId { get; set; }
	public int GenreId { get; set; }
}


public class AlteredBaseFilmGenresDTO
{
	public int FilmId { get; set; }
	public int GenreId { get; set; }

	//May need to change to base to avoid circular reference in filmgenre component
	public FilmDTO? Film { get; set; }
	public GenreDTO? Genre { get; set; }
}

public class ViewFilmGenresDTO
{
	public int FilmId { get; set; }
	public int GenreId { get; set; }

	public string? FilmTitle { get; set; }
	public string? GenreName { get; set; }
}