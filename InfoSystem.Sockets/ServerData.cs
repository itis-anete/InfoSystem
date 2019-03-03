using System.Net.Sockets;

namespace InfoSystem.SocketServer
{
	public class ServerData
	{
		public Socket Socket;
		public Socket Handler;
		public byte[] Buffer;
	}
}