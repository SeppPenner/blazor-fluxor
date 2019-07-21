using Blazor.Fluxor;
using FullStackSample.Api.Requests;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsResponseReducer : Reducer<SearchClientsState, ClientsSearchResponse>
	{
		public override SearchClientsState Reduce(SearchClientsState state, ClientsSearchResponse response) =>
				new SearchClientsState(
					isSearching: false,
					errorMessage: response.ErrorMessage,
					clients: response.Clients
				);
	}
}
