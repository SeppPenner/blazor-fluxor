using FullStackSample.Api.Models;
using System;
using System.Collections.Generic;

namespace FullStackSample.Api.Requests
{
	public class SearchClientsResponse : BaseApiResponse
	{
		public IEnumerable<Client> Clients { get; set; } = Array.Empty<Client>();

		public SearchClientsResponse() { }

		public SearchClientsResponse(IEnumerable<Client> clients)
		{
			Clients = clients;
		}
	}
}
