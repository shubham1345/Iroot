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
    public class User_LanguagesController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Languages
        public ActionResult Languages()
        {
            return View();
        }
        public ActionResult UserLanguagesView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_KnownLanguages = GetLanguages(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_KnownLanguages> GetLanguages(string Id)
        {
            return dbcont.tbl_KnownLanguages.Where(e => e.MemberID == Id);
          //  return dbcont.tbl_KnownLanguages.Where(e=>e.MemberId=Id);
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_KnownLanguages, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}