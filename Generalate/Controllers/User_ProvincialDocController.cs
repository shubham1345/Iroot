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
    public class User_ProvincialDoc : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult ProvincialDoc()
        {
            return View();
        }

        public ActionResult ProvincialDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_ProvincialDoc = GetProvincialDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_ProvincialDoc> GetProvincialDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_ProvincialDoc.Where(e => e.ProvincialId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_ProvincialDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}