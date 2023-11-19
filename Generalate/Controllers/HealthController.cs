using Generalate.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class HealthController : Controller
    {
        // GET: Health
        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Health()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult HealthPrint()
        {
            return View();
        }

        //public ActionResult HealthReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("HealthPrint");
        //}

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Health.ToList(), JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_Health.FirstOrDefault(e => e.HealthId == Id);
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

        public JsonResult Add(tbl_Health newobj)
        {
            try
            {
                dbcont.tbl_Health.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_Health newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_Health.FirstOrDefault(e => e.HealthId == newobj.HealthId);
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
                var genralobj = dbcont.tbl_Health.FirstOrDefault(e => e.HealthId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Health.Remove(genralobj);
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
                tbl_Health gen = new tbl_Health();
                gen = dbcont.tbl_Health.FirstOrDefault(e => e.HealthId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}