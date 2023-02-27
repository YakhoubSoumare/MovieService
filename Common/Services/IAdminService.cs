namespace Common.Services
{
	public interface IAdminService
	{
		Task CreateAsync<TDto>(string uri, TDto dto);
		Task DeleteAsync<TDto>(string uri, int id);
		Task EditAsync<TDto>(string uri, int id, TDto dto);
		Task<List<TDto>> GetAsync<TDto>(string uri);
		Task<TDto> SingleAsync<TDto>(string uri);
	}
}