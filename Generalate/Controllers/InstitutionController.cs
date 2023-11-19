using Generalate.Helpers;
using Generalate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class InstitutionController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();

        // GET: Institution
        public ActionResult InstitutionList(string id, string name)
        {
            List<Tbl_Institution> summaryData = new List<Tbl_Institution>();
            var data = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.MyId == id);

            ViewBag.id = id;
            ViewBag.name = name;
            TempData["id"] = id;
            TempData["name"] = name;

            //ViewBag.SocietyName = dbcont.Societys.FirstOrDefault(x => x.Id.ToString() == data.SocietyId).NameOfTheSocity;
            //ViewBag.parishname = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x => x.MyId == data.ParisId).Name;
            ViewBag.InstitutionDetails = data;
            ViewBag.Institution = dbcont.tbl_Institution.Where(x => x.MyId == id).ToList();

            var parisData = dbcont.tbl_Institution.Where(x => x.MyId == id).ToList();
            var parisLandData = dbcont.Tbl_LandDocuments.Where(x => x.MyId == id).ToList();

            foreach (var item in parisData)
            {
                summaryData.Add(new Tbl_Institution
                {
                    Tial = item.Tial,
                    Description = item.Description,
                    Date = item.Date
                });
            }
            foreach (var item in parisLandData)
            {
                summaryData.Add(new Tbl_Institution
                {
                    Tial = item.Tital,
                    Description = item.Description,
                    Date = item.Date
                });
            }
            ViewBag.summaryData = summaryData;
            List<Tbl_LandDocuments> LandDocumentsList = dbcont.Tbl_LandDocuments.Where(x => x.MyId == id).ToList();
            return View(LandDocumentsList);
        }

        [HttpGet]
        public async Task<ActionResult> GetInstitutionByProvince(string provinceId = null)
        {
            if (provinceId == "0")
            {
                provinceId = null;
            }
            ViewBag.ProvinceList = await dbcont.tbl_Province.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ProvinceName
            }).ToListAsync();

            ViewBag.ProvinceId = provinceId;
            return View();

        }

        //INSTITUTION//
        public JsonResult GetAllInstitutionMeetingDetails(JqueryDatatableParam param)
        {
            try
            {
                string currentloginid = Convert.ToString(Session["loginuserid"]);
                string currentUser = Convert.ToString(Session["username"]);
                // var data = dbcont.tbl_Congregation.FirstOrDefault();
                //if (Session["username"].ToString() == "admin")
                //{
                //    var GeneralCouncil = db.GeneralCouncil.Where(x => x.GenId == id.ToString()).ToList();
                //    ViewBag.AllGeneralCouncil = GeneralCouncil;
                //}
                //else
                //{
                // var GeneralCouncil = db.GeneralCouncil.Where(x => x.CreatedBy == currentUser && x.GenId == id.ToString()).ToList();
                //    ViewBag.AllGeneralCouncil = GeneralCouncil;
                //}

                List<GeneralCouncil> AllInstitutionMeetingDetailsData = new List<GeneralCouncil>();
                List<GeneralCouncil> AllInstitutionMeetingDetailsDataOut = new List<GeneralCouncil>();
                var allProvince = dbcont.tbl_Province.ToList();

                if (Session["username"].ToString() == "admin")
                {
                    // AllMemberData = dbcont.GeneralCouncil.Where(x => x.GenId == id.ToString()).ToList();
                    AllInstitutionMeetingDetailsData = dbcont.MeetingMinutes.ToList();
                }
                else
                {
                    AllInstitutionMeetingDetailsData = dbcont.MeetingMinutes.Where(x => x.CreatedBy == currentUser).ToList();
                }
                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    AllInstitutionMeetingDetailsData = AllInstitutionMeetingDetailsData.Where(x => x.Name.ToLower().Contains(param.sSearch.ToLower())
                                                  || x.Designation.ToLower().Contains(param.sSearch.ToLower())).ToList();
                }
                foreach (var item in AllInstitutionMeetingDetailsData)
                {
                    //  var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);
                    AllInstitutionMeetingDetailsDataOut.Add(new GeneralCouncil
                    {
                        Name = item.Name,
                        Designation = item.Designation,
                        Responsibility = item.Responsibility,
                        Id = item.Id,
                    });
                }
                var data = AllInstitutionMeetingDetailsDataOut.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
                //return Json(data, JsonRequestBehavior.AllowGet);
                var totalRecords = AllInstitutionMeetingDetailsDataOut.Count();
                return Json(new
                {
                    param.sEcho,
                    iTotalRecords = totalRecords,
                    iTotalDisplayRecords = totalRecords,
                    aaData = data
                }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception)
            {
                return null;

            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddInstitution(Tbl_Institution Tbl_Institution, HttpPostedFileBase FileName)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                        FileName.SaveAs(path);
                        Tbl_Institution.FileName = fileName;
                    }
                }
                Tbl_Institution.CreatedBy = Convert.ToString(Session["loginuserid"]);
                Tbl_Institution.CreatedDate = System.DateTime.Now.ToString("dd/mm/yyyy");
                dbcont.tbl_Institution.Add(Tbl_Institution);
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
        public JsonResult GetInstitutionById(int id)
        {
            try
            {
                var genFormation = dbcont.tbl_Institution.FirstOrDefault(e => e.Id == id);
                if (genFormation != null)
                {
                    return Json(genFormation, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Update(Tbl_Institution tbl_Institution, HttpPostedFileBase file)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Image/Institution"), fileName);
                    file.SaveAs(path);
                    tbl_Institution.FileName = fileName;
                }
                var existingobj = dbcont.tbl_Institution.FirstOrDefault(e => e.Id == tbl_Institution.Id);
                if (existingobj != null)
                {
                    tbl_Institution.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Institution);
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
        public JsonResult Delete(int Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var genralobj = dbcont.tbl_Institution.FirstOrDefault(e => e.Id == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Institution.Remove(genralobj);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult DeleteInstitution(int Id)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var genralobj = dbcont.tbl_Institution.FirstOrDefault(e => e.Id == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Institution.Remove(genralobj);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        //Institution Land Doc
        public ActionResult AddInstitutionLand(Tbl_LandDocuments tbl_LandDocuments, HttpPostedFileBase KhasaraFile, HttpPostedFileBase RegistryDocumentFile, HttpPostedFileBase TaxbillFile, HttpPostedFileBase PavathiFile, HttpPostedFileBase MapFile)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (KhasaraFile != null)
                {
                    if (KhasaraFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(KhasaraFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        KhasaraFile.SaveAs(path);
                        tbl_LandDocuments.KhasaraFile = fileName;
                    }
                }
                if (RegistryDocumentFile != null)
                {
                    if (RegistryDocumentFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(RegistryDocumentFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        RegistryDocumentFile.SaveAs(path);
                        tbl_LandDocuments.RegistryDocumentFile = fileName;
                    }
                }
                if (TaxbillFile != null)
                {
                    if (TaxbillFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(TaxbillFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        TaxbillFile.SaveAs(path);
                        tbl_LandDocuments.TaxbillFile = fileName;
                    }
                }
                if (PavathiFile != null)
                {
                    if (PavathiFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(PavathiFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        PavathiFile.SaveAs(path);
                        tbl_LandDocuments.PavathiFile = fileName;
                    }
                }
                if (MapFile != null)
                {
                    if (MapFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(MapFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        MapFile.SaveAs(path);
                        tbl_LandDocuments.MapFile = fileName;
                    }
                }
                if (tbl_LandDocuments.MyId.Contains("Pucd"))
                {
                    tbl_LandDocuments.Type = "Paris";
                }
                else
                {
                    tbl_LandDocuments.Type = "Institution";
                }
                tbl_LandDocuments.CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
                dbcont.Tbl_LandDocuments.Add(tbl_LandDocuments);
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
        public JsonResult GetInstitutionLandDocById(int id)
        {
            try
            {
                var genFormation = dbcont.Tbl_LandDocuments.FirstOrDefault(e => e.Id == id);
                if (genFormation != null)
                {
                    return Json(genFormation, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult UpdateInstitutionLand(Tbl_LandDocuments tbl_LandDocuments, HttpPostedFileBase KhasaraFile, HttpPostedFileBase RegistryDocumentFile, HttpPostedFileBase TaxbillFile, HttpPostedFileBase PavathiFile, HttpPostedFileBase MapFilee)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_LandDocuments.FirstOrDefault(e => e.Id == tbl_LandDocuments.Id);

                if (KhasaraFile != null)
                {
                    if (KhasaraFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(KhasaraFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        KhasaraFile.SaveAs(path);
                        tbl_LandDocuments.KhasaraFile = fileName;
                    }
                }
                else
                {
                    tbl_LandDocuments.KhasaraFile = existingobj.KhasaraFile;
                }
                if (RegistryDocumentFile != null)
                {
                    if (RegistryDocumentFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(RegistryDocumentFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        RegistryDocumentFile.SaveAs(path);
                        tbl_LandDocuments.RegistryDocumentFile = fileName;
                    }
                }
                else
                {
                    tbl_LandDocuments.RegistryDocumentFile = existingobj.RegistryDocumentFile;
                }
                if (TaxbillFile != null)
                {
                    if (TaxbillFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(TaxbillFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        TaxbillFile.SaveAs(path);
                        tbl_LandDocuments.TaxbillFile = fileName;
                    }
                }
                else
                {
                    tbl_LandDocuments.TaxbillFile = existingobj.TaxbillFile;
                }
                if (PavathiFile != null)
                {
                    if (PavathiFile.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(PavathiFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        PavathiFile.SaveAs(path);
                        tbl_LandDocuments.PavathiFile = fileName;
                    }
                }
                else
                {
                    tbl_LandDocuments.PavathiFile = existingobj.PavathiFile;
                }
                if (MapFilee != null)
                {
                    if (MapFilee.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(MapFilee.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/LandDocuments"), fileName);
                        MapFilee.SaveAs(path);
                        tbl_LandDocuments.MapFile = fileName;
                    }
                }
                else
                {
                    tbl_LandDocuments.MapFile = existingobj.MapFile;
                }
                tbl_LandDocuments.CreatedDate = existingobj.CreatedDate;
                tbl_LandDocuments.Type = existingobj.Type;

                if (existingobj != null)
                {
                    tbl_LandDocuments.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_LandDocuments);
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
        public JsonResult DeleteInstitutionLandDocById(int Id)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var genralobj = dbcont.Tbl_LandDocuments.FirstOrDefault(e => e.Id == Id);
                if (genralobj != null)
                {
                    dbcont.Tbl_LandDocuments.Remove(genralobj);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        public JsonResult GetAllInstitutionById1(string id)
        {
            var personalDetails = dbcont.tbl_Institution.FirstOrDefault(x => x.Id.ToString() == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLandDocumentsById1(string id)
        {
            var personalDetails = dbcont.Tbl_LandDocuments.FirstOrDefault(x => x.Id.ToString() == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public void setcookies(string code)
        {
            HttpCookie cookie = new HttpCookie("iscode", code);
            Response.Cookies.Add(cookie);
        }

        #region insttitute
        public async Task<ActionResult> ProvinceInstitution()
        {
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                var allProvince = dbcont.tbl_Province.ToList();
                List<Tbl_ParisInstitutionDetails> alldata = new List<Tbl_ParisInstitutionDetails>();

                var allins = await dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ActiveCkeck == "Active" && x.Type == "Institution").OrderBy(x => x.Name).ToListAsync();
                foreach (var item in allins)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);

                    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                    alldata.Add(item);
                }

                ViewBag.allinstitution = alldata;
            }
            else
            {
                var allProvince = dbcont.tbl_Province.ToList();
                List<Tbl_ParisInstitutionDetails> alldata = new List<Tbl_ParisInstitutionDetails>();

                var allins = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.CreatedBy == currentloginuserid && x.ActiveCkeck == "Active" && x.Type == "Institution").ToList();
                foreach (var item in allins)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);

                    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                    alldata.Add(item);
                }
                ViewBag.allinstitution = alldata;
            }
            return View();
        }


        public async Task<ActionResult> Create(int? Id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            try
            {
                var AllDataTypes = dbcont.DataListItems.Where(x => x.DataListName == "DistTypes").OrderBy(x => x.Name).ToList();
                ViewBag.AllDataTypes = AllDataTypes;
                ViewBag.DisSecId = dbcont.tbl_DistSector.Count() + 1;
                var InstitutionDataListItems = dbcont.DataLists.Where(x => x.Name.ToLower() == "institution").OrderBy(x => x.Name).ToList();
                ViewBag.InstitutionDataListItems = InstitutionDataListItems;
                var activitiesDataListItems = dbcont.DataLists.Where(x => x.Name.ToLower() == "activities").OrderBy(x => x.Name).ToList();
                ViewBag.ActivitiesDataListItems = activitiesDataListItems;
                var countryDataListItems = dbcont.DataLists.Where(x => x.Name.ToLower() == "country").OrderBy(x => x.Name).ToList();
                ViewBag.CoutryDataListItems = countryDataListItems;
                ViewBag.DioceseId = dbcont.tbl_Diocese.Count() + 1;
                if (Id != null && Id != 0)
                {
                    BindViewBag();
                    Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails = await dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();
                    List<tbl_ProvinceGallery> tbl_ProvinceGallery = dbcont.Tbl_ProvinceGallery.Where(x => x.MainID == tbl_ParisInstitutionDetails.MyId).ToList();
                    List<tblProvienceImportantDates> tblProvienceImportantDates = dbcont.tblProvienceImportantDates.Where(x => x.MainID == tbl_ParisInstitutionDetails.MyId).ToList();
                    ViewBag.tbl_ProvinceGallery = JsonConvert.SerializeObject(tbl_ProvinceGallery);
                    ViewBag.tblProvienceImportantDates = JsonConvert.SerializeObject(tblProvienceImportantDates);
                    var institutionName = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Id.ToString() == Id.ToString()).FirstOrDefault().Name;
                    var allAppointments = dbcont.Appointments.Where(x => x.CommunityType.Contains(institutionName) && x.Status == "Active").ToList();
                    ViewBag.Appointments = allAppointments;
                    return View(tbl_ParisInstitutionDetails);
                }
                else
                {
                    BindViewBag();
                    ViewBag.InstitutionId = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Type == "Institution").Count() + 1;
                    ViewBag.tbl_ProvinceGallery = JsonConvert.SerializeObject(null);
                    ViewBag.tblProvienceImportantDates = JsonConvert.SerializeObject(null);
                    return View(new Tbl_ParisInstitutionDetails());
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return RedirectToAction("Login");
            }

        }
        [ValidateInput(false)]
        [HttpPost]
        public async Task<ActionResult> Create(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, string[] Activities, HttpPostedFileBase File, string[] Names, string[] Days, string[] Months, string[] Title, HttpPostedFileBase[] files, string[] spanImgName)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            try
            {
#pragma warning disable CS0472 // The result of the expression is always 'true' since a value of type 'int' is never equal to 'null' of type 'int?'
                if (tbl_ParisInstitutionDetails.Id != 0 && tbl_ParisInstitutionDetails.Id != null)
#pragma warning restore CS0472 // The result of the expression is always 'true' since a value of type 'int' is never equal to 'null' of type 'int?'
                {
                    Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetailsPast = await dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Id == tbl_ParisInstitutionDetails.Id).FirstOrDefaultAsync();

                    tblProvienceImportantDates tblProvienceImportantDatesMain = new tblProvienceImportantDates();
                    tbl_ProvinceGallery tbl_ProvinceMain = new tbl_ProvinceGallery();
                    List<tbl_ProvinceGallery> tbl_ProvinceGallery = dbcont.Tbl_ProvinceGallery.Where(x => x.MainID == tbl_ParisInstitutionDetails.MyId).ToList();
                    List<tblProvienceImportantDates> tblProvienceImportantDates = dbcont.tblProvienceImportantDates.Where(x => x.MainID == tbl_ParisInstitutionDetails.MyId).ToList();
                    tbl_ParisInstitutionDetails.UpdateBy = Convert.ToString(Session["username"]);
                    tbl_ParisInstitutionDetails.UpdateDate = DateTime.Now.ToString("dd/MM/yyyy");
                    if (File != null)
                    {
                        if (File.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(File.FileName);
                            var path = Path.Combine(Server.MapPath("~/Image/ProvinceInstitution"), fileName);
                            File.SaveAs(path);
                            tbl_ParisInstitutionDetails.FileName = fileName;
                        }
                    }
                    if (tblProvienceImportantDates.Count > 0)
                    {
                        for (int i = 0; i < tblProvienceImportantDates.Count; i++)
                        {
                            tblProvienceImportantDates tblProvienceImportantDatesPast = dbcont.tblProvienceImportantDates.Where(x => x.MainID == tbl_ParisInstitutionDetails.MyId).FirstOrDefault();
                            dbcont.tblProvienceImportantDates.Remove(tblProvienceImportantDatesPast);
                            dbcont.SaveChanges();
                        }
                    }
                    tblProvienceImportantDatesMain.MainID = tbl_ParisInstitutionDetails.MyId;
                    if (Names != null)
                    {
                        for (int j = 0; j < Names.Count(); j++)
                        {
                            tblProvienceImportantDatesMain.Name = Names[j];
                            tblProvienceImportantDatesMain.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                            tblProvienceImportantDatesMain.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                            tblProvienceImportantDatesMain.IsActive = 1;
                            dbcont.tblProvienceImportantDates.Add(tblProvienceImportantDatesMain);
                            await dbcont.SaveChangesAsync();
                        }
                    }
                    if (tbl_ProvinceGallery.Count > 0)
                    {
                        for (int i = 0; i < tbl_ProvinceGallery.Count; i++)
                        {
                            tbl_ProvinceGallery tbl_ProvinceGalleryPast = dbcont.Tbl_ProvinceGallery.Where(x => x.MainID == tbl_ParisInstitutionDetails.MyId).FirstOrDefault();
                            dbcont.Tbl_ProvinceGallery.Remove(tbl_ProvinceGalleryPast);
                            dbcont.SaveChanges();
                        }
                    }
                    tbl_ProvinceMain.MainID = tbl_ParisInstitutionDetails.MyId;
                    int Count = 0;
                    if (spanImgName != null)
                    {
                        for (int k = 0; k < spanImgName.Count(); k++)
                        {
                            if (spanImgName[k] != "")
                            {
                                tbl_ProvinceMain.IsActive = 1;
                                tbl_ProvinceMain.FileName = spanImgName[k];
                                tbl_ProvinceMain.Title = Title[Count];
                                dbcont.Tbl_ProvinceGallery.Add(tbl_ProvinceMain);
                                await dbcont.SaveChangesAsync();
                                Count++;
                            }
                        }
                    }
                    if (files != null)
                    {
                        foreach (var file in files)
                        {
                            if (file != null)
                            {
                                if (file.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(file.FileName);
                                    var path = Path.Combine(Server.MapPath("~/Image/ProvinceInstitutionGallery"), fileName);
                                    file.SaveAs(path);
                                    tbl_ProvinceMain.IsActive = 1;
                                    tbl_ProvinceMain.FileName = fileName;
                                }
                                tbl_ProvinceMain.Title = Title[Count];
                                dbcont.Tbl_ProvinceGallery.Add(tbl_ProvinceMain);
                                await dbcont.SaveChangesAsync();
                                Count++;
                            }
                        }
                    }
                    tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                    dbcont.Entry(tbl_ParisInstitutionDetailsPast).CurrentValues.SetValues(tbl_ParisInstitutionDetails);
                    dbcont.SaveChanges();
                    return RedirectToAction("InstitutionCreatedList", "Institution");
                }
                else
                {
                    tbl_ProvinceGallery tbl_Province = new tbl_ProvinceGallery();
                    tblProvienceImportantDates tblProvienceImportantDates = new tblProvienceImportantDates();
                    if (tbl_ParisInstitutionDetails != null)
                    {
                        if (File != null)
                        {
                            if (File.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(File.FileName);
                                var path = Path.Combine(Server.MapPath("~/Image/ProvinceInstitution"), fileName);
                                File.SaveAs(path);
                                tbl_ParisInstitutionDetails.FileName = fileName;
                            }
                        }
                        tbl_Province.MainID = tbl_ParisInstitutionDetails.MyId;
                        tblProvienceImportantDates.MainID = tbl_ParisInstitutionDetails.MyId;

                        int i = 0;
                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                if (file != null)
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        var fileName = Path.GetFileName(file.FileName);
                                        var path = Path.Combine(Server.MapPath("~/Image/ProvinceInstitutionGallery"), fileName);
                                        file.SaveAs(path);
                                        tbl_Province.IsActive = 1;
                                        tbl_Province.FileName = fileName;
                                    }
                                    tbl_Province.Title = Title[i];
                                    dbcont.Tbl_ProvinceGallery.Add(tbl_Province);
                                    await dbcont.SaveChangesAsync();
                                    i++;
                                }
                            }
                        }
                        if (Names != null)
                        {
                            for (int j = 0; j < Names.Count(); j++)
                            {
                                tblProvienceImportantDates.Name = Names[j];
                                tblProvienceImportantDates.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                                tblProvienceImportantDates.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                                tblProvienceImportantDates.IsActive = 1;
                                dbcont.tblProvienceImportantDates.Add(tblProvienceImportantDates);
                                await dbcont.SaveChangesAsync();
                            }
                        }
                        tbl_ParisInstitutionDetails.CreatedBy = currentloginuserid;
                        tbl_ParisInstitutionDetails.Activities = Activities == null ? "" : String.Join(",", Activities);
                        dbcont.Tbl_ParisInstitutionDetails.Add(tbl_ParisInstitutionDetails);
                        await dbcont.SaveChangesAsync();

                    }
                    return RedirectToAction("InstitutionCreatedList", "Institution");
                }


            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public async Task<ActionResult> GetGrid(string name, sbyte? firstItem, sbyte? lastItem,string SearchTxt, Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails, string archieve)
        {
#pragma warning disable CS0219 // The variable 'Html' is assigned but its value is never used
            string Html = "";
#pragma warning restore CS0219 // The variable 'Html' is assigned but its value is never used
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            var status = string.IsNullOrEmpty(archieve) ? "Active" : "Inactive";
            if (Session["username"].ToString() == "admin")
            {
                var allProvince = dbcont.tbl_Province.ToList();
                List<Tbl_ParisInstitutionDetails> alldata = new List<Tbl_ParisInstitutionDetails>();
               
               
                var allins = await dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ActiveCkeck == status && x.Type == "Institution" && (x.InstitutionType.Contains(SearchTxt) || x.Name.Contains(SearchTxt))).OrderBy(x => x.Name).ToListAsync();
                
                if (firstItem != null && lastItem != null)
                {
                    sbyte from = Convert.ToSByte(firstItem);
                    sbyte To = Convert.ToSByte(lastItem);
                    var filteredData = allins.Skip(Math.Max(0,from-1)).Take(To-(from-1));
                    allins = filteredData.ToList();
                }
                
                foreach (var item in allins)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);

                    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                    alldata.Add(item);
                }

                ViewBag.allinstitution = alldata;
            }
            else
            {
                var allProvince = dbcont.tbl_Province.ToList();
                var ProvinceName = allProvince.Where(x => x.Id.ToString() == currentUser).Select(x => x.ProvinceName).FirstOrDefault().ToString();
                List<Tbl_ParisInstitutionDetails> alldata = new List<Tbl_ParisInstitutionDetails>();

                var allins = dbcont.Tbl_ParisInstitutionDetails.Where(x => (x.ProvinceName == currentUser || x.ProvinceName == ProvinceName) && x.ActiveCkeck == status && x.Type == "Institution" && (x.InstitutionType.Contains(SearchTxt) || x.Name.Contains(SearchTxt))).OrderBy(x => x.Name).ToList();
               
                if (firstItem != null && lastItem != null)
                {
                    sbyte from = Convert.ToSByte(firstItem);
                    sbyte To = Convert.ToSByte(lastItem);
                    var filteredData = allins.Skip(Math.Max(0, from - 1)).Take(To - (from - 1));
                    allins = filteredData.ToList();
                }

                foreach (var item in allins)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);

                    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                    alldata.Add(item);
                }
                ViewBag.allinstitution = alldata;
            }
            return PartialView("_InstitutionCreatedList");
            //return Json(new { Url = Url.Action("_InstitutionCreatedList", ViewBag.allinstitution) });
        }
        public async Task<ActionResult> Edit(int Id)
        {
            BindViewBag();
            Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails = await dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return View(tbl_ParisInstitutionDetails);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails)
        {
            BindViewBag();
            string msg = string.Empty;
            if (tbl_ParisInstitutionDetails != null)
            {
                var existtable = await dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Id == tbl_ParisInstitutionDetails.Id).FirstOrDefaultAsync();
                dbcont.Entry(existtable).CurrentValues.SetValues(tbl_ParisInstitutionDetails);
                await dbcont.SaveChangesAsync();
                msg = "1";
            }
            return RedirectToAction("ProvinceInstitution", "Institution");
        }

        public async Task<ActionResult> InstitutionCreatedList()
        {
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allProvince = dbcont.tbl_Province.ToList();
                List<Tbl_ParisInstitutionDetails> alldata = new List<Tbl_ParisInstitutionDetails>();

                var allins = await dbcont.Tbl_ParisInstitutionDetails.Where(x => x.ActiveCkeck == "Active" && x.Type == "Institution").OrderBy(x => x.Name).ToListAsync();
                foreach (var item in allins)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);

                    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                    alldata.Add(item);
                }

                ViewBag.allinstitution = alldata;
            }
            else
            {
                var allProvince = dbcont.tbl_Province.ToList();
                var ProvinceName = allProvince.Where(x => x.Id.ToString() == currentUser).Select(x => x.ProvinceName).FirstOrDefault().ToString();
                List<Tbl_ParisInstitutionDetails> alldata = new List<Tbl_ParisInstitutionDetails>();

                var allins = dbcont.Tbl_ParisInstitutionDetails.Where(x => (x.ProvinceName == currentUser || x.ProvinceName == ProvinceName) && x.ActiveCkeck == "Active" && x.Type == "Institution").ToList();
                foreach (var item in allins)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);

                    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                    alldata.Add(item);
                }
                ViewBag.allinstitution = alldata;
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

        private void BindViewBag()
        {
            var countryList = dbcont.DataListItems.Where(x => x.DataListName == "Country").OrderBy(x => x.Name).ToList();
            ViewBag.Country = countryList;

            var allInstitution = dbcont.DataListItems.Where(x => x.DataListName == "Institution").OrderBy(x => x.Name).ToList();
            ViewBag.InstitutionType = allInstitution;

            var AllActivities1 = dbcont.DataListItems.Where(x => x.DataListName == "Activities").OrderBy(x => x.Name).ToList();
            ViewBag.AllActivities = AllActivities1;

            var provincelist = dbcont.tbl_Province.ToList();
            ViewBag.ProvinceList = provincelist;
        }
        #endregion
        public ActionResult DeleteParisInstitutionDetails(int Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var genralobj = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(e => e.Id == Id);
                if (genralobj != null)
                {
                    dbcont.Tbl_ParisInstitutionDetails.Remove(genralobj);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return RedirectToAction("InstitutionCreatedList", "Institution");
                    //return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return RedirectToAction("InstitutionCreatedList", "Institution");
                    //return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
    }
}     