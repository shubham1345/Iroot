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
    public class User_StCamillusProvincialateDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult StCamillusProvincialateDoc()
        {
            return View();
        }

        public ActionResult StCamillusProvincialateDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_StCamillusProvincialateDoc = GetStCamillusProvincialateDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_StCamillusProvincialateDoc> GetStCamillusProvincialateDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_StCamillusProvincialateDoc.Where(e => e.StCamillusProvincialateId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_StCamillusProvincialateDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}