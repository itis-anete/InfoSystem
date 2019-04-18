using System;

namespace InfoSystem.Web
{
	public class DeletionException : Exception
	{
		public DeletionException() : base("Failed to delete from database.")
		{

		}
	}
}