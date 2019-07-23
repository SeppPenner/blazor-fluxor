using FullStackSample.Api.Models;
using MediatR;

namespace FullStackSample.Api.Requests
{
	public class ClientCreateCommand : IRequest<ClientCreateResponse>
	{
		public ClientCreateOrUpdate Client { get; set; }
	}
}
