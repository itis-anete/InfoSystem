using System.Net.Sockets;

namespace InfoSystem.Sockets
{
	public class ClientData
	{
		public Socket Socket;
		public string Message;
		public byte[] Buffer;
	}
}