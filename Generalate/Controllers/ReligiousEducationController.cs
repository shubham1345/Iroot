using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Web.Helpers;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class ReligiousEducationController : Controller
    {
        // GET: ReligiousEducation

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Religious()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult ReligiousPrint()
        {
            return View();
        }

        //public ActionResult ReligiousReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("ReligiousPrint");
        //}


        public JsonResult GetAll()
        {
            try
            {
                //TODO Rajesh
                return Json(dbcont.tbl_ReligiousEducation.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetById(int Id)
        {
            try
            {
                var gid = dbcont.tbl_ReligiousEducation.FirstOrDefault(e => e.ReligiousId == Id);
                if (gid != null)
                {
                    return Json(gid, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult Add(tbl_ReligiousEducation newobj)
        {
            try
            {

                dbcont.tbl_ReligiousEducation.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_ReligiousEducation newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_ReligiousEducation.FirstOrDefault(e => e.ReligiousId == newobj.ReligiousId);
                dbcont.Entry(existingobj).CurrentValues.SetValues(newobj);
                dbcont.SaveChanges();
                return Json("Sucess");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult Delete(int Id)
        {
            try
            {
                var genralobj = dbcont.tbl_ReligiousEducation.FirstOrDefault(e => e.ReligiousId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_ReligiousEducation.Remove(genralobj);
                    dbcont.SaveChanges();
                    return Json("Success");
                }
                else
                {
                    return Json("Record Not Found");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult ViewProfile(int id)
        {
            try
            {
                tbl_ReligiousEducation gen = new tbl_ReligiousEducation();
                gen = dbcont.tbl_ReligiousEducation.FirstOrDefault(e => e.ReligiousId == id);
                return View(gen);
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
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                memid = System.Web.HttpContext.Current.Request["Memid"];

                if (pic.ContentLength > 0)
                {
                    var _ext = Path.GetExtension(pic.FileName);
                    //fileName = Guid.NewGuid().ToString() + _ext;
                    fileName = pic.FileName + _ext;

                    comPath = Server.MapPath("~/Images/ReligiousCertificate/") + fileName;

                    pic.SaveAs(comPath);
                }
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }
    
}
}