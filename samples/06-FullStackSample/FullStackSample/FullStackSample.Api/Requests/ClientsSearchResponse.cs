using FullStackSample.Api.Models;
using System;
using System.Collections.Generic;

namespace FullStackSample.Api.Requests
{
	public class ClientsSearchResponse : ApiResponse
	{
		public IEnumerable<ClientSummary> Clients { get; set; }

		public ClientsSearchResponse(IEnumerable<ClientSummary> clients)
		{
			Clients = clients;
		}

		public ClientsSearchResponse()
		{
			Clients = Array.Empty<ClientSummary>();
		}

		public ClientsSearchResponse(
			string errorMessage,
			IEnumerable<KeyValuePair<string, string>> validationErrors)
			: base(errorMessage, validationErrors)
		{
		}
	}
}
