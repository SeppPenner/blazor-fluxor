using AutoMapper;
using FullStackSample.Api.Requests;
using FullStackSample.Server.DomainLayer.RequestHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Relational.Query.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackSample.Server.DomainLayer.Services
{
	public static class ServicesRegistration
	{
		public static void Register(IServiceCollection services)
		{
			RegisterRequestHandlers(services);
			RegisterRepositories(services);
			RegisterServices(services);

			services.AddAutoMapper(typeof(ClientsSearchQueryHandler).Assembly);
			services.AddMediatR(typeof(ClientsSearchQueryHandler).Assembly);

			services.AddDbContext<FullStackDbContext>(
					optionsAction: options =>
					{
						options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
					},
					contextLifetime: ServiceLifetime.Scoped,
					optionsLifetime: ServiceLifetime.Singleton);
		}

		private static void RegisterRequestHandlers(IServiceCollection services)
		{
			services.AddScoped<IRequestHandler<ClientsSearchQuery, ClientsSearchResponse>, ClientsSearchQueryHandler>();
			services.AddScoped<IRequestHandler<ClientCreateCommand, ClientCreateResponse>>();
		}

		private static void RegisterRepositories(IServiceCollection services)
		{
			services.AddScoped<IClientReadRepository, ClientReadRepository>();
			services.AddScoped<IClientRepository, ClientRepository>();
		}

		private static void RegisterServices(IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}
	}
}
