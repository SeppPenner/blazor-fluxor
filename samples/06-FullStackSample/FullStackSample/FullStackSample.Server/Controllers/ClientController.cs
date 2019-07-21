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
		public async Task<ClientsSearchResponse> Search([FromBody]ClientsSearchQuery query)
		{
			var response = await Mediator.Send<ClientsSearchResponse>(query);
			return response;
		}
	}
}
