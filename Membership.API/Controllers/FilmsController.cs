using System.Collections.Generic;
using Common.DTOs;
using Membership.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VOD.Membership.Database.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilmsController : ControllerBase
	{
		private readonly IDbService _db;

		public FilmsController(IDbService db)
		{
			_db = db;
		}
		
		[HttpGet]
		public async Task<IResult> Get()
		{
			var films = new object();
			try
			{
				_db.Include<Film>();
				_db.Include<FilmGenre>();
				films = await _db.GetAsync<Film, FilmDTO>();
				//films = await _db.GetAsync<Film, BaseFilmDTO>();
				if (films is null)
				{
					return Results.BadRequest();
				}
			}
			catch
			{
				return Results.NotFound();
			}
			return Results.Ok(films);
		}


		[HttpGet("{id}")]
		public async Task<IResult> Get(int id)
		{
			var film = new object();
			try
			{
				_db.Include<Film>();
				_db.Include<FilmGenre>();
				film = await _db.SingleAsync<Film, FilmDTO>(c => c.Id.Equals(id));
				if (film is null) { return Results.NotFound(); }
			}
			catch
			{
				return Results.BadRequest();
			}
			return Results.Ok(film);
		}


		[HttpPost]
		public async Task<IResult> Post([FromBody] CreateFilmDTO dto)
		{
			try
			{
				var entity = await _db.AddAsync<Film, CreateFilmDTO>(dto);
				var success = await _db.SaveChangesAsync();

				if (success)
				{
					var emptyGenre = (dto.SelectedGenres.Length.Equals(1) && dto.SelectedGenres[0].Equals(0));

					if (!(dto.SelectedGenres == null && dto.SelectedGenres.Length.Equals(0) || emptyGenre))
					{
						foreach (var genreId in dto.SelectedGenres)
						{
							await _db.RTAddAsync<FilmGenre, BaseFilmGenresDTO>(new BaseFilmGenresDTO
							{
								FilmId = entity.Id,
								GenreId = genreId
							});

						}
					}

					success = await _db.SaveChangesAsync();

					return Results.Created(_db.GetURI<Film>(entity), entity);
				}
				return Results.BadRequest();
			}
			catch
			{
				return Results.BadRequest();
			}
		}


		[HttpPut("{id}")]
		public async Task<IResult> Put(int id, [FromBody] EditFilmDTO dto)
		{
			try
			{
				if (dto is null || dto.Id != id)
				{
					return Results.BadRequest("Mismatch Id");
				}
				var exist = await _db.AnyAsync<Film>(c => c.Id.Equals(id));
				if (!exist)
				{
					return Results.NotFound("Could not find given id in database");
				}

				_db.Update<Film, EditFilmDTO>(id, dto); /*Tracking issues*/


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


		[HttpDelete("{id}")]
		public async Task<IResult> Delete(int id)
		{
			try
			{
				var exist = await _db.AnyAsync<Film>(c => c.Id.Equals(id));
				if (!exist)
				{
					return Results.NotFound("Could not find given id in database");
				}
				var deletion = await _db.DeleteAsync<Film>(id);
				if (!deletion)
				{
					return Results.BadRequest("Unable to delete given Id");
				}
				var success = await _db.SaveChangesAsync();
				if (success) { return Results.NoContent(); }
			}
			catch
			{
				return Results.BadRequest();
			}
			return Results.BadRequest();
		}
	}
}
