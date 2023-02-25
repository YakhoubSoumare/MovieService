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

}
