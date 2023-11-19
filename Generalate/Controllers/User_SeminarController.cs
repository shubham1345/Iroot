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
    public class User_SeminarController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Seminar
        public ActionResult Seminar()
        {
            return View();
        }
        public ActionResult UserSeminarView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_Seminar = GetSeminar(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_Seminar> GetSeminar(string Id)
        {
            return dbcont.tbl_Seminar.Where(e => e.MemberID == Id);
        
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Seminar, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}