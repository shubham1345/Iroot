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
    public class User_SpiritualCommunityDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult SpiritualCommunityDoc()
        {
            return View();
        }

        public ActionResult SpiritualCommunityDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_SpiritualCommunityDoc = GetSpiritualCommunityDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_SpiritualCommunityDoc> GetSpiritualCommunityDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_SpiritualCommunityDoc.Where(e => e.SpiritualCommunityId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_SpiritualCommunityDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}