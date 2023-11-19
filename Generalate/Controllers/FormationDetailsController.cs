using Generalate.Helpers;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class FormationDetailsController : Controller
    {
        // GET: FormationDetails
        public ActionResult Index()
        {
            return View();
        }

       
    }
}