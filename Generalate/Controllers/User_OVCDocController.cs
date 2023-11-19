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
    public class User_OVCDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult OVCDoc()
        {
            return View();
        }

        public ActionResult OVCDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_OVCDoc = GetOVCDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_OVCDoc> GetOVCDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_OVCDoc.Where(e => e.OvcDocId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_OVCDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}