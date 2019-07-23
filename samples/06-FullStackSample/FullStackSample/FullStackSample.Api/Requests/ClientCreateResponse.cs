using System.Collections.Generic;
using FullStackSample.Api.Models;

namespace FullStackSample.Api.Requests
{
	public class ClientCreateResponse : ApiResponse
	{
		public ClientCreateOrUpdate Client { get; set; }

		public ClientCreateResponse(ClientCreateOrUpdate client)
		{
			Client = client;
		}

		public ClientCreateResponse()
		{
		}

		public ClientCreateResponse(
			string errorMessage,
			IEnumerable<KeyValuePair<string, string>> validationErrors)
			: base(errorMessage, validationErrors)
		{
		}

	}
}