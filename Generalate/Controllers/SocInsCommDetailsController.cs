using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.MailViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class SocInsCommDetailsController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: SocInsCommDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SocInsCommDetails1(string id)
        {
            Societys data = dbcont.Societys.FirstOrDefault(x => x.Id.ToString() == id);

            var allCociety = dbcont.SocietyData.Where(x => x.SocId == id.ToString()).ToList();
            ViewBag.allCociety = allCociety;

            return View(data);
        }
       

        public ActionResult PrintSocInsCommDetailsReport()
        {

            return View();
        }
        

    }
}