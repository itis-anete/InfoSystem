using System;

namespace InfoSystem.Web
{
	public class AdditionException : Exception
	{
		public AdditionException() : base("Error adding object to database.")
		{

		}
	}
}