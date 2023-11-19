using Generalate.Helpers;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class ParisController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: Paris
        public ActionResult ParisList(string id, string name)
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                var AllProvince = dbcont.tbl_Province.Where(x=> x.ActiveCkeck == "Active").ToList();
                ViewBag.AllProvince = AllProvince;
            }
            else
            {
                var AllProvince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == currentUser).ToList();
                ViewBag.AllProvince = AllProvince;
            }

            List<Tbl_Paris> summaryData = new List<Tbl_Paris>();
            ViewBag.Id = id;
            ViewBag.name = name;
            TempData["Id"] = id;
            TempData["name"] = name;
            ViewBag.ParisDetails = dbcont.Tbl_ParisInstitutionDetails.FirstOrDefault(x=>x.MyId== id);
            ViewBag.ParisData = dbcont.Tbl_Paris.Where(x=>x.MyId== id).ToList();

            var alldata = dbcont.Tbl_Governer.Where(x => x.MyId == id).ToList();
            ViewBag.AllGovData = alldata;

            var parisData= dbcont.Tbl_Paris.Where(x => x.MyId == id).ToList();
            var parisLandData= dbcont.Tbl_LandDocuments.Where(x => x.MyId == id).ToList();
            foreach (var item in parisData)
            {
                summaryData.Add(new Tbl_Paris
                {
                    Tial = item.Tial,
                    Description = item.Description,
                    Date = item.Date
                });
            }
            foreach (var item in parisLandData)
            {
                summaryData.Add(new Tbl_Paris
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

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddParis(Tbl_Paris tbl_Paris, HttpPostedFileBase  file)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Paris"), fileName);
                        file.SaveAs(path);
                        tbl_Paris.FileName = fileName;
                    }
                }
                tbl_Paris.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tbl_Paris.CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
                dbcont.Tbl_Paris.Add(tbl_Paris);
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
        public JsonResult GetParisById(int id)
        {
            try
            {
                var genFormation = dbcont.Tbl_Paris.FirstOrDefault(e => e.Id == id);
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
        public ActionResult Update(Tbl_Paris tbl_Paris, HttpPostedFileBase file)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.Tbl_Paris.FirstOrDefault(e => e.Id == tbl_Paris.Id);
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Paris"), fileName);
                        file.SaveAs(path);
                        tbl_Paris.FileName = fileName;
                    }
                }
                else
                {
                    tbl_Paris.FileName = existingobj.FileName ==null ? "" : existingobj.FileName;
                }

                tbl_Paris.CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
                if (existingobj !=null)
                {
                    tbl_Paris.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Paris);
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
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var genralobj = dbcont.Tbl_Paris.FirstOrDefault(e => e.Id == Id);
                if (genralobj != null)
                {
                    dbcont.Tbl_Paris.Remove(genralobj);
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
        public ActionResult AddParisLand(Tbl_LandDocuments tbl_LandDocuments,HttpPostedFileBase KhasaraFile,HttpPostedFileBase RegistryDocumentFile, HttpPostedFileBase TaxbillFile, HttpPostedFileBase PavathiFile, HttpPostedFileBase MapFile)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
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
        public JsonResult GetParisLandDocById(int id)
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
        public ActionResult UpdateParisLand(Tbl_LandDocuments tbl_LandDocuments, HttpPostedFileBase KhasaraFile, HttpPostedFileBase RegistryDocumentFile, HttpPostedFileBase TaxbillFile, HttpPostedFileBase PavathiFile, HttpPostedFileBase MapFilee)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
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
        public JsonResult DeleteParisLandDocById(int Id)
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

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddGoverner(Tbl_Governer Tbl_Governer, HttpPostedFileBase PanDoc)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (PanDoc != null)
                {
                    if (PanDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(PanDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Paris"), fileName);
                        PanDoc.SaveAs(path);
                        Tbl_Governer.PanDoc = fileName;
                    }
                }
                Tbl_Governer.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Tbl_Governer.Add(Tbl_Governer);
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
        public JsonResult GetGoverner(int id)
        {
            try
            {
                var genFormation = dbcont.Tbl_Governer.FirstOrDefault(e => e.Id == id);
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
        public ActionResult UpdateGoverner(Tbl_Governer Tbl_Governer, HttpPostedFileBase PanDoc)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.Tbl_Governer.FirstOrDefault(e => e.Id == Tbl_Governer.Id);
                if (PanDoc != null)
                {
                    if (PanDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(PanDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Paris"), fileName);
                        PanDoc.SaveAs(path);
                        Tbl_Governer.PanDoc = fileName;
                    }
                }
                else
                {
                    Tbl_Governer.PanDoc = existingobj.PanDoc == null ? "" : existingobj.PanDoc;
                }
               
                if (existingobj != null)
                {
                    Tbl_Governer.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_Governer);
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
        public JsonResult DeleteGoverner(int id)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var genDeath = dbcont.Tbl_Governer.FirstOrDefault(e => e.Id == id);
                if (genDeath != null)
                {
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
        public JsonResult GetAllParishGovernerById1(string id)
        {
            var personalDetails = dbcont.Tbl_Governer.FirstOrDefault(x => x.Id.ToString() == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllParisById1(string id)
        {
            var personalDetails = dbcont.Tbl_Paris.FirstOrDefault(x => x.Id.ToString() == id);
            return Json(personalDetails, JsonRequestBehavior.AllowGet);
        }
        public void setcookies(string code)
        {
            HttpCookie cookie = new HttpCookie("iscode", code);
            Response.Cookies.Add(cookie);
        }
    }
}


