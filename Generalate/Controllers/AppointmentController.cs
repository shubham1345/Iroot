using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class AppointmentController : Controller
    {
        private GeneralDBContext dbcont = new GeneralDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Appointment()
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentloginuser = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                var allAppointment = dbcont.AppointmentData.ToList();
                ViewBag.allAppointment = allAppointment;
            }
            else
            {
                var allAppointment = dbcont.AppointmentData.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allAppointment = allAppointment;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allRenewal = dbcont.DataListItems2.ToList();
                ViewBag.allRenewal = allRenewal;
            }
            else
            {
                var allRenewal = dbcont.DataListItems2.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allRenewal = allRenewal;
            } 
                return View();
        }

        public ActionResult AppointmentDetails(string id, string type)
        {
            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;

            AppointmentData data = dbcont.AppointmentData.FirstOrDefault(x => x.Id.ToString() == id);
            ViewBag.allData = dbcont.AppointmentData.Where(x => x.Id == data.Id).ToList();
            return View(data);
        }

        public ActionResult RenewalDetails(string id, string type)
        {
            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;

            DataListItems2 data = dbcont.DataListItems2.FirstOrDefault(x => x.Id.ToString() == id);
            ViewBag.allData = dbcont.DataListItems2.Where(x => x.Id == data.Id).ToList();
            return View(data);
        }
    }
}