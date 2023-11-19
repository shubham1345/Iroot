using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class User_SacramentController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Sacrament
       
        public ActionResult ViewSacrament()
        {
            return View();
        }

        public ActionResult User_ViewSacrament(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_Entry = GetSacraments(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_Entry> GetSacraments(string Id)
        {

            return dbcont.tbl_Entry.Where(e => e.MemberID == Id);
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Entry, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}