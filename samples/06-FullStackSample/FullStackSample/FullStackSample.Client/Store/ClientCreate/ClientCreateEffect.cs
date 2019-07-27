using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Blazor.Fluxor;
using FluentValidation.Results;
using FullStackSample.Api.Models;
using FullStackSample.Api.Requests;
using FullStackSample.Client.Services;
using FullStackSample.Client.Store.EntityStateEvents;

namespace FullStackSample.Client.Store.ClientCreate
{
	public class ClientCreateEffect : Effect<Api.Requests.ClientCreateCommand>
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
				var response = await ApiService.Execute<Api.Requests.ClientCreateCommand, Api.Requests.ClientCreateResponse>(action);
				if (response.IsValid)
				{
					NotifyStateChanged(dispatcher, response.Client);
				}
				dispatcher.Dispatch(response);
			}
			catch (Exception e)
			{
				var errorAction = new Api.Requests.ClientCreateResponse(
					errorMessage: e.Message,
					validationErrors: null);
				dispatcher.Dispatch(errorAction);
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
