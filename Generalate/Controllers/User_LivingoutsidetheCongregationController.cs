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
    public class User_LivingoutsidetheCongregationController : Controller
    {
        GeneralDBContext db = new GeneralDBContext();
        // GET: User_LivingoutsidetheCongregation
        public ActionResult LivingoutsidetheCongregation()
        {
            return View();
        }
        public ActionResult LivingoutsidetheCongregationView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_LivingOutsideTheCongregation = GetLivingoutsidetheCongregation(Id);
           
            return View(mymodel);
        }

        public IEnumerable<tbl_LivingOutsideTheCongregation> GetLivingoutsidetheCongregation(string Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return db.tbl_LivingOutsideTheCongregation.Where(e => e.MemberID == Id);
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(db.tbl_LivingOutsideTheCongregation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}