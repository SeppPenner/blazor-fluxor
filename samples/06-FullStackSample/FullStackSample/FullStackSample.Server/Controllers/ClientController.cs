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
		public async Task<SearchClientsResponse> Search([FromBody]SearchClientsQuery query)
		{
			var response = await Mediator.Send<SearchClientsResponse>(query);
			return response;
		}
	}
}
