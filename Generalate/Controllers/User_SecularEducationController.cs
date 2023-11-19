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
    public class User_SecularEducationController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();

        // GET: User_SecularEducation
        public ActionResult SecularEducation()
        {
            return View();
        }

        public ActionResult SecularEducationView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_SecularEducation = GetSecularEducation(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_SecularEducation> GetSecularEducation(string Id)
        {
            return dbcont.tbl_SecularEducation.Where(e => e.MemberID == Id);
          //  return dbcont.tbl_SecularEducation;
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_SecularEducation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}