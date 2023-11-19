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
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class VocationPromotionDocController : Controller
    {
        // GET: PersonalDetails

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult VocationPromotionDoc()
        {
            return View();
        }

        public ActionResult VocationPromotionDoc1Print()
        {
            return View();
        }

        //public ActionResult VocationPromotionDoc1Report()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("VocationPromotionDoc1Print");
        //}

        public JsonResult GetAll()
        {
            try
            {
                var result = dbcont.tbl_VocationPromotionDoc.ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_VocationPromotionDoc.FirstOrDefault(e => e.VocationPromotionId == Id);
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

        public JsonResult Add(tbl_VocationPromotionDoc general)
        {
            try
            {
                dbcont.tbl_VocationPromotionDoc.Add(general);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_VocationPromotionDoc fomdetail)
        {
            try
            {
                var existingobj = dbcont.tbl_VocationPromotionDoc.FirstOrDefault(e => e.VocationPromotionId == fomdetail.VocationPromotionId);
                dbcont.Entry(existingobj).CurrentValues.SetValues(fomdetail);
                existingobj.DoccumentName = fomdetail.DoccumentName;
                existingobj.Title = fomdetail.Title;
                existingobj.Date = fomdetail.Date;
                existingobj.Phonenumber = fomdetail.Phonenumber;
                existingobj.Email = fomdetail.Email;
                existingobj.File = fomdetail.File;

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
                var genralobj = dbcont.tbl_VocationPromotionDoc.FirstOrDefault(e => e.VocationPromotionId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_VocationPromotionDoc.Remove(genralobj);
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
                GeneralDBContext dbcont = new GeneralDBContext();
                tbl_VocationPromotionDoc gen = new tbl_VocationPromotionDoc();
                gen = dbcont.tbl_VocationPromotionDoc.FirstOrDefault(e => e.VocationPromotionId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetProvincial()
        {
            var query = (from c in dbcont.tbl_VocationPromotionDoc
                         orderby c.VocationPromotionId ascending
                         select new { Name = c.VocationPromotionId + "-" + c.DoccumentName }).Distinct();

            return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAutoGeneratedVocationPromotionDocId()
        {
            var query = (from c in dbcont.tbl_VocationPromotionDoc
                         select new { c.VocationPromotionId }).Count() + 1;

            string id = string.Format("{0:000}", query);

            return Json(id, JsonRequestBehavior.AllowGet);
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

                    comPath = Server.MapPath("~/Images/VocationPromotionDoc/") + fileName;

                    pic.SaveAs(comPath);
                }
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }

        //  [AcceptVerbs(HttpVerbs.Post)]
        //  public JsonResult UploadFile()
        //  {
        //    var memid = "";
        //    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
        //        memid = System.Web.HttpContext.Current.Request["Memid"];

        //        if (pic.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(pic.FileName);
        //            var _ext = Path.GetExtension(pic.FileName);

        //            _imgname = Guid.NewGuid().ToString();
        //            var _comPath = Server.MapPath("~/Images/") + memid + _ext;
        //            memid = memid + _ext;

        //            ViewBag.Msg = _comPath;
        //            var path = _comPath;

        //            Saving Image in Original Mode
        //        pic.SaveAs(path);

        //            resizing image
        //       MemoryStream ms = new MemoryStream();
        //            WebImage img = new WebImage(_comPath);

        //            if (img.Width > 200)
        //                img.Resize(200, 200);
        //            img.Save(_comPath);
        //            end resize
        //        }
        //    }
        //    return Json(memid, JsonRequestBehavior.AllowGet);
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public JsonResult WillUploadFiles()
        //{
        //    var memid = "";
        //    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
        //        memid = System.Web.HttpContext.Current.Request["Memid"];

        //        if (pic.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(pic.FileName);
        //            var _ext = Path.GetExtension(pic.FileName);

        //            _imgname = Guid.NewGuid().ToString();
        //            var _comPath = Server.MapPath("~/Images/Will/") + memid + _ext;
        //            memid = memid + _ext;

        //            ViewBag.Msg = _comPath;
        //            var path = _comPath;

        //            Saving Image in Original Mode
        //       pic.SaveAs(path);

        //            resizing image
        //       MemoryStream ms = new MemoryStream();
        //            WebImage img = new WebImage(_comPath);

        //            if (img.Width > 200)
        //                img.Resize(200, 200);
        //            img.Save(_comPath);
        //            end resize
        //       }
        //    }
        //    return Json(memid, JsonRequestBehavior.AllowGet);
        //}


        //public FileResult Download()
        //{
        //    string path = Server.MapPath("~/Images/Will/");
        //    string FileName = Path.GetFileName("CMF.jpg");

        //    String fullPath = Path.Combine(path, FileName);
        //    return File(fullPath, "image/jpg", "CMF.jpg");
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public JsonResult UploadFiles()
        //{
        //    var memid = "";
        //    var comPath = "";
        //    var fileName = "";
        //    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
        //        memid = System.Web.HttpContext.Current.Request["Memid"];

        //        if (pic.ContentLength > 0)
        //        {
        //            var _ext = Path.GetExtension(pic.FileName);
        //            fileName = Guid.NewGuid().ToString() + _ext;

        //            comPath = Server.MapPath("~/Documents/Will/") + memid + _ext;

        //            pic.SaveAs(comPath);
        //        }
        //    }
        //    return Json(fileName, JsonRequestBehavior.AllowGet);
        //}

    }
}
