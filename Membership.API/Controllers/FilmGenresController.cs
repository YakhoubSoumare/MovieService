using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using VOD.Membership.Database.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilmGenresController : ControllerBase
	{
		private readonly IDbService _db;

		public FilmGenresController(IDbService db)
		{
			_db = db;
		}

		[HttpPost]
		public async Task<IResult> Post([FromBody] BaseFilmGenresDTO dto)
		{
			return await _db.HTTPPAddRTAsync<FilmGenre, BaseFilmGenresDTO>(dto);
		}

		[HttpDelete("{id}")]
		public async Task<IResult> Delete([FromBody] BaseFilmGenresDTO dto)
		{
			return await _db.HTTPDeleteRTAsync<FilmGenre, BaseFilmGenresDTO>(dto);
		}
	}
}
