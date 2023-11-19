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
    public class LivingOutsideTheCongregationController : Controller
    {
        // GET: LivingOutsideTheCongregation

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult LivingOutside()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult LivingOutsidePrint()
        {
            return View();
        }

        //public ActionResult LivingOutsideReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("LivingOutsidePrint");
        //}

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_LivingOutsideTheCongregation.ToList(), JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_LivingOutsideTheCongregation.FirstOrDefault(e => e.LivingOutsideId == Id);
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

        public JsonResult Add(tbl_LivingOutsideTheCongregation newobj)
        {
            try
            {
                dbcont.tbl_LivingOutsideTheCongregation.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_LivingOutsideTheCongregation newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_LivingOutsideTheCongregation.FirstOrDefault(e => e.LivingOutsideId == newobj.LivingOutsideId);
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
                var genralobj = dbcont.tbl_LivingOutsideTheCongregation.FirstOrDefault(e => e.LivingOutsideId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_LivingOutsideTheCongregation.Remove(genralobj);
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
                tbl_LivingOutsideTheCongregation gen = new tbl_LivingOutsideTheCongregation();
                gen = dbcont.tbl_LivingOutsideTheCongregation.FirstOrDefault(e => e.LivingOutsideId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}