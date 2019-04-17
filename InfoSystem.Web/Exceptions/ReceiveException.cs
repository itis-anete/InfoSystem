using System;

namespace InfoSystem.Web
{
	public class ReceiveException : Exception
	{
		public ReceiveException() : base("Failed to receive from database.")
		{
			
		}

		public ReceiveException(string message) : base(message)
		{
			
		}
	}
}