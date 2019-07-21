using MediatR;

namespace FullStackSample.Api.Requests
{
	public class ClientsSearchQuery : IRequest<ClientsSearchResponse>
	{
		public string Name { get; set; }

		public ClientsSearchQuery() { }

		public ClientsSearchQuery(string name)
		{
			Name = name;
		}
	}
}
