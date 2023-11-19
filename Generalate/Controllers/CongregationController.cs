using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    public class CongregationController : Controller
    {
        // GET: Congregation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MeetingMinutes()
        {
            return View();
        }
    }
}