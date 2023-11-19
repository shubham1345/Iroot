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
    public class JubileeController : Controller
    {
        // GET: Jubilee

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Jubilee()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult JubileePrint()
        {
            return View();
        }

        //public ActionResult JubileeReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("JubileePrint");
        //}


        public JsonResult GetAll()
        {
            try
            {
                //TODO Rajesh
                return Json(dbcont.tbl_Jubilee.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public JsonResult GetAll()
        //{
        //    try
        //    {
        //        //TODO Rajesh
        //        return Json(dbcont.tbl_Jubilee.Where(x => x.IsDeleted == false).ToList(), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public JsonResult GetPersonalDetailsByMemberId(string SirName)
        //{
        //    try
        //    {
        //        //var data = dbcont.tbl_PersonalDetails.FirstOrDefault(x=>x.MemberID== memberId);
        //        var data = dbcont.tbl_Jubilee.FirstOrDefault(x => x.SirName == SirName && x.IsDeleted == false);

        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public JsonResult GetById(int Id)
        {
            try
            {
                var gid = dbcont.tbl_Jubilee.FirstOrDefault(e => e.JubileeID == Id);
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

        public JsonResult Add(tbl_Jubilee newobj)
        {
            try
            {
                dbcont.tbl_Jubilee.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_Jubilee newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_Jubilee.FirstOrDefault(e => e.JubileeID == newobj.JubileeID);
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
                var genralobj = dbcont.tbl_Jubilee.FirstOrDefault(e => e.JubileeID == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Jubilee.Remove(genralobj);
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
                tbl_Jubilee gen = new tbl_Jubilee();
                gen = dbcont.tbl_Jubilee.FirstOrDefault(e => e.JubileeID == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}