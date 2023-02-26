using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using VOD.Membership.Database.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenresController : ControllerBase
	{
		private readonly IDbService _db;

		public GenresController(IDbService db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<IResult> Get()
		{
			var genres = new object();
			try
			{
				_db.Include<Genre>();
				genres = await _db.GetAsync<Genre, GenreDTO>();
				if (genres is null)
				{
					return Results.BadRequest();
				}
			}
			catch
			{
				return Results.NotFound();
			}
			return Results.Ok(genres);
		}


		[HttpGet("{id}")]
		public async Task<IResult> Get(int id)
		{
			var genre = new object();
			try
			{
				_db.Include<Genre>();
				genre = await _db.SingleAsync<Genre, GenreDTO>(c => c.Id.Equals(id));
				if (genre is null) { return Results.NotFound(); }
			}
			catch
			{
				return Results.BadRequest();
			}
			return Results.Ok(genre);
		}


		[HttpPost]
		public async Task<IResult> Post([FromBody] CreateGenreDTO dto)
		{
			try
			{
				var entity = await _db.AddAsync<Genre, CreateGenreDTO>(dto);
				if (await _db.SaveChangesAsync())
				{
					return Results.Created(_db.GetURI<Genre>(entity), entity);
				}
				return Results.BadRequest();
			}
			catch
			{
				return Results.BadRequest();
			}
		}


		[HttpPut("{id}")]
		public async Task<IResult> Put(int id, [FromBody] EditGenreDTO dto)
		{
			try
			{
				if (dto is null || dto.Id != id)
				{
					return Results.BadRequest("Mismatch Id");
				}
				var exist = await _db.AnyAsync<Genre>(c => c.Id.Equals(id));
				if (!exist)
				{
					return Results.NotFound("Could not find given id in database");
				}
				_db.Update<Genre, EditGenreDTO>(id, dto);

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
				var exist = await _db.AnyAsync<Genre>(c => c.Id.Equals(id));
				if (!exist)
				{
					return Results.NotFound("Could not find given id in database");
				}
				var deletion = await _db.DeleteAsync<Genre>(id);
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
