using Blazor.Fluxor;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsFeature : Feature<SearchClientsState>
	{
		public override string GetName() => "SearchClients";
		protected override SearchClientsState GetInitialState() =>
			new SearchClientsState(
				isSearching: false,
				errorMessage: null,
				clients: null
			);
	}
}
