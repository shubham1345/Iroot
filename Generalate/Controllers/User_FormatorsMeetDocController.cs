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
    public class User_FormatorsMeetDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult FormatorsMeetDoc()
        {
            return View();
        }

        public ActionResult FormatorsMeetDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_FormatorsMeetDoc = GetFormatorsMeetDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_FormatorsMeetDoc> GetFormatorsMeetDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_FormatorsMeetDoc.Where(e => e.FormatorsMeetId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_FormatorsMeetDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}