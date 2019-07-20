using AutoMapper;
using FullStackSample.Api.Requests;
using FullStackSample.DomainLayer.ServicesImpl;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Relational.Query.Pipeline;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FullStackSample.DomainLayer.RequestHandlers
{
	public class SearchClientsQueryHandler : IRequestHandler<SearchClientsQuery, SearchClientsResponse>
	{
		private readonly FullStackDbContext DbContext;
		private readonly IMapper Mapper;

		public SearchClientsQueryHandler(FullStackDbContext dbContext, IMapper mapper)
		{
			DbContext = dbContext;
			Mapper = mapper;
		}

		public async Task<SearchClientsResponse> Handle(SearchClientsQuery request, CancellationToken cancellationToken)
		{
			var dbClients = await DbContext.Clients
				.Where(x => x.Name.Contains(request.Name))
				.Take(25)
				.ToArrayAsync();
			var apiClients = Mapper.Map<Api.Models.Client[]>(dbClients);
			return new SearchClientsResponse(apiClients);
		}
	}
}
