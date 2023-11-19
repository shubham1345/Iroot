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
    public class User_FinancialGuidelineDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult FinancialGuidelineDoc()
        {
            return View();
        }

        public ActionResult FinancialGuidelineDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_FinancialGuidelineDoc = GetFinancialGuidelineDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_FinancialGuidelineDoc> GetFinancialGuidelineDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_FinancialGuidelineDoc.Where(e => e.FinancialDocId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_FinancialGuidelineDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}