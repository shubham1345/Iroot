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
    public class TravelRecordController : Controller
    {
        // GET: TravelRecord

        GeneralDBContext dbcont = new GeneralDBContext();
        public ActionResult TravelRecord()
        {
            return View(dbcont.tbl_TravelRecord);
        }

        public ActionResult TravelPrint()
        {
            return View(dbcont.tbl_TravelRecord);
        }

        //public ActionResult TravelReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("TravelPrint");
        //}

        public ActionResult AddTravelRecord()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
                  SelectList list = new SelectList(getids, "Name", "SirName");
                  ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTravelRecord(tbl_TravelRecord newobj)
        {
            try
            {

                dbcont.tbl_TravelRecord.Add(newobj);
                dbcont.SaveChanges();
                return RedirectToAction("TravelRecord");
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(newobj);
        }



        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_TravelRecord.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int Id)
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
             
            try
            {
                var gid = dbcont.tbl_TravelRecord.FirstOrDefault(e => e.TravelId == Id);
                return View(gid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult Add(tbl_TravelRecord newobj)
        {
            newobj.TravelId = null;
            try
            {
                if (ModelState.IsValid)
                {
                    dbcont.tbl_TravelRecord.Add(newobj);
                    dbcont.SaveChanges();
                    return Json("Success");
                }
                else
                {
                    return Json("Failed");
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_TravelRecord newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_TravelRecord.FirstOrDefault(e => e.TravelId == newobj.TravelId);
                dbcont.Entry(existingobj).CurrentValues.SetValues(newobj);
                dbcont.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("TravelRecord");
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                var genralobj = dbcont.tbl_TravelRecord.FirstOrDefault(e => e.TravelId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_TravelRecord.Remove(genralobj);
                    dbcont.SaveChanges();
                }
                else
                {
                }
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("TravelRecord");
        }

        public ActionResult ViewProfile(int id)
        {
            try
            {
                tbl_TravelRecord gen = new tbl_TravelRecord();
                gen = dbcont.tbl_TravelRecord.FirstOrDefault(e => e.TravelId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //    public ActionResult TravelRecord()
        //    {
        //        return View(dbcont.tbl_TravelRecord);
        //    }

        //    public ActionResult TravelPrint()
        //    {
        //        return View(dbcont.tbl_TravelRecord);
        //    }

        //    public ActionResult TravelReport()
        //    {
        //        return new Rotativa.ActionAsPdf("TravelPrint");
        //    }

        //    public ActionResult AddTravelRecord()
        //    {
        //        var getids = dbcont.tbl_PersonalDetails.ToList();
        //        SelectList list = new SelectList(getids, "Name", "MemberID");
        //        ViewBag.tbl_PersonalDetails = list;
        //        return View();
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult AddTravelRecord(tbl_TravelRecord newobj)
        //    {
        //        try
        //        {

        //                dbcont.tbl_TravelRecord.Add(newobj);
        //                dbcont.SaveChanges();
        //                return RedirectToAction("TravelRecord");
        //        }
        //        catch (RetryLimitExceededException /* dex */)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //        }
        //        return View(newobj);
        //    }



        //    public JsonResult GetAll()
        //    {
        //        try
        //        {
        //            return Json(dbcont.tbl_TravelRecord, JsonRequestBehavior.AllowGet);
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }

        //    public ActionResult Edit(int Id)
        //    {
        //        try
        //        {
        //            var gid = dbcont.tbl_TravelRecord.FirstOrDefault(e => e.TravelId == Id);
        //            return View(gid);
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }

        //    public JsonResult Add(tbl_TravelRecord newobj)
        //    {
        //        try
        //        {
        //            dbcont.tbl_TravelRecord.Add(newobj);
        //            dbcont.SaveChanges();
        //            return Json("Success");
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            return Json("Failed");
        //        }
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit(tbl_TravelRecord newobj)
        //    {
        //        try
        //        {
        //            var existingobj = dbcont.tbl_TravelRecord.FirstOrDefault(e => e.TravelId == newobj.TravelId);
        //            dbcont.Entry(existingobj).CurrentValues.SetValues(newobj);
        //            dbcont.SaveChanges();
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }

        //        return RedirectToAction("TravelRecord");
        //    }

        //    public ActionResult Delete(int Id)
        //    {
        //        try
        //        {
        //            var genralobj = dbcont.tbl_TravelRecord.FirstOrDefault(e => e.TravelId == Id);
        //            if (genralobj != null)
        //            {
        //                dbcont.tbl_TravelRecord.Remove(genralobj);
        //                dbcont.SaveChanges();
        //            }
        //            else
        //            {
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }

        //        return RedirectToAction("TravelRecord");
        //    }

        //    public ActionResult ViewProfile(int id)
        //    {
        //        try
        //        {
        //            tbl_TravelRecord gen = new tbl_TravelRecord();
        //            gen = dbcont.tbl_TravelRecord.FirstOrDefault(e => e.TravelId == id);
        //            return View(gen);
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //}
    }
}