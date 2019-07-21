using Microsoft.Extensions.DependencyInjection;

namespace FullStackSample.Client.Services
{
	public static class ServicesRegistration
	{
		public static void Register(IServiceCollection services)
		{
			services.AddScoped<IApiService, ApiService>();
		}
	}
}
