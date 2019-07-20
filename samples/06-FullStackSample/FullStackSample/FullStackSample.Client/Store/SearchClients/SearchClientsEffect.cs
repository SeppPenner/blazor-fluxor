using Blazor.Fluxor;
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
				System.Diagnostics.Debug.WriteLine(new string('=', 32) + " Dispatching SearchClientsQuery");
				var response = await Http.PostJsonAsync<Api.Requests.SearchClientsResponse>("/client/search", query);
				System.Diagnostics.Debug.WriteLine(new string('=', 32) + $" Dispatching SearchClientsResponse {response.Clients.Count()} clients");
				dispatcher.Dispatch(response);
			}
			catch (Exception e)
			{
				var errorAction = 
					new Api.Requests.SearchClientsResponse(
						errorMessage: e.Message,
						clients: null
					);
				System.Diagnostics.Debug.WriteLine(new string('=', 32) + " Dispatching SearchClientsResponse (ERROR)");
				dispatcher.Dispatch(errorAction);
			}
		}
	}
}
