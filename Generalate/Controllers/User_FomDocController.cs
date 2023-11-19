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
    public class User_FomDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult FomDoc()
        {
            return View();
        }

        public ActionResult FomDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_FomDoc = GetFomDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_FomDoc> GetFomDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_FomDoc.Where(e => e.FormationDocId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_FomDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}