using System.Net.Sockets;

namespace InfoSystem.SocketServer
{
	public class ClientData
	{
		public Socket Socket;
		public string Message;
		public byte[] Buffer;
	}
}