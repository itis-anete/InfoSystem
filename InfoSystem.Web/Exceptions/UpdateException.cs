using System;

namespace InfoSystem.Web
{
	public class UpdateException : Exception
	{
		public UpdateException() : base("Failed to update database object.")
		{

		}
	}
}