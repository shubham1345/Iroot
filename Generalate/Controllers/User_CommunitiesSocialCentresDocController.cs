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
    public class User_CommunitiesSocialCentresDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult CommunitiesSocialCentresDoc()
        {
            return View();
        }

        public ActionResult CommunitiesSocialCentresDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_CommunitiesSocialCentresDoc = GetCommunitiesSocialCentresDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_CommunitiesSocialCentresDoc> GetCommunitiesSocialCentresDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_CommunitiesSocialCentresDoc.Where(e => e.CommunityId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_CommunicationOfficeDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}