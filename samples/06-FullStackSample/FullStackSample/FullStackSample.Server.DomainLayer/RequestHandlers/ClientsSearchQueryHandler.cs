using AutoMapper;
using FullStackSample.Api.Requests;
using FullStackSample.Server.DomainLayer.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FullStackSample.Server.DomainLayer.RequestHandlers
{
	public class ClientsSearchQueryHandler : IRequestHandler<ClientsSearchQuery, ClientsSearchResponse>
	{
		private readonly FullStackDbContext DbContext;
		private readonly IMapper Mapper;

		public ClientsSearchQueryHandler(FullStackDbContext dbContext, IMapper mapper)
		{
			DbContext = dbContext;
			Mapper = mapper;
		}

		public async Task<ClientsSearchResponse> Handle(ClientsSearchQuery request, CancellationToken cancellationToken)
		{
			IQueryable<Entities.Client> dbClientsQuery = DbContext.Clients;

			if (!string.IsNullOrEmpty(request.Name))
				dbClientsQuery = dbClientsQuery
					.Where(x => x.Name.Contains(request.Name));

			dbClientsQuery = dbClientsQuery
				.Take(25);

			Entities.Client[] dbClients = await dbClientsQuery.ToArrayAsync();

			var apiClients = Mapper.Map<Api.Models.Client[]>(dbClients);
			return new ClientsSearchResponse(
				errorMessage: null,
				clients: apiClients);
		}
	}
}
