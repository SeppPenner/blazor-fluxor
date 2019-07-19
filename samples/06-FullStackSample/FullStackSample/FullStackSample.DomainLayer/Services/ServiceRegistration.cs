using FullStackSample.DomainLayer.ServicesImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FullStackSample.DomainLayer.Services
{
	public static class ServiceRegistration
	{
		public static void Register(IServiceCollection serviceCollection)
		{
			serviceCollection.AddDbContext<FullStackDbContext>(
					optionsAction: options =>
					{
						options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
					},
					contextLifetime: ServiceLifetime.Scoped,
					optionsLifetime: ServiceLifetime.Singleton);
		}
	}
}
