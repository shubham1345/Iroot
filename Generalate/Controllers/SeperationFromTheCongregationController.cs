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
    public class SeperationFromTheCongregationController : Controller
    {
        // GET: SeperationFromTheCongregation

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Seperation()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult SeperationPrint()
        {
            return View();
        }

        //public ActionResult SeperationReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("SeperationPrint");
        //}

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_SeperationFromTheCongregation.ToList(), JsonRequestBehavior.AllowGet);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                throw;
            }
        }

        public JsonResult GetById(int Id)
        {
            try
            {
                var gid = dbcont.tbl_SeperationFromTheCongregation.FirstOrDefault(e => e.SeperationId == Id);
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

        public JsonResult Add(tbl_SeperationFromTheCongregation newobj)
        {
            try
            {
                dbcont.tbl_SeperationFromTheCongregation.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_SeperationFromTheCongregation newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_SeperationFromTheCongregation.FirstOrDefault(e => e.SeperationId == newobj.SeperationId);
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
                var genralobj = dbcont.tbl_SeperationFromTheCongregation.FirstOrDefault(e => e.SeperationId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_SeperationFromTheCongregation.Remove(genralobj);
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
                tbl_SeperationFromTheCongregation gen = new tbl_SeperationFromTheCongregation();
                gen = dbcont.tbl_SeperationFromTheCongregation.FirstOrDefault(e => e.SeperationId == id);
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
                    fileName = Guid.NewGuid().ToString() + _ext;

                    comPath = Server.MapPath("~/Images/SeperationFromTheCongregation/") + fileName;

                    pic.SaveAs(comPath);
                }
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }
    }
}