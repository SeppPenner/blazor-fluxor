using System.Threading.Tasks;
using Blazor.Fluxor;
using Blazor.Fluxor.Routing;
using FullStackSample.Api.Models;
using FullStackSample.Api.Requests;
using FullStackSample.Client.Services;
using FullStackSample.Client.Store.EntityStateEvents;
using FullStackSample.Client.Store.Main;

namespace FullStackSample.Client.Store.ClientCreate
{
	public class ClientCreateEffect : Effect<ClientCreateCommand>
	{
		private readonly IApiService ApiService;

		public ClientCreateEffect(IApiService apiService)
		{
			ApiService = apiService;
		}

		protected async override Task HandleAsync(ClientCreateCommand action, IDispatcher dispatcher)
		{
			try
			{
				var response = 
					await ApiService.Execute<ClientCreateCommand, ClientCreateResponse>(action);
				if (response.Successful)
					NotifyStateChanged(dispatcher, response.Client);

				dispatcher.Dispatch(response);
				dispatcher.Dispatch(new Go("/clients"));
			}
			catch
			{
				dispatcher.Dispatch(new ClientCreateResponse());
				dispatcher.Dispatch(new NotifyUnexpectedServerErrorStatusChanged(true));
			}
		}

		private void NotifyStateChanged(IDispatcher dispatcher, ClientCreateOrUpdate client)
		{
			var clientStateChangeNotification = new ClientStateNotification(
				id: client.Id,
				name: client.Name);
			dispatcher.Dispatch(clientStateChangeNotification);
		}
	}
}
