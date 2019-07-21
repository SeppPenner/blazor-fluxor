using Blazor.Fluxor;
using FullStackSample.Api.Requests;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsQueryReducer : Reducer<SearchClientsState, ClientsSearchQuery>
	{
		public override SearchClientsState Reduce(SearchClientsState state, ClientsSearchQuery query) =>
			new SearchClientsState(
				isSearching: true,
				errorMessage: null,
				clients: null
			);
	}
}
