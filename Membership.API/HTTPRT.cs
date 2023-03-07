using Common.DTOs;
using VOD.Membership.Database.Services;

namespace Membership.API;

public static class HTTPRT
{
	//Not Optimal for SimilarFilms!	
	public static async Task<IResult> HTTPPAddRTAsync<TEntity, TDto>(this IDbService _db, TDto dto)
	where TEntity : class, IReferenceEntity
	where TDto : class
	{
		if (dto == null) return Results.BadRequest();
		var entity = await _db.RTAddAsync<TEntity, TDto>(dto);
		try
		{
			if (await _db.SaveChangesAsync())
			{
				var node = typeof(TEntity).Name.ToLower();
				string URI = $"{node}s/{entity}";
				return Results.Created(URI, entity);
			}
		}
		catch { }
		return Results.BadRequest();

	}

}
