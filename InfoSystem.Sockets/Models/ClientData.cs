using System.Net.Sockets;

namespace InfoSystem.Sockets.Models
{
	public class ClientData
	{
		public Socket Socket;
		public string Message;
		public byte[] Buffer;
	}
}