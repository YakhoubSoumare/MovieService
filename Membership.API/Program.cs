using System.Text.Json.Serialization;
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

//builder.Services.AddControllersWithViews()
//	.AddNewtonsoftJson(options =>
//	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);

builder.Services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
		cfg.CreateMap<CreateDirectorDTO, Director>();

		cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
		cfg.CreateMap<CreateGenreDTO, Genre>()
		.ForMember(dest => dest.Films, src => src.Ignore());
		cfg.CreateMap<Genre, BaseGenreDTO>();
		

		cfg.CreateMap<Film, FilmDTO>()
		//.ForMember(dest => dest.SimilarFilms, src => src.Ignore())
		//.ForMember(dest => dest.Genres, src => src.Ignore())
		.ReverseMap()
		.ForMember(dest => dest.SimilarFilms, src => src.Ignore())
		.ForMember(dest => dest.Genres, src => src.Ignore())
		.ForMember(dest => dest.Director, src => src.Ignore());

		cfg.CreateMap<Film, BaseFilmDTO>();

		cfg.CreateMap<CreateFilmDTO, Film>()
		.ForMember(dest => dest.SimilarFilms, src => src.Ignore())
		.ForMember(dest => dest.Director, src => src.Ignore())
		.ForMember(dest => dest.Genres, src => src.Ignore());

		cfg.CreateMap<SimilarFilm, SimilarFilmDTO>().ReverseMap();
		cfg.CreateMap<BaseSimilarFilmDTO, SimilarFilm>();
		//.ForMember(dest => dest.Film, scr => scr.Ignore())
		//.ForMember(dest => dest.Similar, scr => scr.Ignore());

		cfg.CreateMap<FilmGenre, FilmGenresDTO>()
		.ForMember(dest => dest.Film, scr => scr.Ignore())
		.ReverseMap()
		.ForMember(dest => dest.Film, scr => scr.Ignore());

		cfg.CreateMap<BaseFilmGenresDTO, FilmGenre>()
		.ForMember(dest => dest.Genre, src => src.Ignore());
		//.ForMember(dest => dest.Film, src => src.Ignore());

	});

	var mapper = config.CreateMapper();

	services.AddSingleton(mapper);
}

void RegisterService(IServiceCollection services)
{
	services.AddScoped<IDbService, DbService>();
}