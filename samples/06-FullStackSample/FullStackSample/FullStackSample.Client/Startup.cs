using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazor.Fluxor;
using Blazor.Fluxor.Routing;
using FullStackSample.Client.Services;
using PeterLeslieMorris.Blazor.Validation;
using Blazor.Fluxor.ReduxDevTools;

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
					.AddMiddleware<ReduxDevToolsMiddleware>()
			);
			services.AddFormValidation(config =>
				config.AddFluentValidation(typeof(Api.Models.ClientSummary).Assembly)
			);
		}

		public void Configure(IComponentsApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
