using System;
using System.Net;

namespace InfoSystem.Sockets
{
	public static class Resolver
	{
		public static void UseSocket()
		{
			while (true)
			{
				Console.Write("Server / client ? s/c ");
				var answer = Console.ReadKey().KeyChar;
				
				Console.WriteLine();

				switch (answer)
				{
					case 'c':
						Console.Write("Type message:");
						var message = Console.ReadLine();
						RunSafely(() => SocketClient.Start(_clientIp, _port, message));
						break;
					case 's':
						RunSafely(() => SocketServer.Start(_serverIp, _port));
						break;
					default:
						return;
				}
				Console.WriteLine();
			}
		}

		private static void RunSafely(Action code, Action<Exception> onException = null)
		{
			if (onException == null)
				onException = exception => Console.WriteLine(exception.Message);

			try
			{
				code();
			}
			catch (Exception exception)
			{
				onException(exception);
			}
		}

		private static readonly IPAddress _clientIp = IPAddress.Parse("192.168.0.68");
		private static readonly IPAddress _serverIp = IPAddress.Parse("192.168.0.10");
		private static readonly int _port = 8080;
	}
}