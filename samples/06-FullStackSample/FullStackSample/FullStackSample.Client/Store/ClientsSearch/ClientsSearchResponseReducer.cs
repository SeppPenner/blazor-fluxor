using Blazor.Fluxor;
using FullStackSample.Api.Requests;

namespace FullStackSample.Client.Store.ClientsSearch
{
	public class ClientsSearchResponseReducer : Reducer<ClientsSearchState, ClientsSearchResponse>
	{
		public override ClientsSearchState Reduce(ClientsSearchState state, ClientsSearchResponse response) =>
				new ClientsSearchState(
					isSearching: false,
					errorMessage: response.ErrorMessage,
					clients: response.Clients
				);
	}
}
