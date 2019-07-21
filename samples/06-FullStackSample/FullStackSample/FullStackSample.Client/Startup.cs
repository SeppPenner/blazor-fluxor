using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazor.Fluxor;
using Blazor.Fluxor.Routing;
using FullStackSample.Client.Services;

namespace FullStackSample.Client
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			ServicesRegistration.Register(services);
			services.AddFluxor(options =>
				options
					.UseDependencyInjection(typeof(Startup).Assembly)
					.AddMiddleware<RoutingMiddleware>()
			);
		}

		public void Configure(IComponentsApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
