using Microsoft.Extensions.Configuration;

namespace InfoSystem.Core
{
	public class ConfigurationProvider
	{
		public IConfigurationRoot Configuration { get; private set; }

		public ConfigurationProvider()
		{
			Configuration = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();
		}
	}
}