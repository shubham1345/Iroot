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
    public class User_FinancialReportDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult FinancialReportDoc()
        {
            return View();
        }

        public ActionResult FinancialReportDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_FinancialReportDoc = GetFinancialReportDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_FinancialReportDoc> GetFinancialReportDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_FinancialReportDoc.Where(e => e.FinancialReportId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_FinancialReportDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}