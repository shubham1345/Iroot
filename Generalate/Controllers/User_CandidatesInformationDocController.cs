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
    public class User_CandidatesInformationDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult CandidatesInformationDoc()
        {
            return View();
        }

        public ActionResult CandidatesInformationDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_CandidatesInformationDoc = GetCandidatesInformationDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_CandidatesInformationDoc> GetCandidatesInformationDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_CandidatesInformationDoc.Where(e => e.CandidatesInformationId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_CandidatesInformationDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}