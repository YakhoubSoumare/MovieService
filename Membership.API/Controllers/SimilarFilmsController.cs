using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using VOD.Membership.Database.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimilarFilmsController : ControllerBase
{
	private readonly IDbService _db;

	public SimilarFilmsController(IDbService db)
	{
		_db = db;
	}

	[HttpPost]
	public async Task<IResult> Post([FromBody] BaseSimilarFilmDTO dto)
	{
		return await _db.HTTPPAddRTAsync<SimilarFilm, BaseSimilarFilmDTO>(dto);
	}

	[HttpDelete("{id}")]
	public async Task<IResult> Delete([FromBody] BaseSimilarFilmDTO dto)
	{
		return await _db.HTTPDeleteRTAsync<SimilarFilm, BaseSimilarFilmDTO>(dto);
	}
}
