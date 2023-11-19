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
    public class User_VocationalTrainingDocController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Complaint
        public ActionResult VocationalTrainingDoc()
        {
            return View();
        }

        public ActionResult VocationalTrainingDocView(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_VocationalTrainingDoc = GetVocationalTrainingDoc(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_VocationalTrainingDoc> GetVocationalTrainingDoc(int Id)
        {

            // return dbcont.tbl_ReligiousEducation(e=>e.MemberId=Id);
            return dbcont.tbl_VocationalTrainingDoc.Where(e => e.VocationalTrainingId == Id);
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_VocationalTrainingDoc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}