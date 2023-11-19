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
    public class User_SocialInstitutionDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult SocialInstitutionDoc()
        {
            return View();
        }

        public ActionResult SocialInstitutionDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_SocialInstitutionDoc = GetSocialInstitutionDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_SocialInstitutionDoc> GetSocialInstitutionDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_SocialInstitutionDoc.Where(e => e.SocialInstitutionId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_SocialInstitutionDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}