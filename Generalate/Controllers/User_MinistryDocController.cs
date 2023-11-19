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
    public class User_MinistryDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult MinistryDoc()
        {
            return View();
        }

        public ActionResult MinistryDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_MinistryDoc = GetMinistryDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_MinistryDoc> GetMinistryDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_MinistryDoc.Where(e => e.MinistryDocId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_MinistryDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}