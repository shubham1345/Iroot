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
    public class User_MissionDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult MissionDoc()
        {
            return View();
        }

        public ActionResult MissionDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_MissionDoc = GetMissionDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_MissionDoc> GetMissionDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_MissionDoc.Where(e => e.MissionId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_MissionDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}