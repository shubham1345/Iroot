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
    public class User_GeneralateDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult GeneralateDoc()
        {
            return View();
        }

        public ActionResult GeneralateDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_GeneralateDoc = GetGeneralateDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_GeneralateDoc> GetGeneralateDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_GeneralateDoc.Where(e => e.GeneralateId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_GeneralateDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}