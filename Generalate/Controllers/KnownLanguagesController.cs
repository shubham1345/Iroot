using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class KnownLanguagesController : Controller
    {
        // GET: KnownLanguages

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Languages()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult LanguagesPrint()
        {
            return View();
        }

        //public ActionResult LanguagesReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("LanguagesPrint");
        //}


        public JsonResult GetAll()
        {
            try
            {
                //TODO Rajesh
                return Json(dbcont.tbl_KnownLanguages.ToList(), JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_KnownLanguages.FirstOrDefault(e => e.KnownLanguagesId == Id);
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

        public JsonResult Add(tbl_KnownLanguages newobj)
        {
            try
            {
                dbcont.tbl_KnownLanguages.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_KnownLanguages newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_KnownLanguages.FirstOrDefault(e => e.KnownLanguagesId == newobj.KnownLanguagesId);
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
                var genralobj = dbcont.tbl_KnownLanguages.FirstOrDefault(e => e.KnownLanguagesId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_KnownLanguages.Remove(genralobj);
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
                tbl_KnownLanguages gen = new tbl_KnownLanguages();
                gen = dbcont.tbl_KnownLanguages.FirstOrDefault(e => e.KnownLanguagesId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}