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
    public class EmergencyContactController : Controller
    {
        // GET: EmergencyContact

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Contact()
        {
           
          // ViewBag.tbl_PersonalDetails = new SelectList(dbcont.tbl_PersonalDetails, "Name", "MemberID");
           var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
           SelectList list = new SelectList(getids, "Name", "SirName");
           ViewBag.tbl_PersonalDetails = list;
            return View();
           
        }

        public ActionResult ContactPrint()
        {
            return View();
        }

        //public ActionResult ContactReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("ContactPrint");
        //}

        public JsonResult GetAll()
        {
            try
            {
                var contactResult = dbcont.tbl_EmergencyContact.ToList();
                return Json(contactResult, JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_EmergencyContact.FirstOrDefault(e => e.EmergencyContactId == Id);
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

        public JsonResult Add(tbl_EmergencyContact general)
        {
            try
            {
                dbcont.tbl_EmergencyContact.Add(general);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_EmergencyContact emrgncycont)
        {
            try
            {
                var existingobj = dbcont.tbl_EmergencyContact.FirstOrDefault(e => e.EmergencyContactId == emrgncycont.EmergencyContactId);
                dbcont.Entry(existingobj).CurrentValues.SetValues(emrgncycont);
                dbcont.SaveChanges();
                return Json("Sucess");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }
        }

        public JsonResult Delete(int Id)
        {
            try
            {
                var genralobj = dbcont.tbl_EmergencyContact.FirstOrDefault(e => e.EmergencyContactId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_EmergencyContact.Remove(genralobj);
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
                tbl_EmergencyContact gen = new tbl_EmergencyContact();
                gen = dbcont.tbl_EmergencyContact.FirstOrDefault(e => e.EmergencyContactId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}