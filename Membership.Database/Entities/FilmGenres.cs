namespace Membership.Database.Entities;

//Applying ToTable("FilmGenres") in OnModelCreating to use this entity instead of
//generated reference table provided by Entity Framework
public class FilmGenre : IReferenceEntity
{
	public int FilmId { get; set; }
	public int GenreId { get; set; }

	public virtual Film? Film { get; set; }
	public virtual Genre? Genre { get; set; }
}
