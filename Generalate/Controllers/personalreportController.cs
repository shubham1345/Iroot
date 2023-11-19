using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class personalreportController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: Member
        //public ActionResult AddMember()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddMember(AddMember addMember)
        //{
        //    tbl_PersonalDetails tbl_PersonalDetails = new tbl_PersonalDetails();
        //    tbl_PersonalDetails.MemberID = addMember.MemberId;
        //    tbl_PersonalDetails.Name = addMember.Name;
        //    tbl_PersonalDetails.SirName = addMember.SirName;
        //    dbcont.tbl_PersonalDetails.Add(tbl_PersonalDetails);
        //    dbcont.SaveChanges();
        //    return RedirectToAction("MemberInfoById", addMember);
        //}

        //public ActionResult MemberInfoById(AddMember addMember)
        //{
        //    var pertionalDetailbyMemberId = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID.ToLower() == addMember.MemberId.ToLower());
        //    if (pertionalDetailbyMemberId != null)
        //    {
        //        addMember.Name = pertionalDetailbyMemberId.Name;
        //        addMember.SirName = pertionalDetailbyMemberId.SirName;
        //    }
        //    return View(addMember);
        //}

        public ActionResult personalreport()
        {
            var allDesignation = dbcont.DataListItems.ToList();
            ViewBag.allDesignation = allDesignation;
            return View();
        }
        //public ActionResult PrintMemberReport()
        //{

        //    return View();
        //}

        public JsonResult GetAllPersions()
        {
            var allRecords = dbcont.tbl_Primarydetails
                               .Select(x => new { x.Knowname, x.MemberId })
                               .ToList();
            return Json(allRecords, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllDesignationandInstitution()
        {
            var allRecords = dbcont.DataListItems
                               .Select(x => new { x.Designation, x.Institution, x.Id })
                               .ToList();
            return Json(allRecords, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// id = persion id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetPersionById(string id)
        {
            var personalDetails = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPrimaryById(string id)
        {
            var personalDetails = dbcont.tbl_Primarydetails.FirstOrDefault(x => x.MemberId == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllFamilyById(string id)
        {
            var personalDetails = dbcont.FamilyDetails.Where(x => x.MemberId == id).ToList();
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAppoinmentByDesignation(string name)
        {
            var personalDetails = dbcont.Appointments.Where(x => x.DesignationType.ToLower().Contains(name.ToLower())).ToList();
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllInstitutionByInstitution(string name)
        {
            var personalDetails = dbcont.Appointments.Where(x => x.InstitutionType.ToLower().Contains(name.ToLower())).ToList();
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetMembersInfo(string radioButton, string fromdate, string todate, string age)
        {
            var membersDetail = dbcont.tbl_PersonalDetails.ToList();
            return Json(membersDetail, JsonRequestBehavior.AllowGet);
        }

        //Maam Code
        public object MemberID { get; private set; }

        // GET: Member
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(AddMember addMember)
        {
            //var memeberDetails = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID == addMember.MemberId);
            //if (memeberDetails == null)
            //{
            //    tbl_PersonalDetails tbl_PersonalDetails = new tbl_PersonalDetails();
            //    tbl_PersonalDetails.MemberID = addMember.MemberId;
            //    tbl_PersonalDetails.Name = addMember.Name;
            //    tbl_PersonalDetails.SirName = addMember.SirName;
            //    dbcont.tbl_PersonalDetails.Add(tbl_PersonalDetails);
            //    dbcont.SaveChanges();
            //}
            //else
            //{
            //    memeberDetails.MemberID = addMember.MemberId;
            //    memeberDetails.Name = addMember.Name;
            //    memeberDetails.SirName = addMember.SirName;

            //    dbcont.SaveChanges();
            //}

            //return RedirectToAction("MemberInfoById", addMember.MemberId);
            var url = Request.UrlReferrer.AbsoluteUri;

            tbl_PersonalDetails tbl_PersonalDetails = new tbl_PersonalDetails();
            tbl_PersonalDetails.MemberID = addMember.MemberId;
            tbl_PersonalDetails.Name = addMember.Name;
            tbl_PersonalDetails.SirName = addMember.SirName;
            dbcont.tbl_PersonalDetails.Add(tbl_PersonalDetails);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Member Added Successfully!');location.replace('" + url + "')</script>");

        }

        public ActionResult MemberInfoById(string memberId)
        {
            //MemberInformationViewModel memberInformationViewModel = new MemberInformationViewModel();
            var pertionalInfo = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID.ToString() == memberId);
            var pertionalPrimaryInfo = dbcont.tbl_Primarydetails.FirstOrDefault(x => x.MemberId.ToString() == memberId);
            var FamilyDetails = dbcont.FamilyDetails.Where(x => x.MemberId == pertionalInfo.MemberID).ToList();
            var tbl_Health = dbcont.tbl_Health.Where(x => x.MemberID == pertionalInfo.MemberID).ToList();
            //memberInformationViewModel.tbl_Primarydetails = pertionalPrimaryInfo;
            ViewBag.tbl_Primarydetails = pertionalPrimaryInfo;
            ViewBag.FamilyDetails = FamilyDetails;
            ViewBag.tbl_Health = tbl_Health;

            if (pertionalInfo != null)
            {
                ViewBag.memberId = pertionalInfo.MemberID;
                ViewBag.name = pertionalInfo.Name;
                ViewBag.sirname = pertionalInfo.SirName;
            }
            //Work for the REport
            MemberReportViewModel memberReportViewModel = new MemberReportViewModel();
            memberReportViewModel.PersonalDetial = pertionalInfo;
            //End
            var allhealths = dbcont.tbl_Health.Where(x => x.MemberID == memberId).ToList();
            ViewBag.allhealths = allhealths;
            var allpassed = dbcont.tbl_Passed.Where(x => x.MemberID == memberId).ToList();
            ViewBag.allpassed = allpassed;
            var allSummary = GetAllSummaryData(pertionalInfo.MemberID);
            ViewBag.allSummary = allSummary;

            var scrament = dbcont.Sacraments.Where(x => x.MemberId == memberId).ToList();
            ViewBag.scrament = scrament;

            return View(memberReportViewModel);

        }
        public JsonResult GetAll()
        {
            try
            {
                var result = dbcont.tbl_unknow.ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                throw;
            }
        }

        public JsonResult Add12(tbl_unknow newobj)
        {
            try
            {
                dbcont.tbl_unknow.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }
        public JsonResult Addf(tbl_PersonalDetails newobj)
        {
            try
            {
                dbcont.tbl_PersonalDetails.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }
        public JsonResult Delete(int Id)
        {
            try
            {
                var genralobj = dbcont.tbl_unknow.FirstOrDefault(e => e.memid == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_unknow.Remove(genralobj);
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

                return Json("Record Not Found");
            }
        }
        public JsonResult Update(tbl_unknow fomdetail)
        {
            try
            {
                var existingobj = dbcont.tbl_unknow.FirstOrDefault(e => e.memid == fomdetail.memid);
                dbcont.Entry(existingobj).CurrentValues.SetValues(fomdetail);
                existingobj.Knowname = fomdetail.Knowname;
                existingobj.Baptismialname = fomdetail.Baptismialname;


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
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
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

                    comPath = Server.MapPath("~/Images/Adhar/") + fileName;

                    pic.SaveAs(comPath);
                }
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile1()
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

                    comPath = Server.MapPath("~/Images/Pan/") + fileName;

                    pic.SaveAs(comPath);
                }
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetFormationById(int id)
        {
            try
            {
                var genFormation = dbcont.tbl_unknow.FirstOrDefault(e => e.memid == id);
                if (genFormation != null)
                {
                    return Json(genFormation, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Fail", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        //public JsonResult GetById(int Id)
        //{
        //    try
        //    {
        //        var gid = dbcont.tbl_unknow.FirstOrDefault(e => e.memid == Id);
        //        if (gid != null)
        //        {
        //            return Json(gid, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(null, JsonRequestBehavior.AllowGet);
        //        }


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public JsonResult GetAllPrimaryByAge(int age)
        {
            var currentyear = System.DateTime.Now.Year;
            List<tbl_Primarydetails> alldata = new List<tbl_Primarydetails>();
            var allPrimaryMan = dbcont.tbl_Primarydetails.Where(x => x.DOB != null);
            foreach (var item in allPrimaryMan)
            {
                var perYear = item.DOB.Substring(item.DOB.Length - 4);
                int yearDiff = currentyear - Convert.ToInt32(perYear);
                if (yearDiff == age)
                {
                    alldata.Add(item);
                }
            }
            return Json(alldata, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BasedOnSeniority()
        {
            var currentyear = System.DateTime.Now.Year;
            List<BasedOnSeniorityViewModel> alldata = new List<BasedOnSeniorityViewModel>();
            var allPrimaryMan = dbcont.tbl_Primarydetails
                              .Where(x => x.Ordination != null)
                              .ToList();
            foreach (var item in allPrimaryMan)
            {
                var perYear = item.Ordination.Substring(item.Ordination.Length - 4);
                int yearDiff = currentyear - Convert.ToInt32(perYear);
                alldata.Add(new BasedOnSeniorityViewModel
                {
                    Baptismialname = item.Baptismialname,
                    DOB = item.DOB,
                    emailid = item.emailid,
                    Knowname = item.Knowname,
                    Ordination = item.Ordination,
                    Year = yearDiff
                });
            }
            return Json(alldata.OrderByDescending(X => X.Year).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeathAnnivers()
        {
            var data = dbcont.tbl_Passed
                              .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Birthday()
        {
            var data = dbcont.tbl_Primarydetails
                              .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Feastday()
        {
            var data = dbcont.tbl_Primarydetails
                              .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Chronologicalorder()
        {
            var data = dbcont.tbl_Primarydetails
                                .OrderBy(x => x.Knowname)
                                .ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Basedonbatch(int year)
        {
            var currentyear = System.DateTime.Now.Year;
            List<BasedOnSeniorityViewModel> alldata = new List<BasedOnSeniorityViewModel>();
            var allPrimaryMan = dbcont.tbl_Primarydetails
                              .Where(x => x.Ordination != null)
                              .ToList();
            foreach (var item in allPrimaryMan)
            {
                var perYear = item.Ordination.Substring(item.Ordination.Length - 4);
                //int yearDiff = currentyear - Convert.ToInt32(perYear);
                alldata.Add(new BasedOnSeniorityViewModel
                {
                    Baptismialname = item.Baptismialname,
                    DOB = item.DOB,
                    emailid = item.emailid,
                    Knowname = item.Knowname,
                    Ordination = item.Ordination,
                    Year = Convert.ToInt32(perYear)
                });
            }
            return Json(alldata.Where(x => x.Year == year).ToList(), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// primary details
        /// </summary>
        /// <param name="tbl_Primarydetails"></param>
        /// <param name="PanDoc"></param>
        /// <param name="AdharDoc"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPrimaryDetails(tbl_Primarydetails tbl_Primarydetails, HttpPostedFileBase PanDoc, HttpPostedFileBase AdharDoc)
        {
            var memeberDetails = dbcont.tbl_Primarydetails.FirstOrDefault(x => x.MemberId == tbl_Primarydetails.MemberId);
            if (memeberDetails == null)
            {
                if (PanDoc != null)
                {
                    if (PanDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(PanDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Primarydetails"), fileName);
                        PanDoc.SaveAs(path);
                        tbl_Primarydetails.File1 = fileName;   //pan document file1 for the name
                    }
                }

                if (AdharDoc != null)
                {
                    if (AdharDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(AdharDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Primarydetails"), fileName);
                        AdharDoc.SaveAs(path);
                        tbl_Primarydetails.File2 = fileName;  //AdharDoc document file2 for the name
                    }
                }

                tbl_Primarydetails Primarydetails = new tbl_Primarydetails();
                Primarydetails.MemberId = tbl_Primarydetails.MemberId;
                dbcont.tbl_Primarydetails.Add(tbl_Primarydetails);
                dbcont.SaveChanges();
            }
            //else
            //{
            //    memeberDetails.MemberId = tbl_Primarydetails.MemberId;

            //    dbcont.SaveChanges();
            //}
            return RedirectToAction("MemberInfoById", new { memberId = tbl_Primarydetails.MemberId, name = "", sirname = "" });

        }
        public JsonResult GetPrimaryDetailById(int id)
        {
            try
            {
                var data = dbcont.tbl_Primarydetails.FirstOrDefault(e => e.Primaryid == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Fail", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult UpdatePrimary(tbl_Primarydetails tbl_Primarydetails, HttpPostedFileBase PanDoc, HttpPostedFileBase AdharDoc)
        {
            try
            {
                var existingobj = dbcont.tbl_Primarydetails.FirstOrDefault(e => e.Primaryid == tbl_Primarydetails.Primaryid);
                if (PanDoc != null)
                {
                    if (PanDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(PanDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Primarydetails"), fileName);
                        PanDoc.SaveAs(path);
                        tbl_Primarydetails.File1 = fileName;   //pan document file1 for the name
                    }
                }
                else
                {
                    tbl_Primarydetails.File1 = tbl_Primarydetails.File1;   //pan document file1 for the name
                }

                if (AdharDoc != null)
                {
                    if (AdharDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(AdharDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Primarydetails"), fileName);
                        AdharDoc.SaveAs(path);
                        tbl_Primarydetails.File2 = fileName;  //AdharDoc document file2 for the name
                    }
                }
                else
                {
                    tbl_Primarydetails.File2 = tbl_Primarydetails.File2;   //pan document file1 for the name

                }
                dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Primarydetails);
                dbcont.SaveChanges();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
            var url = Request.UrlReferrer.AbsoluteUri;
            return Redirect(url);
        }


        /// <summary>
        /// Family  details
        /// </summary>
        /// <param name="general"></param>
        /// <returns></returns>
        public ActionResult AddFamily(FamilyDetails family)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                dbcont.FamilyDetails.Add(family);
                dbcont.SaveChanges();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Some error occure!');location.replace('" + url + "')</script>");
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Record Save Successfully!');location.replace('" + url + "')</script>");
        }

        public ActionResult FamilyUpdate(FamilyDetails family)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            FamilyDetails data = dbcont.FamilyDetails.FirstOrDefault(x => x.Id == family.Id);
            if (data != null)
            {
                dbcont.Entry(data).CurrentValues.SetValues(family);
                dbcont.SaveChanges();
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Family update Successfully!');location.replace('" + url + "')</script>");

        }

        public ActionResult FamilyDelete(int id)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                var genralobj = dbcont.FamilyDetails.FirstOrDefault(e => e.Id == id);
                if (genralobj != null)
                {
                    dbcont.FamilyDetails.Remove(genralobj);
                    dbcont.SaveChanges();
                    return Content("<script language='javascript' type='text/javascript'>alert('Record Delete Successfully');location.replace('" + url + "')</script>");

                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Record Not Found');location.replace('" + url + "')</script>");

                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Some Error Occure');location.replace('" + url + "')</script>");


            }
        }
        public JsonResult GetFamilyById(int Id)
        {
            try
            {
                var gid = dbcont.FamilyDetails.FirstOrDefault(e => e.Id == Id);
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
        public JsonResult Update(tbl_PersonalDetails persnldtls)
        {
            try
            {
                var existingobj = dbcont.tbl_PersonalDetails.FirstOrDefault(e => (e.PersonalDetailsId == persnldtls.PersonalDetailsId && e.IsDeleted == false));
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
        public JsonResult DeletePertionalData(int Id)
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


        //For the Report data
        public JsonResult GetAllFormationById(string id)
        {
            var allFOrmation = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == id).ToList();
            return Json(allFOrmation, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAcademyById(string id)
        {
            var allAcademy = dbcont.tbl_Academy.Where(x => x.MemberId == id).ToList();
            return Json(allAcademy, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAppinmentById(string id)
        {
            var Appointments = dbcont.Appointments.Where(x => x.MemberId == id).ToList();
            return Json(Appointments, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllTravelById(string id)
        {
            var tbl_TravelRecord = dbcont.tbl_TravelRecord.Where(x => x.MemberID == id).ToList();
            return Json(tbl_TravelRecord, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllHealthById(string id)
        {
            var healths = dbcont.tbl_Health.Where(x => x.MemberID == id).ToList();
            return Json(healths, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllPassedById(string id)
        {
            var passed = dbcont.tbl_Passed.Where(x => x.MemberID == id).ToList();
            return Json(passed, JsonRequestBehavior.AllowGet);
        }


        //Health
        public ActionResult CreateHealth(tbl_Health tbl_Health, HttpPostedFileBase file)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Health"), fileName);
                    file.SaveAs(path);
                    tbl_Health.Spare3 = fileName;   //pan document file1 for the name
                }
            }
            dbcont.tbl_Health.Add(tbl_Health);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Health Added Successfully!');location.replace('" + url + "')</script>");
        }
        public JsonResult GetHealthById1(int id)
        {
            var tbl_Health = dbcont.tbl_Health.FirstOrDefault(x => x.HealthId == id);
            return Json(tbl_Health, JsonRequestBehavior.AllowGet);
        }


        public ActionResult HealthUpdate(tbl_Health tbl_Health)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            var data = dbcont.tbl_Health.FirstOrDefault(x => x.HealthId == tbl_Health.HealthId);
            if (data != null)
            {
                dbcont.Entry(data).CurrentValues.SetValues(tbl_Health);
                dbcont.SaveChanges();
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Health Updated Successfully!');location.replace('" + url + "')</script>");
        }


        //tbl_Passed
        public ActionResult CreatePassed(tbl_Passed tbl_Passed, HttpPostedFileBase file)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Passed"), fileName);
                    file.SaveAs(path);
                    tbl_Passed.Spare3 = fileName;   //pan document file1 for the name
                }
            }
            dbcont.tbl_Passed.Add(tbl_Passed);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Health Added Successfully!');location.replace('" + url + "')</script>");
        }
        public ActionResult UpdatePassed(tbl_Passed Passed)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            var data = dbcont.tbl_Passed.FirstOrDefault(x => x.PassedId == Passed.PassedId);
            if (data != null)
            {
                dbcont.Entry(data).CurrentValues.SetValues(Passed);
                dbcont.SaveChanges();
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Passed Update Successfully!');location.replace('" + url + "')</script>");

        }
        public JsonResult GetPassedById(int Id)
        {
            try
            {
                var gid = dbcont.tbl_Passed.FirstOrDefault(e => e.PassedId == Id);
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
        //Get All Summary Data
        public List<DetailsSummaryViewModel> GetAllSummaryData(string memberId)
        {
            List<DetailsSummaryViewModel> data = new List<DetailsSummaryViewModel>();

            var primaryDetails = dbcont.tbl_Primarydetails.FirstOrDefault(x => x.MemberId.ToString() == memberId);
            if (primaryDetails != null)
            {
                data.Add(new DetailsSummaryViewModel
                {
                    Title = primaryDetails.Knowname,
                    Date = primaryDetails.DOB,
                    Description = primaryDetails.noofsisters
                });
            }

            var familyData = dbcont.FamilyDetails.Where(x => x.MemberId == memberId).ToList();
            if (familyData != null)
            {
                foreach (var item in familyData)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Name,
                        Date = item.YearOfBirth,
                        Description = item.Address
                    });
                }
            }

            var allhealths = dbcont.tbl_Health.Where(x => x.MemberID == memberId).ToList();
            if (allhealths != null)
            {
                foreach (var item in allhealths)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Title,
                        Date = item.FromDate,
                        Description = item.Description
                    });
                }
            }

            var allpassed = dbcont.tbl_Passed.Where(x => x.MemberID == memberId).ToList();
            if (allpassed != null)
            {
                foreach (var item in allpassed)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Title,
                        Date = item.Date,
                        Description = item.Description
                    });
                }
            }

            var allScraments = dbcont.Sacraments.Where(x => x.MemberId == memberId).ToList();
            if (allScraments != null)
            {
                foreach (var item in allScraments)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Title,
                        Date = item.Date,
                        Description = item.Remarks
                    });
                }
            }

            return data;
        }

        public ActionResult AddScrament(Sacraments sacraments)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            dbcont.Sacraments.Add(sacraments);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Sacrament Added Successfully!');location.replace('" + url + "')</script>");
        }
        public JsonResult GetScrament(int id)
        {
            var scrament = dbcont.Sacraments.FirstOrDefault(x => x.Id == id);
            return Json(scrament, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateScrament(Sacraments sacraments)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            var data = dbcont.Sacraments.FirstOrDefault(x => x.Id == sacraments.Id);
            if (data != null)
            {
                dbcont.Entry(data).CurrentValues.SetValues(sacraments);
                dbcont.SaveChanges();
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Sacrament Update Successfully!');location.replace('" + url + "')</script>");

        }

        public ActionResult DeleteScrament(int id)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            var data = dbcont.Sacraments.FirstOrDefault(x => x.Id == id);
            dbcont.Sacraments.Remove(data);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Sacrament Delete Successfully!');location.replace('" + url + "')</script>");

        }

        public ActionResult HealthDelete(int id)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            var data = dbcont.tbl_Health.FirstOrDefault(x => x.HealthId == id);
            dbcont.tbl_Health.Remove(data);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Health Delete Successfully!');location.replace('" + url + "')</script>");

        }
        public ActionResult DeathDelete(int id)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            var data = dbcont.tbl_Passed.FirstOrDefault(x => x.PassedId == id);
            dbcont.tbl_Passed.Remove(data);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Health Delete Successfully!');location.replace('" + url + "')</script>");

        }


    }
}