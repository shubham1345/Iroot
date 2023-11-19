using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Web.Helpers;
using System.Text.RegularExpressions;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class PersonalDetailsController : Controller
    {
       
        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult PersonalDetail()
        {
            return View();
        }

        public ActionResult PersonalDetailPrint()
        {
            return View();
        }

        //public ActionResult PersonalDetailReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("PersonalDetailPrint");
        //}

        public JsonResult GetAll()
        {
            try
            {
               
                return Json(dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //TODO Rajesh
        public JsonResult GetPersonalDetailsByMemberId(string SirName)
        {
            try
            {
                //var data = dbcont.tbl_PersonalDetails.FirstOrDefault(x=>x.MemberID== memberId);
                var data = dbcont.tbl_PersonalDetails.FirstOrDefault(x=>x.SirName== SirName && x.IsDeleted==false);

                return Json(data, JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_PersonalDetails.FirstOrDefault(e => e.PersonalDetailsId == Id && e.IsDeleted==false);
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

        public JsonResult Add(tbl_PersonalDetails general)
        {
            try
            {
                general.IsDeleted = false;
                dbcont.tbl_PersonalDetails.Add(general);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_PersonalDetails persnldtls)
        {
            try
            {
                var existingobj = dbcont.tbl_PersonalDetails.FirstOrDefault(e => (e.PersonalDetailsId == persnldtls.PersonalDetailsId &&e.IsDeleted==false));
                dbcont.Entry(existingobj).CurrentValues.SetValues(persnldtls);
                //existingobj.Name = persnldtls.Name;
                //existingobj.NameBaptismial = persnldtls.NameBaptismial;
                //existingobj.EmailID = persnldtls.EmailID;
                //existingobj.OtherNameName = persnldtls.OtherNameName;
                ////existingobj.Image = persnldtls.Image;
                //existingobj.MotherTongue = persnldtls.MotherTongue;
                //existingobj.Mobile = persnldtls.Mobile;
                //existingobj.BloodGroup = persnldtls.BloodGroup;
                //existingobj.DOB = persnldtls.DOB;
                //existingobj.VillageTown = persnldtls.VillageTown;
                //existingobj.District = persnldtls.District;
                //existingobj.State = persnldtls.State;
                //existingobj.Country = persnldtls.Country;
                //existingobj.Pincode = persnldtls.Pincode;
                //existingobj.AadharNo = persnldtls.AadharNo;
                //existingobj.NameasinAadharCard = persnldtls.NameasinAadharCard;
                //existingobj.FatherName = persnldtls.FatherName;
                //existingobj.FMobile = persnldtls.FMobile;
                //existingobj.MotherName = persnldtls.MotherName;
                //existingobj.MMobile = persnldtls.MMobile;
                //existingobj.NoOfBrother = persnldtls.NoOfBrother;
                //existingobj.NoOfSister = persnldtls.NoOfSister;
                //existingobj.PlaceintheFamily = persnldtls.PlaceintheFamily;

                dbcont.SaveChanges();
                return Json("Sucess");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Delete(int Id)
        {
            try
            {
                var genralobj = dbcont.tbl_PersonalDetails.FirstOrDefault(e => e.PersonalDetailsId == Id);
                if (genralobj != null)
                {
                    genralobj.IsDeleted = true;
                    dbcont.Entry(genralobj).CurrentValues.SetValues(genralobj);
                    //dbcont.tbl_PersonalDetails.Remove(genralobj);
                    dbcont.SaveChanges();
                    return Json("Success");
                }
                else
                {
                    return Json("Record Not Found");
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }
        }

        public ActionResult ViewProfile(int id)
        {
            try
            {
                tbl_PersonalDetails gen = new tbl_PersonalDetails();
                gen = dbcont.tbl_PersonalDetails.FirstOrDefault(e => e.PersonalDetailsId == id && e.IsDeleted==false);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public JsonResult GetProvincial()
        //{
        //    var query = (from c in dbcont.tbl_Provincial
        //                 orderby c.PId ascending
        //                 select new {Name = c.PId + "-" + c.Name}).Distinct();

        //    return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetAutoGeneratedMemberId()
        {
            var query = (from c in dbcont.tbl_PersonalDetails
                         select new {c.PersonalDetailsId }).Count()+100 + 1;
            string id = string.Format("{0:000}", query);
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            var memid = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                memid = System.Web.HttpContext.Current.Request["Memid"];

                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    //_imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~/Images/PertionalDetails/") + memid + _ext;
                    memid = memid + _ext;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                   MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                      img.Resize(200, 200);
                    img.Save(_comPath);
                    // end resize
                }
            }
            return Json(memid, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult WillUploadFiles()
        {
            var memid = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                memid = System.Web.HttpContext.Current.Request["Memid"];

                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    //_imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~/Images/Will/") + memid + _ext;
                    memid = memid + _ext;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                   // MemoryStream ms = new MemoryStream();
                  //  WebImage img = new WebImage(_comPath);

                    //if (img.Width > 200)
                    //    img.Resize(200, 200);
                  //  img.Save(_comPath);
                    // end resize
                }
            }
            return Json(memid, JsonRequestBehavior.AllowGet);
        }


        public FileResult Download()
        {
            string path = Server.MapPath("~/Images/Will/");
            string FileName = Path.GetFileName("CMF.jpg");

            String fullPath = Path.Combine(path, FileName);
            return File(fullPath,"image/jpg" , "CMF.jpg");
        }

       // [AcceptVerbs(HttpVerbs.Post)]
       [AllowAnonymous]
       [HttpPost]
        public JsonResult UploadFiles(FileUploadViewModel fileUploadViewModel)
        {
            var memid = "";
            var comPath = "";
            var fileName = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                memid = System.Web.HttpContext.Current.Request["Memid"];

                if (pic.ContentLength > 0)
                {
                    var _ext = Path.GetExtension(pic.FileName);
                    fileName = Guid.NewGuid().ToString() + _ext;

                    comPath = Server.MapPath("~/Images/Will/") + memid + _ext;

                    pic.SaveAs(comPath);
                }
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPertionBySirName(string SirName)
        {
            var data = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.SirName == SirName && x.IsDeleted==false);

            var getPertionalDetailsBySirName = dbcont.tbl_PersonalDetails.FirstOrDefault(x=>x.SirName.ToLower()==SirName.ToLower() &&x.IsDeleted==false);

            if (getPertionalDetailsBySirName != null)
            {
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Not", JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult GetAllTodayBirthday()
        {
            string Date = "";
            var todayDate = DateTime.Now.Day;
            if (todayDate < 10)
            {
                Date = "0" + todayDate.ToString();
            }
            else
            {
                Date = todayDate.ToString();

            }
            try
            {
                var allRecord = dbcont.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.DOB !=null).ToList();
                if (allRecord.Count>0)
                {
                    var allRecordBirthday = allRecord.Where(x => Regex.Split(x.DOB, @"\D+")[0] == Date)
                                                          .Select(x => new { x.Name, x.SirName, x.DOB })
                                                          .ToList();
                    return Json(allRecordBirthday, JsonRequestBehavior.AllowGet);

                }
                return Json(null, JsonRequestBehavior.AllowGet);


            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return null;
            }
        }
        public JsonResult CountOfAllPersion()
        {
            try
            {
                return Json(dbcont.tbl_PersonalDetails.Where(x => x.IsDeleted == false).Count(), JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
                throw;
            }
        }
        public JsonResult FilterPerson(FilterPersions filterPersions)
        {
            try
            {
                var allRecords = dbcont.tbl_PersonalDetails.Where(x => x.IsDeleted == false).ToList();
                if (allRecords.Count>0)
                {
                    if (!string.IsNullOrEmpty(filterPersions.Name))
                    {
                        allRecords = allRecords.Where(x => x.Name.ToLower().Contains(filterPersions.Name.ToLower())).ToList();

                    }
                    if (!string.IsNullOrEmpty(filterPersions.Mobile))
                    {
                        allRecords = allRecords.Where(x => x.Mobile.Contains(filterPersions.Mobile)).ToList();

                    }
                    if (!string.IsNullOrEmpty(filterPersions.Email))
                    {
                        allRecords = allRecords.Where(x => x.EmailID.ToLower().Contains(filterPersions.Email.ToLower())).ToList();

                    }
                    return Json(allRecords, JsonRequestBehavior.AllowGet);

                }
                return Json(null, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
                throw;
            }
        }
    }
}