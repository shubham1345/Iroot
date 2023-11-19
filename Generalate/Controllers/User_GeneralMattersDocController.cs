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
    public class User_GeneralMattersDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult GeneralMattersDoc()
        {
            return View();
        }

        public ActionResult GeneralMattersDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_GeneralMattersDoc = GetGeneralMattersDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_GeneralMattersDoc> GetGeneralMattersDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_GeneralMattersDoc.Where(e => e.GeneralMattersId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_GeneralMattersDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}