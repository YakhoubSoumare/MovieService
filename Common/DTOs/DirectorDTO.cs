using System.ComponentModel.DataAnnotations;

namespace Common.DTOs;

public class DirectorDTO
{
	public int Id { get; set; }
	public string? Name { get; set; }
}

public class CreateDirectorDTO
{
	public string? Name { get; set; }
}

public class EditDirectorDTO : CreateDirectorDTO
{
	public int Id { get; set; }
}