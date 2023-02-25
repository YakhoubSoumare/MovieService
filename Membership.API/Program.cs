using AutoMapper;
using Common.DTOs;
using Microsoft.EntityFrameworkCore;
using VOD.Membership.Database.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(policy => {
	policy.AddPolicy("CorsAllAccessPolicy", opt =>
	opt.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod()
	);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MSContext>(
options => options.UseSqlServer(
builder.Configuration.GetConnectionString("MSConnection")));

ConfigureAutomapper(builder.Services);

RegisterService(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseCors("CorsAllAccessPolicy");
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureAutomapper(IServiceCollection services)
{
	var config = new MapperConfiguration(cfg =>
	{
		cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
		cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
		cfg.CreateMap<Film, FilmDTO>().ReverseMap();
		cfg.CreateMap<SimilarFilm, SimilarFilmDTO>().ReverseMap();
		cfg.CreateMap<FilmGenre, FilmGenresDTO>().ReverseMap();

	});

	var mapper = config.CreateMapper();

	services.AddSingleton(mapper);
}

void RegisterService(IServiceCollection services)
{
	services.AddScoped<IDbService, DbService>();
}