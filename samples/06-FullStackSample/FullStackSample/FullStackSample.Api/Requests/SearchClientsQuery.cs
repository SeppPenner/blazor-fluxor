using Blazor.Fluxor;
using MediatR;

namespace FullStackSample.Api.Requests
{
	public class SearchClientsQuery : IRequest<SearchClientsResponse>, IAction
	{
		public string Name { get; set; }

		public SearchClientsQuery() { }

		public SearchClientsQuery(string name)
		{
			Name = name;
		}
	}
}
