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
    public class RetirementController : Controller
    {
        // GET: Retirement

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Retirement()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult RetirementPrint()
        {
            return View();
        }

        //public ActionResult RetirementReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("RetirementPrint");
        //}


        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Retirement.ToList(), JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_Retirement.FirstOrDefault(e => e.RetirementId == Id);
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

        public JsonResult Add(tbl_Retirement newobj)
        {
            try
            {
                dbcont.tbl_Retirement.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_Retirement newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_Retirement.FirstOrDefault(e => e.RetirementId == newobj.RetirementId);
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
                var genralobj = dbcont.tbl_Retirement.FirstOrDefault(e => e.RetirementId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Retirement.Remove(genralobj);
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
                tbl_Retirement gen = new tbl_Retirement();
                gen = dbcont.tbl_Retirement.FirstOrDefault(e => e.RetirementId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}