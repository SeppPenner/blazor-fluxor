using Blazor.Fluxor;
using FullStackSample.Api.Requests;

namespace FullStackSample.Client.Store.ClientsSearch
{
	public class ClientsSearchQueryReducer : Reducer<ClientsSearchState, ClientsSearchQuery>
	{
		public override ClientsSearchState Reduce(ClientsSearchState state, ClientsSearchQuery query) =>
			new ClientsSearchState(
				isSearching: true,
				errorMessage: null,
				clients: null
			);
	}
}
