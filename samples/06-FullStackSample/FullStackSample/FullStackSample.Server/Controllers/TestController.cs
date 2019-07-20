using FullStackSample.Api.Requests;
using FullStackSample.DomainLayer.ServicesImpl;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FullStackSample.Server.Controllers
{
	public class TestController : Controller
	{
		readonly FullStackDbContext DbContext;
		readonly IMediator Mediator;

		public TestController(FullStackDbContext dbContext, IMediator mediator)
		{
			DbContext = dbContext;
			Mediator = mediator;
		}

		public async Task<SearchClientsResponse> Index()
		{
			var request = new SearchClientsQuery("Client");
			var response = await Mediator.Send<SearchClientsResponse>(request);
			return response;
		}
	}
}