using Common.DTOs;
using Membership.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VOD.Membership.Database.Services;

public class DbService : IDbService
{
	private readonly MSContext _db;
	private readonly IMapper _mapper;

	public DbService(MSContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}

	private async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
	where TEntity : class
	{
		return await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
	}

	public async Task<bool> SaveChangesAsync()
	{
		return await _db.SaveChangesAsync() >= 0;
	}

	public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
	where TEntity : class, IEntity
	{
		return await _db.Set<TEntity>().AnyAsync(expression);
	}

	public async Task<List<TDto>> GetAsync<TEntity, TDto>()
		where TEntity : class, IEntity
		where TDto : class
	{
		var entities = await _db.Set<TEntity>().ToListAsync();
		return _mapper.Map<List<TDto>>(entities);
	}

	public async Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
	where TEntity : class
	where TDto : class
	{
		var entity = await SingleAsync(expression);
		return _mapper.Map<TDto>(entity);
	}

	public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
	where TEntity : class, IEntity
	where TDto : class
	{
		var entity = _mapper.Map<TEntity>(dto);
		await _db.AddAsync(entity);

		return entity;
	}

	public void Update<TEntity, TDto>(int id, TDto dto)
	where TEntity : class, IEntity
	where TDto : class
	{
		var entity = _mapper.Map<TEntity>(dto);
		entity.Id = id;
		_db.Set<TEntity>().Update(entity);
	}

	public async Task<bool> DeleteAsync<TEntity>(int id)
	where TEntity : class, IEntity
	{
		try
		{
			var entity = await SingleAsync<TEntity>(e => e.Id.Equals(id));
			if (entity is null) return false;
			_db.Remove(entity);
		}
		catch { }
		return true;
	}

	public void Include<TEntity>()
	where TEntity : class
	{
		var propertyNames = _db.Model.FindEntityType(typeof(TEntity))?.GetNavigations().Select(e => e.Name);

		if (propertyNames is null) { return; }

		foreach (var name in propertyNames)
		{
			_db.Set<TEntity>().Include(name).Load();
		}

	}

	public string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity
	{
		string URI = string.Empty;
		var node = typeof(TEntity).Name.ToLower();
		if (node.EndsWith("y"))
		{
			URI = $"{node.Remove(node.Length - 1, 1) + "ie"}s/{entity.Id}";
		}
		else
		{
			URI = $"{node}s/{entity.Id}";
		}
		return URI;
	}

	public bool RTDeleteAsync<TReferenceEntity, TDto>(TDto dto)
	where TReferenceEntity : class, IReferenceEntity
	where TDto : class
	{

		try
		{
			var entity = _mapper.Map<TReferenceEntity>(dto);
			if (entity is null) return false;
			_db.Remove(entity);
		}
		catch { throw; }
		return true;
	}

	public async Task<TReferenceEntity> RTAddAsync<TReferenceEntity, TDto>(TDto dto)
	where TReferenceEntity : class, IReferenceEntity
	where TDto : class
	{
		var entity = _mapper.Map<TReferenceEntity>(dto);
		await _db.AddAsync(entity);
		return entity;
	}

	public async Task<List<TDto>> RTGetAsync<TEntity, TDto>()
		where TEntity : class, IReferenceEntity
		where TDto : class
	{
		var entities = await _db.Set<TEntity>().ToListAsync();
		return _mapper.Map<List<TDto>>(entities);
	}

	public async Task<bool> DeleteSimilarFilms(int filmId, int similarId)
	{
		try
		{
			var entity = await SingleAsync<SimilarFilm>(e => e.FilmId.Equals(filmId) && e.SimilarFilmId.Equals(similarId));
			var entity2 = await SingleAsync<SimilarFilm>(e => e.SimilarFilmId.Equals(filmId) && e.FilmId.Equals(similarId));
			if (entity is null || entity2 is null) return false;
			_db.Remove(entity);
			_db.Remove(entity2);
		}
		catch { }
		return true;
	}

	public async Task<bool> DeleteFilmGenres(int filmId, int genreId)
	{
		try
		{
			var entity = await SingleAsync<FilmGenre>(e => e.FilmId.Equals(filmId) && e.GenreId.Equals(genreId));
			if (entity is null) return false;
			_db.Remove(entity);
		}
		catch { }
		return true;
	}

	public async Task<List<ViewSimilarFilmDTO>> SimilarGetAsync()
	{
		var entities = await _db.Set<SimilarFilm>().ToListAsync();
		foreach(var entity in entities)
		{
			var film = await SingleAsync<Film>(e => e.Id.Equals(entity.FilmId));
			entity.Film.Title = film.Title;
			var similarfilm = await SingleAsync<Film>(e => e.Id.Equals(entity.SimilarFilmId));
			entity.Similar.Title = similarfilm.Title;
		}
		return _mapper.Map<List<ViewSimilarFilmDTO>>(entities);
	}

	public async Task<List<ViewFilmGenresDTO>> FilmGenresGetAsync()
	{
		var entities = await _db.Set<FilmGenre>().ToListAsync();
		foreach (var entity in entities)
		{
			var film = await SingleAsync<Film>(e => e.Id.Equals(entity.FilmId));
			entity.Film.Title = film.Title;
			var genre = await SingleAsync<Genre>(e => e.Id.Equals(entity.GenreId));
			entity.Genre.Name = genre.Name;
		}
		return _mapper.Map<List<ViewFilmGenresDTO>>(entities);
	}

	public async Task<SimilarFilm> AddSimilarAsync(BaseSimilarFilmDTO dto)
	{
		//To make similarity go both ways
		BaseSimilarFilmDTO dto2 = new();
		dto2.FilmId = dto.SimilarFilmId;
		dto2.SimilarFilmId = dto.FilmId;
		
		try
		{
			var entity = _mapper.Map<SimilarFilm>(dto);
			await _db.AddAsync(entity);
			var entity2 = _mapper.Map<SimilarFilm>(dto2);
			await _db.AddAsync(entity2);

			return entity;

		}
		catch { throw; }

	}

}
