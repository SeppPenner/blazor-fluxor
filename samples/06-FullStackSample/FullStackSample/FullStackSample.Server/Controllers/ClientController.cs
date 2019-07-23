using FullStackSample.Api.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FullStackSample.Server.Controllers
{
	public class ClientController
	{
		readonly IMediator Mediator;

		public ClientController(IMediator mediator)
		{
			Mediator = mediator;
		}

		[HttpPost]
		public Task<ClientsSearchResponse> Search([FromBody]ClientsSearchQuery query) =>
			Mediator.Send(query);

		[HttpPost]
		public Task<ClientCreateResponse> Create([FromBody]ClientCreateCommand command) =>
			Mediator.Send(command);
	}
}
