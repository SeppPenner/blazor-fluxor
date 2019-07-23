using FullStackSample.Api.Models;
using System;
using System.Collections.Generic;

namespace FullStackSample.Api.Requests
{
	public class ClientsSearchResponse : BaseApiResponse
	{
		public IEnumerable<ClientSummary> Clients { get; set; } = Array.Empty<ClientSummary>();

		public ClientsSearchResponse() { }

		public ClientsSearchResponse(string errorMessage, IEnumerable<ClientSummary> clients)
			: base(errorMessage)
		{
			Clients = clients ?? Array.Empty<ClientSummary>();
		}
	}
}
