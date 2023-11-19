using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Generalate.Models.ViewModels;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using Generalate.Helpers;
using System.Runtime.Caching;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class EntryLifeController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Details(string id)
        {
            if (id != null)
                Session["DetailsDioId"] = id;
            else
                id = Session["DetailsDioId"].ToString();

            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string currentUser = Convert.ToString(Session["username"]);
            //if (id != null)
            //{
            var data = dbcont.tbl_Diocese.FirstOrDefault(x => x.DioId.ToString() == id);
            ViewBag.DioId = data.DioId;
            ViewBag.DioceseName = data.DioceseName;
            //}
            //else
            //{
            //    ViewBag.DioId ="";
            //    ViewBag.DioceseName = data.DioceseName;
            //}


            var DioData = dbcont.tbl_DioceseData.Where(x => x.DioId == data.DioId.ToString()).ToList();
            ViewBag.DioData = DioData;

            var allDioInst = dbcont.tbl_DioceseInst.Where(x => x.DioId == data.DioId.ToString()).ToList();
            ViewBag.allDioInst = allDioInst;

            var allDioCom = dbcont.tbl_DioceseCom.Where(x => x.DioId == data.DioId.ToString()).ToList();
            ViewBag.allDioCom = allDioCom;

            var DioDataBish = dbcont.tbl_DioBishSec.Where(x => x.DioId == data.DioId.ToString()).ToList();
            ViewBag.DioDataBish = DioDataBish;

            var allDioParish = dbcont.tbl_DioceseParish.Where(x => x.DioId == data.DioId.ToString()).ToList();
            ViewBag.allDioParish = allDioParish;

            return View();
        }
        public JsonResult GetAllCommunity()
        {
            List<string> alldata = new List<string>();
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var tbl_congdata = dbcont.Tbl_Cong.ToList();
                var tbl_comhouse = dbcont.ComHouse.ToList();
                var tbl_comoutside = dbcont.ComOutSide.ToList();
                foreach (var item in tbl_congdata)
                {
                    alldata.Add(item.CongregationName);
                }
                foreach (var item in tbl_comhouse)
                {
                    alldata.Add(item.CommunityName);
                }
                foreach (var item in tbl_comoutside)
                {
                    alldata.Add(item.CommunityName);
                }
                return Json(alldata.Distinct(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var tbl_Province = dbcont.tbl_Province.FirstOrDefault(x => x.Id.ToString() == currentUser);
                //var ProvanceName = dbcont.tbl_Province

                //----condition removed ---
                var tbl_congdata = dbcont.Tbl_Cong.Where(x => (x.ProvinceName == tbl_Province.ProvinceName || x.ProvinceName == currentUser /*|| x.ProvinceName == "admin"*/)).ToList();
                //-------rwemoving condition for current user
                var tbl_comhouse = dbcont.ComHouse.Where(x => x.ProvinceName == currentUser).ToList();
                var tbl_comoutside = dbcont.ComOutSide.Where(x => x.ProvinceName == currentUser).ToList();
                foreach (var item in tbl_congdata)
                {
                    alldata.Add(item.CongregationName);
                }
                foreach (var item in tbl_comhouse)
                {
                    alldata.Add(item.CommunityName);
                }
                foreach (var item in tbl_comoutside)
                {
                    alldata.Add(item.CommunityName);
                }
                return Json(alldata.Distinct(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllCommunity_All()
        {
            List<string> alldata = new List<string>();
            string currentUser = Convert.ToString(Session["username"]);
            
                var tbl_congdata = dbcont.Tbl_Cong.ToList();
                var tbl_comhouse = dbcont.ComHouse.ToList();
                var tbl_comoutside = dbcont.ComOutSide.ToList();
                var tbl_ExtraComm = dbcont.tblAddExtraCommunity.ToList();
                foreach (var item in tbl_congdata)
                {
                    alldata.Add(item.CongregationName);
                }
                foreach (var item in tbl_comhouse)
                {
                    alldata.Add(item.CommunityName);
                }
                foreach (var item in tbl_comoutside)
                {
                    alldata.Add(item.CommunityName);
                }
                foreach (var item in tbl_ExtraComm)
                {
                    alldata.Add(item.Name);
                }
            return Json(alldata.Distinct(), JsonRequestBehavior.AllowGet);
            
            //else
            //{
            //    var tbl_Province = dbcont.tbl_Province.FirstOrDefault(x => x.Id.ToString() == currentUser);
            //    //var ProvanceName = dbcont.tbl_Province

            //    //----condition removed ---Where(x => (x.ProvinceName == tbl_Province.ProvinceName || x.ProvinceName == currentUser /*|| x.ProvinceName == "admin"*/)).
            //    var tbl_congdata = dbcont.Tbl_Cong.ToList();
            //    //-------rwemoving condition for current user
            //    var tbl_comhouse = dbcont.ComHouse.Where(x => x.ProvinceName == currentUser).ToList();
            //    var tbl_comoutside = dbcont.ComOutSide.Where(x => x.ProvinceName == currentUser).ToList();
            //    foreach (var item in tbl_congdata)
            //    {
            //        alldata.Add(item.CongregationName);
            //    }
            //    foreach (var item in tbl_comhouse)
            //    {
            //        alldata.Add(item.CommunityName);
            //    }
            //    foreach (var item in tbl_comoutside)
            //    {
            //        alldata.Add(item.CommunityName);
            //    }
            //    return Json(alldata.Distinct(), JsonRequestBehavior.AllowGet);
            //}
        }
        public JsonResult GetAllFormator()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes" && x.Archivecheck != "yes" && x.IsDeleted == false && x.Diedcheck == null && x.Sapcheck == null)
                               .Select(x => new { x.Name, x.PersonalDetailsId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes" && x.Archivecheck != "yes" && x.ProvinceName == currentUser && x.IsDeleted == false && x.Diedcheck == null && x.Sapcheck == null)
                              .Select(x => new { x.Name, x.PersonalDetailsId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllPersions()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes" && x.Archivecheck != "yes" && x.IsDeleted == false && x.Diedcheck == null && x.Sapcheck == null)
                               .Select(x => new { x.Name, x.PersonalDetailsId, x.SirName }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_PersonalDetails
                           .Where(x => x.IsTransfer != "yes" && x.Archivecheck != "yes" && x.IsDeleted == false && x.Diedcheck == null && x.Sapcheck == null && x.ProvinceName == currentUser)
                           .Select(x => new { x.Name, x.PersonalDetailsId, x.SirName }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllSuperior()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes" && x.Archivecheck != "yes" && x.IsDeleted == false && x.Diedcheck == null && x.Sapcheck == null)
                               .Select(x => new { x.Name, x.PersonalDetailsId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes" && x.Archivecheck != "yes" && x.IsDeleted == false && x.Diedcheck == null && x.Sapcheck == null && x.ProvinceName == currentUser)
                               .Select(x => new { x.Name, x.PersonalDetailsId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteFormationById(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_formationsDetails.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Tbl_formationsDetails.Remove(data);
                    dbcont.SaveChanges();

                    var Formation = dbcont.Tbl_formationsDetails.ToList().LastOrDefault(x => x.MemberId.ToString() == data.MemberId);

                    var dataUpdate = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID == data.MemberId);
                    if (dataUpdate != null)
                    {
                        dataUpdate.CurrentStatus = Formation.CurrentStatus;
                        dbcont.SaveChanges();
                    }

                    ObjectCache objectcache = MemoryCache.Default;
                    objectcache.Remove("PersonelCache");
                    var data1 = new HomeController().GetPersonelDetaisl();

                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");

                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetFormationById(int id)
        {
            try
            {
                var genFormation = dbcont.Tbl_formationsDetails.FirstOrDefault(e => e.Id == id);
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
        public ActionResult AddFormationDetail(Tbl_formationsDetails tbl_FormationsDetails, HttpPostedFileBase[] FileName)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath + "?memberId=" + tbl_FormationsDetails.MemberId;
            try
            {
                var formationdata = dbcont.Tbl_formationsDetails.FirstOrDefault(x => x.MemberId == tbl_FormationsDetails.MemberId && x.StageOfFormation == tbl_FormationsDetails.StageOfFormation);
                if(formationdata != null)
                {
                    setcookies("205");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    List<string> fileNames = new List<string>();
                    foreach (var file in FileName)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                string filename = Path.GetFileName(file.FileName);
                                fileNames.Add(filename);
                                var path = Path.Combine(Server.MapPath("~/Image/Formation"), filename);
                                file.SaveAs(path);
                            }
                        }
                    }
                    tbl_FormationsDetails.FileName = string.Join(",", fileNames);
                    if (tbl_FormationsDetails.StageOfFormation == "0")
                    {
                        setcookies("203");
                        return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                    }
                    tbl_FormationsDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                    dbcont.Tbl_formationsDetails.Add(tbl_FormationsDetails);
                    dbcont.SaveChanges();

                    string[] id = tbl_FormationsDetails.MemberId.Split(' ');
                    string memid = id[0];
                    var dataUpdate = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID.Contains(memid));
                    if (dataUpdate != null)
                    {
                        dataUpdate.CurrentStatus = tbl_FormationsDetails.StageOfFormation;
                        dbcont.SaveChanges();
                    }
                    ObjectCache objectcache = MemoryCache.Default;
                    objectcache.Remove("PersonelCache");
                    var data = new HomeController().GetPersonelDetaisl();
                    setcookies("200");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
              
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        public JsonResult UpdateCurrentstatus(int countid,string newstatus)
        {
            try
            {
                var data = dbcont.Tbl_formationsDetails.FirstOrDefault(x => x.Id == countid);
                if(data != null)
                {
                    data.Status = newstatus;
                    dbcont.SaveChanges();
                    ObjectCache objectcache = MemoryCache.Default;
                    objectcache.Remove("PersonelCache");
                    var data1 = new HomeController().GetPersonelDetaisl();

                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Fail", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                throw;
            }
        }

        public ActionResult UpdateFormationDetail(Tbl_formationsDetails tbl_FormationsDetails, HttpPostedFileBase FileName)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_formationsDetails.FirstOrDefault(e => e.Id == tbl_FormationsDetails.Id);
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Formation"), fileName);
                        FileName.SaveAs(path);
                        tbl_FormationsDetails.FileName = fileName;
                    }
                }
                else
                {
                    tbl_FormationsDetails.FileName = existingobj.FileName;
                }
                if (existingobj != null)
                {
                    tbl_FormationsDetails.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_FormationsDetails);
                    dbcont.SaveChanges();

                    string[] names = tbl_FormationsDetails.Name.Split(' ');
                    string name = names[0];
                    var dataUpdate = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.Name.Contains(name));
                    if (dataUpdate != null)
                    {
                        dataUpdate.CurrentStatus = tbl_FormationsDetails.StageOfFormation;
                        dbcont.SaveChanges();
                        ObjectCache objectcache = MemoryCache.Default;
                        objectcache.Remove("PersonelCache");
                        var data = new HomeController().GetPersonelDetaisl();
                    }
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult AddVowsDetail(Tbl_formationsDetails tbl_FormationsDetails, HttpPostedFileBase[] FileName)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath + "?memberId=" + tbl_FormationsDetails.MemberId;
            try
            {

                var formationdata = dbcont.Tbl_formationsDetails.FirstOrDefault(x => x.MemberId == tbl_FormationsDetails.MemberId && x.StageOfFormation == tbl_FormationsDetails.StageOfFormation);
                if (formationdata != null)
                {
                    setcookies("205");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    List<string> fileNames = new List<string>();
                    foreach (var file in FileName)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                string filename = Path.GetFileName(file.FileName);
                                fileNames.Add(filename);
                                var path = Path.Combine(Server.MapPath("~/Image/Formation"), filename);
                                file.SaveAs(path);
                            }
                        }
                    }
                    tbl_FormationsDetails.FileName = string.Join(",", fileNames);
                    if (tbl_FormationsDetails.StageOfFormation == "0")
                    {
                        setcookies("203");
                        return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                    }
                    tbl_FormationsDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                    dbcont.Tbl_formationsDetails.Add(tbl_FormationsDetails);
                    dbcont.SaveChanges();

                    string[] id = tbl_FormationsDetails.MemberId.Split(' ');
                    string memid = id[0];
                    var dataUpdate = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID.Contains(memid));
                    if (dataUpdate != null)
                    {
                        dataUpdate.CurrentStatus = tbl_FormationsDetails.StageOfFormation;
                        dbcont.SaveChanges();
                    }
                    ObjectCache objectcache = MemoryCache.Default;
                    objectcache.Remove("PersonelCache");
                    var data = new HomeController().GetPersonelDetaisl();
                    setcookies("200");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }

              
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        //tbl_Academy Work
        [HttpPost]
        public ActionResult AddAcademyDetail(tbl_Academy tbl_Academy, HttpPostedFileBase doc)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath + "?memberId=" + tbl_Academy.MemberId;
            try
            {
                if (doc != null)
                {
                    if (doc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(doc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Academy"), fileName);
                        doc.SaveAs(path);
                        tbl_Academy.doc = fileName;
                    }
                }
                tbl_Academy.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_Academy.Add(tbl_Academy);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetAcademyById(int id)
        {
            try
            {
                var genAcademy = dbcont.tbl_Academy.FirstOrDefault(e => e.acaid == id);
                if (genAcademy != null)
                {
                    return Json(genAcademy, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateAcademyDetail(tbl_Academy tbl_Academy, HttpPostedFileBase doc)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.tbl_Academy.FirstOrDefault(e => e.acaid == tbl_Academy.acaid);
                if (doc != null)
                {
                    if (doc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(doc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Academy"), fileName);
                        doc.SaveAs(path);
                        tbl_Academy.doc = fileName;
                    }
                }
                else
                {
                    tbl_Academy.doc = existingobj.doc;
                }
                if (existingobj != null)
                {
                    tbl_Academy.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Academy);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult AcademicDelete(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var genAcademy = dbcont.tbl_Academy.FirstOrDefault(e => e.acaid == id);
                if (genAcademy != null)
                {
                    dbcont.tbl_Academy.Remove(genAcademy);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        #region Appoinment work
        public JsonResult GetDataListItemsByDataListName(string dataListName)
        {
            var dataListItems = dbcont.DataListItems
                .Where(x => x.DataListName.ToLower() == dataListName.ToLower())
                .ToList();
            return Json(dataListItems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPresentProvinceGuid()
        {
            return Json(Guid.NewGuid());
        }



        public ActionResult SaveAppointment(Appointments appointments, HttpPostedFileBase[] doc, string[] DesignationType, string[] InstitutionType, string[] CommunityType)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?memberId=" + appointments.MemberId;
            try
            {
                List<string> fileNames = new List<string>();
                foreach (var file in doc)
                {
                    if (file != null)
                    {
                        if (file.ContentLength > 0)
                        {
                            string filename = Path.GetFileName(file.FileName);
                            fileNames.Add(filename);
                            var path = Path.Combine(Server.MapPath("~/Image/Appointment"), filename);
                            file.SaveAs(path);
                        }
                    }
                }

                appointments.doc = string.Join(",", fileNames);
                appointments.DesignationType = DesignationType == null ? "" : String.Join(",", DesignationType);
                appointments.InstitutionType = InstitutionType == null ? "" : String.Join(",", InstitutionType);
                var comType = "";
                for (int i = 0; i < CommunityType.Count(); i++)
                {
                    if (CommunityType[i] != "0" && CommunityType[i] != "")
                    {
                        comType = CommunityType[i];
                    }
                }
                appointments.CommunityType = comType;
                //  appointments.CommunityType = CommunityType[1]; //= CommunityType == null ? "" : String.Join(",", CommunityType);
                appointments.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Appointments.Add(appointments);
                dbcont.SaveChanges();

                string[] names = appointments?.Name.Split(' ');
                string name = names[0];
                var dataUpdate = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.Name.Contains(name));
                if (dataUpdate != null)
                {
                    dataUpdate.CurrentCommunity = appointments.CommunityType;
                    dbcont.SaveChanges();
                }
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }


        public ActionResult SaveAppointment1(Appointments appointments, HttpPostedFileBase[] doc, string[] DesignationType, string[] InstitutionType, string[] CommunityType)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?memberId=" + appointments.MemberId;
            try
            {
                List<string> fileNames = new List<string>();

                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }

                    //// Get the complete folder path and store the file inside it.  
                    //fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                    //file.SaveAs(fname);

                    string filename = Path.GetFileName(file.FileName);
                    fileNames.Add(filename);
                    var path = Path.Combine(Server.MapPath("~/Image/Appointment"), fname);
                    file.SaveAs(path);
                }


                //   List<string> fileNames = new List<string>();
                //foreach (var file in doc)
                //{
                //    if (file != null)
                //    {
                //        if (file.ContentLength > 0)
                //        {
                //            string filename = Path.GetFileName(file.FileName);
                //            fileNames.Add(filename);
                //            var path = Path.Combine(Server.MapPath("~/Image/Appointment"), filename);
                //            file.SaveAs(path);
                //        }
                //    }
                //}

                appointments.doc = string.Join(",", fileNames);
                appointments.DesignationType = DesignationType == null ? "" : String.Join(",", DesignationType);
                appointments.InstitutionType = InstitutionType == null ? "" : String.Join(",", InstitutionType);
                appointments.CommunityType = CommunityType == null ? "" : String.Join(",", CommunityType);
                appointments.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Appointments.Add(appointments);
                dbcont.SaveChanges();

                string[] names = appointments.Name.Split(' ');
                string name = names[0];
                var dataUpdate = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.Name.Contains(name));
                if (dataUpdate != null)
                {
                    dataUpdate.CurrentCommunity = appointments.CommunityType;
                    dbcont.SaveChanges();
                }
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        public ActionResult SaveInstutionAppointment(InstutionAppointments appointments, HttpPostedFileBase[] doc, string[] DesignationType, string[] InstitutionType, string[] CommunityType)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?memberId=" + appointments.MemberId;
            try
            {
                List<string> fileNames = new List<string>();

                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }

                    //// Get the complete folder path and store the file inside it.  
                    //fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                    //file.SaveAs(fname);

                    string filename = Path.GetFileName(file.FileName);
                    fileNames.Add(filename);
                    var path = Path.Combine(Server.MapPath("~/Image/Appointment"), fname);
                    file.SaveAs(path);
                }


                //   List<string> fileNames = new List<string>();
                //foreach (var file in doc)
                //{
                //    if (file != null)
                //    {
                //        if (file.ContentLength > 0)
                //        {
                //            string filename = Path.GetFileName(file.FileName);
                //            fileNames.Add(filename);
                //            var path = Path.Combine(Server.MapPath("~/Image/Appointment"), filename);
                //            file.SaveAs(path);
                //        }
                //    }
                //}

                appointments.doc = string.Join(",", fileNames);
                appointments.DesignationType = DesignationType == null ? "" : String.Join(",", DesignationType);
                appointments.InstitutionType = InstitutionType == null ? "" : String.Join(",", InstitutionType);
                appointments.CommunityType = CommunityType == null ? "" : String.Join(",", CommunityType);
                appointments.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.InstutionAppointments.Add(appointments);
                dbcont.SaveChanges();

                string[] names = appointments.Name.Split(' ');
                string name = names[0];
                var dataUpdate = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.Name.Contains(name));
                if (dataUpdate != null)
                {
                    dataUpdate.CurrentCommunity = appointments.CommunityType;
                    dbcont.SaveChanges();
                }
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        public ActionResult UpdateInstutionAppointment(InstutionAppointments appointments, HttpPostedFileBase[] doc, string[] DesignationType, string[] InstitutionType, string[] CommunityType)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?memberId=" + appointments.MemberId;
            try
            {
                var existingobj = dbcont.InstutionAppointments.FirstOrDefault(e => e.Id == appointments.Id);
                List<string> fileNames = new List<string>();

                if (doc != null && doc.Length > 0)
                {
                    foreach (var file in doc)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                string filename = Path.GetFileName(file.FileName);
                                fileNames.Add(filename);
                                var path = Path.Combine(Server.MapPath("~/Image/Appointment"), filename);
                                file.SaveAs(path);
                            }
                        }
                        else
                        {
                            appointments.doc = existingobj.doc;
                        }
                    }
                }
                else
                {
                    appointments.doc = existingobj.doc;
                }

                if (existingobj != null)
                {
                    appointments.CreatedBy = existingobj.CreatedBy;
                    appointments.DesignationType = DesignationType == null ? "" : String.Join(",", DesignationType);
                    appointments.InstitutionType = InstitutionType == null ? "" : String.Join(",", InstitutionType);
                    var comType = string.Empty;
                    if (CommunityType != null)
                    {
                        for (int i = 0; i < CommunityType.Count(); i++)
                        {
                            if (CommunityType[i] != "0" && CommunityType[i] != "")
                            {
                                comType = CommunityType[i];
                            }
                        }
                    }

                    appointments.CommunityType = comType;

                    if (fileNames.Count > 0)
                    {
                        appointments.doc = String.Join(",", fileNames);

                    }
                    dbcont.Entry(existingobj).CurrentValues.SetValues(appointments);
                    dbcont.SaveChanges();
                }               

                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }


        public JsonResult GetAppointmentById(string id)
        {
            try
            {
                var data = dbcont.Appointments.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetInsAppointmentById(string id)
        {
            try
            {
                var data = dbcont.InstutionAppointments.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AppointmentUpdate(Appointments appointments, HttpPostedFileBase[] doc, string[] DesignationType, string[] InstitutionType, string[] CommunityType,string updateDesignationType)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Appointments.FirstOrDefault(e => e.Id == appointments.Id);
                List<string> fileNames = new List<string>();
                if (doc.Length > 0)
                {
                    foreach (var file in doc)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                string filename = Path.GetFileName(file.FileName);
                                fileNames.Add(filename);
                                var path = Path.Combine(Server.MapPath("~/Image/Appointment"), filename);
                                file.SaveAs(path);
                            }
                        }
                        else
                        {
                            appointments.doc = existingobj.doc;
                        }
                    }
                }
                else
                {
                    appointments.doc = existingobj.doc;
                }

                if (existingobj != null)
                {
                    //appointments.doc = string.Join(",", fileNames);
                    appointments.CreatedBy = existingobj.CreatedBy;
                    //   appointments.DesignationType = appointments.DesignationType;
                    ////  appointments.DesignationType = DesignationType == null ? "" : String.Join(",", DesignationType);
                    //appointments.InstitutionType = InstitutionType == null ? "" : String.Join(",", InstitutionType);
                    //appointments.CommunityType = appointments.CommunityType;

                    // Mar 23, 2021 - Changes
                    appointments.DesignationType = DesignationType == null ? updateDesignationType : String.Join(",", DesignationType);
                    appointments.InstitutionType = InstitutionType == null ? "" : String.Join(",", InstitutionType);
                    var comType = "";
                    for (int i = 0; i < CommunityType.Count(); i++)
                    {
                        if (CommunityType[i] != "0" && CommunityType[i] != "")
                        {
                            comType = CommunityType[i];
                        }
                    }
                    appointments.CommunityType = comType;

                    // appointments.CommunityType = CommunityType == null ? "" : String.Join(",", CommunityType);
                    if (fileNames.Count > 0)
                    {
                        appointments.doc = String.Join(",", fileNames);

                    }
                    dbcont.Entry(existingobj).CurrentValues.SetValues(appointments);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult AppoinmentDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Appointments.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Appointments.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");

                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        #endregion
        public ActionResult InstututionAppoinmentDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.InstutionAppointments.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.InstutionAppointments.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");

                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }


        #region  SUMMARY lIST
        public List<DetailsSummaryViewModel> GetALlSummary(string memberId)
        {
            var memberunicNumber = dbcont.Tbl_Transfer.FirstOrDefault(x => x.NewMemberId == memberId);
            List<string> allprememberids = new List<string>();
            if (memberunicNumber != null)
            {
                allprememberids = dbcont.tbl_PersonalDetails.Where(x => x.MemberUnicId == memberunicNumber.MemberUnicId).Select(x => x.MemberID).ToList();
            }

            List<DetailsSummaryViewModel> allSummary = new List<DetailsSummaryViewModel>();
            List<Tbl_Complains> allTbl_Complains = new List<Tbl_Complains>();
            List<Tbl_formationsDetails> allTbl_formationsDetails = new List<Tbl_formationsDetails>();
            List<tbl_Academy> alltbl_Academy = new List<tbl_Academy>();
            List<Appointments> allAppointments = new List<Appointments>();

            if (memberunicNumber != null)
            {
                var allTbl_Complainsdata = dbcont.Tbl_Complains.ToList();
                foreach (var memberIditem in allprememberids)
                {
                    var allallTbl_Complainsdata = allTbl_Complainsdata.Where(x => x.MemberId == memberIditem);
                    foreach (var item in allallTbl_Complainsdata)
                    {
                        allTbl_Complains.Add(item);
                    }
                }
            }
            else
            {
                allTbl_Complains = dbcont.Tbl_Complains.Where(x => x.MemberId == memberId).ToList();
            }

            if (memberunicNumber != null)
            {
                var allallTbl_formationsDetailsdata = dbcont.Tbl_formationsDetails.ToList();
                foreach (var memberIditem in allprememberids)
                {
                    var allallallallTbl_formationsDetailsdata = allallTbl_formationsDetailsdata.Where(x => x.MemberId == memberIditem);
                    foreach (var item in allallallallTbl_formationsDetailsdata)
                    {
                        allTbl_formationsDetails.Add(item);
                    }
                }
            }
            else
            {
                allTbl_formationsDetails = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == memberId).ToList();
            }

            //allTbl_formationsDetails = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == memberId).ToList();
            if (memberunicNumber != null)
            {
                var alltbl_Academysdata = dbcont.tbl_Academy.ToList();
                foreach (var memberIditem in allprememberids)
                {
                    var alltbl_Academysdataformemberid = alltbl_Academysdata.Where(x => x.MemberId == memberIditem);
                    foreach (var item in alltbl_Academysdataformemberid)
                    {
                        alltbl_Academy.Add(item);
                    }
                }
            }
            else
            {
                alltbl_Academy = dbcont.tbl_Academy.Where(x => x.MemberId == memberId).ToList();
            }
            //alltbl_Academy = dbcont.tbl_Academy.Where(x => x.MemberId == memberId).ToList();
            if (memberunicNumber != null)
            {
                var allAppointmentsdata = dbcont.Appointments.ToList();
                foreach (var memberIditem in allprememberids)
                {
                    var allAppointmentsdatamemberid = allAppointmentsdata.Where(x => x.MemberId == memberIditem);
                    foreach (var item in allAppointmentsdatamemberid)
                    {
                        allAppointments.Add(item);
                    }
                }
            }
            else
            {
                allAppointments = dbcont.Appointments.Where(x => x.MemberId == memberId).ToList();
            }
            //allAppointments = dbcont.Appointments.Where(x => x.MemberId == memberId).ToList();


            foreach (var item in allTbl_Complains)
            {
                allSummary.Add(new DetailsSummaryViewModel
                {
                    Title = item.Title,
                    Date = item.Date,
                    Description = item.Discription
                });
            }
            foreach (var item in allTbl_formationsDetails)
            {
                allSummary.Add(new DetailsSummaryViewModel
                {
                    Title = item.Title,
                    Date = item.FromDate,
                    Description = item.Description
                });
            }
            foreach (var item in alltbl_Academy)
            {
                allSummary.Add(new DetailsSummaryViewModel
                {
                    Title = item.title,
                    Date = item.fromdate,
                    Description = "No Description"
                });
            }
            foreach (var item in allAppointments)
            {
                allSummary.Add(new DetailsSummaryViewModel
                {
                    Title = item.Title,
                    Date = item.Date,
                    Description = item.Description
                });
            }
            return allSummary.ToList();
        }
        #endregion
        //Complains
        public ActionResult AddComplaindata(Tbl_Complains Tbl_Complains, HttpPostedFileBase FileName)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Compains"), fileName);
                        FileName.SaveAs(path);
                        Tbl_Complains.FileName = fileName;
                    }
                }
                Tbl_Complains.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Tbl_Complains.Add(Tbl_Complains);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult ComplainUpdate(Tbl_Complains Tbl_Complains, HttpPostedFileBase FileName)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id == Tbl_Complains.Id);
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Compains"), fileName);
                        FileName.SaveAs(path);
                        Tbl_Complains.FileName = fileName;
                    }
                }

                if (existingobj != null)
                {
                    Tbl_Complains.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_Complains);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult DeleteCompainById(string id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var apporecord = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id.ToString() == id);
                if (apporecord != null)
                {
                    dbcont.Tbl_Complains.Remove(apporecord);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetCompainById(int id)
        {
            try
            {
                var genComplain = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id == id);
                if (genComplain != null)
                {
                    return Json(genComplain, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateCompain(Tbl_Complains Tbl_Complains)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id == Tbl_Complains.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_Complains);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        //Retirement
        public ActionResult AddRetirement(tbl_Retirement tbl_Retirement)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath + "?memberId=" + tbl_Retirement.MemberID;
            try
            {
                tbl_Retirement.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_Retirement.Add(tbl_Retirement);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetretireById(int id)
        {
            try
            {
                var data = dbcont.tbl_Retirement.FirstOrDefault(e => e.RetirementId == id);
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
        public ActionResult RetirementUpdate(tbl_Retirement tbl_Retirement)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath + "?memberId=" + tbl_Retirement.MemberID;
            try
            {
                var data = dbcont.tbl_Retirement.FirstOrDefault(x => x.RetirementId == tbl_Retirement.RetirementId);
                if (data != null)
                {
                    tbl_Retirement.CreatedBy = data.CreatedBy;
                    dbcont.Entry(data).CurrentValues.SetValues(tbl_Retirement);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult RetirementDelete(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var apporecord = dbcont.tbl_Retirement.FirstOrDefault(e => e.RetirementId == id);
                if (apporecord != null)
                {
                    dbcont.tbl_Retirement.Remove(apporecord);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        //diodata
        public ActionResult AddDioData(tbl_DioceseData tbl_DioceseData, HttpPostedFileBase File)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Diocese"), fileName);
                        File.SaveAs(path);
                        tbl_DioceseData.File = fileName;
                    }
                }
                tbl_DioceseData.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_DioceseData.Add(tbl_DioceseData);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult UpdateDioData(tbl_DioceseData tbl_DioceseData, HttpPostedFileBase File)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.tbl_DioceseData.FirstOrDefault(e => e.Id == tbl_DioceseData.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Diocese"), fileName);
                        File.SaveAs(path);
                        tbl_DioceseData.File = fileName;
                    }
                }
                else
                {
                    tbl_DioceseData.File = existingobj.File;
                }
                if (existingobj != null)
                {
                    tbl_DioceseData.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_DioceseData);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetdioById(string id)
        {
            try
            {
                var data = dbcont.tbl_DioceseData.FirstOrDefault(e => e.Id.ToString() == id);
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
        public ActionResult DioceseDelete(string id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var apporecord = dbcont.tbl_DioceseData.FirstOrDefault(e => e.Id.ToString() == id);
                if (apporecord != null)
                {
                    dbcont.tbl_DioceseData.Remove(apporecord);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }

        }

        //dioBishop
        public ActionResult AddBishop(tbl_DioBishSec tbl_DioBishSec)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                tbl_DioBishSec.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_DioBishSec.Add(tbl_DioBishSec);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult UpdateDioBishData(tbl_DioBishSec tbl_DioBishSec)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var data = dbcont.tbl_DioBishSec.FirstOrDefault(x => x.id == tbl_DioBishSec.id);
                if (data != null)
                {
                    tbl_DioBishSec.CreatedBy = data.CreatedBy;
                    dbcont.Entry(data).CurrentValues.SetValues(tbl_DioBishSec);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetdioBishopById(string id)
        {
            try
            {
                var data = dbcont.tbl_DioBishSec.FirstOrDefault(e => e.id.ToString() == id);
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
        public ActionResult DioBishopDelete(string id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var apporecord = dbcont.tbl_DioBishSec.FirstOrDefault(e => e.id.ToString() == id);
                if (apporecord != null)
                {
                    dbcont.tbl_DioBishSec.Remove(apporecord);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        //HomeVisit
        public ActionResult AddHomeVisit(tbl_HomeVisit tblHomeVisit)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                tblHomeVisit.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_HomeVisit.Add(tblHomeVisit);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetHomeVisitById(int id)
        {
            try
            {
                var allmembers = dbcont.tbl_PersonalDetails.ToList();
                var data = dbcont.tbl_HomeVisit.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    var membername = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.PersonalDetailsId.ToString() == data.Name);
                    //data.Name = membername == null ? "" : membername.Name;
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
        public ActionResult HomeVisitUpdate(tbl_HomeVisit tblHomeVisit)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_HomeVisit.FirstOrDefault(x => x.Id == tblHomeVisit.Id);
                if (data != null)
                {
                    tblHomeVisit.CreatedBy = data.CreatedBy;
                    dbcont.Entry(data).CurrentValues.SetValues(tblHomeVisit);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult HomeVisitDelete(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var apporecord = dbcont.tbl_HomeVisit.FirstOrDefault(e => e.Id == id);
                if (apporecord != null)
                {
                    dbcont.tbl_HomeVisit.Remove(apporecord);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }

        }

        //ComOSContact
        public ActionResult AddComOSContact(tbl_ComOSContact tbl_ComOSContact)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                tbl_ComOSContact.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_ComOSContact.Add(tbl_ComOSContact);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult UpdateComOSContact(tbl_ComOSContact tbl_ComOSContact)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var data = dbcont.tbl_ComOSContact.FirstOrDefault(x => x.id == tbl_ComOSContact.id);
                if (data != null)
                {
                    tbl_ComOSContact.CreatedBy = data.CreatedBy;
                    dbcont.Entry(data).CurrentValues.SetValues(tbl_ComOSContact);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetComOSContactById(string id)
        {
            try
            {
                var data = dbcont.tbl_ComOSContact.FirstOrDefault(e => e.id.ToString() == id);
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
        public ActionResult ComOSContactDelete(string id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var apporecord = dbcont.tbl_ComOSContact.FirstOrDefault(e => e.id.ToString() == id);
                if (apporecord != null)
                {
                    dbcont.tbl_ComOSContact.Remove(apporecord);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        //ComOSProvince
        public ActionResult AddCOSProv(ComOSProvince ComOSProvince, HttpPostedFileBase File)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/ComOSIns"), fileName);
                        File.SaveAs(path);
                        ComOSProvince.File = fileName;
                    }
                }
                ComOSProvince.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.ComOSProvince.Add(ComOSProvince);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetByIdOSProvince(string id)
        {
            try
            {
                var genSociety = dbcont.ComOSProvince.FirstOrDefault(e => e.id.ToString() == id);
                if (genSociety != null)
                {
                    return Json(genSociety, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateOSProvince(ComOSProvince ComOSProvince, HttpPostedFileBase File)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.ComOSProvince.FirstOrDefault(e => e.id == ComOSProvince.id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/ComOSIns"), fileName);
                        File.SaveAs(path);
                        ComOSProvince.File = fileName;
                    }
                }
                else
                {
                    ComOSProvince.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    ComOSProvince.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(ComOSProvince);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult DeleteOSProvince(string id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var data = dbcont.ComOSProvince.FirstOrDefault(e => e.id.ToString() == id);
                if (data != null)
                {
                    dbcont.ComOSProvince.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        //ComOSProContact
        public ActionResult AddCOSProCont(ComOSProContact ComOSProContact)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                ComOSProContact.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.ComOSProContact.Add(ComOSProContact);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult UpdateCOSProCont(ComOSProContact ComOSProContact)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var data = dbcont.ComOSProContact.FirstOrDefault(x => x.id == ComOSProContact.id);
                if (data != null)
                {
                    ComOSProContact.CreatedBy = data.CreatedBy;
                    dbcont.Entry(data).CurrentValues.SetValues(ComOSProContact);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetCOSProContById(string id)
        {
            try
            {
                var data = dbcont.ComOSProContact.FirstOrDefault(e => e.id.ToString() == id);
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
        public ActionResult COSProContDelete(string id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var apporecord = dbcont.ComOSProContact.FirstOrDefault(e => e.id.ToString() == id);
                if (apporecord != null)
                {
                    dbcont.ComOSProContact.Remove(apporecord);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult AddExtraCommunity(string Name)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            try
            {
                tblAddExtraCommunity tblAddExtraCommunity = new tblAddExtraCommunity();
                tblAddExtraCommunity.Name = Name;
                tblAddExtraCommunity.UserId = Convert.ToString(Session["loginuserid"]);
                dbcont.tblAddExtraCommunity.Add(tblAddExtraCommunity);
                dbcont.SaveChanges();
                return View();
            }
            catch (Exception)
            {
                setcookies("204");
                return View();
                throw;
            }
        }
        public ActionResult AddExtraDesignation(string Name,string frenchname)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            try
            {
                Tbl_CommunityAppointmentDetails Tbl_CommunityAppointmentDetails = new Tbl_CommunityAppointmentDetails();
                Tbl_CommunityAppointmentDetails.Name = Name;
                Tbl_CommunityAppointmentDetails.Name_French = frenchname;
                dbcont.Tbl_CommunityAppointmentDetails.Add(Tbl_CommunityAppointmentDetails);
                dbcont.SaveChanges();
                return View();
            }
            catch (Exception)
            {
                setcookies("204");
                return View();
                throw;
            }
        }
        public ActionResult AddExtraCommunity2(string Name)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            try
            {
                Tbl_Cong tblAddExtraCommunity = new Tbl_Cong();
                tblAddExtraCommunity.CongregationName = Name;
                tblAddExtraCommunity.CommId = Name+"-"+DateTime.Now.ToString("mmssfff");
                tblAddExtraCommunity.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tblAddExtraCommunity.Enterby = "Generalate";
                tblAddExtraCommunity.ProvinceName = Convert.ToString(Session["username"]);
                dbcont.Tbl_Cong.Add(tblAddExtraCommunity);
                dbcont.SaveChanges();
                return View();
            }
            catch (Exception)
            {
                setcookies("204");
                return View();
                throw;
            }
        }
        public ActionResult AddExtraCommunity4(string Name)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            try
            {
                tbl_DioceseCom tblAddExtraCommunity = new tbl_DioceseCom();
                tblAddExtraCommunity.ComName = Name;
                tblAddExtraCommunity.DioId = Name + "-" + DateTime.Now.ToString("mmssfff");
                tblAddExtraCommunity.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tblAddExtraCommunity.ProvinceName = Convert.ToString(Session["username"]);
                dbcont.tbl_DioceseCom.Add(tblAddExtraCommunity);
                dbcont.SaveChanges();
                return View();
            }
            catch (Exception)
            {
                setcookies("204");
                return View();
                throw;
            }
        }
        public ActionResult AddExtraCommunity5(string Name)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            try
            {
                tbl_ComOSCommunity tblAddExtraCommunity = new tbl_ComOSCommunity();
                tblAddExtraCommunity.ComName = Name;
                tblAddExtraCommunity.DioId = Name + "-" + DateTime.Now.ToString("mmssfff");
                tblAddExtraCommunity.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tblAddExtraCommunity.ProvinceName = Convert.ToString(Session["username"]);
                dbcont.tbl_ComOSCommunity.Add(tblAddExtraCommunity);
                dbcont.SaveChanges();
                return View();
            }
            catch (Exception)
            {
                setcookies("204");
                return View();
                throw;
            }
        }
        //ComOSCommunity
        public ActionResult AddCOSCom(tbl_ComOSCommunity tbl_ComOSCommunity, HttpPostedFileBase File)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/ComOSIns"), fileName);
                        File.SaveAs(path);
                        tbl_ComOSCommunity.File = fileName;
                    }
                }
                tbl_ComOSCommunity.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_ComOSCommunity.Add(tbl_ComOSCommunity);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetByIdCOSCom(string id)
        {
            try
            {
                var genSociety = dbcont.tbl_ComOSCommunity.FirstOrDefault(e => e.id.ToString() == id);
                if (genSociety != null)
                {
                    return Json(genSociety, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateCOSCom(tbl_ComOSCommunity tbl_ComOSCommunity, HttpPostedFileBase File)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.tbl_ComOSCommunity.FirstOrDefault(e => e.id == tbl_ComOSCommunity.id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/ComOSIns"), fileName);
                        File.SaveAs(path);
                        tbl_ComOSCommunity.File = fileName;
                    }
                }
                else
                {
                    tbl_ComOSCommunity.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_ComOSCommunity);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult DeleteCOSCom(string id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_ComOSCommunity.FirstOrDefault(e => e.id.ToString() == id);
                if (data != null)
                {
                    dbcont.tbl_ComOSCommunity.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        public void setcookies(string code)
        {
            HttpCookie cookie = new HttpCookie("iscode", code);
            Response.Cookies.Add(cookie);
        }

    }
}

