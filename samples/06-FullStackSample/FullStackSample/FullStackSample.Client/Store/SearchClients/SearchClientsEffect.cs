using Blazor.Fluxor;
using FullStackSample.Client.Services;
using FullStackSample.Client.Store.EntityStateEvents;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsEffect : Effect<Api.Requests.ClientsSearchQuery>
	{
		private readonly IApiService ApiService;

		public SearchClientsEffect(IApiService apiService)
		{
			ApiService = apiService;
		}

		protected async override Task HandleAsync(Api.Requests.ClientsSearchQuery query, IDispatcher dispatcher)
		{
			try
			{
				var response = await ApiService.Execute<Api.Requests.ClientsSearchQuery, Api.Requests.ClientsSearchResponse>(query);

				response.Clients.ToList().ForEach(x => dispatcher.Dispatch(
					new ClientStateNotification(
						id: x.Id,
						name: x.Name)
					)
				);

				dispatcher.Dispatch(response);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.ToString());
				var errorAction =
					new Api.Requests.ClientsSearchResponse(
						errorMessage: e.Message,
						clients: null
					);
				dispatcher.Dispatch(errorAction);
			}
		}
	}
}
