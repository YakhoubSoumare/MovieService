using Membership.Database.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Membership.Database.Contexts;

public class MSContext : DbContext
{
	public DbSet<Director> Directors => Set<Director>();
	public DbSet<Film> Films => Set<Film>();
	public DbSet<Genre> Genres => Set<Genre>();
	public DbSet<SimilarFilm> SimilarFilms => Set<SimilarFilm>();
	public DbSet<FilmGenre> FilmGenres => Set<FilmGenre>();

	public MSContext(DbContextOptions<MSContext> options) : base(options)
	{}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
		{
			relationship.DeleteBehavior = DeleteBehavior.Restrict;
		}

		modelBuilder.Entity<FilmGenre>().HasKey(fg => new {fg.FilmId, fg.GenreId});

		modelBuilder.Entity<SimilarFilm>().HasKey(sf => new {sf.FilmId, sf.SimilarFilmId});

		modelBuilder.Entity<Film>(entity => 
		{
			entity
			.HasMany(d => d.SimilarFilms)
			.WithOne(f => f.Film)
			.HasForeignKey(d => d.FilmId)
			.OnDelete(DeleteBehavior.ClientSetNull);

			entity
			.HasMany(d => d.Genres)
			.WithMany(f => f.Films)
			.UsingEntity<FilmGenre>()
			.ToTable("FilmGenres");
		});

	}

}
