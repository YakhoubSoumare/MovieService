namespace Common.DTOs;

public class SimilarFilmDTO
{
	//To set this Id as the main film, configuration in OnModelCreating: .HasForeignKey(d => d.FilmId)
	public int FilmId { get; set; }
	public int SimilarFilmId { get; set; }

	//To avoid Main film being loaded as similar (Circular references), configuration in OnModelCreating: OnDelete(DeleteBehavior.ClientSetNull);
	public virtual BaseFilmDTO? Film { get; set; }
	public virtual BaseFilmDTO? Similar { get; set; }
}

public class BaseSimilarFilmDTO
{
	//To set this Id as the main film, configuration in OnModelCreating: .HasForeignKey(d => d.FilmId)
	public int FilmId { get; set; }
	public int SimilarFilmId { get; set; }
}


//To view movie titles
public class ViewSimilarFilmDTO
{
	
	public int FilmId { get; set; }
	public int SimilarFilmId { get; set; }

	
	public string? FilmTitle { get; set; }
	public string? SimilarTitle { get; set; }
}