namespace Common.HttpClients;

public class MembershipHttpClient
{
	public HttpClient Client { get; }
	public MembershipHttpClient(HttpClient client)
	{
		Client = client;
	}


}
