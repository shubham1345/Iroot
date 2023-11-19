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
    public class User_VocationPromotionDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult VocationPromotionDoc()
        {
            return View();
        }

        public ActionResult VocationPromotionDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_VocationPromotionDoc = GetVocationPromotionDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_VocationPromotionDoc> GetVocationPromotionDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_VocationPromotionDoc.Where(e => e.VocationPromotionId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_VocationPromotionDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}