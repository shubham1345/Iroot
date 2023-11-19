using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Helpers;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class User_HomeandHomeVisitController : Controller
    {

        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_HomeandHomeVisit
        public ActionResult ServiceintheCongregation()
        {
            return View();
        }
        public ActionResult ServiceintheCongregationView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_HomeLiveAndHomeVisit = GetServiceintheCongregation(Id);
            return View(mymodel);
        }

        public IEnumerable<tbl_HomeLiveAndHomeVisit> GetServiceintheCongregation(string Id)
        {
            return dbcont.tbl_HomeLiveAndHomeVisit.Where(e => e.MemberID == Id);
            // return dbcont.tbl_EntryLife;
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_HomeLiveAndHomeVisit.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            var memid = "";
            var comPath = "";
            var fileName = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["Images"];
                memid = System.Web.HttpContext.Current.Request["Memid"];

                if (pic.ContentLength > 0)
                {
                    var _ext = Path.GetExtension(pic.FileName);
                    fileName = Guid.NewGuid().ToString() + _ext;

                    comPath = Server.MapPath("~/Documents/") + fileName;

                    pic.SaveAs(comPath);
                }
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }

    }
}