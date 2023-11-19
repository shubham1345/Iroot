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
    public class SocInsCommPageController : Controller
    {
        private GeneralDBContext dbcont = new GeneralDBContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SocInsCommPage()
        {
            List<SocnsCommPageVewModel> socnsCommPageVewModels = new List<SocnsCommPageVewModel>();
            //System.Data.Entity.DbSet<Societys> allSocietysData = dbcont.Societys;
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allSocietysData = dbcont.Societys.ToList();
                foreach (Societys item in allSocietysData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.NameOfTheSocity,
                        Type = "s"
                    });
                }
            }

            else
            {
                var allSocietysData = dbcont.Societys.Where(x => x.ProvinceName == currentUser).ToList();
                foreach (Societys item in allSocietysData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.NameOfTheSocity,
                        Type = "s"
                    });
                }
            }
           
            if (Session["username"].ToString() == "admin")
            {
                var allTbl_ParisData = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Paris" && x.ActiveCkeck == "Active").ToList();
                foreach (Tbl_ParisInstitutionDetails item in allTbl_ParisData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.Name,
                        Type = "P"
                    });
                }
            }
            else
            {
                var allTbl_ParisData = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Paris" && x.ActiveCkeck == "Active" && x.ProvinceName == currentUser).ToList();
                foreach (Tbl_ParisInstitutionDetails item in allTbl_ParisData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.Name,
                        Type = "P"
                    });
                }
            }

            if (Session["username"].ToString() == "admin")
            {
                var allTbl_InstitutionData = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Institution" && x.ActiveCkeck == "Active").ToList();
                foreach (Tbl_ParisInstitutionDetails item in allTbl_InstitutionData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.Name,
                        Type = "i"
                    });
                }
            }
            else
            {
                var allTbl_InstitutionData = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Institution" && x.ActiveCkeck == "Active" && x.ProvinceName == currentUser).ToList();
                foreach (Tbl_ParisInstitutionDetails item in allTbl_InstitutionData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.Name,
                        Type = "i"
                    });
                }
            }

            if (Session["username"].ToString() == "admin")
            {
                var allTbl_CongData = dbcont.Tbl_Cong.Where(x=> x.ActiveCkeck == "Active").ToList();
                foreach (Tbl_Cong item in allTbl_CongData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.CongregationName,
                        Type = "c"
                    });
                }
            }
            else
            {
                var allTbl_CongData = dbcont.Tbl_Cong.Where(x => x.ProvinceName == currentUser && x.ActiveCkeck == "Active").ToList();
                foreach (Tbl_Cong item in allTbl_CongData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.CongregationName,
                        Type = "c"
                    });
                }
            }

            if (Session["username"].ToString() == "admin")
            {
                var allTbl_ProvData = dbcont.tbl_Province.Where(x=> x.ActiveCkeck == "Active").ToList();
                foreach (tbl_Province item in allTbl_ProvData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.ProvinceName,
                        Type = "Pr"
                    });
                }
            }
            else
            {
                var allTbl_ProvData = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == currentUser).ToList();
                foreach (tbl_Province item in allTbl_ProvData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.ProvinceName,
                        Type = "Pr"
                    });
                }
            }
            if (Session["username"].ToString() == "admin")
            {
                var allTbl_CongreData = dbcont.tbl_Congregation.ToList();
                foreach (tbl_Congregation item in allTbl_CongreData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.CongregationName,
                        Type = "Cn"
                    });
                }
            }
            else
            {
                var allTbl_CongreData = dbcont.tbl_Congregation.Where(x => x.ProvinceName == currentUser).ToList();
                foreach (tbl_Congregation item in allTbl_CongreData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.CongregationName,
                        Type = "Cn"
                    });
                }
            }
            if (Session["username"].ToString() == "admin")
            {
                var allTbl_COSData = dbcont.ComOutSide.Where(x=> x.ActiveCkeck == "Active").ToList();
                foreach (ComOutSide item in allTbl_COSData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.CommunityName,
                        Type = "COS"
                    });
                }
            }
            else
            {
                var allTbl_COSData = dbcont.ComOutSide.Where(x => x.ProvinceName == currentUser && x.ActiveCkeck == "Active").ToList();
                foreach (ComOutSide item in allTbl_COSData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.CommunityName,
                        Type = "COS"
                    });
                }
            }
            if (Session["username"].ToString() == "admin")
            {
                var allTbl_CHData = dbcont.ComHouse.Where(x=> x.ActiveCkeck == "Active").ToList();
                foreach (ComHouse item in allTbl_CHData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.CommunityName,
                        Type = "CH"
                    });
                }
            }
            else
            {
                var allTbl_CHData = dbcont.ComHouse.Where(x => x.ProvinceName == currentUser && x.ActiveCkeck == "Active").ToList();
                foreach (ComHouse item in allTbl_CHData)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.CommunityName,
                        Type = "CH"
                    });
                }
            }
            if (Session["username"].ToString() == "admin")
            { 
                var datatble = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active").ToList();
                foreach (tbl_DistSector item in datatble)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.DistSecName,
                        types = item.DisSec,
                        Type = "DCR"
                    });
                }
            }
            else
            {
                var datatble = dbcont.tbl_DistSector.Where(x => x.ProvinceName == currentUser && x.ActiveCkeck == "Active").ToList();
                foreach (tbl_DistSector item in datatble)
                {
                    socnsCommPageVewModels.Add(new SocnsCommPageVewModel
                    {
                        id = Convert.ToString(item.Id),
                        Name = item.DistSecName,
                        types = item.DisSec,
                        Type = "DCR"
                    });
                }
            }

            return View(socnsCommPageVewModels);
        }
      
        public ActionResult PrintSocInsCommReport()
        {
            return View();
        }
        public JsonResult GetAllPersions()
        {
            List<Societys> allRecords = dbcont.Societys

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
        public JsonResult GetAllInsViewData1()
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentloginid = Convert.ToString(Session["loginuserid"]);

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("id");

            var allInstDate = dbcont.Appointments.Where(x => x.InstitutionType == param1);
            var allInstDate1 = dbcont.Appointments.Where(x => x.InstitutionType == param1 && x.ProvinceName == currentUser);

            List<getAllappoint> alldata = new List<getAllappoint>();
            if (Session["username"].ToString() == "admin")
            {
                foreach (var item in allInstDate)
                {
                    alldata.Add(new getAllappoint
                    {
                        Name = item.Name,
                        Designation = item.DesignationType,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var item in allInstDate1)
                {
                    alldata.Add(new getAllappoint
                    {
                        Name = item.Name,
                        Designation = item.DesignationType,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllCommViewData1()
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentloginid = Convert.ToString(Session["loginuserid"]);

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("id");

            var ComNames = dbcont.Tbl_Cong.FirstOrDefault(x => x.Id.ToString() == param1);

            var allInstDate = dbcont.Appointments.Where(x => x.CommunityType == ComNames.CongregationName);
            var allInstDate1 = dbcont.Appointments.Where(x => x.CommunityType == ComNames.CongregationName && x.ProvinceName == currentUser);

            List<getAllappoint> alldata = new List<getAllappoint>();
            if (Session["username"].ToString() == "admin")
            {
                foreach (var item in allInstDate)
                {
                    alldata.Add(new getAllappoint
                    {
                        Name = item.Name,
                        Designation = item.DesignationType,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var item in allInstDate1)
                {
                    alldata.Add(new getAllappoint
                    {
                        Name = item.Name,
                        Designation = item.DesignationType,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
        public class getAllappoint
        {
            public string Name { get; set; }
            public string Designation { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
        }
        public JsonResult GetAllInsViewData123(string fromdate, string todate)
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentloginid = Convert.ToString(Session["loginuserid"]);

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("id");

            var allInstDate = dbcont.Appointments.Where(x=> x.InstitutionType == param1 && x.FromDate == fromdate && x.ToDate == todate);
            var allInstDate1 = dbcont.Appointments.Where(x => x.InstitutionType == param1 && x.FromDate == fromdate && x.ToDate == todate && x.ProvinceName == currentUser);

            List<getAllappoint> alldata = new List<getAllappoint>();
            if (Session["username"].ToString() == "admin")
            {
                foreach (var item in allInstDate)
                {
                    alldata.Add(new getAllappoint
                    {
                        Name = item.Name,
                        Designation = item.DesignationType,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var item in allInstDate1)
                {
                    alldata.Add(new getAllappoint
                    {
                        Name = item.Name,
                        Designation = item.DesignationType,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllCommViewData123(string fromdate, string todate)
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentloginid = Convert.ToString(Session["loginuserid"]);

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("id");

            var ComNames = dbcont.Tbl_Cong.FirstOrDefault(x => x.Id.ToString() == param1);

            var allInstDate = dbcont.Appointments.Where(x => x.CommunityType == ComNames.CongregationName && x.FromDate == fromdate && x.ToDate == todate);
            var allInstDate1 = dbcont.Appointments.Where(x => x.CommunityType == ComNames.CongregationName && x.ProvinceName == currentUser && x.FromDate == fromdate && x.ToDate == todate);

            List<getAllappoint> alldata = new List<getAllappoint>();
            if (Session["username"].ToString() == "admin")
            {
                foreach (var item in allInstDate)
                {
                    alldata.Add(new getAllappoint
                    {
                        Name = item.Name,
                        Designation = item.DesignationType,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var item in allInstDate1)
                {
                    alldata.Add(new getAllappoint
                    {
                        Name = item.Name,
                        Designation = item.DesignationType,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetSocietyById(string id)
        {
            tbl_PersonalDetails personalDetails = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPrimaryById(string id)
        {
            Societys personalDetails = dbcont.Societys.FirstOrDefault(x => x.MemberId == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllFamilyById(string id)
        {
            List<FamilyDetails> personalDetails = dbcont.FamilyDetails.Where(x => x.MemberId == id).ToList();
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAppoinmentByDesignation(string name)
        {
            List<Appointments> personalDetails = dbcont.Appointments.Where(x => x.DesignationType.ToLower().Contains(name.ToLower())).ToList();
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllInstitutionByInstitution(string name)
        {
            List<Appointments> personalDetails = dbcont.Appointments.Where(x => x.InstitutionType.ToLower().Contains(name.ToLower())).ToList();
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMembersInfo(string radioButton, string fromdate, string todate, string age)
        {
            List<tbl_PersonalDetails> membersDetail = dbcont.tbl_PersonalDetails.ToList();
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
            string url = Request.UrlReferrer.AbsoluteUri;
            tbl_PersonalDetails tbl_PersonalDetails = new tbl_PersonalDetails
            {
                MemberID = addMember.MemberId,
                Name = addMember.Name,
                SirName = addMember.SirName
            };
            dbcont.tbl_PersonalDetails.Add(tbl_PersonalDetails);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Member Added Successfully!');location.replace('" + url + "')</script>");
        }

        public ActionResult MemberInfoById(string memberId)
        {
            //MemberInformationViewModel memberInformationViewModel = new MemberInformationViewModel();
            tbl_PersonalDetails pertionalInfo = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID.ToString() == memberId);
            Societys pertionalPrimaryInfo = dbcont.Societys.FirstOrDefault(x => x.MemberId.ToString() == memberId);
            List<FamilyDetails> FamilyDetails = dbcont.FamilyDetails.Where(x => x.MemberId == pertionalInfo.MemberID).ToList();
            //memberInformationViewModel.Societys = pertionalPrimaryInfo;
            ViewBag.Societys = pertionalPrimaryInfo;
            ViewBag.FamilyDetails = FamilyDetails;

            if (pertionalInfo != null)
            {
                ViewBag.memberId = pertionalInfo.MemberID;
                ViewBag.name = pertionalInfo.Name;
                ViewBag.sirname = pertionalInfo.SirName;
            }
            //Work for the REport
            MemberReportViewModel memberReportViewModel = new MemberReportViewModel
            {
                PersonalDetial = pertionalInfo
            };
            //End
            List<tbl_Health> allhealths = dbcont.tbl_Health.Where(x => x.MemberID == memberId).ToList();
            ViewBag.allhealths = allhealths;

            List<tbl_Passed> allpassed = dbcont.tbl_Passed.Where(x => x.MemberID == memberId).ToList();
            ViewBag.allpassed = allpassed;
            List<DetailsSummaryViewModel> allSummary = GetAllSummaryData(pertionalInfo.MemberID);
            ViewBag.allSummary = allSummary;

            List<Sacraments> scrament = dbcont.Sacraments.Where(x => x.MemberId == memberId).ToList();
            ViewBag.scrament = scrament;

            return View(memberReportViewModel);

        }
     
        public ActionResult AddFamily(FamilyDetails family)
        {
            string url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                dbcont.FamilyDetails.Add(family);
                dbcont.SaveChanges();
            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Some error occure!');location.replace('" + url + "')</script>");
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Record Save Successfully!');location.replace('" + url + "')</script>");
        }

        public ActionResult FamilyUpdate(FamilyDetails family)
        {
            string url = Request.UrlReferrer.AbsoluteUri;
            FamilyDetails data = dbcont.FamilyDetails.FirstOrDefault(x => x.Id == family.Id);
            if (data != null)
            {
                family.CreatedBy = data.CreatedBy;
                dbcont.Entry(data).CurrentValues.SetValues(family);
                dbcont.SaveChanges();
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Family update Successfully!');location.replace('" + url + "')</script>");

        }

        public ActionResult FamilyDelete(int id)
        {
            string url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                FamilyDetails genralobj = dbcont.FamilyDetails.FirstOrDefault(e => e.Id == id);
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
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Some Error Occure');location.replace('" + url + "')</script>");
            }
        }
        public JsonResult GetFamilyById(int Id)
        {
            try
            {
                FamilyDetails gid = dbcont.FamilyDetails.FirstOrDefault(e => e.Id == Id);
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

        //For the Report data
        public JsonResult GetAllFormationById(string id)
        {
            List<Tbl_formationsDetails> allFOrmation = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == id).ToList();
            return Json(allFOrmation, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAcademyById(string id)
        {
            List<tbl_Academy> allAcademy = dbcont.tbl_Academy.Where(x => x.MemberId == id).ToList();
            return Json(allAcademy, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAppinmentById(string id)
        {
            List<Appointments> Appointments = dbcont.Appointments.Where(x => x.MemberId == id).ToList();
            return Json(Appointments, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllHealthById(string id)
        {
            List<tbl_Health> healths = dbcont.tbl_Health.Where(x => x.MemberID == id).ToList();
            return Json(healths, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllPassedById(string id)
        {
            List<tbl_Passed> passed = dbcont.tbl_Passed.Where(x => x.MemberID == id).ToList();
            return Json(passed, JsonRequestBehavior.AllowGet);
        }

        //Health
        public ActionResult CreateHealth(tbl_Health tbl_Health, HttpPostedFileBase file)
        {
            string url = Request.UrlReferrer.AbsoluteUri;
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/Health"), fileName);
                    file.SaveAs(path);
                    tbl_Health.Spare3 = fileName;   //pan document file1 for the name
                }
            }
            dbcont.tbl_Health.Add(tbl_Health);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Health Added Successfully!');location.replace('" + url + "')</script>");
        }
        //tbl_Passed
        public ActionResult CreatePassed(tbl_Passed tbl_Passed, HttpPostedFileBase file)
        {
            string url = Request.UrlReferrer.AbsoluteUri;
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/Passed"), fileName);
                    file.SaveAs(path);
                    tbl_Passed.Spare3 = fileName;   //pan document file1 for the name
                }
            }
            dbcont.tbl_Passed.Add(tbl_Passed);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Health Added Successfully!');location.replace('" + url + "')</script>");
        }
        //Get All Summary Data
        public List<DetailsSummaryViewModel> GetAllSummaryData(string memberId)
        {
            List<DetailsSummaryViewModel> data = new List<DetailsSummaryViewModel>();

            Societys primaryDetails = dbcont.Societys.FirstOrDefault(x => x.MemberId.ToString() == memberId);
            if (primaryDetails != null)
            {
                data.Add(new DetailsSummaryViewModel
                {

                });
            }

            List<FamilyDetails> familyData = dbcont.FamilyDetails.Where(x => x.MemberId == memberId).ToList();
            if (familyData != null)
            {
                foreach (FamilyDetails item in familyData)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Name,
                        Date = item.YearOfBirth,
                        Description = item.Address
                    });
                }
            }

            List<tbl_Health> allhealths = dbcont.tbl_Health.Where(x => x.MemberID == memberId).ToList();
            if (allhealths != null)
            {
                foreach (tbl_Health item in allhealths)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Title,
                        Date = item.FromDate,
                        Description = item.Description
                    });
                }
            }

            List<tbl_Passed> allpassed = dbcont.tbl_Passed.Where(x => x.MemberID == memberId).ToList();
            if (allpassed != null)
            {
                foreach (tbl_Passed item in allpassed)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Title,
                        Date = item.Date,
                        Description = item.Description
                    });
                }
            }

            List<Sacraments> allScraments = dbcont.Sacraments.Where(x => x.MemberId == memberId).ToList();
            if (allScraments != null)
            {
                foreach (Sacraments item in allScraments)
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
            string url = Request.UrlReferrer.AbsoluteUri;
            dbcont.Sacraments.Add(sacraments);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Sacrament Added Successfully!');location.replace('" + url + "')</script>");
        }
        public JsonResult GetScrament(int id)
        {
            Sacraments scrament = dbcont.Sacraments.FirstOrDefault(x => x.Id == id);
            return Json(scrament, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateScrament(Sacraments sacraments)
        {
            string url = Request.UrlReferrer.AbsoluteUri;
            Sacraments data = dbcont.Sacraments.FirstOrDefault(x => x.Id == sacraments.Id);
            if (data != null)
            {
                sacraments.CreatedBy = data.CreatedBy;
                dbcont.Entry(data).CurrentValues.SetValues(sacraments);
                dbcont.SaveChanges();
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Sacrament Update Successfully!');location.replace('" + url + "')</script>");
        }
        public ActionResult DeleteScrament(int id)
        {
            string url = Request.UrlReferrer.AbsoluteUri;
            Sacraments data = dbcont.Sacraments.FirstOrDefault(x => x.Id == id);
            dbcont.Sacraments.Remove(data);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Sacrament Delete Successfully!');location.replace('" + url + "')</script>");

        }

        public ActionResult SubInstitutionList(string id, string type)
        {   
            Tbl_ParisInstitutionDetails data = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.Id.ToString() == id);
            ViewBag.allInstitution = dbcont.tbl_Institution.Where(x => x.MyId == data.MyId).ToList();

            List<Appointments> AppointData = dbcont.Appointments.Where(x => x.InstitutionType == data.InstitutionType).ToList();
            ViewBag.AppointData = AppointData;
            return View(data);
        }
        public ActionResult SubInstitutionList1(string id, string type)
        {
            Tbl_ParisInstitutionDetails data = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.Id.ToString() == id);
            ViewBag.allInstitution = dbcont.tbl_Institution.Where(x => x.MyId == data.MyId).ToList();

            List<Appointments> AppointData = dbcont.Appointments.Where(x => x.InstitutionType == data.InstitutionType).ToList();
            ViewBag.AppointData = AppointData;
            return View(data);
        }
        public ActionResult SubCommunityList(string id, string name)
        {
            Tbl_Cong data12 = dbcont.Tbl_Cong.FirstOrDefault(x => x.Id.ToString() == id);
            List<CongData> CongrigationData = dbcont.CongData.Where(x => x.CongId == data12.Id.ToString()).ToList();
            ViewBag.CongrigationData = CongrigationData;

            List<Appointments> AppointData = dbcont.Appointments.Where(x => x.CommunityType == data12.CongregationName).ToList();
            ViewBag.AppointData = AppointData;
            return View(data12);
        }
        public ActionResult SubCommunityList1(string id, string name)
        {
            Tbl_Cong data12 = dbcont.Tbl_Cong.FirstOrDefault(x => x.Id.ToString() == id);
            List<CongData> CongrigationData = dbcont.CongData.Where(x => x.CongId == data12.Id.ToString()).ToList();
            ViewBag.CongrigationData = CongrigationData;

            List<Appointments> AppointData = dbcont.Appointments.Where(x => x.CommunityType == data12.CongregationName).ToList();
            ViewBag.AppointData = AppointData;
            return View(data12);
        }
        public ActionResult SubCongList(string id, string type)
        {
            tbl_Congregation data12 = dbcont.tbl_Congregation.FirstOrDefault(x => x.Id.ToString() == id);
            List<Tbl_CongrationsData> CongregationData = dbcont.Tbl_CongrationsDatas.Where(x => x.CongrationId == data12.Id.ToString()).ToList();
            ViewBag.CongregationData = CongregationData;
            return View(data12);
        }
        public ActionResult SubSocietyList(string id, string type)
        {
            Societys data12 = dbcont.Societys.FirstOrDefault(x => x.Id.ToString() == id);
            List<SocietyData> SocietyData = dbcont.SocietyData.Where(x => x.SocId == id).ToList();
            ViewBag.allData = SocietyData;
            return View(data12);
        }
        public ActionResult SubProvList(string id, string name)
        {
            tbl_Province data12 = dbcont.tbl_Province.FirstOrDefault(x => x.Id.ToString() == id);
            List<Tbl_provinceData> ProvinceData = dbcont.Tbl_provinceDatas.Where(x => x.ProvinceId == data12.MyId.ToString()).ToList();
            ViewBag.ProvinceData = ProvinceData;

            List<Tbl_ProvinceCouncil> ProvinceCouncil = dbcont.Tbl_ProvinceCouncil.Where(x => x.ProvinceName == data12.ProvinceName).ToList();
            ViewBag.ProvinceCouncil = ProvinceCouncil;
            return View(data12);

            // return View();
        }
        public ActionResult SubParisList(string id, string type)
        {
            Tbl_ParisInstitutionDetails data12 = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.Id.ToString() == id);
            List<Tbl_Paris> allParis = dbcont.Tbl_Paris.Where(x => x.MyId == data12.MyId).ToList();
            ViewBag.allParis = allParis;

            List<Tbl_Governer> GovernerSoc = dbcont.Tbl_Governer.Where(x => x.MyId == data12.MyId).ToList();
            ViewBag.GovernerSoc = GovernerSoc;
            return View(data12);
        }
        public ActionResult SubParisList1(string id, string type)
        {
            Tbl_ParisInstitutionDetails data12 = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.Id.ToString() == id);
            List<Tbl_Paris> allParis = dbcont.Tbl_Paris.Where(x => x.MyId == data12.MyId).ToList();
            ViewBag.allParis = allParis;

            List<Tbl_Governer> GovernerSoc = dbcont.Tbl_Governer.Where(x => x.MyId == data12.MyId).ToList();
            ViewBag.GovernerSoc = GovernerSoc;
            return View(data12);
        }
        public ActionResult ParishMember(string id)
        {
            Tbl_ParisInstitutionDetails data12 = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.Id.ToString() == id);
            List<Tbl_Paris> allParis = dbcont.Tbl_Paris.Where(x => x.MyId == data12.MyId).ToList();
            ViewBag.allParis = allParis;

            List<Tbl_Governer> GovernerSoc = dbcont.Tbl_Governer.Where(x => x.MyId == data12.MyId).ToList();
            ViewBag.GovernerSoc = GovernerSoc;

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;
            return View(data12);
        }
        public ActionResult ProvCouncil(string id)
        {
            tbl_Province data12 = dbcont.tbl_Province.FirstOrDefault(x => x.Id.ToString() == id);
            List<Tbl_provinceData> ProvinceData = dbcont.Tbl_provinceDatas.Where(x => x.ProvinceId == data12.MyId.ToString()).ToList();
            ViewBag.ProvinceData = ProvinceData;

            List<Tbl_ProvinceCouncil> ProvinceCouncil = dbcont.Tbl_ProvinceCouncil.Where(x => x.ProvinceId == data12.MyId).ToList();
            ViewBag.ProvinceCouncil = ProvinceCouncil;

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;

            return View(data12);
        }
        public ActionResult ProCommission(string id)
        {
            tbl_Province data12 = dbcont.tbl_Province.FirstOrDefault(x => x.Id.ToString() == id);
            List<Tbl_provinceData> ProvinceData = dbcont.Tbl_provinceDatas.Where(x => x.ProvinceId == data12.MyId.ToString()).ToList();
            ViewBag.ProvinceData = ProvinceData;

            List<tbl_ProCommission> tbl_ProCommission = dbcont.tbl_ProCommission.Where(x => x.ProId == data12.MyId).ToList();
            ViewBag.tbl_ProCommission = tbl_ProCommission;

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;

            return View(data12);
        }
        public ActionResult GeneralCouncil(string id, string FromDate, string ToDate)
        {
            tbl_Congregation data12 = dbcont.tbl_Congregation.FirstOrDefault(x => x.Id.ToString() == id);

            List<GeneralCouncil> GeneralCouncil = dbcont.MeetingMinutes.Where(x => x.GenId == data12.Id.ToString()).ToList();
            ViewBag.GeneralCouncil = GeneralCouncil;

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;

            return View(data12);
        }
        public JsonResult AllGenCouncilData (string FromDate, string ToDate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            firstDay = Convert.ToDateTime(FromDate);
            lastDay = Convert.ToDateTime(ToDate);

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id");

            var datas = dbcont.MeetingMinutes.Where(x => Convert.ToDateTime(x.FromDate) <= firstDay && Convert.ToDateTime(x.ToDate) <= lastDay);
            var allRecords = datas.Where(x => x.GenId == topid).Select(x => new { x.Name, x.Designation, x.Responsibility }).ToList();
            return Json(allRecords, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CommunityMember(string id)
        {
            Tbl_Cong data12 = dbcont.Tbl_Cong.FirstOrDefault(x => x.Id.ToString() == id);
            List<CongData> CongrigationData = dbcont.CongData.Where(x => x.CongId == data12.Id.ToString()).ToList();
            ViewBag.CongrigationData = CongrigationData;

            List<Appointments> AppointData = dbcont.Appointments.Where(x => x.CommunityType == data12.CongregationName).ToList();
            ViewBag.AppointData = AppointData;

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;
            return View(data12);
        }
        public ActionResult InstituteMember(string id, string type)
        {
            Tbl_ParisInstitutionDetails data = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.Id.ToString() == id);
            //ViewBag.allInstitution = dbcont.tbl_Institution.Where(x => x.MyId == data.MyId).ToList();

            List<Appointments> AppointData = dbcont.Appointments.Where(x => x.InstitutionType == data.Id.ToString()).ToList();
            ViewBag.AppointData = AppointData;

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;
            return View(data);
        }
        public JsonResult GetAllInsViewData(string province)
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                var allInstDetails = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ActiveCkeck == "Active" && x.Type.ToLower() == "Institution".ToLower())
                                  .Select(x => new { x.Id, x.MyId, x.Name, x.Place, x.ProvinceName }).ToList();
               
                return Json(allInstDetails, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == currentUser && x.Type.ToLower() == "Institution".ToLower())
                            .Select(x => new { x.Id, x.Name, x.MyId, x.Place, x.ProvinceName }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SocMember(string id, string type)
        {
            Societys data = dbcont.Societys.FirstOrDefault(x => x.Id.ToString() == id);
            //ViewBag.allInstitution = dbcont.tbl_Institution.Where(x => x.MyId == data.MyId).ToList();
             
            List<Tbl_Governer> AppointData = dbcont.Tbl_Governer.Where(x => x.MyId == id).ToList();
            ViewBag.AppointData = AppointData;

            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;

            return View(data);
        }
        public ActionResult MemberComOutSide(string id, string type)
        {
            ComOutSide data = dbcont.ComOutSide.FirstOrDefault(x => x.Id.ToString() == id);
            ViewBag.ComOutSide = dbcont.ComOutSide.Where(x => x.MyId == data.MyId).ToList();
            List<Appointments> AppointData = dbcont.Appointments.Where(x => x.CommunityType == data.CommunityName).ToList();
            ViewBag.AppointData = AppointData;
            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;
            return View(data);
        }
        public ActionResult MemberComHouse(string id, string type)
        {
            ComOutSide data = dbcont.ComOutSide.FirstOrDefault(x => x.Id.ToString() == id);
            ViewBag.ComOutSide = dbcont.ComOutSide.Where(x => x.MyId == data.MyId).ToList();
            List<Appointments> AppointData = dbcont.Appointments.Where(x => x.CommunityType == data.Id.ToString()).ToList();
            ViewBag.AppointData = AppointData;
            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id"); // current provinceid
            ViewBag.Id = topid;
            return View(data);
        }
        public ActionResult SubComOutSide(string id, string name)
        {
            ComOutSide data12 = dbcont.ComOutSide.FirstOrDefault(x => x.Id.ToString() == id);
            List<ComOutSideDetails> ComOutSide = dbcont.ComOutSideDetails.Where(x => x.ComId == data12.MyId.ToString()).ToList();
            ViewBag.ComOutSideData = ComOutSide;
            return View(data12);
        }
        public ActionResult SubComHouse(string id, string name)
        {
            ComHouse data12 = dbcont.ComHouse.FirstOrDefault(x => x.Id.ToString() == id);
            List<ComHouseDetails> ComHouse = dbcont.ComHouseDetails.Where(x => x.ComId == data12.MyId.ToString()).ToList();
            ViewBag.ComHouseData = ComHouse;
            return View(data12);
        }
        public ActionResult SubDisSec(string id, string name)
        {
            tbl_DistSector data12 = dbcont.tbl_DistSector.FirstOrDefault(x => x.Id.ToString() == id);
            List<tbl_DistSectorData> DistSectorData = dbcont.tbl_DistSectorData.Where(x => x.MyId == data12.Id.ToString()).ToList();
            ViewBag.DistSectorData = DistSectorData;
            return View(data12);
        }
    }
}