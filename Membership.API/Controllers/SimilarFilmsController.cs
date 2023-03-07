using System.Collections.Generic;
using Common.DTOs;
using Membership.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using VOD.Membership.Database.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers;

[ApiController]
public class SimilarFilmsController : ControllerBase
{
	private readonly IDbService _db;

	public SimilarFilmsController(IDbService db)
	{
		_db = db;
	}

	[Route("api/SimilarFilms")]
	[HttpGet]
	public async Task<IResult> Get()
	{
		List<ViewSimilarFilmDTO> similarFilms = new();
		try
		{
			similarFilms = await _db.SimilarGetAsync();

			if (similarFilms is null)
			{
				return Results.BadRequest();
			}	
			
		}
		catch
		{
			return Results.NotFound();
		}
		return Results.Ok(similarFilms);
	}

	[Route("api/SimilarFilms")]
	[HttpPost]
	public async Task<IResult> Post([FromBody] BaseSimilarFilmDTO dto)
	{
		if (dto == null) return Results.BadRequest();
		try
		{
			var entity = await _db.AddSimilarAsync(dto);
			if (await _db.SaveChangesAsync())
			{
				
				return Results.Created("similarfilms", entity);
			}
			return Results.BadRequest();
		}
		catch { }
		return Results.BadRequest();
	}

	[Route("api/films/{filmId}/similar/{similarFilmId}")]
	[HttpDelete]
	public async Task<IResult> Delete(int filmId, int similarFilmId)
	{
		try
		{
			var deletion = await _db.DeleteSimilarFilms(filmId, similarFilmId);
			if (!deletion)
			{
				return Results.BadRequest("Unable to delete given Id");
			}
			var success = await _db.SaveChangesAsync();
			if (success)
			{
				return Results.NoContent();
			}
		}
		catch
		{
			return Results.BadRequest();
		}

		return Results.BadRequest();
	}
}