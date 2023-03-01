using Common.DTOs;
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
		var similarFilms = new object();
		try
		{
			similarFilms = await _db.RTGetAsync<SimilarFilm, BaseSimilarFilmDTO>();
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

	//[Route("api/SimilarFilms")]
	//[HttpPost]
	//public async Task<IResult> Post([FromBody] BaseSimilarFilmDTO dto)
	//{
	//	return await _db.HTTPPAddRTAsync<SimilarFilm, BaseSimilarFilmDTO>(dto);
	//}

	//[Route("api/films/{filmId}/similar/{similarFilmId}")]
	//[HttpDelete]
	//public async Task<IResult> Delete(int filmId, int similarFilmId)
	//{
	//	return await _db.HTTPDeleteRTAsync<SimilarFilm, BaseSimilarFilmDTO>(dto);
	//}
}
