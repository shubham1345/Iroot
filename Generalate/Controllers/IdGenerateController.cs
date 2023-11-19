using Generalate.Helpers;
using Generalate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class IdGenerateController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: IdGenerate

        #region IdGenerator
        public ActionResult IdGenerator(string memberId)
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentlogin = Convert.ToString(Session["loginuserid"]);
            ViewBag.ProvinceId = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").Count() + 1;
            ViewBag.DisSecId = dbcont.tbl_DistSector.Count() + 1;
            ViewBag.ComOutSide = dbcont.ComOutSide.Count() + 1;
            ViewBag.ComHouses123 = dbcont.ComHouse.Count() + 1;
            ViewBag.CongreId = dbcont.tbl_Congregation.Count() + 1;
            ViewBag.CommId = dbcont.Tbl_Cong.Count() + 1;
            ViewBag.InstitutionId = "AutoGen";
            //ViewBag.InstitutionId = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Institution").Count() + 1;
            ViewBag.PerisId = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Paris").Count() + 1;
            ViewBag.SocietyId = dbcont.Societys.Count() + 1;
            ViewBag.DioceseId = dbcont.tbl_Diocese.Count() + 1;

            //PrishView
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.Paris = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Paris").ToList();
            }
            else
            {
                ViewBag.Paris = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ProvinceName == currentUser && x.Type == "Paris").ToList();
            }

            //SocietyView  
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.Society = dbcont.Societys.ToList();
            }
            else
            {
                ViewBag.Society = dbcont.Societys.Where(x => x.ProvinceName == currentUser).ToList();
            }

            //InstituteView
            if (Session["username"].ToString() == "admin")
            {
                var allins = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Institution").ToList();
                ViewBag.allinstitution = allins;
            }
            else
            {
                var allins = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ProvinceName == currentUser && x.Type == "Institution").ToList();
                ViewBag.allinstitution = allins;
            }

            //ParishView
            if (Session["username"].ToString() == "admin")
            {
                var allParish = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Paris").ToList();
                ViewBag.Parish = allParish;
            }
            else
            {
                var allins = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ProvinceName == currentUser && x.Type == "Paris").ToList();
                ViewBag.Parish = allins;
            }

            //Province Viewtbl_Province
            if (Session["username"].ToString() == "admin")
            {
                var AllProvince = dbcont.tbl_Province.ToList();
                ViewBag.AllProvince = AllProvince;
            }
            else
            {
                var AllProvince = dbcont.tbl_Province.Where(x => x.Id.ToString() == currentUser).ToList();
                ViewBag.AllProvince = AllProvince;
            }

            var AllRegType = dbcont.DataListItems.Where(x => x.DataListName == "RegistrationType").ToList();
            ViewBag.AllRegType = AllRegType;

            var allDataListItems = dbcont.DataLists.ToList();
            ViewBag.allDataListItems = allDataListItems;

            var countryDataListItems = dbcont.DataLists.Where(x => x.Name.ToLower() == "country").ToList();
            ViewBag.CoutryDataListItems = countryDataListItems;

            var activitiesDataListItems = dbcont.DataLists.Where(x => x.Name.ToLower() == "activities").ToList();
            ViewBag.ActivitiesDataListItems = activitiesDataListItems;

            //CommunityView
            if (Session["username"].ToString() == "admin")
            {
                var allComm = dbcont.Tbl_Cong.ToList();
                ViewBag.Community = allComm;
            }
            else
            {
                var allComm = dbcont.Tbl_Cong.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.Community = allComm;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allCommOutside = dbcont.ComOutSide.ToList();
                ViewBag.allCommOutside = allCommOutside;
            }
            else
            {
                var allCommOutside = dbcont.ComOutSide.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allCommOutside = allCommOutside;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allCommOutsideInst = dbcont.tbl_ComOSInstitute.ToList();
                ViewBag.allCommOutsideInst = allCommOutsideInst;
            }
            else
            {
                var allCommOutsideInst = dbcont.tbl_ComOSInstitute.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allCommOutsideInst = allCommOutsideInst;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allDioInst = dbcont.tbl_DioceseInst.ToList();
                ViewBag.allDioInst = allDioInst;
            }
            else
            {
                var allDioInst = dbcont.tbl_DioceseInst.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allDioInst = allDioInst;
            }

            if (Session["username"].ToString() == "admin")
            {
                var ComHouse = dbcont.ComHouse.ToList();
                ViewBag.ComHouse = ComHouse;
            }
            else
            {
                var ComHouse = dbcont.ComHouse.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.ComHouse = ComHouse;
            }

            //CongregationView
            var allCong = dbcont.tbl_Congregation.ToList();
            ViewBag.congregation = allCong;

            //ProvinceView
            if (Session["loginuserid"].ToString() == "admin")
            {
                var allProv = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
                ViewBag.Province = allProv;
            }
            else
            {
                var allProv = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == currentUser).ToList();
                ViewBag.Province = allProv;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allDio = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active").ToList();
                ViewBag.AllDiocese = allDio;
            }
            else
            {
                var allDio = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == currentUser).ToList();
                ViewBag.AllDiocese = allDio;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allDisSec = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active").ToList();
                ViewBag.DistSector = allDisSec;
            }
            else
            {
                var allDisSec = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == currentUser).ToList();
                ViewBag.DistSector = allDisSec;
            }

            var allInstitution = dbcont.DataListItems.Where(x => x.DataListName == "Institution").OrderBy(x => x.Name).ToList();
            ViewBag.InstitutionType = allInstitution;

            var pertionalPrimaryInfo = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.Id.ToString() == memberId);
            ViewBag.Tbl_ParisInstitutionDetails = pertionalPrimaryInfo;

            var AllActivities = dbcont.DataListItems.Where(x => x.DataListName == "Activities").OrderBy(x => x.Name).OrderBy(x => x.Name).ToList();
            ViewBag.AllActivities = AllActivities;

            var countryList = dbcont.DataListItems.Where(x => x.DataListName == "Country").OrderBy(x => x.Name).OrderBy(x => x.Name).ToList();
            ViewBag.CountriesofMission = countryList;
            ViewBag.Country = countryList;

            var AllDataTypes = dbcont.DataListItems.Where(x => x.DataListName == "DistTypes").ToList();
            ViewBag.AllDataTypes = AllDataTypes;

            var allsociety = dbcont.Societys.ToList();

            string currentuserid = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.DataListItems.Where(x => x.DataListName == "State").ToList();
                ViewBag.State = allRecords;
            }

            else
            {
                var allRecords = dbcont.DataListItems.Where(x => x.DataListName == "State" && x.CreatedBy == currentuserid).ToList();
                ViewBag.State = allRecords;

            }


            return View(allsociety);
        }
        #endregion
        #region Parish
        [HttpPost]
        public ActionResult IdGenerator(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, HttpPostedFileBase FileName, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Paris"), fileName);
                        FileName.SaveAs(path);
                        tbl_ParisInstitutionDetails.FileName = fileName;
                    }
                }
                tbl_ParisInstitutionDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                dbcont.Tbl_ParisInstitutionDetails.Add(tbl_ParisInstitutionDetails);
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
        [HttpPost]
        public ActionResult UpdateIdGenerate(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, HttpPostedFileBase FileName, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            var existingobj = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == tbl_ParisInstitutionDetails.Id);
            try
            {
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Paris"), fileName);
                        FileName.SaveAs(path);
                        tbl_ParisInstitutionDetails.FileName = fileName;
                    }
                }
                else
                {
                    tbl_ParisInstitutionDetails.FileName = existingobj.FileName == null ? "" : existingobj.FileName;
                }

                tbl_ParisInstitutionDetails.Type = "Paris";
                tbl_ParisInstitutionDetails.MyId = existingobj.MyId;

                if (existingobj != null)
                {
                    tbl_ParisInstitutionDetails.CreatedBy = existingobj.CreatedBy;
                    tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_ParisInstitutionDetails);
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
        public ActionResult ParishDelete(int id)
        {
            var data = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == id);
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (data != null)
                {
                    dbcont.Tbl_ParisInstitutionDetails.Remove(data);
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
        public JsonResult GetParishById(int id)
        {
            try
            {
                var genFormation = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == id);
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
        #endregion
        #region Parish
        [HttpPost]
        public ActionResult IdGenerator1(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, HttpPostedFileBase FileName, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Paris"), fileName);
                        FileName.SaveAs(path);
                        tbl_ParisInstitutionDetails.FileName = fileName;
                    }
                }
                tbl_ParisInstitutionDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                dbcont.Tbl_ParisInstitutionDetails.Add(tbl_ParisInstitutionDetails);
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
        [HttpPost]
        public ActionResult UpdateIdGenerate1(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, HttpPostedFileBase FileName, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            var existingobj = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == tbl_ParisInstitutionDetails.Id);
            try
            {
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Paris"), fileName);
                        FileName.SaveAs(path);
                        tbl_ParisInstitutionDetails.FileName = fileName;
                    }
                }
                else
                {
                    tbl_ParisInstitutionDetails.FileName = existingobj.FileName == null ? "" : existingobj.FileName;
                }

                tbl_ParisInstitutionDetails.Type = "Paris";
                tbl_ParisInstitutionDetails.MyId = existingobj.MyId;

                if (existingobj != null)
                {
                    tbl_ParisInstitutionDetails.CreatedBy = existingobj.CreatedBy;
                    tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_ParisInstitutionDetails);
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
        public ActionResult ParishDelete1(int id)
        {
            var data = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == id);
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (data != null)
                {
                    dbcont.Tbl_ParisInstitutionDetails.Remove(data);
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
        public JsonResult GetParishById1(int id)
        {
            try
            {
                var genFormation = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == id);
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
        #endregion

        #region Parish Institution
        [HttpPost]
        public ActionResult AddParisInstitution(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, HttpPostedFileBase FileName, HttpPostedFileBase OtherDoc, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                        FileName.SaveAs(path);
                        tbl_ParisInstitutionDetails.FileName = fileName;
                    }
                }
                if (OtherDoc != null)
                {
                    if (OtherDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(OtherDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                        OtherDoc.SaveAs(path);
                        tbl_ParisInstitutionDetails.OtherDoc = fileName;
                    }
                }
                tbl_ParisInstitutionDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                dbcont.Tbl_ParisInstitutionDetails.Add(tbl_ParisInstitutionDetails);
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

        [HttpPost]
        public ActionResult AddParisInstitution12(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                tbl_ParisInstitutionDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                //tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                dbcont.Tbl_ParisInstitutionDetails.Add(tbl_ParisInstitutionDetails);
                dbcont.SaveChanges();
                setcookies("200");
                return Json("Created successfully !" + "&" + tbl_ParisInstitutionDetails.Id);
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("Created error !" + "&");
            }
        }

        [HttpPost]
        public ActionResult UpdateInsitution(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, HttpPostedFileBase FileName, HttpPostedFileBase OtherDoc, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == tbl_ParisInstitutionDetails.Id);
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                        FileName.SaveAs(path);
                        tbl_ParisInstitutionDetails.FileName = fileName;
                    }
                }
                else
                {
                    tbl_ParisInstitutionDetails.FileName = existingobj.FileName;
                }
                if (OtherDoc != null)
                {
                    if (OtherDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(OtherDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                        OtherDoc.SaveAs(path);
                        tbl_ParisInstitutionDetails.OtherDoc = fileName;
                    }
                }
                else
                {
                    tbl_ParisInstitutionDetails.OtherDoc = existingobj.OtherDoc;
                }

                tbl_ParisInstitutionDetails.MyId = existingobj.MyId;
                tbl_ParisInstitutionDetails.Type = "Institution";

                if (existingobj != null)
                {
                    tbl_ParisInstitutionDetails.CreatedBy = existingobj.CreatedBy;
                    tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_ParisInstitutionDetails);
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
        public JsonResult GetAllParisInstitution(string Type)
        {
            List<Tbl_ParisInstitutionDetails> result = new List<Tbl_ParisInstitutionDetails>();
            if (Type == "Paris")
            {
                result = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Paris").ToList();
            }
            else if (Type == "Institution")
            {
                result = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Institution").ToList();
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetParisInstitutionById(string id)
        {
            try
            {
                var genFormation = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id.ToString() == id);
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
        public ActionResult InstitutionDelete(int id)
        {
            var data = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == id);
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (data != null)
                {
                    dbcont.Tbl_ParisInstitutionDetails.Remove(data);
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

        [HttpPost]
        public ActionResult AddParisInstitution1(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, HttpPostedFileBase FileName, HttpPostedFileBase OtherDoc, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                        FileName.SaveAs(path);
                        tbl_ParisInstitutionDetails.FileName = fileName;
                    }
                }
                if (OtherDoc != null)
                {
                    if (OtherDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(OtherDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                        OtherDoc.SaveAs(path);
                        tbl_ParisInstitutionDetails.OtherDoc = fileName;
                    }
                }

                //
                //
                var newMyId = tbl_ParisInstitutionDetails.MyId;
                var myId = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ProvinceName == tbl_ParisInstitutionDetails.ProvinceName && x.Type == "Institution").Any() ? dbcont.Tbl_ParisInstitutionDetails.ToList().LastOrDefault(x => x.ProvinceName == tbl_ParisInstitutionDetails.ProvinceName && x.Type == "Institution").MyId : "01";
                if (myId != "01")
                {
                    myId = myId.Split('/')[1];
                    long z = Convert.ToInt64(myId) + 1;
                    myId = (z < 10) ? newMyId.Split('/')[0] + "/0" + z.ToString() : newMyId.Split('/')[0] + "/" + z.ToString();
                }
                else
                {
                    myId = newMyId.Split('/')[0] + "/" + myId.ToString();
                }
                //
                tbl_ParisInstitutionDetails.MyId = myId;
                tbl_ParisInstitutionDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                dbcont.Tbl_ParisInstitutionDetails.Add(tbl_ParisInstitutionDetails);
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
        [HttpPost]
        public ActionResult UpdateInsitution1(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, HttpPostedFileBase FileName, HttpPostedFileBase OtherDoc, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == tbl_ParisInstitutionDetails.Id);
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                        FileName.SaveAs(path);
                        tbl_ParisInstitutionDetails.FileName = fileName;
                    }
                }
                else
                {
                    tbl_ParisInstitutionDetails.FileName = existingobj.FileName;
                }
                if (OtherDoc != null)
                {
                    if (OtherDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(OtherDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                        OtherDoc.SaveAs(path);
                        tbl_ParisInstitutionDetails.OtherDoc = fileName;
                    }
                }
                else
                {
                    tbl_ParisInstitutionDetails.OtherDoc = existingobj.OtherDoc;
                }

                tbl_ParisInstitutionDetails.MyId = existingobj.MyId;
                tbl_ParisInstitutionDetails.Type = "Institution";

                if (existingobj != null)
                {
                    tbl_ParisInstitutionDetails.CreatedBy = existingobj.CreatedBy;
                    tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_ParisInstitutionDetails);
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

        public JsonResult GetParisInstitutionById1(string id)
        {
            try
            {
                var genFormation = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id.ToString() == id);
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
        public ActionResult InstitutionDelete1(int id)
        {
            var data = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == id);
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (data != null)
                {
                    dbcont.Tbl_ParisInstitutionDetails.Remove(data);
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

        #region Community
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCommunity(Tbl_Cong tbl_Cong, HttpPostedFileBase File, string[] Activities,string[] Names, string[] Days, string[] Months, string[] Title,string[] spanImgName,string Operation,HttpPostedFileBase[] galleryfiles)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?id=" + tbl_Cong.EnterbyId;
            try
            {
                if(Operation == "Edit")
                {
                    Tbl_Cong CongData = dbcont.Tbl_Cong.FirstOrDefault(x => x.CommId == tbl_Cong.CommId);
                    Tbl_CommInstiImportantdates tbl_CommInstiImportantdates = new Tbl_CommInstiImportantdates();
                    List<Tbl_CommInstiImportantdates> Importantdates = dbcont.Tbl_CommInstiImportantdates.Where(x => x.MainID == tbl_Cong.CommId).ToList();
                    Tbl_CommInstiGallery tbl_CommInstiGallery = new Tbl_CommInstiGallery();
                    List<Tbl_CommInstiGallery> CommunityGallery = dbcont.Tbl_CommInstiGallery.Where(x => x.MainID == tbl_Cong.CommId).ToList();

                    if(Importantdates.Count > 0)
                    {
                        for (int i = 0; i < Importantdates.Count(); i++)
                        {
                            Tbl_CommInstiImportantdates pastimportantdates = dbcont.Tbl_CommInstiImportantdates.FirstOrDefault(x => x.MainID == tbl_Cong.CommId);
                            dbcont.Tbl_CommInstiImportantdates.Remove(pastimportantdates);
                            dbcont.SaveChanges();
                        }
                    }
                    tbl_CommInstiImportantdates.MainID = tbl_Cong.CommId;
                    if (Names != null)
                    {
                        for (int j = 0; j < Names.Count(); j++)
                        {
                            tbl_CommInstiImportantdates.Name = Names[j];
                            tbl_CommInstiImportantdates.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                            tbl_CommInstiImportantdates.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                            tbl_CommInstiImportantdates.IsActive = 1;
                            dbcont.Tbl_CommInstiImportantdates.Add(tbl_CommInstiImportantdates);
                            dbcont.SaveChanges();
                        }
                    }

                    if (CommunityGallery.Count > 0)
                    {
                        for (int i = 0; i < CommunityGallery.Count(); i++)
                        {
                            Tbl_CommInstiGallery Gallery = dbcont.Tbl_CommInstiGallery.FirstOrDefault(x => x.MainID == tbl_Cong.CommId);
                            dbcont.Tbl_CommInstiGallery.Remove(Gallery);
                            dbcont.SaveChanges();
                        }
                    }

                    tbl_CommInstiGallery.MainID = tbl_Cong.CommId;
                    int count = 0;
                    if (spanImgName != null)
                    {
                        for (int k = 0; k < spanImgName.Count(); k++)
                        {
                            if (spanImgName[k] != "")
                            {
                                tbl_CommInstiGallery.IsActive = 1;
                                tbl_CommInstiGallery.FileName = spanImgName[k];
                                tbl_CommInstiGallery.Title = Title[count];
                                dbcont.Tbl_CommInstiGallery.Add(tbl_CommInstiGallery);
                                dbcont.SaveChanges();
                                count++;
                            }
                        }
                    }

                    if (File != null)
                    {
                        if (File.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(File.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                            File.SaveAs(path);
                            tbl_Cong.File = fileName;
                        }
                    }

                    if (galleryfiles != null)
                    {
                        foreach (var file in galleryfiles)
                        {
                            if (file != null && file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                var path = Path.Combine(Server.MapPath("~/Image/communitygellery"), fileName);
                                file.SaveAs(path);
                                tbl_CommInstiGallery.FileName = fileName;
                                tbl_CommInstiGallery.IsActive = 1;

                            }
                            tbl_CommInstiGallery.Title = Title[count];
                            dbcont.Tbl_CommInstiGallery.Add(tbl_CommInstiGallery);
                            dbcont.SaveChanges();
                            count++;
                        }

                    }

                    dbcont.Entry(CongData).CurrentValues.SetValues(tbl_Cong);
                    dbcont.SaveChanges();

                }

                else
                {
                    Tbl_CommInstiImportantdates tbl_CommInstiImportantdates = new Tbl_CommInstiImportantdates();
                    Tbl_CommInstiGallery tbl_CommInstiGallery = new Tbl_CommInstiGallery();
                    if(tbl_Cong != null)
                    {
                        if (File != null)
                        {
                            if (File.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(File.FileName);
                                var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                                File.SaveAs(path);
                                tbl_Cong.File = fileName;
                            }
                        }

                        tbl_CommInstiImportantdates.MainID = tbl_Cong.CommId;
                        tbl_CommInstiGallery.MainID = tbl_Cong.CommId;

                        int i = 0;
                        if (galleryfiles != null)
                        {
                            foreach (var file in galleryfiles)
                            {
                                if (file != null && file.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(file.FileName);
                                    var path = Path.Combine(Server.MapPath("~/Image/communitygellery"), fileName);
                                    file.SaveAs(path);
                                    tbl_CommInstiGallery.FileName = fileName;
                                    tbl_CommInstiGallery.IsActive = 1;

                                }
                                tbl_CommInstiGallery.Title = Title[i];
                                dbcont.Tbl_CommInstiGallery.Add(tbl_CommInstiGallery);
                                dbcont.SaveChanges();
                                i++;
                            }

                        }

                        if (Names != null)
                        {
                            for (int j = 0; j < Names.Count(); j++)
                            {
                                tbl_CommInstiImportantdates.Name = Names[j];
                                tbl_CommInstiImportantdates.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                                tbl_CommInstiImportantdates.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                                tbl_CommInstiImportantdates.IsActive = 1;
                                dbcont.Tbl_CommInstiImportantdates.Add(tbl_CommInstiImportantdates);
                                dbcont.SaveChanges();
                            }
                        }
                        tbl_Cong.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                        tbl_Cong.ProvinceName = Convert.ToString(Session["username"]);
                        dbcont.Tbl_Cong.Add(tbl_Cong);
                        dbcont.SaveChanges();

                    }
                }

                //if (File != null)
                //{
                //    if (File.ContentLength > 0)
                //    {
                //        var fileName = Path.GetFileName(File.FileName);
                //        var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                //        File.SaveAs(path);
                //        tbl_Cong.File = fileName;
                //    }
                //}
                //tbl_Cong.CreatedBy = Convert.ToString(Session["loginuserid"]);
                //tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                //tbl_Cong.ProvinceName = Convert.ToString(Session["username"]);
                //dbcont.Tbl_Cong.Add(tbl_Cong);
                //dbcont.SaveChanges();
                setcookies("200");
                return RedirectToAction("ViewCongrationList2_Community","Home");
                //return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddGeneralCommunity(Tbl_GeneralCommunity tbl_Cong, HttpPostedFileBase File, string[] Activities, string[] Names, string[] Days, string[] Months, string[] Title, string[] spanImgName, string Operation, HttpPostedFileBase[] galleryfiles)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?id=" + tbl_Cong.EnterbyId;
            try
            {
                if (Operation == "Edit")
                {
                    Tbl_GeneralCommunity CongData = dbcont.Tbl_GeneralCommunity.FirstOrDefault(x => x.GenCommId == tbl_Cong.GenCommId);
                    Tbl_CommInstiImportantdates tbl_CommInstiImportantdates = new Tbl_CommInstiImportantdates();
                    List<Tbl_CommInstiImportantdates> Importantdates = dbcont.Tbl_CommInstiImportantdates.Where(x => x.MainID == tbl_Cong.GenCommId).ToList();
                    Tbl_CommInstiGallery tbl_CommInstiGallery = new Tbl_CommInstiGallery();
                    List<Tbl_CommInstiGallery> CommunityGallery = dbcont.Tbl_CommInstiGallery.Where(x => x.MainID == tbl_Cong.GenCommId).ToList();

                    if (Importantdates.Count > 0)
                    {
                        for (int i = 0; i < Importantdates.Count(); i++)
                        {
                            Tbl_CommInstiImportantdates pastimportantdates = dbcont.Tbl_CommInstiImportantdates.FirstOrDefault(x => x.MainID == tbl_Cong.GenCommId);
                            dbcont.Tbl_CommInstiImportantdates.Remove(pastimportantdates);
                            dbcont.SaveChanges();
                        }
                    }
                    tbl_CommInstiImportantdates.MainID = tbl_Cong.GenCommId;
                    if (Names != null)
                    {
                        for (int j = 0; j < Names.Count(); j++)
                        {
                            tbl_CommInstiImportantdates.Name = Names[j];
                            tbl_CommInstiImportantdates.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                            tbl_CommInstiImportantdates.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                            tbl_CommInstiImportantdates.IsActive = 1;
                            dbcont.Tbl_CommInstiImportantdates.Add(tbl_CommInstiImportantdates);
                            dbcont.SaveChanges();
                        }
                    }

                    if (CommunityGallery.Count > 0)
                    {
                        for (int i = 0; i < CommunityGallery.Count(); i++)
                        {
                            Tbl_CommInstiGallery Gallery = dbcont.Tbl_CommInstiGallery.FirstOrDefault(x => x.MainID == tbl_Cong.GenCommId);
                            dbcont.Tbl_CommInstiGallery.Remove(Gallery);
                            dbcont.SaveChanges();
                        }
                    }

                    tbl_CommInstiGallery.MainID = tbl_Cong.GenCommId;
                    int count = 0;
                    if (spanImgName != null)
                    {
                        for (int k = 0; k < spanImgName.Count(); k++)
                        {
                            if (spanImgName[k] != "")
                            {
                                tbl_CommInstiGallery.IsActive = 1;
                                tbl_CommInstiGallery.FileName = spanImgName[k];
                                tbl_CommInstiGallery.Title = Title[count];
                                dbcont.Tbl_CommInstiGallery.Add(tbl_CommInstiGallery);
                                dbcont.SaveChanges();
                                count++;
                            }
                        }
                    }

                    if (File != null)
                    {
                        if (File.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(File.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                            File.SaveAs(path);
                            tbl_Cong.File = fileName;
                        }
                    }

                    if (galleryfiles != null)
                    {
                        foreach (var file in galleryfiles)
                        {
                            if (file != null && file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                var path = Path.Combine(Server.MapPath("~/Image/communitygellery"), fileName);
                                file.SaveAs(path);
                                tbl_CommInstiGallery.FileName = fileName;
                                tbl_CommInstiGallery.IsActive = 1;

                            }
                            tbl_CommInstiGallery.Title = Title[count];
                            dbcont.Tbl_CommInstiGallery.Add(tbl_CommInstiGallery);
                            dbcont.SaveChanges();
                            count++;
                        }

                    }

                    dbcont.Entry(CongData).CurrentValues.SetValues(tbl_Cong);
                    dbcont.SaveChanges();

                }

                else
                {
                    Tbl_CommInstiImportantdates tbl_CommInstiImportantdates = new Tbl_CommInstiImportantdates();
                    Tbl_CommInstiGallery tbl_CommInstiGallery = new Tbl_CommInstiGallery();
                    if (tbl_Cong != null)
                    {
                        if (File != null)
                        {
                            if (File.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(File.FileName);
                                var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                                File.SaveAs(path);
                                tbl_Cong.File = fileName;
                            }
                        }

                        tbl_CommInstiImportantdates.MainID = tbl_Cong.GenCommId;
                        tbl_CommInstiGallery.MainID = tbl_Cong.GenCommId;

                        int i = 0;
                        if (galleryfiles != null)
                        {
                            foreach (var file in galleryfiles)
                            {
                                if (file != null && file.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(file.FileName);
                                    var path = Path.Combine(Server.MapPath("~/Image/communitygellery"), fileName);
                                    file.SaveAs(path);
                                    tbl_CommInstiGallery.FileName = fileName;
                                    tbl_CommInstiGallery.IsActive = 1;

                                }
                                tbl_CommInstiGallery.Title = Title[i];
                                dbcont.Tbl_CommInstiGallery.Add(tbl_CommInstiGallery);
                                dbcont.SaveChanges();
                                i++;
                            }

                        }

                        if (Names != null)
                        {
                            for (int j = 0; j < Names.Count(); j++)
                            {
                                tbl_CommInstiImportantdates.Name = Names[j];
                                tbl_CommInstiImportantdates.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                                tbl_CommInstiImportantdates.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                                tbl_CommInstiImportantdates.IsActive = 1;
                                dbcont.Tbl_CommInstiImportantdates.Add(tbl_CommInstiImportantdates);
                                dbcont.SaveChanges();
                            }
                        }
                        tbl_Cong.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                        tbl_Cong.ProvinceName = Convert.ToString(Session["username"]);
                        dbcont.Tbl_GeneralCommunity.Add(tbl_Cong);
                        dbcont.SaveChanges();

                    }
                }

                //if (File != null)
                //{
                //    if (File.ContentLength > 0)
                //    {
                //        var fileName = Path.GetFileName(File.FileName);
                //        var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                //        File.SaveAs(path);
                //        tbl_Cong.File = fileName;
                //    }
                //}
                //tbl_Cong.CreatedBy = Convert.ToString(Session["loginuserid"]);
                //tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                //tbl_Cong.ProvinceName = Convert.ToString(Session["username"]);
                //dbcont.Tbl_Cong.Add(tbl_Cong);
                //dbcont.SaveChanges();
                setcookies("200");
                return RedirectToAction("ViewCongrationList2_Community", "Home");
                //return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
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

        public JsonResult GetCommunityById(string id)
        {
            try
            {
                var genSociety = dbcont.Tbl_GeneralCommunity.FirstOrDefault(e => e.Id.ToString() == id);
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
        [HttpPost]
        public ActionResult UpdateCommunity(Tbl_Cong tbl_Cong, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?page=community"  /*tbl_Cong.EnterbyId*/;
            try
            {
                var existingobj = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id == tbl_Cong.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                        File.SaveAs(path);
                        tbl_Cong.File = fileName;
                    }
                }
                else
                {
                    tbl_Cong.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    tbl_Cong.CreatedBy = existingobj.CreatedBy;
                    tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                    tbl_Cong.ProvinceName = existingobj.ProvinceName;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Cong);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return RedirectToAction("ViewCongrationList2_Community", "Home");
                //return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult CommunityDelete(string id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_GeneralCommunity.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    dbcont.Tbl_GeneralCommunity.Remove(data);
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

        [HttpPost]
        public ActionResult AddCommunity1(Tbl_Cong tbl_Cong, HttpPostedFileBase File, string[] Activities)
        {
            //string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + tbl_Cong.EnterbyId;
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                        File.SaveAs(path);
                        tbl_Cong.File = fileName;
                    }
                }
                tbl_Cong.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                dbcont.Tbl_Cong.Add(tbl_Cong);
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

        [HttpPost]
        public ActionResult AddCommunity12(Tbl_Cong tbl_Cong)
        {
            try
            {
                tbl_Cong.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Tbl_Cong.Add(tbl_Cong);
                dbcont.SaveChanges();
                setcookies("200");
                return Json("Created successfully !" + "&" + tbl_Cong.Id);
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("Created error !" + "&");
                throw;
            }
        }

        public JsonResult GetCommunityById1(string id)
        {
            try
            {
                var genSociety = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id.ToString() == id);
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
        [HttpPost]
        public ActionResult UpdateCommunity1(Tbl_Cong tbl_Cong, HttpPostedFileBase File, string[] Activities)
        {
            //string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + tbl_Cong.EnterbyId;
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id == tbl_Cong.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                        File.SaveAs(path);
                        tbl_Cong.File = fileName;
                    }
                }
                else
                {
                    tbl_Cong.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    tbl_Cong.CreatedBy = existingobj.CreatedBy;
                    tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Cong);
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
        public ActionResult CommunityDelete1(string id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    dbcont.Tbl_Cong.Remove(data);
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

        #region Outside Community
        [HttpPost]
        public ActionResult AddCommunityOutSide(ComOutSide ComOutSide, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/ComOS"), fileName);
                        File.SaveAs(path);
                        ComOutSide.File = fileName;
                    }
                }
                ComOutSide.CreatedBy = Convert.ToString(Session["loginuserid"]);
                ComOutSide.Activities = Activities == null ? "" : String.Join(",", Activities);
                dbcont.ComOutSide.Add(ComOutSide);
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
        public JsonResult GetCommunityByIdOutside(string id)
        {
            try
            {
                var genSociety = dbcont.ComOutSide.FirstOrDefault(e => e.Id.ToString() == id);
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
        [HttpPost]
        public ActionResult UpdateCommunityOutside(ComOutSide ComOutSide, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.ComOutSide.FirstOrDefault(e => e.Id == ComOutSide.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/ComOS"), fileName);
                        File.SaveAs(path);
                        ComOutSide.File = fileName;
                    }
                }
                else
                {
                    ComOutSide.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    ComOutSide.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(ComOutSide);
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
        public ActionResult CommunityDeleteOutside(string id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.ComOutSide.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    dbcont.ComOutSide.Remove(data);
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

        #region CommunityHouse
        [HttpPost]
        public ActionResult AddCommunityHouse(ComHouse ComHouse, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/ComHouse"), fileName);
                        File.SaveAs(path);
                        ComHouse.File = fileName;
                    }
                }
                ComHouse.CreatedBy = Convert.ToString(Session["loginuserid"]);
                ComHouse.Activities = Activities == null ? "" : String.Join(",", Activities);
                dbcont.ComHouse.Add(ComHouse);
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
        public JsonResult GetCommunityByIdComHouse(string id)
        {
            try
            {
                var genSociety = dbcont.ComHouse.FirstOrDefault(e => e.Id.ToString() == id);
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
        [HttpPost]
        public ActionResult UpdateCommunityComHouse(ComHouse ComHouse, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.ComHouse.FirstOrDefault(e => e.Id == ComHouse.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/ComHouse"), fileName);
                        File.SaveAs(path);
                        ComHouse.File = fileName;
                    }
                }
                else
                {
                    ComHouse.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    ComHouse.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(ComHouse);
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
        public ActionResult CommunityDeleteComHouse(string id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.ComHouse.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    dbcont.ComHouse.Remove(data);
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

        #region Outside Community Institute
        [HttpPost]
        public ActionResult AddCOSInst(tbl_ComOSInstitute tbl_ComOSInstitute, HttpPostedFileBase File)
        {
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
                        tbl_ComOSInstitute.File = fileName;
                    }
                }
                tbl_ComOSInstitute.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_ComOSInstitute.Add(tbl_ComOSInstitute);
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
        public JsonResult GetByIdComOutSideInst(string id)
        {
            try
            {
                var genSociety = dbcont.tbl_ComOSInstitute.FirstOrDefault(e => e.id.ToString() == id);
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
        [HttpPost]
        public ActionResult UpdateComOutSideInst(tbl_ComOSInstitute tbl_ComOSInstitute, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.tbl_ComOSInstitute.FirstOrDefault(e => e.id == tbl_ComOSInstitute.id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/ComOSIns"), fileName);
                        File.SaveAs(path);
                        tbl_ComOSInstitute.File = fileName;
                    }
                }
                else
                {
                    tbl_ComOSInstitute.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    tbl_ComOSInstitute.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_ComOSInstitute);
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
        public ActionResult DeleteComOutSideInst(string id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_ComOSInstitute.FirstOrDefault(e => e.id.ToString() == id);
                if (data != null)
                {
                    dbcont.tbl_ComOSInstitute.Remove(data);
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

        #region Dio Institute
        [HttpPost]
        public ActionResult AddDioInst(tbl_DioceseInst tbl_DioceseInst, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DioInst"), fileName);
                        File.SaveAs(path);
                        tbl_DioceseInst.File = fileName;
                    }
                }
                dbcont.tbl_DioceseInst.Add(tbl_DioceseInst);
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

        public ActionResult AddDioInst12(tbl_DioceseInst tbl_DioceseInst)
        {
            try
            {
                var dioId = dbcont.tbl_Diocese.First(x => x.Id.ToString() == tbl_DioceseInst.DioId.ToString()).DioId; ;
                tbl_DioceseInst.DioId = dioId;
                dbcont.tbl_DioceseInst.Add(tbl_DioceseInst);
                dbcont.SaveChanges();
                setcookies("200");
                return Json("Created successfully !" + "&" + tbl_DioceseInst.id);
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("Created error !" + "&");
            }
        }

        public JsonResult GetByIdDioInst(string id)
        {
            try
            {
                var genSociety = dbcont.tbl_DioceseInst.FirstOrDefault(e => e.id.ToString() == id);
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
        [HttpPost]
        public ActionResult UpdateDioInst(tbl_DioceseInst tbl_DioceseInst, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.tbl_DioceseInst.FirstOrDefault(e => e.id == tbl_DioceseInst.id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DioInst"), fileName);
                        File.SaveAs(path);
                        tbl_DioceseInst.File = fileName;
                    }
                }
                else
                {
                    tbl_DioceseInst.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    tbl_DioceseInst.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_DioceseInst);
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
        public ActionResult DeleteDioInst(string id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_DioceseInst.FirstOrDefault(e => e.id.ToString() == id);
                if (data != null)
                {
                    dbcont.tbl_DioceseInst.Remove(data);
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
        #region Dio Community
        [HttpPost]
        public ActionResult AddDioCom(tbl_DioceseCom tbl_DioceseCom, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DioInst"), fileName);
                        File.SaveAs(path);
                        tbl_DioceseCom.File = fileName;
                    }
                }
                dbcont.tbl_DioceseCom.Add(tbl_DioceseCom);
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

        [HttpPost]
        public ActionResult AddDioCom12(tbl_DioceseCom tbl_DioceseCom)
        {
            try
            {
                var dioId = dbcont.tbl_Diocese.First(x => x.Id.ToString() == tbl_DioceseCom.DioId.ToString()).DioId; ;
                tbl_DioceseCom.DioId = dioId;
                dbcont.tbl_DioceseCom.Add(tbl_DioceseCom);
                dbcont.SaveChanges();
                setcookies("200");
                return Json("Created successfully !" + "&" + tbl_DioceseCom.id);
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("Created error !" + "&");
            }
        }
        public JsonResult GetByIdDioCom(string id)
        {
            try
            {
                var genSociety = dbcont.tbl_DioceseCom.FirstOrDefault(e => e.id.ToString() == id);
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
        [HttpPost]
        public ActionResult UpdateDioCom(tbl_DioceseCom tbl_DioceseCom, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.tbl_DioceseCom.FirstOrDefault(e => e.id == tbl_DioceseCom.id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DioInst"), fileName);
                        File.SaveAs(path);
                        tbl_DioceseCom.File = fileName;
                    }
                }
                else
                {
                    tbl_DioceseCom.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    tbl_DioceseCom.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_DioceseCom);
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
        public ActionResult DeleteDioCom(string id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_DioceseCom.FirstOrDefault(e => e.id.ToString() == id);
                if (data != null)
                {
                    dbcont.tbl_DioceseCom.Remove(data);
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

        #region Dio Parishes
        [HttpPost]
        public ActionResult AddDioParish(tbl_DioceseParish tbl_DioceseParish, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DioInst"), fileName);
                        File.SaveAs(path);
                        tbl_DioceseParish.File = fileName;
                    }
                }
                tbl_DioceseParish.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_DioceseParish.Add(tbl_DioceseParish);
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

        [HttpPost]
        public ActionResult AddParishByProvince(tbl_ParishByProvince tbl_ParishByProvince, HttpPostedFileBase File)
        {
            //var data = db.tbl_Province.FirstOrDefault(x => x.Id == tbl_ParishByProvince.ProvinceName);
            string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + Convert.ToString(Session["ConRegId"]);
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/ParishByProvince"), fileName);
                        File.SaveAs(path);
                        tbl_ParishByProvince.File = fileName;
                    }
                }
                tbl_ParishByProvince.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_ParishByProvince.Add(tbl_ParishByProvince);
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
        [HttpPost]
        public ActionResult UpdateParishByProvince(tbl_ParishByProvince tbl_ParishByProvince, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + Convert.ToString(Session["ConRegId"]);
            try
            {
                var existingobj = dbcont.tbl_ParishByProvince.FirstOrDefault(e => e.Id == tbl_ParishByProvince.Id);

                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/ParishByProvince"), fileName);
                        File.SaveAs(path);
                        tbl_ParishByProvince.File = fileName;
                    }
                }
                else
                {
                    tbl_ParishByProvince.File = existingobj.File;
                }
                if (existingobj != null)
                {
                    tbl_ParishByProvince.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_ParishByProvince);
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
        public JsonResult GetParishByProvince(string id)
        {
            try
            {
                var genSociety = dbcont.tbl_ParishByProvince.FirstOrDefault(e => e.Id.ToString() == id);
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
        public ActionResult DeleteParishByProvince(string id)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + Convert.ToString(Session["ConRegId"]);
            try
            {
                var data = dbcont.tbl_ParishByProvince.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    dbcont.tbl_ParishByProvince.Remove(data);
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

        #region Land Documents

        [HttpPost]
        public ActionResult AddLandDocumentByProvince(tbl_LandDetailsByProvince tbl_LandDetailsByProvince, HttpPostedFileBase File)
        {
            //var data = db.tbl_Province.FirstOrDefault(x => x.Id == tbl_ParishByProvince.ProvinceName);
            string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + Convert.ToString(Session["ConRegId"]);
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDetailsByProvince"), fileName);
                        File.SaveAs(path);
                        tbl_LandDetailsByProvince.File = fileName;
                    }
                }
                tbl_LandDetailsByProvince.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_LandDetailsByProvince.Add(tbl_LandDetailsByProvince);
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
        [HttpPost]
        public ActionResult UpdateLandDocumentByProvince(tbl_LandDetailsByProvince tbl_LandDetailsByProvince, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + Convert.ToString(Session["ConRegId"]);
            try
            {
                var existingobj = dbcont.tbl_LandDetailsByProvince.FirstOrDefault(e => e.Id == tbl_LandDetailsByProvince.Id);

                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDetailsByProvince"), fileName);
                        File.SaveAs(path);
                        tbl_LandDetailsByProvince.File = fileName;
                    }
                }
                else
                {
                    tbl_LandDetailsByProvince.File = existingobj.File;
                }
                if (existingobj != null)
                {
                    tbl_LandDetailsByProvince.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_LandDetailsByProvince);
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
        public JsonResult GetLandDocumentByProvince(string id)
        {
            try
            {
                var genSociety = dbcont.tbl_LandDetailsByProvince.FirstOrDefault(e => e.Id.ToString() == id);
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
        public ActionResult DeleteLandDocumentByProvince(string id)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + Convert.ToString(Session["ConRegId"]);
            try
            {
                var data = dbcont.tbl_LandDetailsByProvince.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    dbcont.tbl_LandDetailsByProvince.Remove(data);
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

        [HttpPost]
        public ActionResult AddDioParish12(tbl_DioceseParish tbl_DioceseParish)
        {
            try
            {
                tbl_DioceseParish.CreatedBy = Convert.ToString(Session["loginuserid"]);
                var dioId = dbcont.tbl_Diocese.First(x => x.Id.ToString() == tbl_DioceseParish.DioId.ToString()).DioId;
                tbl_DioceseParish.DioId = dioId;
                dbcont.tbl_DioceseParish.Add(tbl_DioceseParish);
                dbcont.SaveChanges();
                setcookies("200");
                return Json("Created successfully !" + "&" + tbl_DioceseParish.Id);
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("Created error !" + "&");
            }
        }

        public JsonResult GetByIdDioParish(string id)
        {
            try
            {
                var genSociety = dbcont.tbl_DioceseParish.FirstOrDefault(e => e.Id.ToString() == id);
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
        [HttpPost]
        public ActionResult UpdateDioParish(tbl_DioceseParish tbl_DioceseParish, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.tbl_DioceseParish.FirstOrDefault(e => e.Id == tbl_DioceseParish.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DioInst"), fileName);
                        File.SaveAs(path);
                        tbl_DioceseParish.File = fileName;
                    }
                }
                else
                {
                    tbl_DioceseParish.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    tbl_DioceseParish.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_DioceseParish);
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
        public ActionResult DeleteDioParish(string id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_DioceseParish.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    dbcont.tbl_DioceseParish.Remove(data);
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

        #region Congregation
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCongregations(tbl_Congregation tbl_Congregation, HttpPostedFileBase[] files,/* HttpPostedFileBase File,*/string[] CongregationCountriesofMission,string[] Names, string[] Days,string[] Months, string[] Title, string[] spanImgName,string Operation,HttpPostedFileBase[] galleyfiles)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;

            try
            {
                if(Operation == "Edit")
                {
                    tbl_Congregation tbl_Cong = dbcont.tbl_Congregation.FirstOrDefault(x => x.CongreId == tbl_Congregation.CongreId);
                    Tbl_InstitutionImportantdates tbl_InstitutionImportantdates = new Tbl_InstitutionImportantdates();
                    List<Tbl_InstitutionImportantdates> Importantdates = dbcont.Tbl_InstitutionImportantdates.Where(x => x.MainID == tbl_Congregation.CongreId).ToList();
                    Tbl_InstituteGallery tbl_InstituteGallery = new Tbl_InstituteGallery();
                    List<Tbl_InstituteGallery> InstituteGallery = dbcont.Tbl_InstituteGallery.Where(x => x.MainID == tbl_Congregation.CongreId).ToList();


                    if(Importantdates.Count > 0)
                    {
                        for(int i = 0; i <Importantdates.Count(); i++)
                        {
                            Tbl_InstitutionImportantdates pastimportantdates = dbcont.Tbl_InstitutionImportantdates.FirstOrDefault(x => x.MainID == tbl_Congregation.CongreId);
                            dbcont.Tbl_InstitutionImportantdates.Remove(pastimportantdates);
                            dbcont.SaveChanges();
                        }
                    }
                    tbl_InstitutionImportantdates.MainID = tbl_Congregation.CongreId;
                    if(Names != null)
                    {
                        for(int j=0; j<Names.Count(); j++)
                        {
                            tbl_InstitutionImportantdates.Name = Names[j];
                            tbl_InstitutionImportantdates.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                            tbl_InstitutionImportantdates.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                            tbl_InstitutionImportantdates.IsActive = 1;
                            dbcont.Tbl_InstitutionImportantdates.Add(tbl_InstitutionImportantdates);
                            dbcont.SaveChanges();

                        }
                    }

                    if(InstituteGallery.Count > 0)
                    {
                        for(int i =0; i<InstituteGallery.Count(); i++)
                        {
                            Tbl_InstituteGallery Gallery = dbcont.Tbl_InstituteGallery.FirstOrDefault(x => x.MainID == tbl_Congregation.CongreId);
                            dbcont.Tbl_InstituteGallery.Remove(Gallery);
                            dbcont.SaveChanges();
                        }
                    }
                    tbl_InstituteGallery.MainID = tbl_Congregation.CongreId;
                    int count = 0;
                    if(spanImgName != null)
                    {
                        for(int k=0; k<spanImgName.Count(); k++)
                        {
                            if(spanImgName[k] != "")
                            {
                                tbl_InstituteGallery.IsActive = 1;
                                tbl_InstituteGallery.FileName = spanImgName[k];
                                tbl_InstituteGallery.Title = Title[count];
                                dbcont.Tbl_InstituteGallery.Add(tbl_InstituteGallery);
                                dbcont.SaveChanges();
                                count++;
                            }
                        }
                    }

                    if(galleyfiles != null)
                    {
                        foreach (var file in galleyfiles)
                        {
                            if (file != null && file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                var path = Path.Combine(Server.MapPath("~/Image/Congationgellery"), fileName);
                                file.SaveAs(path);
                                tbl_InstituteGallery.FileName = fileName;
                                tbl_InstituteGallery.IsActive = 1;

                            }
                            tbl_InstituteGallery.Title = Title[count];
                            dbcont.Tbl_InstituteGallery.Add(tbl_InstituteGallery);
                            dbcont.SaveChanges();
                            count++;
                        }

                    }

                    int fileCnt = 0;
                    foreach (var file in files)
                    {
                        fileCnt++;
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Image/Congation"), fileName);
                            file.SaveAs(path);
                            if (fileCnt == 1)
                                tbl_Congregation.CongregationLogo = fileName;
                            else if (fileCnt == 2)
                                tbl_Congregation.File = fileName;
                        }
                    }
                    dbcont.Entry(tbl_Cong).CurrentValues.SetValues(tbl_Congregation);
                    dbcont.SaveChanges();

                }
                else
                {
                    Tbl_InstitutionImportantdates Instiimportantdates = new Tbl_InstitutionImportantdates();
                    Tbl_InstituteGallery tbl_InstituteGallery = new Tbl_InstituteGallery();
                    if(tbl_Congregation != null)
                    {

                        int fileCnt = 0;
                        foreach (var file in files)
                        {
                            fileCnt++;
                            if (file != null && file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                var path = Path.Combine(Server.MapPath("~/Image/Congation"), fileName);
                                file.SaveAs(path);
                                if (fileCnt == 1)
                                    tbl_Congregation.CongregationLogo = fileName;
                                else if (fileCnt == 2)
                                    tbl_Congregation.File = fileName;
                            }
                        }

                        Instiimportantdates.MainID = tbl_Congregation.CongreId;
                        tbl_InstituteGallery.MainID = tbl_Congregation.CongreId;
                        int i = 0;
                        if (galleyfiles != null)
                        {
                            foreach (var file in galleyfiles)
                            {
                                if (file != null && file.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(file.FileName);
                                    var path = Path.Combine(Server.MapPath("~/Image/Congationgellery"), fileName);
                                    file.SaveAs(path);
                                    tbl_InstituteGallery.FileName = fileName;
                                    tbl_InstituteGallery.IsActive = 1;

                                }
                                tbl_InstituteGallery.Title = Title[i];
                                dbcont.Tbl_InstituteGallery.Add(tbl_InstituteGallery);
                                dbcont.SaveChanges();
                                i++;
                            }

                        }

                        if (Names != null)
                        {
                            for (int j = 0; j < Names.Count(); j++)
                            {
                                Instiimportantdates.Name = Names[j];
                                Instiimportantdates.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                                Instiimportantdates.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                                Instiimportantdates.IsActive = 1;
                                dbcont.Tbl_InstitutionImportantdates.Add(Instiimportantdates);
                                dbcont.SaveChanges();

                            }
                        }


                        tbl_Congregation.CongregationCountriesofMission = CongregationCountriesofMission == null ? "" : String.Join(",", CongregationCountriesofMission);
                        tbl_Congregation.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        dbcont.tbl_Congregation.Add(tbl_Congregation);
                        dbcont.SaveChanges();

                    }
                }
                //if (File != null)
                //{
                //    if (File.ContentLength > 0)
                //    {
                //        var fileName = Path.GetFileName(File.FileName);
                //        var path = Path.Combine(Server.MapPath("~/Image/Congation"), fileName);
                //        File.SaveAs(path);
                //        tbl_Congregation.File = fileName;
                //    }
                //}
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
        public JsonResult GetCongreById(Guid Id)
        {
            try
            {
                var genSociety = dbcont.tbl_Congregation.FirstOrDefault(e => e.Id == Id);
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

        [HttpPost]
        public ActionResult UpdateCongregation(tbl_Congregation tbl_Congregation, HttpPostedFileBase[] files, string[] CongregationCountriesofMission)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.tbl_Congregation.FirstOrDefault(e => e.Id == tbl_Congregation.Id);
                //if (File != null)
                //{
                //    if (File.ContentLength > 0)
                //    {
                //        var fileName = Path.GetFileName(File.FileName);
                //        var path = Path.Combine(Server.MapPath("~/Image/Congation"), fileName);
                //        File.SaveAs(path);
                //        tbl_Congregation.File = fileName;
                //    }
                //}
                //else
                //{
                //    tbl_Congregation.File = existingobj.File;
                //}
                int fileCnt = 0;
                foreach (var file in files)
                {
                    fileCnt++;
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Congation"), fileName);
                        file.SaveAs(path);
                        if (fileCnt == 1)
                            tbl_Congregation.CongregationLogo = fileName;
                        else if (fileCnt == 2)
                            tbl_Congregation.File = fileName;
                    }
                    else
                    {
                        if (fileCnt == 1)
                            tbl_Congregation.CongregationLogo = existingobj.CongregationLogo;
                        else if (fileCnt == 2)
                            tbl_Congregation.File = existingobj.File;
                    }
                }
                tbl_Congregation.CongregationCountriesofMission = CongregationCountriesofMission == null ? "" : String.Join(",", CongregationCountriesofMission);

                if (existingobj != null)
                {
                    tbl_Congregation.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Congregation);
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
        public ActionResult CongreDelete(Guid Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_Congregation.FirstOrDefault(e => e.Id == Id);
                if (data != null)
                {
                    dbcont.tbl_Congregation.Remove(data);
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
        #region Province
        [HttpPost]

        //public ActionResult AddProvince(tbl_Province tbl_Province, HttpPostedFileBase File, string[] Activities)
        //public ActionResult AddProvince(tbl_Province tbl_Province, IEnumerable<HttpPostedFileBase> files, string[] Activities)
        [ValidateInput(false)]
        public ActionResult AddProvince(tbl_Province tbl_Province, HttpPostedFileBase[] files, string[] Activities, string[] ProvinceCountriesofMission, string[] Names, string[] Days, string[] Months)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            tblProvinceImportantDates tblCommunityImportantDatesMain = new tblProvinceImportantDates();
            try
            {
                int fileCnt = 0;
                foreach (var file in files)
                {
                    fileCnt++;
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Province"), fileName);
                        file.SaveAs(path);
                        if (fileCnt == 1)
                            tbl_Province.ProvinceLogo = fileName;
                        else if (fileCnt == 2)
                            tbl_Province.File = fileName;

                    }
                }

                //if (File != null)
                //{
                //    if (File.ContentLength > 0)
                //    {
                //        var fileName = Path.GetFileName(File.FileName);
                //        var path = Path.Combine(Server.MapPath("~/Image/Province"), fileName);
                //        File.SaveAs(path);
                //        tbl_Province.File = fileName;
                //    }
                //}
                tbl_Province.Activities = Activities == null ? "" : String.Join(",", Activities);
                tbl_Province.ProvinceCountriesofMission = ProvinceCountriesofMission == null ? "" : String.Join(",", ProvinceCountriesofMission);
                tbl_Province.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_Province.Add(tbl_Province);
                dbcont.SaveChanges();
                tbl_Province tblProvince = dbcont.tbl_Province.Where(x => x.MyId == (tbl_Province.MyId).ToString()).FirstOrDefault();
                tblCommunityImportantDatesMain.MainID = Convert.ToString(tblProvince.Id);
                if (Names != null)
                {
                    for (int j = 0; j < Names.Count(); j++)
                    {
                        tblCommunityImportantDatesMain.Name = Names[j];
                        tblCommunityImportantDatesMain.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                        tblCommunityImportantDatesMain.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                        tblCommunityImportantDatesMain.IsActive = 1;
                        dbcont.tblProvinceImportantDates.Add(tblCommunityImportantDatesMain);
                        dbcont.SaveChangesAsync();
                    }
                }
                //setcookies("200");
                return RedirectToAction("GetProvienceList", "IdGenerate");

                //return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
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
        public JsonResult GetProvById(Guid Id)
        {
            try
            {
                var genSociety = dbcont.tbl_Province.FirstOrDefault(e => e.Id == Id);
               
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
        public ActionResult ProvinceDelete(Guid Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_Province.FirstOrDefault(e => e.Id == Id);
                if (data != null)
                {
                    dbcont.tbl_Province.Remove(data);
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
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateProvince(tbl_Province tbl_Province, HttpPostedFileBase[] files, /*HttpPostedFileBase File*/ string[] Activities, string[] ProvinceCountriesofMission, string[] Names, string[] Days, string[] Months)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            tblProvinceImportantDates tblCommunityImportantDatesMain = new tblProvinceImportantDates();
            List<tblProvinceImportantDates> tblCommunityImportantDates = dbcont.tblProvinceImportantDates.Where(x => x.MainID == (tbl_Province.Id).ToString()).ToList();
            try
            {
                var existingobj = dbcont.tbl_Province.FirstOrDefault(e => e.Id == tbl_Province.Id);
                //if (File != null)
                //{
                //    if (File.ContentLength > 0)
                //    {
                //        var fileName = Path.GetFileName(File.FileName);
                //        var path = Path.Combine(Server.MapPath("~/Image/Province"), fileName);
                //        File.SaveAs(path);
                //        tbl_Province.File = fileName;
                //    }
                //}
                //else
                //{
                //    tbl_Province.File = existingobj.File;
                //}
                if (tblCommunityImportantDates.Count > 0)
                {
                    for (int i = 0; i < tblCommunityImportantDates.Count; i++)
                    {
                        tblProvinceImportantDates tblCommunityImportantDatesPast = dbcont.tblProvinceImportantDates.Where(x => x.MainID == (tbl_Province.Id).ToString()).FirstOrDefault();
                        dbcont.tblProvinceImportantDates.Remove(tblCommunityImportantDatesPast);
                        dbcont.SaveChanges();
                    }
                }
                tblCommunityImportantDatesMain.MainID = Convert.ToString(tbl_Province.Id);
                if (Names != null)
                {
                    for (int j = 0; j < Names.Count(); j++)
                    {
                        tblCommunityImportantDatesMain.Name = Names[j];
                        tblCommunityImportantDatesMain.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                        tblCommunityImportantDatesMain.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                        tblCommunityImportantDatesMain.IsActive = 1;
                        dbcont.tblProvinceImportantDates.Add(tblCommunityImportantDatesMain);
                        dbcont.SaveChangesAsync();
                    }
                }
                int fileCnt = 0;
                foreach (var file in files)
                {
                    fileCnt++;
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Province"), fileName);
                        file.SaveAs(path);
                        if (fileCnt == 1)
                            tbl_Province.ProvinceLogo = fileName;
                        else if (fileCnt == 2)
                            tbl_Province.File = fileName;
                    }
                    else
                    {
                        if (fileCnt == 1)
                            tbl_Province.ProvinceLogo = existingobj.ProvinceLogo;
                        else if (fileCnt == 2)
                            tbl_Province.File = existingobj.File;
                    }
                }

                if (existingobj != null)
                {
                    tbl_Province.Activities = Activities == null ? "" : String.Join(",", Activities);
                    tbl_Province.ProvinceCountriesofMission = ProvinceCountriesofMission == null ? "" : String.Join(",", ProvinceCountriesofMission);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Province);
                    dbcont.SaveChanges();
                }
                //setcookies("201");
                return RedirectToAction("GetProvienceList", "IdGenerate");

                //return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        #endregion

        #region DistSec
        [HttpPost]
        public ActionResult AddDistSec(tbl_DistSector tbl_DistSector, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DistSec"), fileName);
                        File.SaveAs(path);
                        tbl_DistSector.File = fileName;
                    }
                }
                tbl_DistSector.Activities = Activities == null ? "" : String.Join(",", Activities);
                tbl_DistSector.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_DistSector.Add(tbl_DistSector);
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

        //http://localhost:8089/Home/CongrationList?id=7ad1aa9f-c0b9-ea11-8329-8cec4b7a5447

        [HttpPost]
        public ActionResult AddDistSec1(tbl_DistSector tbl_DistSector, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;

            if (Session["ConRegId"] != null)
                url = this.Request.UrlReferrer.AbsolutePath + "?id=" + Session["ConRegId"].ToString();
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DistSec"), fileName);
                        File.SaveAs(path);
                        tbl_DistSector.File = fileName;
                    }
                }
                tbl_DistSector.Activities = Activities == null ? "" : String.Join(",", Activities);
                tbl_DistSector.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_DistSector.Add(tbl_DistSector);
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


        [HttpPost]
        public ActionResult AddDistSec2(tbl_DistSector tbl_DistSector, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;

            if (Session["ConRegId"] != null)
                url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + Session["ConRegId"].ToString();


            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DistSec"), fileName);
                        File.SaveAs(path);
                        tbl_DistSector.File = fileName;
                    }
                }
                tbl_DistSector.Activities = Activities == null ? "" : String.Join(",", Activities);
                tbl_DistSector.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_DistSector.Add(tbl_DistSector);
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


        [HttpPost]
        public ActionResult AddDistSec22(tbl_DistSector tbl_DistSector)
        {
            try
            {
                tbl_DistSector.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_DistSector.Add(tbl_DistSector);
                dbcont.SaveChanges();
                setcookies("200");
                return Json("Created succesfully !" + "$" + tbl_DistSector.Id);
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("Created error !" + "$");
            }

        }
        public JsonResult GetDistSecById(Guid Id)
        {
            try
            {
                var genSociety = dbcont.tbl_DistSector.FirstOrDefault(e => e.Id == Id);
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
        public ActionResult DistSecDelete(Guid Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_DistSector.FirstOrDefault(e => e.Id == Id);
                if (data != null)
                {
                    dbcont.tbl_DistSector.Remove(data);
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
        [HttpPost]
        public ActionResult UpdateDistSec(tbl_DistSector tbl_DistSector, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.tbl_DistSector.FirstOrDefault(e => e.Id == tbl_DistSector.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/DistSec"), fileName);
                        File.SaveAs(path);
                        tbl_DistSector.File = fileName;
                    }
                }
                else
                {
                    tbl_DistSector.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    tbl_DistSector.CreatedBy = existingobj.CreatedBy;
                    tbl_DistSector.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_DistSector);
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
        #endregion

        #region Community
        [HttpPost]
        public ActionResult AddCongrations(Tbl_Cong Tbl_Cong, HttpPostedFileBase File, string[] Activities)
        {
            try
            {
                var existingobj = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id == Tbl_Cong.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                        File.SaveAs(path);
                        Tbl_Cong.File = fileName;
                    }
                }
                Tbl_Cong.CreatedBy = Convert.ToString(Session["loginuserid"]);
                Tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                dbcont.Tbl_Cong.Add(Tbl_Cong);
                dbcont.SaveChanges();
                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Record Update Successfully!');location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Some Error Occure!');location.replace('" + url + "')</script>");
            }

        }
        public JsonResult GetCongById(Guid Id)
        {
            try
            {
                var genSociety = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id == Id);
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
        [HttpPost]
        public ActionResult UpdateCongrigation(Tbl_Cong Tbl_Cong, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id == Tbl_Cong.Id);

                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/CommunitiesSocialCentresDoc"), fileName);
                        File.SaveAs(path);
                        Tbl_Cong.File = fileName;
                    }
                }
                else
                {
                    Tbl_Cong.File = existingobj.File;
                }
                if (existingobj != null)
                {
                    Tbl_Cong.CreatedBy = existingobj.CreatedBy;
                    Tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_Cong);
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
        public ActionResult CongDelete(Guid Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id == Id);
                if (data != null)
                {
                    dbcont.Tbl_Cong.Remove(data);
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

        #region Society
        [HttpPost]
        public ActionResult AddSociety(Societys Societys, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?id=" + Societys.EnterbyId;
            try
            {
                var existingobj = dbcont.Societys.FirstOrDefault(e => e.Id == Societys.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Sociert"), fileName);
                        File.SaveAs(path);
                        Societys.File = fileName;
                    }
                }
                Societys.Activities = Activities == null ? "" : String.Join(",", Activities);
                Societys.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Societys.Add(Societys);
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
        public JsonResult GetSocietyById(int id)
        {
            try
            {
                var genSociety = dbcont.Societys.FirstOrDefault(e => e.Id == id);
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
        [HttpPost]
        public ActionResult UpdateSociety(Societys Societys, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Societys.FirstOrDefault(e => e.Id == Societys.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Sociert"), fileName);
                        File.SaveAs(path);
                        Societys.File = fileName;
                    }
                }
                else
                {
                    Societys.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    Societys.Activities = Activities == null ? "" : String.Join(",", Activities);
                    Societys.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Societys);
                    dbcont.SaveChanges();
                    setcookies("201");
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
        public ActionResult SocietyDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Societys.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Societys.Remove(data);
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

        [HttpPost]
        public ActionResult AddSociety1(Societys Societys, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + Societys.EnterbyId;
            try
            {
                var existingobj = dbcont.Societys.FirstOrDefault(e => e.Id == Societys.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Sociert"), fileName);
                        File.SaveAs(path);
                        Societys.File = fileName;
                    }
                }
                Societys.Activities = Activities == null ? "" : String.Join(",", Activities);
                Societys.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Societys.Add(Societys);
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
        public JsonResult GetSocietyById1(int id)
        {
            try
            {
                var genSociety = dbcont.Societys.FirstOrDefault(e => e.Id == id);
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
        [HttpPost]
        public ActionResult UpdateSociety1(Societys Societys, HttpPostedFileBase File, string[] Activities)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Societys.FirstOrDefault(e => e.Id == Societys.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Sociert"), fileName);
                        File.SaveAs(path);
                        Societys.File = fileName;
                    }
                }
                else
                {
                    Societys.File = existingobj.File;
                }

                if (existingobj != null)
                {
                    Societys.Activities = Activities == null ? "" : String.Join(",", Activities);
                    Societys.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Societys);
                    dbcont.SaveChanges();
                    setcookies("201");
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
        public ActionResult SocietyDelete1(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Societys.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Societys.Remove(data);
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
        #region Diocese
        [HttpPost]
        public ActionResult AddDiocese(tbl_Diocese tbl_Diocese, HttpPostedFileBase FileDio, string[] State)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (FileDio != null)
                {
                    if (FileDio.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileDio.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Diocese"), fileName);
                        FileDio.SaveAs(path);
                        tbl_Diocese.FileDio = fileName;
                    }
                }
                tbl_Diocese.State = State == null ? "" : String.Join(",", State);
                tbl_Diocese.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_Diocese.Add(tbl_Diocese);
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
        public JsonResult GetDioceseById(string Id)
        {
            try
            {
                var diodata = dbcont.tbl_Diocese.FirstOrDefault(e => e.Id.ToString() == Id);
                if (diodata != null)
                {
                    return Json(diodata, JsonRequestBehavior.AllowGet);
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
        public ActionResult DioceseDelete(string Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_Diocese.FirstOrDefault(e => e.Id.ToString() == Id);
                if (data != null)
                {
                    dbcont.tbl_Diocese.Remove(data);
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
        [HttpPost]
        public ActionResult UpdateDiocese(tbl_Diocese tbl_Diocese, HttpPostedFileBase FileDio)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.tbl_Diocese.FirstOrDefault(e => e.Id == tbl_Diocese.Id);
                if (FileDio != null)
                {
                    if (FileDio.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileDio.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Diocese"), fileName);
                        FileDio.SaveAs(path);
                        tbl_Diocese.FileDio = fileName;
                    }
                }
                else
                {
                    tbl_Diocese.FileDio = existingobj.FileDio;
                }

                if (existingobj != null)
                {
                    tbl_Diocese.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Diocese);
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
        #endregion
        public JsonResult SaveDioceseData(tbl_Diocese tbl_Diocese)
        {
            tbl_Diocese.CreatedBy = Convert.ToString(Session["loginuserid"]);
            dbcont.tbl_Diocese.Add(tbl_Diocese);
            dbcont.SaveChanges();
            var allRecords = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active")
             .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).ToList();
            return Json(allRecords, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddDiocese1(tbl_Diocese tbl_Diocese, HttpPostedFileBase FileDio)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (FileDio != null)
                {
                    if (FileDio.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileDio.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Diocese"), fileName);
                        FileDio.SaveAs(path);
                        tbl_Diocese.FileDio = fileName;
                    }
                }
                tbl_Diocese.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_Diocese.Add(tbl_Diocese);
                dbcont.SaveChanges();
                setcookies("208");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        #region staff
        [HttpPost]
        public ActionResult AddStaff(StaffDetails StaffDetails, string[] Designation)
        {
            string url = this.Request.UrlReferrer.AbsolutePath + "?id=" + StaffDetails.EnterbyId;
            try
            {
                StaffDetails.Designation = Designation == null ? "" : String.Join(",", Designation);
                StaffDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.StaffDetails.Add(StaffDetails);
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
        public JsonResult GetStaffById(int id)
        {
            try
            {
                var data = dbcont.StaffDetails.FirstOrDefault(e => e.Id == id);
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
        [HttpPost]
        public ActionResult StaffUpdate(StaffDetails StaffDetails, string[] Designation)
        {
            //string url = this.Request.UrlReferrer.AbsolutePath + "?id=" + StaffDetails.EnterbyId;
            string url = this.Request.UrlReferrer.AbsolutePath + "?id=" + StaffDetails.EnterbyId;
            string url2 = this.Request.UrlReferrer.PathAndQuery;
            try
            {
                var existingobj = dbcont.StaffDetails.FirstOrDefault(e => e.Id == StaffDetails.Id);
                if (existingobj != null)
                {
                    StaffDetails.Designation = Designation == null ? "" : String.Join(",", Designation);
                    StaffDetails.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(StaffDetails);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url2 + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url2 + "')</script>");
                throw;
            }
        }
        public ActionResult StaffDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.StaffDetails.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.StaffDetails.Remove(data);
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

        [HttpPost]
        public ActionResult AddStaff1(StaffDetails StaffDetails, string[] Designation, HttpPostedFileBase File)
        {
            //string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + StaffDetails.EnterbyId;
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var fileName = string.Empty;

                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Primarydetails"), fileName);
                        File.SaveAs(path);
                        StaffDetails.File = fileName;   //pan document file1 for the name
                    }
                }
                StaffDetails.Designation = Designation == null ? "" : String.Join(",", Designation);
                StaffDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.StaffDetails.Add(StaffDetails);
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
        public JsonResult GetStaffById1(int id)
        {
            try
            {
                var data = dbcont.StaffDetails.FirstOrDefault(e => e.Id == id);
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
        [HttpPost]
        public ActionResult StaffUpdate1(StaffDetails StaffDetails, string[] Designation)
        {
            // string url = this.Request.UrlReferrer.AbsolutePath + "?myId=" + StaffDetails.EnterbyId;
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.StaffDetails.FirstOrDefault(e => e.Id == StaffDetails.Id);
                if (existingobj != null)
                {
                    StaffDetails.Designation = Designation == null ? "" : String.Join(",", Designation);
                    StaffDetails.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(StaffDetails);
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
        public ActionResult StaffDelete1(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.StaffDetails.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.StaffDetails.Remove(data);
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

        public JsonResult GetAllDioceseNameCong()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_Diocese
                         .Where(x => x.ActiveCkeck == "Active" /*&& x.CreatedBy == currentloginid*/)
                         .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult GetAllDioceseNameCongnit()
        //{
        //    string currentloginid = Convert.ToString(Session["loginuserid"]);
        //    string currentUser = Convert.ToString(Session["username"]);
        //    if (Session["username"].ToString() == "admin")
        //    {
        //        var allRecords = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active")
        //                          .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
        //        return Json(allRecords, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        var allRecords = dbcont.tbl_Diocese
        //                 .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
        //                 .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
        //        return Json(allRecords, JsonRequestBehavior.AllowGet);
        //    }
        //}
        public JsonResult GetAllDioceseNameCong1()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            //if (session["username"].tostring() == "admin")
            {
                var allRecords = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            //else
            //{
            //    var allRecords = dbcont.tbl_Diocese
            //             .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
            //             .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
            //    return Json(allRecords, JsonRequestBehavior.AllowGet);
            //}
        }
        public JsonResult GetAllDioceseNameCong21()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_Diocese
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                         .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllDioceseNameCong2()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_Diocese
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                         .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DioceseNameProv()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_Diocese
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                         .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DDDioceseParish(string Id)
        {
            //var dioId = dbcont.tbl_Diocese.FirstOrDefault(x => x.Id.ToString() == Id).DioId;---old Code
            var dioId = dbcont.tbl_Diocese.Where(x => x.Id.ToString() == Id).FirstOrDefault();
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                if (dioId != null)
                {
                    var allRecords = dbcont.tbl_DioceseParish.Where(x => x.DioId == dioId.DioId)
                                  .Select(x => new { x.ParishName, x.Id }).OrderBy(x => x.ParishName).ToList();
                    return Json(allRecords, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return null;
                }
                    
            }
            else
            {
                if (dioId != null)
                {
                    var allRecords = dbcont.tbl_DioceseParish
                         .Where(x => x.DioId == dioId.DioId && x.CreatedBy == currentloginid)
                         .Select(x => new { x.ParishName, x.Id }).OrderBy(x => x.ParishName).ToList();
                    return Json(allRecords, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return null;
                }
            }
        }
        public JsonResult DioceseNameParish()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_DioceseParish
                                  .Select(x => new { x.ParishName, x.ProvinceName, x.Id }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_Diocese
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                         .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DioceseNameCOS()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.ProvinceName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_Diocese
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                         .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.ProvinceName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DioceseNameDisSec()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_Diocese
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                         .Select(x => new { x.DioceseName, x.ProvinceName, x.Id, x.Place }).OrderBy(x => x.DioceseName).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllDisSec()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DistSecName, x.Id, x.Place }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_DistSector
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                         .Select(x => new { x.DistSecName, x.Id, x.Place }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllDisSec1()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DistSecName, x.Id, x.Place }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_DistSector
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                         .Select(x => new { x.DistSecName, x.Id, x.Place }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllDisSec2()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.DistSecName, x.Id, x.Place }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_DistSector
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                         .Select(x => new { x.DistSecName, x.Id, x.Place }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllSociety()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.Societys.Where(x => x.ActiveCkeck == "Active")
                                  .Select(x => new { x.NameOfTheSocity, x.Id }).OrderBy(x => x.NameOfTheSocity).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.Societys
                         .Where(x => x.ActiveCkeck == "Active" && x.CreatedBy == currentloginid)
                           .Select(x => new { x.NameOfTheSocity, x.Id }).OrderBy(x => x.NameOfTheSocity).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllParish()
        {
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ActiveCkeck == "Active" && x.Type == "Paris")
                                  .Select(x => new { x.Name, x.Id }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.Tbl_ParisInstitutionDetails
                         .Where(x => x.ActiveCkeck == "Active" && x.Type == "Paris" && x.CreatedBy == currentloginid)
                           .Select(x => new { x.Name, x.Id }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        //getViewPopupdata
        public JsonResult GetAllGeneralateById1(string id)
        {
            var personalDetails = dbcont.tbl_Congregation.Where(x => x.Id.ToString() == id).ToList();
            List<tbl_Congregation> AllDatas = new List<tbl_Congregation>();

            foreach (var item in personalDetails)
            {
                AllDatas.Add(new tbl_Congregation
                {
                    CongregationName = item.CongregationName,
                    Establishment = item.Establishment,
                    Email = item.Email,
                    Diocese = GetDioceseData(item.Diocese),
                    Website = item.Website,
                    Phone = item.Phone,
                    Fax = item.Fax,
                    Country = item.Country,
                    Address = item.Address,
                    Activities = item.Activities,
                    History = item.History,
                    Vission = item.Vission,
                    Mission = item.Mission,
                    File = item.File,
                    NameofFounder = item.NameofFounder,
                    NameofCoFounder = item.NameofCoFounder,
                    CongregationMotto = item.CongregationMotto,
                    CongregationLogo = item.CongregationLogo,
                    CongregationCountriesofMission = item.CongregationCountriesofMission,
                });
            }
            return Json(AllDatas, JsonRequestBehavior.AllowGet);
        }
        public string GetDioceseData(string diocesename)
        {
            List<string> DioceseNames = new List<string>();
            var tbl_Diocese = dbcont.tbl_Diocese;
            string[] diocesename1 = diocesename == null ? new string[0] : diocesename.Split(',');
            foreach (var parish in diocesename1)
            {
                var data = tbl_Diocese.FirstOrDefault(x => x.Id.ToString() == parish);
                if (data != null)
                {
                    DioceseNames.Add(data.DioceseName);
                }
            }
            return String.Join(",", DioceseNames);
        }
        public string GetDisSecData(string DistSecname)
        {
            List<string> DistSecName = new List<string>();
            var tbl_DistSector = dbcont.tbl_DistSector;
            if (DistSecname != null)
            {
                string[] DistSecname1 = DistSecname.Split(',');
                foreach (var sector in DistSecname1)
                {
                    var data = tbl_DistSector.FirstOrDefault(x => x.Id.ToString() == sector);
                    if (data != null)
                    {
                        DistSecName.Add(data.DistSecName);
                    }
                }
            }
            return String.Join(",", DistSecName);
        }
        public string GetProvinceData(string provname)
        {
            List<string> ProvinceNames = new List<string>();
            var tbl_Province = dbcont.tbl_Province;
            string[] provname1 = provname.Split(',');
            foreach (var province in provname1)
            {
                var data = tbl_Province.FirstOrDefault(x => x.Id.ToString() == province);
                if (data != null)
                {
                    ProvinceNames.Add(data.ProvinceName);
                }
            }
            return String.Join(",", ProvinceNames);
        }
        public string GetParishData(string parishname)
        {
            List<string> ParishNames = new List<string>();
            var Tbl_ParisInstitutionDetails = dbcont.Tbl_ParisInstitutionDetails;
            string[] parishname1 = parishname == null ? new string[0] : parishname.Split(',');
            foreach (var parish in parishname1)
            {
                var data = Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.Id.ToString() == parish);
                if (data != null)
                {
                    ParishNames.Add(data.Name);
                }
            }
            return String.Join(",", ParishNames);
        }
        public string GetSocietyData(string Societyname)
        {
            List<string> SocietyName = new List<string>();
            var Societies = dbcont.Societys;
            string[] Societyname1 = Societyname.Split(',');
            foreach (var Society in Societyname1)
            {
                var data = Societies.FirstOrDefault(x => x.Id.ToString() == Society);
                if (data != null)
                {
                    SocietyName.Add(data.NameOfTheSocity);
                }
            }
            return String.Join(",", SocietyName);
        }
        public JsonResult GetAllProvinceById1(string id)
        {
            var personalDetails = dbcont.tbl_Province.Where(x => x.Id.ToString() == id).ToList();
            List<tbl_Province> allFormationD = new List<tbl_Province>();
            foreach (var item in personalDetails)
            {
                if (item.Diocese == "0" || item.Diocese != null)
                {
                    allFormationD.Add(new tbl_Province
                    {
                        DisSec = GetDisSecData(item.DisSec),
                        Place1 = item.Place1,
                        ProvinceName = item.ProvinceName,
                        Place = item.Place,
                        EmailId = item.EmailId,
                        Country = item.Country,
                        Phone = item.Phone,                        
                        Fax = item.Fax,
                        ActiveCkeck = item.ActiveCkeck,
                        Diocese = GetDioceseData(item.Diocese),
                        Activities = item.Activities,
                        History = item.History,
                        Vission = item.Vission,
                        Mission = item.Mission,
                        File = item.File,
                        ProvinceLogo = item.ProvinceLogo,
                        ProvinceMotto = item.ProvinceMotto,
                        ProvinceCountriesofMission = item.ProvinceCountriesofMission
                    });
                }
            }
            return Json(allFormationD, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDistSecById1(string id)
        {
            var personalDetails = dbcont.tbl_DistSector.Where(x => x.Id.ToString() == id).ToList();
            List<tbl_DistSector> allFormationD = new List<tbl_DistSector>();
            foreach (var item in personalDetails)
            {
                allFormationD.Add(new tbl_DistSector
                {
                    DisSec = item.DisSec,
                    DistSecName = item.DistSecName,
                    EmailId = item.EmailId,
                    Country = item.Country,
                    ActiveCkeck = item.ActiveCkeck,
                    Diocese = GetDioceseData(item.Diocese),
                    ProvinceName = GetProvinceData(item.ProvinceName),
                    Activities = item.Activities,
                    History = item.History,
                    Vission = item.Vission,
                    Mission = item.Mission,
                    File = item.File
                });
            }
            return Json(allFormationD, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllCongOutSideById1(string id)
        {
            var personalDetails = dbcont.ComOutSide.Where(x => x.Id.ToString() == id).ToList();
            List<ComOutSide> allFormationD = new List<ComOutSide>();
            foreach (var item in personalDetails)
            {
                allFormationD.Add(new ComOutSide
                {
                    OtherProvince = item.OtherProvince,
                    Phone = item.Phone,
                    EmailId = item.EmailId,
                    Country = item.Country,
                    ActiveCkeck = item.ActiveCkeck,
                    Diocese = GetDioceseData(item.Diocese),
                    Activities = item.Activities,
                    CommunityName = item.CommunityName,
                    MyId = item.MyId,
                    Place = item.Place,
                    File = item.File
                });
            }
            return Json(allFormationD, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllComHouseById1(string id)
        {
            var personalDetails = dbcont.ComHouse.Where(x => x.Id.ToString() == id).ToList();
            List<ComHouse> allFormationD = new List<ComHouse>();
            foreach (var item in personalDetails)
            {
                allFormationD.Add(new ComHouse
                {
                    DisSec = GetDisSecData(item.DisSec),
                    OtherProvince = item.OtherProvince,
                    CommunityName = item.CommunityName,
                    CommunityCode = item.CommunityCode,
                    Phone = item.Phone,
                    Place = item.Place,
                    EmailId = item.EmailId,
                    Country = item.Country,
                    ActiveCkeck = item.ActiveCkeck,
                    Diocese = GetDioceseData(item.Diocese),
                    Activities = item.Activities,
                    File = item.File
                });
            }
            return Json(allFormationD, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllDioceseById1(string id)
        {
            var personalDetails = dbcont.tbl_Diocese.Where(x => x.Id.ToString() == id).ToList();
            List<tbl_Diocese> allFormationD = new List<tbl_Diocese>();
            foreach (var item in personalDetails)
            {
                allFormationD.Add(new tbl_Diocese
                {
                    ProvinceName = GetProvinceData(item.ProvinceName),
                    State = item.State,
                    Place = item.Place,
                    EmailId = item.EmailId,
                    Country = item.Country,
                    ActiveCkeck = item.ActiveCkeck,
                    DioceseName = item.DioceseName,
                    FileDio = item.FileDio
                });
            }
            return Json(allFormationD, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllGenMeetingById1(string id)
        {
            var personalDetails = dbcont.Tbl_CongrationsDatas.FirstOrDefault(x => x.id.ToString() == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllInstitutionById1(string id)
        {
            var personalDetails = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Id.ToString() == id).ToList();
            List<Tbl_ParisInstitutionDetails> AllDatas = new List<Tbl_ParisInstitutionDetails>();
            foreach (var item in personalDetails)
            {
                AllDatas.Add(new Tbl_ParisInstitutionDetails
                {
                    DisSec = GetDisSecData(item.DisSec),
                    InstitutionType = item.InstitutionType,
                    Name = item.Name,
                    Place = item.Place,
                    YearOfEstablacement = item.YearOfEstablacement,
                    Telephone = item.Telephone,
                    Country = item.Country,
                    EmailId = item.EmailId,
                    ActiveCkeck = item.ActiveCkeck,
                    Diocese = GetDioceseData(item.Diocese),
                    Activities = item.Activities,
                    ParisId = GetParishData(item.ParisId),
                    SocietyId = GetSocietyData(item.SocietyId),
                    RegistrationNo = item.RegistrationNo,
                    DiscCode = item.DiscCode,
                    TypeCode = item.TypeCode,
                    RegIdCode = item.RegIdCode,
                    BEORegCode = item.BEORegCode,
                    CertificationCode = item.CertificationCode,
                    Address = item.Address,
                    Vission = item.Vission,
                    Mission = item.Mission,
                    FileName = item.FileName,
                    OtherDoc = item.OtherDoc,
                });
            }
            return Json(AllDatas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllInstitutionById11(string id)
        {
            var personalDetails = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Id.ToString() == id).ToList();
            List<Tbl_ParisInstitutionDetails> AllDatas = new List<Tbl_ParisInstitutionDetails>();
            foreach (var item in personalDetails)
            {
                AllDatas.Add(new Tbl_ParisInstitutionDetails
                {
                    Name = item.Name,
                    TypesOfReg = item.TypesOfReg,
                    Place = item.Place,
                    Telephone = item.Telephone,
                    YearOfEstablacement = item.YearOfEstablacement,
                    ActiveCkeck = item.ActiveCkeck,
                    Diocese = GetDioceseData(item.Diocese),
                    Activities = item.Activities,
                    Address = item.Address,
                    Vission = item.Vission,
                    Mission = item.Mission,
                    FileName = item.FileName,
                });
            }
            return Json(AllDatas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllCommunityById1(string id)
        {
            var personalDetails = dbcont.Tbl_GeneralCommunity.Where(x => x.Id.ToString() == id).ToList();
            List<Tbl_Cong> AllDatas = new List<Tbl_Cong>();
            foreach (var item in personalDetails)
            {
                AllDatas.Add(new Tbl_Cong
                {
                    Id = item.Id,
                    DisSec = GetDisSecData(item.DisSec),
                    CommCode = item.CommCode,
                    CongregationName = item.CongregationName,
                    Place = item.Place,
                    Phone = item.Phone,
                    Country = item.Country,
                    EmailId = item.EmailId,
                    ActiveCkeck = item.ActiveCkeck,
                    Diocese = GetDioceseData(item.Diocese),
                    Address = item.Address,
                    Activities = item.Activities,
                    Vission = item.Vission,
                    Mission = item.Mission,
                    File = item.File,
                });
            }
            return Json(AllDatas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllCommunityMembersById(string Id)
        {
            List<Appointments> AllDatas = new List<Appointments>();
            if (!string.IsNullOrEmpty(Id))
            {
                var communityName = dbcont.Tbl_Cong.Where(x => x.Id.ToString() == Id).FirstOrDefault().CongregationName;
                AllDatas = dbcont.Appointments.Where(x => x.CommunityType.Contains(communityName) && x.Status == "Active").ToList();
            }
            
            return Json(AllDatas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllCommunitydatabase()
        {
            Uri myUri = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string topid = HttpUtility.ParseQueryString(myUri.Query).Get("id");

            var personalDetails = dbcont.Tbl_Cong.Where(x => x.Id.ToString() == topid).ToList();
            List<Tbl_Cong> AllDatas = new List<Tbl_Cong>();
            foreach (var item in personalDetails)
            {
                AllDatas.Add(new Tbl_Cong
                {
                    Id = item.Id,
                    DisSec = GetDisSecData(item.DisSec),
                    CommCode = item.CommCode,
                    CongregationName = item.CongregationName,
                    Place = item.Place,
                    Phone = item.Phone,
                    Country = item.Country,
                    EmailId = item.EmailId,
                    ActiveCkeck = item.ActiveCkeck,
                    Diocese = GetDioceseData(item.Diocese),
                    Address = item.Address,
                    Activities = item.Activities,
                    Vission = item.Vission,
                    Mission = item.Mission,
                    File = item.File,
                });
            }
            return Json(AllDatas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllSocietyById1(string id)
        {
            var personalDetails = dbcont.Societys.Where(x => x.Id.ToString() == id).ToList();
            List<Societys> AllDatas = new List<Societys>();
            foreach (var item in personalDetails)
            {
                AllDatas.Add(new Societys
                {
                    DisSec = GetDisSecData(item.DisSec),
                    NameOfTheSocity = item.NameOfTheSocity,
                    TypesOfReg = item.TypesOfReg,
                    Date = item.Date,
                    RegistrationNumber = item.RegistrationNumber,
                    PanNumber = item.PanNumber,
                    Diocese = GetDioceseData(item.Diocese),
                    Activities = item.Activities,
                    ActiveCkeck = item.ActiveCkeck,
                    FCRANumber = item.FCRANumber,
                    Number12A = item.Number12A,
                    Number12AA = item.Number12AA,
                    Number80G = item.Number80G,
                    Vission = item.Vission,
                    Mission = item.Mission,
                    File = item.File,
                    Address = item.Address,
                });
            }
            return Json(AllDatas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllStaffDetailsById1(string id)
        {
            var personalDetails = dbcont.StaffDetails.FirstOrDefault(x => x.Id.ToString() == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllTransferById1(string id)
        {
            var personalDetails = dbcont.Tbl_Transfer.Where(x => x.Id.ToString() == id).ToList();
            List<Tbl_Transfer> AllDatas = new List<Tbl_Transfer>();
            foreach (var item in personalDetails)
            {
                AllDatas.Add(new Tbl_Transfer
                {
                    CreatedDate = item.CreatedDate,
                    BrotherName = item.BrotherName,
                    OldProvinceName = item.OldProvinceName,
                    NewProvinceName = item.NewProvinceName,

                });
            }
            return Json(AllDatas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllHVById1(string id)
        {
            var personalDetails = dbcont.tbl_HomeVisit.FirstOrDefault(x => x.Id.ToString() == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllRenewalById1(string id)
        {
            List<Tbl_RenewalVows> AllRenewalVows = new List<Tbl_RenewalVows>();
            List<Tbl_RenewalVows> alldata = new List<Tbl_RenewalVows>();
            AllRenewalVows = dbcont.Tbl_RenewalVows.Where(x => x.Id.ToString() == id).ToList();
            var allProvince = dbcont.tbl_Province.ToList();
            foreach (var item in AllRenewalVows)
            {
                var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);
                alldata.Add(new Tbl_RenewalVows
                {
                    Name = item.Name,
                    FileNo = item.FileNo,
                    Surname = item.Surname,
                    Superior = item.Superior,
                    Duration = item.Duration,
                    Witness = item.Witness,
                    RenVowsDoc = item.RenVowsDoc,
                    ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName
                });
            }
            return Json(alldata, JsonRequestBehavior.AllowGet);
        }
        public void setcookies(string code)
        {
            HttpCookie cookie = new HttpCookie("iscode", code);
            Response.Cookies.Add(cookie);
        }
        public ActionResult IdGeneratorNew(string memberId,string Id)
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentlogin = Convert.ToString(Session["loginuserid"]);
            ViewBag.ProvinceId = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").Count() + 1;
            ViewBag.DisSecId = dbcont.tbl_DistSector.Count() + 1;
            ViewBag.ComOutSide = dbcont.ComOutSide.Count() + 1;
            ViewBag.ComHouses123 = dbcont.ComHouse.Count() + 1;
            ViewBag.CongreId = dbcont.tbl_Congregation.Count() + 1;
            ViewBag.CommId = dbcont.Tbl_Cong.Count() + 1;
            ViewBag.InstitutionId = "AutoGen";
            //ViewBag.InstitutionId = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Institution").Count() + 1;
            ViewBag.PerisId = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Paris").Count() + 1;
            ViewBag.SocietyId = dbcont.Societys.Count() + 1;
            ViewBag.DioceseId = dbcont.tbl_Diocese.Count() + 1;
            if(Id != null && Id != "")
            {
                List<tblProvinceImportantDates> tblCommunityImportantDates = dbcont.tblProvinceImportantDates.Where(x => x.MainID == (Id).ToString()).ToList();
                ViewBag.tblProvinceImportantDates = JsonConvert.SerializeObject(tblCommunityImportantDates);
                ViewBag.EditId = Id;
            }
            else
            {
                ViewBag.tblProvinceImportantDates = "NoData";
                ViewBag.EditId = "";
            }
            //PrishView
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.Paris = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Paris").ToList();
            }
            else
            {
                ViewBag.Paris = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ProvinceName == currentUser && x.Type == "Paris").ToList();
            }

            //SocietyView  
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.Society = dbcont.Societys.ToList();
            }
            else
            {
                ViewBag.Society = dbcont.Societys.Where(x => x.ProvinceName == currentUser).ToList();
            }

            //InstituteView
            if (Session["username"].ToString() == "admin")
            {
                var allins = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Institution").ToList();
                ViewBag.allinstitution = allins;
            }
            else
            {
                var allins = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ProvinceName == currentUser && x.Type == "Institution").ToList();
                ViewBag.allinstitution = allins;
            }

            //ParishView
            if (Session["username"].ToString() == "admin")
            {
                var allParish = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Paris").ToList();
                ViewBag.Parish = allParish;
            }
            else
            {
                var allins = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ProvinceName == currentUser && x.Type == "Paris").ToList();
                ViewBag.Parish = allins;
            }

            //Province Viewtbl_Province
            if (Session["username"].ToString() == "admin")
            {
                var AllProvince = dbcont.tbl_Province.ToList();
                ViewBag.AllProvince = AllProvince;
            }
            else
            {
                var AllProvince = dbcont.tbl_Province.Where(x => x.Id.ToString() == currentUser).ToList();
                ViewBag.AllProvince = AllProvince;
            }

            var AllRegType = dbcont.DataListItems.Where(x => x.DataListName == "RegistrationType").ToList();
            ViewBag.AllRegType = AllRegType;

            var allDataListItems = dbcont.DataLists.ToList();
            ViewBag.allDataListItems = allDataListItems;

            var countryDataListItems = dbcont.DataLists.Where(x => x.Name.ToLower() == "country").ToList();
            ViewBag.CoutryDataListItems = countryDataListItems;

            var activitiesDataListItems = dbcont.DataLists.Where(x => x.Name.ToLower() == "activities").ToList();
            ViewBag.ActivitiesDataListItems = activitiesDataListItems;

            //CommunityView
            if (Session["username"].ToString() == "admin")
            {
                var allComm = dbcont.Tbl_Cong.ToList();
                ViewBag.Community = allComm;
            }
            else
            {
                var allComm = dbcont.Tbl_Cong.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.Community = allComm;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allCommOutside = dbcont.ComOutSide.ToList();
                ViewBag.allCommOutside = allCommOutside;
            }
            else
            {
                var allCommOutside = dbcont.ComOutSide.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allCommOutside = allCommOutside;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allCommOutsideInst = dbcont.tbl_ComOSInstitute.ToList();
                ViewBag.allCommOutsideInst = allCommOutsideInst;
            }
            else
            {
                var allCommOutsideInst = dbcont.tbl_ComOSInstitute.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allCommOutsideInst = allCommOutsideInst;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allDioInst = dbcont.tbl_DioceseInst.ToList();
                ViewBag.allDioInst = allDioInst;
            }
            else
            {
                var allDioInst = dbcont.tbl_DioceseInst.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allDioInst = allDioInst;
            }

            if (Session["username"].ToString() == "admin")
            {
                var ComHouse = dbcont.ComHouse.ToList();
                ViewBag.ComHouse = ComHouse;
            }
            else
            {
                var ComHouse = dbcont.ComHouse.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.ComHouse = ComHouse;
            }

            //CongregationView
            var allCong = dbcont.tbl_Congregation.ToList();
            ViewBag.congregation = allCong;

            //ProvinceView
            if (Session["loginuserid"].ToString() == "admin")
            {
                var allProv = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
                ViewBag.Province = allProv;
            }
            else
            {
                var allProv = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == currentUser).ToList();
                ViewBag.Province = allProv;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allDio = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active").ToList();
                ViewBag.AllDiocese = allDio;
            }
            else
            {
                var allDio = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == currentUser).ToList();
                ViewBag.AllDiocese = allDio;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allDisSec = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active").ToList();
                ViewBag.DistSector = allDisSec;
            }
            else
            {
                var allDisSec = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == currentUser).ToList();
                ViewBag.DistSector = allDisSec;
            }

            var allInstitution = dbcont.DataListItems.Where(x => x.DataListName == "Institution").OrderBy(x => x.Name).ToList();
            ViewBag.InstitutionType = allInstitution;

            var pertionalPrimaryInfo = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.Id.ToString() == memberId);
            ViewBag.Tbl_ParisInstitutionDetails = pertionalPrimaryInfo;

            var AllActivities = dbcont.DataListItems.Where(x => x.DataListName == "Activities").OrderBy(x => x.Name).OrderBy(x => x.Name).ToList();
            ViewBag.AllActivities = AllActivities;

            var countryList = dbcont.DataListItems.Where(x => x.DataListName == "Country").OrderBy(x => x.Name).OrderBy(x => x.Name).ToList();
            ViewBag.CountriesofMission = countryList;
            ViewBag.Country = countryList;

            var AllDataTypes = dbcont.DataListItems.Where(x => x.DataListName == "DistTypes").ToList();
            ViewBag.AllDataTypes = AllDataTypes;

            var allsociety = dbcont.Societys.ToList();

            string currentuserid = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.DataListItems.Where(x => x.DataListName == "State").ToList();
                ViewBag.State = allRecords;
            }

            else
            {
                var allRecords = dbcont.DataListItems.Where(x => x.DataListName == "State" && x.CreatedBy == currentuserid).ToList();
                ViewBag.State = allRecords;

            }


            return View(allsociety);
        }
        public ActionResult GetProvienceList()
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentlogin = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                var AllProvince = dbcont.tbl_Province.ToList();
                ViewBag.AllProvince = AllProvince;
            }
            else
            {
                var AllProvince = dbcont.tbl_Province.Where(x => x.Id.ToString() == currentUser).ToList();
                ViewBag.AllProvince = AllProvince;
            }

            var userRoleName = Session["UserRole"] as string;
            if (!string.IsNullOrEmpty(userRoleName))
            {
                var userRoleId = dbcont.Tbl_UserRole.Where(x => x.Role_Name == userRoleName).Select(x => x.Userrole_Id).FirstOrDefault();
                var topmenulist = dbcont.Tbl_TopMenuPermission.Where(x => x.RoleId == userRoleId.ToString()).ToList();
                Session["TopmenuPermission"] = topmenulist;
            }
            return View();
        }
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ActionResult> GetGrid(string name, sbyte? firstItem, sbyte? lastItem, string SearchTxt, Tbl_Cong tbl_ParisInstitutionDetails)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
#pragma warning disable CS0219 // The variable 'Html' is assigned but its value is never used
            string Html = "";
#pragma warning restore CS0219 // The variable 'Html' is assigned but its value is never used
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allProvince = dbcont.tbl_Province.ToList();
                List<tbl_Province> alldata = new List<tbl_Province>();

                var allins =  dbcont.tbl_Province.Where(x => x.ActiveCkeck == name && (x.ProvinceName.Contains(SearchTxt) || x.Phone.Contains(SearchTxt) || x.Place.Contains(SearchTxt) || x.EmailId.Contains(SearchTxt) || x.Country.Contains(SearchTxt))).OrderBy(x => x.Id).ToList();
                ViewBag.Firstitem = firstItem;
                if (firstItem != null && lastItem != null)
                {
                    sbyte from = Convert.ToSByte(firstItem);
                    sbyte To = Convert.ToSByte(lastItem);
                    var filteredData = allins.Skip(Math.Max(0, from - 1)).Take(To - (from - 1));
                    allins = filteredData.ToList();
                }

                //foreach (var item in allins)
                //{
                //    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);

                //    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                //    alldata.Add(item);
                //}

                ViewBag.allinstitution = allins;
            }
            else
            {
                var allProvince = dbcont.tbl_Province.ToList();
                List<tbl_Province> alldata = new List<tbl_Province>();

                var allins =  dbcont.tbl_Province.Where(x => x.Id.ToString() == currentUser && x.ActiveCkeck == name && (x.ProvinceName.Contains(SearchTxt) || x.Phone.Contains(SearchTxt) || x.Place.Contains(SearchTxt) || x.EmailId.Contains(SearchTxt) || x.Country.Contains(SearchTxt))).OrderBy(x => x.Id).ToList();
                ViewBag.Firstitem = firstItem;
                if (firstItem != null && lastItem != null)
                {
                    sbyte from = Convert.ToSByte(firstItem);
                    sbyte To = Convert.ToSByte(lastItem);
                    var filteredData = allins.Skip(Math.Max(0, from - 1)).Take(To - (from - 1));
                    allins = filteredData.ToList();
                }

                //foreach (var item in allins)
                //{
                //    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);

                //    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                //    alldata.Add(item);
                //}

                ViewBag.allinstitution = allins;
            }
            return PartialView("_GetProvienceList");
            //return Json(new { Url = Url.Action("_InstitutionCreatedList", ViewBag.allinstitution) });
        }
    }
}
