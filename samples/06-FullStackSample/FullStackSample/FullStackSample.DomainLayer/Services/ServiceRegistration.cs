using AutoMapper;
using FullStackSample.Api.Requests;
using FullStackSample.DomainLayer.RequestHandlers;
using FullStackSample.DomainLayer.ServicesImpl;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackSample.DomainLayer.Services
{
	public static class ServiceRegistration
	{
		public static void Register(IServiceCollection serviceCollection)
		{
			RegisterRequestHandlers(serviceCollection);

			serviceCollection.AddAutoMapper(typeof(SearchClientsQueryHandler).Assembly);
			serviceCollection.AddMediatR(typeof(SearchClientsQueryHandler).Assembly);

			serviceCollection.AddDbContext<FullStackDbContext>(
					optionsAction: options =>
					{
						options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
					},
					contextLifetime: ServiceLifetime.Scoped,
					optionsLifetime: ServiceLifetime.Singleton);
		}

		private static void RegisterRequestHandlers(IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<IRequestHandler<SearchClientsQuery, SearchClientsResponse>, SearchClientsQueryHandler>();
		}
	}
}
