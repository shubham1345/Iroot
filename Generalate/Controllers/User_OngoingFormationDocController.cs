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
    public class User_OngoingFormationDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult OngoingFormationDoc()
        {
            return View();
        }

        public ActionResult OngoingFormationDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_OngoingFormationDoc = GetOngoingFormationDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_OngoingFormationDoc> GetOngoingFormationDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_OngoingFormationDoc.Where(e => e.OngoingFormationId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_OngoingFormationDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}