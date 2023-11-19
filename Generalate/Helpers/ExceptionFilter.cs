using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Helpers
{
    public class ExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {

            Log.Error(filterContext.Exception, "Error");
            Log.Error(filterContext.HttpContext.Request.RawUrl);

        }

    }
}