using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using VOD.Membership.Database.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectorsController : ControllerBase
{
	private readonly IDbService _db;

	public DirectorsController(IDbService db)
	{
		_db = db;
	}

	[HttpGet]
	public async Task<IResult> Get()
	{
		var directors = new object();
		try
		{
			_db.Include<Director>();
			directors = await _db.GetAsync<Director, DirectorDTO>();
			if (directors is null)
			{
				return Results.BadRequest();
			}
		}
		catch
		{
			return Results.NotFound();
		}
		return Results.Ok(directors);
	}


	[HttpGet("{id}")]
	public async Task<IResult> Get(int id)
	{
		var director = new object();
		try
		{
			_db.Include<Director>();
			director = await _db.SingleAsync<Director, DirectorDTO>(c => c.Id.Equals(id));
			if (director is null) { return Results.NotFound(); }
		}
		catch
		{
			return Results.BadRequest();
		}
		return Results.Ok(director);
	}


	[HttpPost]
	public async Task<IResult> Post([FromBody] CreateDirectorDTO dto)
	{
		try
		{
			var entity = await _db.AddAsync<Director, CreateDirectorDTO>(dto);
			if (await _db.SaveChangesAsync())
			{
				return Results.Created(_db.GetURI<Director>(entity), entity);
			}
			return Results.BadRequest();
		}
		catch
		{
			return Results.BadRequest();
		}
	}


	[HttpPut("{id}")]
	public async Task<IResult> Put(int id, [FromBody] EditDirectorDTO dto)
	{
		try
		{
			if (dto is null || dto.Id != id)
			{
				return Results.BadRequest("Mismatch Id");
			}
			var exist = await _db.AnyAsync<Director>(c => c.Id.Equals(id));
			if (!exist)
			{
				return Results.NotFound("Could not find given id in database");
			}
			_db.Update<Director, EditDirectorDTO>(id, dto);

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
			var exist = await _db.AnyAsync<Director>(c => c.Id.Equals(id));
			if (!exist)
			{
				return Results.NotFound("Could not find given id in database");
			}
			var deletion = await _db.DeleteAsync<Director>(id);
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