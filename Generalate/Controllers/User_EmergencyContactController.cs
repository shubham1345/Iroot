using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
//using Rotativa;
using System.Globalization;
using System.Dynamic;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class User_EmergencyContactController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_EmergencyContact
        
        
        public ActionResult Homeuser()
        {
            return View();
        }
        public ActionResult EmergencyContact()
        {

            return View();
        }
       
        public ActionResult User_PersonalDetail()
        {

            return View();
        }
        public ActionResult User_PersonalDetails(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_PersonalDetails = GetPersonalDetails(Id);
            return View(mymodel);
        }

        public ActionResult EmergencyContactView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
                mymodel.tbl_EmergencyContact = GetEmergencyContact(Id);
          
            return View(mymodel);
        }
        public JsonResult GetAll()
        {

            try
            {
                var month = DateTime.Now.ToString("MM");
                var year = DateTime.Now.ToString("yyyy");

                var getJubilee = dbcont.tbl_Jubilee.Where(c => c.FirstProfession.StartsWith(month) && c.FirstProfession.EndsWith(year));

                return Json(getJubilee, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult UserEmergencyContact()
        {
            return View();
        }
        public JsonResult GetAllEC()
        {
            try
            {
                return Json(dbcont.tbl_EmergencyContact, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public JsonResult GetByStatus()
        {

            try
            {
                                                              //All
                    return Json(dbcont.tbl_PersonalDetails, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception)
            {
                throw;
            }

        }
       
        public IEnumerable<tbl_PersonalDetails> GetPersonalDetails(string Id)
        {
            List<tbl_PersonalDetails> PersonalDetails = new List<tbl_PersonalDetails>();
            PersonalDetails.Add(dbcont.tbl_PersonalDetails.FirstOrDefault(e => e.MemberID == Id));
            return PersonalDetails;
            
           // return dbcont.tbl_PersonalDetails;
        }
        public IEnumerable<tbl_EmergencyContact> GetEmergencyContact(string Id)
        {
            return dbcont.tbl_EmergencyContact.Where(e => e.MemberID == Id);
            //return dbcont.tbl_EmergencyContact;
        }
    }
}