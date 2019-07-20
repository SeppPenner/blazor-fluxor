using Microsoft.AspNetCore.Blazor.Hosting;

namespace FullStackSample.Client.Website
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
				BlazorWebAssemblyHost.CreateDefaultBuilder()
						.UseBlazorStartup<Startup>();
	}
}
