using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InfoSystem.Web.Filters
{
	public class BadRequestExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			Console.WriteLine(context.Exception);
			if (context.Result == null || context.Result.GetType() != typeof(ConflictResult))
				context.Result = new ObjectResult(context.Exception.Message) {StatusCode = 500};
		}
	}
}