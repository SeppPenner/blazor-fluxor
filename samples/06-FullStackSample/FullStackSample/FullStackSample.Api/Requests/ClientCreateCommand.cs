using FullStackSample.Api.Models;
using MediatR;
using System;

namespace FullStackSample.Api.Requests
{
	public class ClientCreateCommand : IRequest<ClientCreateResponse>
	{
		public ClientCreateOrUpdate Client { get; set; }

		public ClientCreateCommand() { }

		public ClientCreateCommand(ClientCreateOrUpdate client)
		{
			if (client == null)
				throw new ArgumentNullException(nameof(client));

			Client = client;
		}
	}
}
