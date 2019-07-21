using Blazor.Fluxor;
using FullStackSample.Client.Services;
using FullStackSample.Client.Store.EntityStateEvents;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsEffect : Effect<Api.Requests.SearchClientsQuery>
	{
		private readonly IApiService ApiService;

		public SearchClientsEffect(IApiService apiService)
		{
			ApiService = apiService;
		}

		protected async override Task HandleAsync(Api.Requests.SearchClientsQuery query, IDispatcher dispatcher)
		{
			try
			{
				var response = await ApiService.Execute<Api.Requests.SearchClientsQuery, Api.Requests.SearchClientsResponse>(query);

				//TODO: Dispatch events to tell all other states that we have more up to date Client data
				//response.Clients.ToList().ForEach(x => dispatcher.Dispatch(
				//	new ClientStateNotification(
				//		id: x.Id,
				//		name: x.Name)
				//	)
				//);

				dispatcher.Dispatch(response);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.ToString());
				var errorAction = 
					new Api.Requests.SearchClientsResponse(
						errorMessage: e.Message,
						clients: null
					);
				dispatcher.Dispatch(errorAction);
			}
		}
	}
}
