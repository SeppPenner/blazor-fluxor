using Blazor.Fluxor;

namespace FullStackSample.Client.Store.ClientCreate
{
	public class ClientCreateResponseReducer : Reducer<ClientCreateState, Api.Requests.ClientCreateResponse>
	{
		public override ClientCreateState Reduce(ClientCreateState state, Api.Requests.ClientCreateResponse action)
			=> new ClientCreateState(isExecutingApi: false, errorMessage: action.ErrorMessage);
	}
}
