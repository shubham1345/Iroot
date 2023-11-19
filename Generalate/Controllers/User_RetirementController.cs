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
    public class User_RetirementController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Retirement
        public ActionResult Retirement()
        {

            return View();
        }
        public ActionResult RetirementView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_Retirement = GetRetirement(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_Retirement> GetRetirement(string Id)
        {
            return dbcont.tbl_Retirement.Where(e => e.MemberID == Id);
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