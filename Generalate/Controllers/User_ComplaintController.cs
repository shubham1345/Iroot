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
    public class User_ComplaintController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult Complaint()
        {
            return View();
        }

        public ActionResult ComplaintView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_Complaint = GetComplaint(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_Complaint> GetComplaint(string Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_Complaint.Where(e => e.MemberID == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Complaint, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}