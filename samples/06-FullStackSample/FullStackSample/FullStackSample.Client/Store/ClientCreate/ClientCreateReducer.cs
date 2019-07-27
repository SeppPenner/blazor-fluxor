using Blazor.Fluxor;

namespace FullStackSample.Client.Store.ClientCreate
{
	public class ClientCreateReducer : Reducer<ClientCreateState, Api.Requests.ClientCreateCommand>
	{
		public override ClientCreateState Reduce(ClientCreateState state, Api.Requests.ClientCreateCommand action)
			=> new ClientCreateState(isExecutingApi: true, errorMessage: null);
	}
}
