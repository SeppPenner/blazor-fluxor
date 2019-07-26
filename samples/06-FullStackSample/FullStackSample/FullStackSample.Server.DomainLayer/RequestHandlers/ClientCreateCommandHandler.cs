using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using FullStackSample.Api.Requests;
using FullStackSample.Server.DomainLayer.Extensions;
using FullStackSample.Server.DomainLayer.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FullStackSample.Server.DomainLayer.RequestHandlers
{
	public class ClientCreateCommandHandler : IRequestHandler<ClientCreateCommand, ClientCreateResponse>
	{
		private readonly FullStackDbContext DbContext;
		private readonly IMapper Mapper;
		private readonly IValidator Validator;

		public ClientCreateCommandHandler(FullStackDbContext dbContext, IMapper mapper, IValidator validator)
		{
			DbContext = dbContext;
			Mapper = mapper;
			Validator = validator;
		}

		public async Task<ClientCreateResponse> Handle(ClientCreateCommand request, CancellationToken cancellationToken)
		{
			ValidationResult validationResult =
				await Validator.ValidateAsync(request.Client, cancellationToken);

			if (!validationResult.IsValid)
				return new ClientCreateResponse(null, validationResult.ToResponseErrors());


			var clientEntity = Mapper.Map<Entities.Client>(request.Client);
			DbContext.Clients.Add(clientEntity);
			await DbContext.SaveChangesAsync();

			var apiClient = Mapper.Map<Api.Models.ClientCreateOrUpdate>(clientEntity);
			return new ClientCreateResponse(apiClient);
		}
	}
}
