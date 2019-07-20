using Blazor.Fluxor;
using FullStackSample.Api.Requests;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsResponseReducer : Reducer<SearchClientsState, SearchClientsResponse>
	{
		public override SearchClientsState Reduce(SearchClientsState state, SearchClientsResponse response) =>
				new SearchClientsState(
					isSearching: false,
					errorMessage: response.ErrorMessage,
					clients: response.Clients
				);
	}
}
