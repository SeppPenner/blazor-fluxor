using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazor.Fluxor;
using Blazor.Fluxor.Routing;

namespace FullStackSample.Client
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
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
