using Blazor.Fluxor;
using FullStackSample.Client.Store.EntityStateEvents;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsEffect : Effect<Api.Requests.SearchClientsQuery>
	{
		private readonly HttpClient Http;

		public SearchClientsEffect(HttpClient http)
		{
			Http = http;
		}

		protected async override Task HandleAsync(Api.Requests.SearchClientsQuery query, IDispatcher dispatcher)
		{
			try
			{
				var response = await Http.PostJsonAsync<Api.Requests.SearchClientsResponse>("/client/search", query);
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
