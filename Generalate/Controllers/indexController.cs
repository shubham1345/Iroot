using Generalate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class indexController : Controller
    {
        // GET: index
        public ActionResult Index()
        {
            return View();
        }
    }
}