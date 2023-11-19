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
    public class ServiceInTheCongregationController : Controller
    {
        // GET: ServiceInTheCongregation

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult ServicePrint()
        {
            return View();
        }

        //public ActionResult ServiceReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("ServicePrint");
        //}

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_ServiceInTheCongregation, JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_ServiceInTheCongregation.FirstOrDefault(e => e.ServiceId == Id);
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

        public JsonResult Add(tbl_ServiceInTheCongregation newobj)
        {
            try
            {
                dbcont.tbl_ServiceInTheCongregation.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_ServiceInTheCongregation newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_ServiceInTheCongregation.FirstOrDefault(e => e.ServiceId == newobj.ServiceId);
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
                var genralobj = dbcont.tbl_ServiceInTheCongregation.FirstOrDefault(e => e.ServiceId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_ServiceInTheCongregation.Remove(genralobj);
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
                tbl_ServiceInTheCongregation gen = new tbl_ServiceInTheCongregation();
                gen = dbcont.tbl_ServiceInTheCongregation.FirstOrDefault(e => e.ServiceId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}