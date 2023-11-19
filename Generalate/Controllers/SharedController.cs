using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    public class SharedController : Controller
    {
        private GeneralDBContext db = new GeneralDBContext();
        private GeneralDBContext dbcont = new GeneralDBContext();
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }   

        public ActionResult _Layout()
        {
            var data = dbcont.tbl_Congregation.FirstOrDefault();
            ViewBag.id = data.Id;
            ViewBag.CongId = data.CongreId;
            ViewBag.Congregation = data.CongregationName;
            ViewBag.Topmenu = dbcont.Tbl_Topmenuheader.ToList();
            ViewBag.Topmenupermission = dbcont.Tbl_TopMenuPermission.ToList();
            return View();
        }

    }
}