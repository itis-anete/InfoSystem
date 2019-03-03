using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace InfoSystem.SocketServer
{
	public class SocketClient
	{
		public static void Start(IPAddress ip, int port, string message)
		{
			var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
			socket.BeginConnect(ip, port, Connect,
				new ClientData
				{
					Socket = socket,
					Message = message,
					Buffer = null
				});
		}

		private static void Connect(IAsyncResult ar)
		{
			var data = (ClientData) ar.AsyncState;
			data.Socket.EndConnect(ar);

			var message = Encoding.UTF8.GetBytes(data.Message);
			data.Socket.BeginSend(new List<ArraySegment<byte>> {message}, SocketFlags.None, Send, data);
		}

		private static void Send(IAsyncResult ar)
		{
			var data = (ClientData) ar.AsyncState;
			data.Socket.EndSend(ar);

			var buffer = new byte[1024];
			data.Buffer = buffer;
			data.Socket.BeginReceive(
				new List<ArraySegment<byte>> {buffer},
				SocketFlags.None,
				Receive,
				data);
		}

		private static void Receive(IAsyncResult ar)
		{
			var data = (ClientData) ar.AsyncState;
			var socket = data.Socket;
			var buffer = data.Buffer;

			var size = socket.EndReceive(ar);

			Console.WriteLine("Response: " +
			                  Encoding.UTF8.GetString(buffer, 0, size));

			socket.Close();
			Console.WriteLine("Client closed");
		}
	}
}