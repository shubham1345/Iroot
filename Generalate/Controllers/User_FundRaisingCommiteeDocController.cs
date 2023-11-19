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
    public class User_FundRaisingCommiteeDoc : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult FundRaisingCommiteeDoc()
        {
            return View();
        }

        public ActionResult FundRaisingCommiteeDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_FundRaisingCommiteeDoc = GetFundRaisingCommiteeDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_FundRaisingCommiteeDoc> GetFundRaisingCommiteeDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_FundRaisingCommiteeDoc.Where(e => e.FundRaisingId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_FundRaisingCommiteeDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}