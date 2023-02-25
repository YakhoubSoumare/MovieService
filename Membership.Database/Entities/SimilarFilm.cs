namespace Membership.Database.Entities;

public class SimilarFilm : IReferenceEntity
{
	//To set this Id as the main film, configuration in OnModelCreating: .HasForeignKey(d => d.FilmId)
	public int FilmId { get; set; }
	public int SimilarFilmId { get; set; }

	//To avoid Main film being loaded as similar (Circular references), configuration in OnModelCreating: OnDelete(DeleteBehavior.ClientSetNull);
	public virtual Film? Film { get; set; }
	[ForeignKey("SimilarFilmId")]
	public virtual Film? Similar { get; set; }
}