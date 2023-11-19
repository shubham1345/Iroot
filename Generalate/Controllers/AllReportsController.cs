using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
//using Rotativa;
using System.Globalization;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class AllReportsController : Controller
    {
        GeneralDBContext db = new GeneralDBContext();

        // GET: AllReports

        public ActionResult ViewAllReport()
        {
            return View(db.tbl_PersonalDetails.Where(x=>x.IsDeleted==false));
        }
        public ActionResult ViewAllReport1()
        {
            return View(db.tbl_PersonalDetails.Where(x => x.IsDeleted == false));
        }
        public ActionResult ViewAllReport2()
        {
            return View(db.tbl_Jubilee);
        }
        public ActionResult ViewAllReport3()
        {
            return View(db.tbl_Jubilee);
        }



        public ActionResult Report()
        {
            return View();
        }
        public JsonResult GetByStatus(string status, int? age)
        {

            try
            {
                if (status == "ALive")
                {
                    // Live
                    var getByStatus = from s in db.tbl_PersonalDetails
                                      where !db.tbl_Passed.Any(es => (es.MemberID == s.MemberID)) && !db.tbl_SeperationFromTheCongregation.Any(es => (es.MemberID == s.MemberID))
                                      select new { s.PersonalDetailsId, s.Name, s.MemberID };

                    return Json(getByStatus, JsonRequestBehavior.AllowGet);
                }

                else if (status == "Passed")
                {
                    //Passed
                    var getByStatus = from s in db.tbl_PersonalDetails
                                      where db.tbl_Passed.Any(es => (es.MemberID == s.MemberID))
                                      select new { s.PersonalDetailsId, s.Name, s.MemberID };

                    return Json(getByStatus, JsonRequestBehavior.AllowGet);
                }

                else if (status == "Seperated")
                {
                    //Seperation
                    var getByStatus = from s in db.tbl_PersonalDetails
                                      where db.tbl_SeperationFromTheCongregation.Any(es => (es.MemberID == s.MemberID))
                                      select new { s.PersonalDetailsId, s.Name, s.MemberID };

                    return Json(getByStatus, JsonRequestBehavior.AllowGet);
                }

                else if (status == "Age")
                {
                    //Age
                    //return Json(db.tbl_PersonalDetails, JsonRequestBehavior.AllowGet);
                    var getByStatus = db.tbl_PersonalDetails.ToList().Where(x => CalculateAge(x.DOB) == age.Value).Select(s => new { s.PersonalDetailsId, s.Name, s.MemberID }).AsQueryable();
                    //var today = DateTime.Today;
                    //var getByStatus = db.tbl_PersonalDetails.Where(x => (Convert.ToDateTime(x.DOB).Month - today.Month >= 0 || Convert.ToDateTime(x.DOB).Day - today.Day >= 0) ?
                    //Convert.ToDateTime(x.DOB).Year - today.Year == age.Value : Convert.ToDateTime(x.DOB).Year - today.Year == age.Value - 1).AsQueryable();
                    return Json(getByStatus, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    //All
                    return Json(db.tbl_PersonalDetails, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public FileResult Download(string filename)
        {
            string path = Server.MapPath(filename);


            //string FileName = Path.GetFileName("CMF.jpg");
            bool fileExists = (System.IO.File.Exists(path) ? true : false);
            //String fullPath = Path.Combine(path, FileName);
            //return File(path, "image/jpg", "CMF.jpg");
            if (fileExists)
            {
                string e = Path.GetExtension(path);
                string filename2 = Path.GetFileName(path);
                return File(path, e, filename2);

            }
            return null;
        }

        private int CalculateAge(string dob)
        {
            DateTime dateOfBirth = DateTime.ParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
        //public JsonResult GetByStatus(string status)
        //{

        //    try
        //    {
        //        if (status == "ALive")
        //        {
        //            // Live
        //            var getByStatus = from s in db.tbl_PersonalDetails
        //                              where !db.tbl_Passed.Any(es => (es.MemberID == s.MemberID)) || !db.tbl_SeperationFromTheCongregation.Any(es => (es.MemberID == s.MemberID))
        //                              select new { s.PersonalDetailsId, s.Name, s.MemberID };

        //            return Json(getByStatus, JsonRequestBehavior.AllowGet);
        //        }

        //        else if (status == "Passed")
        //        {
        //            //Passed
        //            var getByStatus = from s in db.tbl_PersonalDetails
        //                              where db.tbl_Passed.Any(es => (es.MemberID == s.MemberID))
        //                              select new { s.PersonalDetailsId, s.Name, s.MemberID };

        //            return Json(getByStatus, JsonRequestBehavior.AllowGet);
        //        }

        //        else if (status == "Seperated")
        //        {
        //            //Seperation
        //            var getByStatus = from s in db.tbl_PersonalDetails
        //                              where db.tbl_SeperationFromTheCongregation.Any(es => (es.MemberID == s.MemberID))
        //                              select new { s.PersonalDetailsId, s.Name, s.MemberID };

        //            return Json(getByStatus, JsonRequestBehavior.AllowGet);
        //        }

        //        else
        //        {
        //            //All
        //            return Json(db.tbl_PersonalDetails, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        public ActionResult Index(string Id)
        {

            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_PersonalDetails = GetPersonalDetails(Id);
            //TODO Rajesh
            
            mymodel.tbl_EmergencyContact = GetEmergencyContact(Id);
            mymodel.tbl_Entry = GetSacraments(Id);
            mymodel.tbl_EntryLife = Formation(Id);
            mymodel.tbl_SecularEducation = SecularEducation(Id);
            mymodel.tbl_ReligiousEducation = ReligiousEducation(Id);
            mymodel.tbl_Seminar = Seminar(Id);
            mymodel.tbl_KnownLanguages = Languages(Id);
            mymodel.tbl_HomeLiveAndHomeVisit = HomeliveandHomeVisit(Id);
            mymodel.tbl_ServiceInTheCongregation = ServiceInTheCongregation(Id);
            mymodel.tbl_SeperationFromTheCongregation = SeperationFromTheCongregation(Id);
            mymodel.tbl_LivingOutsideTheCongregation = LivingOutsideTheCongregationController(Id);
            mymodel.tbl_TravelRecord = Travel(Id);
            mymodel.tbl_Jubilee = Jubilee(Id);
            mymodel.tbl_Health = Health(Id);
            mymodel.tbl_Complaint = Complaints(Id);
            mymodel.tbl_Retirement = Retirements(Id);
            mymodel.tbl_Passed = Passed(Id);
            return View(mymodel);
        }

        public ActionResult IndexPrint(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_PersonalDetails = GetPersonalDetails(Id);
            //TODO Rajesh
            mymodel.tbl_EmergencyContact = GetEmergencyContact(Id);
            mymodel.tbl_Entry = GetSacraments(Id);
            mymodel.tbl_EntryLife = Formation(Id);
            mymodel.tbl_SecularEducation = SecularEducation(Id);
            mymodel.tbl_ReligiousEducation = ReligiousEducation(Id);
            mymodel.tbl_Seminar = Seminar(Id);
            mymodel.tbl_KnownLanguages = Languages(Id);
            mymodel.tbl_HomeLiveAndHomeVisit = HomeliveandHomeVisit(Id);
            mymodel.tbl_ServiceInTheCongregation = ServiceInTheCongregation(Id);
            mymodel.tbl_SeperationFromTheCongregation = SeperationFromTheCongregation(Id);
            mymodel.tbl_LivingOutsideTheCongregation = LivingOutsideTheCongregationController(Id);
            mymodel.tbl_TravelRecord = Travel(Id);
            mymodel.tbl_Jubilee = Jubilee(Id);
            mymodel.tbl_Health = Health(Id);
            mymodel.tbl_Complaint = Complaints(Id);
            mymodel.tbl_Retirement = Retirements(Id);
            mymodel.tbl_Passed = Passed(Id);
            return View(mymodel);
        }

        //public ActionResult IndexReport()
        //{

        //    return new Rotativa.MVC.ActionAsPdf("IndexPrint");
        //}


        public IEnumerable<tbl_PersonalDetails> GetPersonalDetails(string Id)
        {
            List<tbl_PersonalDetails> PersonalDetails = new List<tbl_PersonalDetails>();
            PersonalDetails.Add(db.tbl_PersonalDetails.FirstOrDefault(e => e.MemberID == Id));
            return PersonalDetails;
        }

        public IEnumerable<tbl_EmergencyContact> GetEmergencyContact(string Id)
        {
            return db.tbl_EmergencyContact.Where(e => e.MemberID == Id);
        }

        public IEnumerable<tbl_Entry> GetSacraments(string Id)
        {
            return db.tbl_Entry.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_EntryLife> Formation(string Id)
        {
            return db.tbl_EntryLife.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_Seminar> Seminar(string Id)
        {
            return db.tbl_Seminar.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_KnownLanguages> Languages(string Id)
        {
            return db.tbl_KnownLanguages.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_SecularEducation> SecularEducation(string Id)
        {
            return db.tbl_SecularEducation.Where(e => e.MemberID == Id);
        }

        public IEnumerable<tbl_ReligiousEducation> ReligiousEducation(string Id)
        {
            return db.tbl_ReligiousEducation.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_HomeLiveAndHomeVisit> HomeliveandHomeVisit(string Id)
        {
            return db.tbl_HomeLiveAndHomeVisit.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_ServiceInTheCongregation> ServiceInTheCongregation(string Id)
        {
            return db.tbl_ServiceInTheCongregation.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_SeperationFromTheCongregation> SeperationFromTheCongregation(string Id)
        {
            return db.tbl_SeperationFromTheCongregation.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_LivingOutsideTheCongregation> LivingOutsideTheCongregationController(string Id)
        {
            return db.tbl_LivingOutsideTheCongregation.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_Health> Health(string Id)
        {
            return db.tbl_Health.Where(e => e.MemberID == Id);
        }

        public IEnumerable<tbl_TravelRecord> Travel(string Id)
        {
            return db.tbl_TravelRecord.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_Complaint> Complaints(string Id)
        {
            return db.tbl_Complaint.Where(e => e.MemberID == Id);
        }

        public IEnumerable<tbl_Retirement> Retirements(string Id)
        {
            return db.tbl_Retirement.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_Passed> Passed(string Id)
        {
            return db.tbl_Passed.Where(e => e.MemberID == Id);
        }
        public IEnumerable<tbl_Jubilee> Jubilee(string Id)
        {
            return db.tbl_Jubilee.Where(e => e.MemberID == Id);
        }
        public ActionResult TravelRecords()
        {
            List<tbl_TravelRecord> TravelRecord = new List<tbl_TravelRecord>();
            try
            {
                TravelRecord.Add(db.tbl_TravelRecord.FirstOrDefault(e => e.MemberID == "CMF001"));
            }
            catch (Exception)
            {

            }
            return View(TravelRecord);
        }




    }
}