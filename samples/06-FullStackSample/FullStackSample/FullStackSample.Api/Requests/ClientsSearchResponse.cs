using FullStackSample.Api.Models;
using System;
using System.Collections.Generic;

namespace FullStackSample.Api.Requests
{
	public class ClientsSearchResponse : BaseApiResponse
	{
		public IEnumerable<Client> Clients { get; set; } = Array.Empty<Client>();

		public ClientsSearchResponse() { }

		public ClientsSearchResponse(string errorMessage, IEnumerable<Client> clients)
			: base(errorMessage)
		{
			Clients = clients ?? Array.Empty<Client>();
		}
	}
}
