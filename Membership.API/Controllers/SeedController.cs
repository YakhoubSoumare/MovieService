using Membership.Database.Extensions;
using Microsoft.AspNetCore.Mvc;
using VOD.Membership.Database.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeedController : ControllerBase
{
	private readonly IDbService _db;

	public SeedController(IDbService db)
	{
		_db = db;
	}

	[HttpPost]
	public async Task<IResult> Seed([FromBody] string value)
	{
		try
		{
			await _db.SeedMembershipData();
		}
		catch
		{
			return Results.BadRequest();
		}
		return Results.NoContent();
	}
}