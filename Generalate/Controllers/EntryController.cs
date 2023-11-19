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
    public class EntryController : Controller
    {
        // GET: Entry

        GeneralDBContext dbcont = new GeneralDBContext();
        public ActionResult Entry()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult EntryPrint()
        {
            return View();
        }

        //public ActionResult EntryReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("EntryPrint");
        //}

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Entry, JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_Entry.FirstOrDefault(e => e.EntryId == Id);
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

        public JsonResult Add(tbl_Entry general)
        {
            try
            {
                dbcont.tbl_Entry.Add(general);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_Entry entry)
        {
            try
            {
                var existingobj = dbcont.tbl_Entry.FirstOrDefault(e => e.EntryId == entry.EntryId);
                dbcont.Entry(existingobj).CurrentValues.SetValues(entry);
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
                var genralobj = dbcont.tbl_Entry.FirstOrDefault(e => e.EntryId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Entry.Remove(genralobj);
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
                tbl_Entry gen = new tbl_Entry();
                gen = dbcont.tbl_Entry.FirstOrDefault(e => e.EntryId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
       //public ActionResult Entry()
       // {
       //     return View();
       // }

       // public ActionResult EntryPrint()
       // {
       //     return View();
       // }

       // public ActionResult EntryReport()
       // {
       //     return new Rotativa.ActionAsPdf("EntryPrint");
       // }

       // public JsonResult GetAll()
       // {
       //     try
       //     {
       //         return Json(dbcont.tbl_Entry, JsonRequestBehavior.AllowGet);
       //     }
       //     catch (Exception)
       //     {
       //         throw;
       //     }
       // }

       // public JsonResult GetById(int Id)
       // {
       //     try
       //     {
       //         var gid = dbcont.tbl_Entry.FirstOrDefault(e => e.EntryId == Id);
       //         if (gid != null)
       //         {
       //             return Json(gid, JsonRequestBehavior.AllowGet);
       //         }
       //         else
       //         {
       //             return Json(null, JsonRequestBehavior.AllowGet);
       //         }
       //     }
       //     catch (Exception)
       //     {

       //         throw;
       //     }
       // }

       // public JsonResult Add(tbl_Entry general)
       // {
       //     try
       //     {
       //         dbcont.tbl_Entry.Add(general);
       //         dbcont.SaveChanges();
       //         return Json("Success");
       //     }
       //     catch (Exception ex)
       //     {
       //         Console.WriteLine(ex.Message);
       //         return Json("Failed");
       //     }
       // }

       // public JsonResult Update(tbl_Entry entry)
       // {
       //     try
       //     {
       //         var existingobj = dbcont.tbl_Entry.FirstOrDefault(e => e.EntryId == entry.EntryId);
       //         dbcont.Entry(existingobj).CurrentValues.SetValues(entry);
       //         dbcont.SaveChanges();
       //         return Json("Sucess");
       //     }
       //     catch (Exception)
       //     {

       //         throw;
       //     }
       // }

       // public JsonResult Delete(int Id)
       // {
       //     try
       //     {
       //         var genralobj = dbcont.tbl_Entry.FirstOrDefault(e => e.EntryId == Id);
       //         if (genralobj != null)
       //         {
       //             dbcont.tbl_Entry.Remove(genralobj);
       //             dbcont.SaveChanges();
       //             return Json("Success");
       //         }
       //         else
       //         {
       //             return Json("Record Not Found");
       //         }
       //     }
       //     catch (Exception)
       //     {

       //         throw;
       //     }
       // }

       // public ActionResult ViewProfile(int id)
       // {
       //     try
       //     {
       //         tbl_Entry gen = new tbl_Entry();
       //         gen = dbcont.tbl_Entry.FirstOrDefault(e => e.EntryId == id);
       //         return View(gen);
       //     }
       //     catch (Exception)
       //     {

       //         throw;
       //     }
       // }
    }
}