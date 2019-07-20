using Blazor.Fluxor;
using FullStackSample.Api.Requests;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsQueryReducer : Reducer<SearchClientsState, SearchClientsQuery>
	{
		public override SearchClientsState Reduce(SearchClientsState state, SearchClientsQuery query) =>
			new SearchClientsState(
				isSearching: true,
				errorMessage: null,
				clients: null
			);
	}
}
