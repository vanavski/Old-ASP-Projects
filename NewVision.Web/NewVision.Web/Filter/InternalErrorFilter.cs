using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewVision.Web.Filter
{
    public class InternalErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine(context.Exception);
            context.Result = new ObjectResult(context.Exception.ToString()) { StatusCode = 500 };
        }
    }
}
