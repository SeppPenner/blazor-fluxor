using Blazor.Fluxor;
using FullStackSample.Api.Requests;
using FullStackSample.Client.Services;
using FullStackSample.Client.Store.EntityStateEvents;
using FullStackSample.Client.Store.Main;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackSample.Client.Store.ClientsSearch
{
	public class ClientsSearchEffect : Effect<Api.Requests.ClientsSearchQuery>
	{
		private readonly IApiService ApiService;

		public ClientsSearchEffect(IApiService apiService)
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
			catch
			{
				dispatcher.Dispatch(new NotifyUnexpectedServerErrorStatusChanged(true));
				dispatcher.Dispatch(new ClientsSearchResponse());
			}
		}
	}
}
