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
		public static void Register(IServiceCollection services)
		{
			RegisterRequestHandlers(services);

			services.AddAutoMapper(typeof(SearchClientsQueryHandler).Assembly);
			services.AddMediatR(typeof(SearchClientsQueryHandler).Assembly);

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
			services.AddScoped<IRequestHandler<SearchClientsQuery, SearchClientsResponse>, SearchClientsQueryHandler>();
		}
	}
}
