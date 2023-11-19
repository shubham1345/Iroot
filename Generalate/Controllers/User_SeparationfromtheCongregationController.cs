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
    public class User_SeparationfromtheCongregationController : Controller
    {

        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_SeparationfromtheCongregation
        public ActionResult SeparationfromtheCongregation()
        {
            return View();
        }
        public ActionResult SeparationfromtheCongregationView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_SeperationFromTheCongregation = GetSeperationFromTheCongregation(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_SeperationFromTheCongregation> GetSeperationFromTheCongregation(string Id)
        {
            return dbcont.tbl_SeperationFromTheCongregation.Where(e => e.MemberID == Id);
            // return dbcont.tbl_EntryLife;
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_SeperationFromTheCongregation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}