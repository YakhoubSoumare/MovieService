namespace Membership.Database.Entities;

public class Film : IEntity
{
	public int Id { get ; set ; }
	[MaxLength(50), Required]
	public string? Title { get; set ; }
	public DateTime? Released { get; set ; }
	public int DirectorId { get; set ; }
	public virtual Director? Director { get; set ; }
	[MaxLength(200)]
	public string? Description { get; set ; }
	[MaxLength(1024)]
	public string? FilmUrl { get; set ; }

	public virtual ICollection<Genre>? Genres { get; set ; }
	public virtual ICollection<SimilarFilm>? SimilarFilms { get; set; }
}
