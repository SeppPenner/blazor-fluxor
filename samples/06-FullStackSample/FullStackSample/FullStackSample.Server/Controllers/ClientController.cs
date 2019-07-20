using FullStackSample.Api.Requests;
using MediatR;
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

		public async Task<SearchClientsResponse> Search()
		{
			var request = new SearchClientsQuery("Client");
			var response = await Mediator.Send<SearchClientsResponse>(request);
			return response;
		}
	}
}
