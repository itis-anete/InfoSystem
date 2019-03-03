using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace InfoSystem.SocketServer
{
	public static class SocketServer
	{
		public static void Start(IPAddress ip, int port)
		{
			var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
			var endPoint = new IPEndPoint(ip, port);
			socket.Bind(endPoint);
			socket.Listen(100);

			socket.BeginAccept(Accept, socket);
		}

		private static void Accept(IAsyncResult ar)
		{
			var socket = (Socket) ar.AsyncState;
			var handler = socket.EndAccept(ar);

			var buffer = new byte[1024];
			handler.BeginReceive(
				new List<ArraySegment<byte>> {buffer},
				SocketFlags.None,
				Receive,
				new ServerData()
				{
					Socket = socket,
					Handler = handler,
					Buffer = buffer
				});
		}

		private static void Receive(IAsyncResult ar)
		{
			var data = (ServerData) ar.AsyncState;
			var handler = data.Handler;

			var size = handler.EndReceive(ar);

			Console.WriteLine("Data received: " +
			                  Encoding.UTF8.GetString(data.Buffer, 0, size));

			var message = Encoding.UTF8.GetBytes("Packets received<EOF>");
			handler.BeginSend(new List<ArraySegment<byte>> {message}, SocketFlags.None, SendResponse, data);
		}

		private static void SendResponse(IAsyncResult ar)
		{
			var data = (ServerData) ar.AsyncState;
			
			var handler = data.Handler;
			handler.EndSend(ar);
			handler.Close();
			
			data.Socket.Close();
			Console.WriteLine("Server sent data...");
		}
	}
}