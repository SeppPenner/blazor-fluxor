using MediatR;

namespace FullStackSample.Api.Requests
{
	public class SearchClientsQuery : IRequest<SearchClientsResponse>
	{
		public string Name { get; set; }

		public SearchClientsQuery() { }

		public SearchClientsQuery(string name)
		{
			Name = name;
		}
	}
}
