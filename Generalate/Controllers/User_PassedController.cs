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
    public class User_PassedController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Passed
        public ActionResult Passed()
        {
            return View();
        }

        public ActionResult PassedView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_Passed = GetPassed(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_Passed> GetPassed(string Id)
        {
            return dbcont.tbl_Passed.Where(e => e.MemberID == Id);
            // return dbcont.tbl_EntryLife;
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Retirement, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}