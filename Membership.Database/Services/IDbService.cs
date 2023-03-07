using Common.DTOs;

namespace VOD.Membership.Database.Services;

public interface IDbService
{
	Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
		where TEntity : class, IEntity
		where TDto : class;
	Task<SimilarFilm> AddSimilarAsync(BaseSimilarFilmDTO dto);
	Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;
	Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
	Task<bool> DeleteFilmGenres(int filmId, int genreId);
	Task<bool> DeleteSimilarFilms(int filmId, int similarId);
	Task<List<ViewFilmGenresDTO>> FilmGenresGetAsync();
	Task<List<TDto>> GetAsync<TEntity, TDto>()
		where TEntity : class, IEntity
		where TDto : class;
	string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity;
	void Include<TEntity>() where TEntity : class;
	Task<TReferenceEntity> RTAddAsync<TReferenceEntity, TDto>(TDto dto)
		where TReferenceEntity : class, IReferenceEntity
		where TDto : class;
	bool RTDeleteAsync<TReferenceEntity, TDto>(TDto dto)
		where TReferenceEntity : class, IReferenceEntity
		where TDto : class;
	Task<List<TDto>> RTGetAsync<TEntity, TDto>()
		where TEntity : class, IReferenceEntity
		where TDto : class;
	Task<bool> SaveChangesAsync();
	Task<List<ViewSimilarFilmDTO>> SimilarGetAsync();
	Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
		where TEntity : class
		where TDto : class;
	void Update<TEntity, TDto>(int id, TDto dto)
		where TEntity : class, IEntity
		where TDto : class;
}