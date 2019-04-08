using System.Net.Sockets;

namespace InfoSystem.Sockets.Models
{
	public class ServerData
	{
		public Socket Socket;
		public Socket Handler;
		public byte[] Buffer;
	}
}