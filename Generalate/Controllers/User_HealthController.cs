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
    public class User_HealthController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Health
        public ActionResult Health()
        {
            return View();
        }
        public ActionResult HealthView( string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_Health = GetHealth(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_Health> GetHealth(string Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_Health.Where(e => e.MemberID == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Health, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}