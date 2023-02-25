using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Collections.Specialized.BitVector32;
using VOD.Membership.Database.Services;
using Common.DTOs;

namespace Membership.Database.Extensions;

public static class MSContextExtensions
{
	public static async Task SeedMembershipData(this IDbService db)
	{
		string description = "" +
			"Contrary to popular belief, Lorem Ipsum is not simply random text. " +
			"It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. " +
			"Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, " +
			"looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, " +
			"and going through the cites of the word in classical literature, discovered the undoubtable source. " +
			"Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" " +
			"(The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory " +
			"of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, " +
			"\"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32." +
			"";

		try
		{
			#region Seed Directors
			////Spiderman
			//await db.AddAsync<Director, DirectorDTO>(new DirectorDTO
			//{
			//	Name = "Sam Raimi"
			//});

			////Avatar
			//await db.AddAsync<Director, DirectorDTO>(new DirectorDTO
			//{
			//	Name = "James Cameron"
			//});

			////Batman
			//await db.AddAsync<Director, DirectorDTO>(new DirectorDTO
			//{
			//	Name = "Matt Reeves"
			//});

			////Ironman
			//await db.AddAsync<Director, DirectorDTO>(new DirectorDTO
			//{
			//	Name = "Jon Favreau"
			//});

			////Ex Machina
			//await db.AddAsync<Director, DirectorDTO>(new DirectorDTO
			//{
			//	Name = "Alex Garland"
			//});

			////Matrix
			//await db.AddAsync<Director, DirectorDTO>(new DirectorDTO
			//{
			//	Name = "Wachowski"
			//});

			//await db.SaveChangesAsync();
			#endregion

			#region Seed Genres

			//await db.AddAsync<Genre, GenreDTO>(new GenreDTO { Name = "Action" });

			//await db.AddAsync<Genre, GenreDTO>(new GenreDTO { Name = "Sci-Fi" });

			//await db.AddAsync<Genre, GenreDTO>(new GenreDTO { Name = "Adventure" });

			//await db.AddAsync<Genre, GenreDTO>(new GenreDTO { Name = "Crime" });

			//await db.AddAsync<Genre, GenreDTO>(new GenreDTO { Name = "Drama" });

			//await db.SaveChangesAsync();
			#endregion

			#region Seed Films

			//await db.AddAsync<Film, FilmDTO>
			//	(new FilmDTO
			//	{

			//		Title = "Avatar",
			//		Released = new DateTime(2009,01,01),
			//		DirectorId = 2,
			//		Description = description.Substring(0, 20),
			//		FilmUrl = "<iframe width=\"1280\" height=\"720\" src=\"https://www.youtube.com/embed/5PSNL1qE6VY\" title=\"Avatar | Official Trailer (HD) | 20th Century FOX\" " +
			//		"frameborder=\"0\" " +
			//		"allow=\"accelerometer; " +
			//		"autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>"
			//	});

			//await db.AddAsync<Film, FilmDTO>
			//	(new FilmDTO
			//	{

			//		Title = "Spider Man",
			//		Released = new DateTime(2002, 01, 01),
			//		DirectorId = 1,
			//		Description = description.Substring(21, 20),
			//		FilmUrl = "<iframe width=\"1280\" height=\"720\" src=\"https://www.youtube.com/embed/t06RUxPbp_c\" title=\"SPIDER-MAN [2002] – " +
			//		"Official Trailer (HD)\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; " +
			//		"web-share\" allowfullscreen></iframe>"
			//	});

			//await db.AddAsync<Film, FilmDTO>
			//	(new FilmDTO
			//	{

			//		Title = "Iron Man",
			//		Released = new DateTime(2008, 01, 01),
			//		DirectorId = 4,
			//		Description = description.Substring(42, 20),
			//		FilmUrl = "<iframe width=\"1280\" height=\"720\" src=\"https://www.youtube.com/embed/8ugaeA-nMTc\" title=\"Iron Man (2008) Trailer #1 | Movieclips Classic Trailers\" " +
			//		"frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>"
			//	});

			//await db.AddAsync<Film, FilmDTO>
			//	(new FilmDTO
			//	{

			//		Title = "Matrix",
			//		Released = new DateTime(1999, 01, 01),
			//		DirectorId = 6,
			//		Description = description.Substring(63, 20),
			//		FilmUrl = "<iframe width=\"1280\" height=\"720\" src=\"https://www.youtube.com/embed/m8e-FF8MsqU\" title=\"Matrix Trailer HD (1999)\" frameborder=\"0\" " +
			//		"allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>"
			//	});

			//await db.AddAsync<Film, FilmDTO>
			//	(new FilmDTO
			//	{

			//		Title = "Ex Machina",
			//		Released = new DateTime(2015, 01, 01),
			//		DirectorId = 5,
			//		Description = description.Substring(11, 20),
			//		FilmUrl = "<iframe width=\"1280\" height=\"720\" src=\"https://www.youtube.com/embed/sNExF5WYMaA\" title=\"Ex Machina - Official International Trailer 1 (Universal Pictures) HD\" frameborder=\"0\" " +
			//		"allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>"
			//	});

			//await db.AddAsync<Film, FilmDTO>
			//	(new FilmDTO
			//	{

			//		Title = "Batman",
			//		Released = new DateTime(2022, 01, 01),
			//		DirectorId = 3,
			//		Description = description.Substring(31, 20),
			//		FilmUrl = "<iframe width=\"1280\" height=\"720\" src=\"https://www.youtube.com/embed/mqqft2x_Aa4\" title=\"THE BATMAN – Main Trailer\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" " +
			//		"allowfullscreen></iframe>"
			//	});

			//await db.SaveChangesAsync();

			#endregion

			#region Seed SimilarFilms

			//await db.RTAddAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
			//{
			//	FilmId = 2,
			//	SimilarFilmId= 3,
			//});

			//await db.RTAddAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
			//{
			//	FilmId = 2,
			//	SimilarFilmId = 6,
			//});

			//await db.RTAddAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
			//{
			//	FilmId = 3,
			//	SimilarFilmId = 6,
			//});

			//await db.RTAddAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
			//{
			//	FilmId = 4,
			//	SimilarFilmId = 5,
			//});

			//await db.SaveChangesAsync();

			#endregion

			#region Seed FilmGenres

			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(1,1));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(1, 3));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(1, 5));

			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(2, 1));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(2, 2));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(2, 3));

			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(3, 1));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(3, 2));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(3, 3));

			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(4, 1));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(4, 2));

			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(5, 1));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(5, 2));

			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(6, 1));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(6, 2));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(6, 3));
			//await db.RTAddAsync<FilmGenre, FilmGenresDTO>(new FilmGenresDTO(6, 5));

			//await db.SaveChangesAsync();

			#endregion






			#region Seed Courses
			//var instructor1 = await db.SingleAsync<Instructor, InstructorDTO>(i => i.Name.Equals("John Doe"));
			//var instructor2 = await db.SingleAsync<Instructor, InstructorDTO>(i => i.Name.Equals("Jane Doe"));
			//await db.AddAsync<Course, CourseDTO>(new CourseDTO
			//{
			//	Title = "Course1",
			//	Description = description.Substring(30, 50),
			//	ImageUrl = "/images/course1.jpg",
			//	MarqeeImage = "/images/laptop.jpg",
			//	Free = false,
			//	InstructorId = instructor1.Id
			//});

			//await db.AddAsync<Course, CourseDTO>(new CourseDTO
			//{
			//	Title = "Course2",
			//	Description = description.Substring(35, 50),
			//	ImageUrl = "/images/course2.jpg",
			//	MarqeeImage = "/images/laptop.jpg",
			//	Free = true,
			//	InstructorId = instructor2.Id
			//});

			//await db.AddAsync<Course, CourseDTO>(new CourseDTO
			//{
			//	Title = "Course3",
			//	Description = description.Substring(40, 50),
			//	ImageUrl = "/images/course3.jpg",
			//	MarqeeImage = "/images/laptop.jpg",
			//	Free = false,
			//	InstructorId = instructor1.Id
			//});

			//await db.SaveChangesAsync();
			#endregion

			#region Seed Sections
			//var course1 = await db.SingleAsync<Course, CourseDTO>(c => c.Title.Equals("Course1"));
			//var course2 = await db.SingleAsync<Course, CourseDTO>(c => c.Title.Equals("Course2"));
			//var course3 = await db.SingleAsync<Course, CourseDTO>(c => c.Title.Equals("Course3"));

			//await db.AddAsync<Section, SectionDTO>(new SectionDTO
			//{
			//	Title = "Section1",
			//	CourseId = course1.Id
			//});

			//await db.AddAsync<Section, SectionDTO>(new SectionDTO
			//{
			//	Title = "Section2",
			//	CourseId = course1.Id
			//});

			//await db.AddAsync<Section, SectionDTO>(new SectionDTO
			//{
			//	Title = "Section3",
			//	CourseId = course2.Id
			//});

			//await db.SaveChangesAsync();

			//var section1 = await db.SingleAsync<Section, SectionDTO>(s => s.Title.Equals("Section1"));
			//var section2 = await db.SingleAsync<Section, SectionDTO>(s => s.Title.Equals("Section2"));
			//var section3 = await db.SingleAsync<Section, SectionDTO>(s => s.Title.Equals("Section3"));
			#endregion

			#region Seed Videos
			//await db.AddAsync<Video, VideoDTO>(new VideoDTO
			//{
			//	Title = "Video1",
			//	Description = description.Substring(45, 50),
			//	Duration = 50,
			//	Thumbnail = "/images/video1.jpg",
			//	SecionId = section1.Id,
			//	Url = "<iframe width=\"1280\" height=\"720\" src=\"" +
			//	"https://www.youtube.com/embed/hAX5WbW-kSs?list=PLsFMOWiVqTuhBnGu97o4ynkoFNfK4lo0T\" " +
			//	"title=\"[ Intro ] " +
			//	"Full stack WordPress development course: Theme and Plugin Development\" " +
			//	"frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; " +
			//	"gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>"
			//});

			//await db.AddAsync<Video, VideoDTO>(new VideoDTO
			//{
			//	Title = "Video2",
			//	Description = description.Substring(10, 50),
			//	Duration = 45,
			//	Thumbnail = "/images/video2.jpg",
			//	SecionId = section1.Id,
			//	Url = "<iframe width=\"1280\" height=\"720\" src=\"" +
			//	"https://www.youtube.com/embed/hAX5WbW-kSs?list=PLsFMOWiVqTuhBnGu97o4ynkoFNfK4lo0T\" " +
			//	"title=\"[ Intro ] " +
			//	"Full stack WordPress development course: Theme and Plugin Development\" " +
			//	"frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; " +
			//	"gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>"
			//});

			//await db.AddAsync<Video, VideoDTO>(new VideoDTO
			//{
			//	Title = "Video3",
			//	Description = description.Substring(10, 50),
			//	Duration = 41,
			//	Thumbnail = "/images/video3.jpg",
			//	SecionId = section1.Id,
			//	Url = "<iframe width=\"1280\" height=\"720\" src=\"" +
			//	"https://www.youtube.com/embed/hAX5WbW-kSs?list=PLsFMOWiVqTuhBnGu97o4ynkoFNfK4lo0T\" " +
			//	"title=\"[ Intro ] " +
			//	"Full stack WordPress development course: Theme and Plugin Development\" " +
			//	"frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; " +
			//	"gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>"
			//});

			//await db.AddAsync<Video, VideoDTO>(new VideoDTO
			//{
			//	Title = "Video4",
			//	Description = description.Substring(25, 50),
			//	Duration = 41,
			//	Thumbnail = "/images/video4.jpg",
			//	SecionId = section3.Id,
			//	Url = "<iframe width=\"1280\" height=\"720\" src=\"" +
			//   "https://www.youtube.com/embed/hAX5WbW-kSs?list=PLsFMOWiVqTuhBnGu97o4ynkoFNfK4lo0T\" " +
			//   "title=\"[ Intro ] " +
			//   "Full stack WordPress development course: Theme and Plugin Development\" " +
			//   "frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; " +
			//   "gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>"
			//});

			//await db.AddAsync<Video, VideoDTO>(new VideoDTO
			//{
			//	Title = "Video5",
			//	Description = description.Substring(45, 50),
			//	Duration = 42,
			//	Thumbnail = "/images/video5.jpg",
			//	SecionId = section2.Id,
			//	Url = "<iframe width=\"1280\" height=\"720\" src=\"" +
			//   "https://www.youtube.com/embed/hAX5WbW-kSs?list=PLsFMOWiVqTuhBnGu97o4ynkoFNfK4lo0T\" " +
			//   "title=\"[ Intro ] " +
			//   "Full stack WordPress development course: Theme and Plugin Development\" " +
			//   "frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; " +
			//   "gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>"
			//});

			//await db.SaveChangesAsync();
			#endregion

		}
		catch
		{
			throw;
		}
	}
}