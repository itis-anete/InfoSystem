using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace InfoSystem.Web
{
	/// <summary>
	/// Main class of a program.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// Program entrance point.
		/// </summary>
		/// <param name="args">Program arguments.</param>
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Method that initiates web configuration of an application.
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}