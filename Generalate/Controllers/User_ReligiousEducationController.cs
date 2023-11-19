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
    public class User_ReligiousEducationController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_ReligiousEducation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReligiousEducationView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_ReligiousEducation = GetReligiousEducation(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_ReligiousEducation> GetReligiousEducation(string Id)
        {

           // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_ReligiousEducation.Where(e => e.MemberID == Id);
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_ReligiousEducation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}