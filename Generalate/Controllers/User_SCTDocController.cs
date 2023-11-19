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
    public class User_SCTDocontroller : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult SCTDoc()
        {
            return View();
        }

        public ActionResult SCTDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_SCTDoc = GetSCTDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_SCTDoc> GetSCTDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_SCTDoc.Where(e => e.SctDocId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_SCTDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}