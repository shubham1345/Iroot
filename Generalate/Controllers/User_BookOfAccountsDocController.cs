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
    public class User_BookOfAccountsDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult BookOfAccountsDoc()
        {
            return View();
        }

        public ActionResult BookOfAccountsDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_BookOfAccountsDoc = GetBookOfAccountsDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_BookOfAccountsDoc> GetBookOfAccountsDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_BookOfAccountsDoc.Where(e => e.BookOfAccountsId == Id);
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