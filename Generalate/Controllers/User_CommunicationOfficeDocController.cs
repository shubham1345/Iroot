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
    public class User_CommunicationOfficeDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult CommunicationOfficeDoc()
        {
            return View();
        }

        public ActionResult CommunicationOfficeDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_CommunicationOfficeDoc = GetCommunicationOfficeDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_CommunicationOfficeDoc> GetCommunicationOfficeDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_CommunicationOfficeDoc.Where(e => e.CommunicationOfficeId == Id);
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