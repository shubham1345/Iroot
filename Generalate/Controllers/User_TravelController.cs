using Generalate.Helpers;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class User_TravelController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Travel
        public ActionResult Travel()
        {
            return View();
        }

        public ActionResult TravelView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_TravelRecord = GetTravelRecord(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_TravelRecord> GetTravelRecord(string Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_TravelRecord.Where(e => e.MemberID == Id);
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_TravelRecord, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}