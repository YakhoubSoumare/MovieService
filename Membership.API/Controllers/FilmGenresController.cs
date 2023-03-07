using Common.DTOs;
using Membership.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using VOD.Membership.Database.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers
{
	[ApiController]
	public class FilmGenresController : ControllerBase
	{
		private readonly IDbService _db;

		public FilmGenresController(IDbService db)
		{
			_db = db;
		}

		[Route("api/filmgenres")]
		[HttpGet]
		public async Task<IResult> Get()
		{
			var filmGenres = new object();
			try
			{
				filmGenres = await _db.FilmGenresGetAsync();
				if (filmGenres is null)
				{
					return Results.BadRequest();
				}
			}
			catch
			{
				return Results.NotFound();
			}
			return Results.Ok(filmGenres);
		}


		[Route("api/filmgenres")]
		[HttpPost]
		public async Task<IResult> Post([FromBody] BaseFilmGenresDTO dto)
		{
			return await _db.HTTPPAddRTAsync<FilmGenre, BaseFilmGenresDTO>(dto);
		}

		[Route("api/films/{filmId}/genres/{genreId}")]
		[HttpDelete]
		public async Task<IResult> Delete(int filmId, int genreId)
		{
			try
			{
				var deletion = await _db.DeleteFilmGenres(filmId, genreId);
				if (!deletion)
				{
					return Results.BadRequest("Unable to delete given connection");
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

}
