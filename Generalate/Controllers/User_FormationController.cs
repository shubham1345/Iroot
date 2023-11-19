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
    public class User_FormationController : Controller
    {

        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Formation
        public ActionResult UserFormation()
        {
            return View();
        }
        public ActionResult UserFormationView(String Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_EntryLife = GetFormation(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_EntryLife> GetFormation(string Id)
        {
            return dbcont.tbl_EntryLife.Where(e => e.MemberID == Id);
            // return dbcont.tbl_EntryLife;
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_EntryLife, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}