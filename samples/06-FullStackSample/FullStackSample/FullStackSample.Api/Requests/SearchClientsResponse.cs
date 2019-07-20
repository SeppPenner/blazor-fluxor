using Blazor.Fluxor;
using FullStackSample.Api.Models;
using System;
using System.Collections.Generic;

namespace FullStackSample.Api.Requests
{
	public class SearchClientsResponse : BaseApiResponse, IAction
	{
		public IEnumerable<Client> Clients { get; set; } = Array.Empty<Client>();

		public SearchClientsResponse() { }

		public SearchClientsResponse(string errorMessage, IEnumerable<Client> clients)
			: base(errorMessage)
		{
			Clients = clients ?? Array.Empty<Client>();
		}
	}
}
