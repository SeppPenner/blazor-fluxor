using Blazor.Fluxor;
using FullStackSample.Api.Requests;
using System.Linq;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsResponseReducer : Reducer<SearchClientsState, SearchClientsResponse>
	{
		public override SearchClientsState Reduce(SearchClientsState state, SearchClientsResponse response)
		{
			System.Diagnostics.Debug.WriteLine("**********Client count " + response.Clients.Count());
			return
				new SearchClientsState(
					isSearching: false,
					errorMessage: response.ErrorMessage,
					clients: response.Clients
				);

		}
	}
}
