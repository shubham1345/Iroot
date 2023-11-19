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
    public class SeminarController : Controller
    {
        // GET: Seminar

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Seminar()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult SeminarPrint()
        {
            return View();
        }

        //public ActionResult SeminarReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("SeminarPrint");
        //}

        public JsonResult GetAll()
        {
            try
            {
                //TODO Rajesh
                return Json(dbcont.tbl_Seminar.ToList(), JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_Seminar.FirstOrDefault(e => e.SeminarId == Id);
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

        public JsonResult Add(tbl_Seminar newobj)
        {
            try
            {
                dbcont.tbl_Seminar.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_Seminar newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_Seminar.FirstOrDefault(e => e.SeminarId == newobj.SeminarId);
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
                var genralobj = dbcont.tbl_Seminar.FirstOrDefault(e => e.SeminarId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Seminar.Remove(genralobj);
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
                tbl_Seminar gen = new tbl_Seminar();
                gen = dbcont.tbl_Seminar.FirstOrDefault(e => e.SeminarId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}