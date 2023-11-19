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
    public class ComplainController : Controller
    {
        private GeneralDBContext dbcont = new GeneralDBContext();
        // GET: Complain
        public ActionResult AddComplain()
        {
            
            List<tbl_PersonalDetails> allRecords = dbcont.tbl_PersonalDetails
                             .Where(x => x.IsDeleted == false)
                             .ToList();
            ViewBag.AllMembers = allRecords;
            List<Tbl_Complains> allComplains = dbcont.Tbl_Complains.ToList();
            return View(allComplains);
        }
        [HttpPost]
        public ActionResult AddComplain(Tbl_Complains tbl_Complains, HttpPostedFileBase FileName)
        {
            var redirectURL = TempData["EntryDetail"].ToString();
            //var url = Request.Url.ToString();
            if (FileName != null)
            {
                if (FileName.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(FileName.FileName);
                    var path = Path.Combine(Server.MapPath("~/Image/Compains"), fileName);
                    FileName.SaveAs(path);
                    tbl_Complains.FileName = fileName;
                }
            }
            dbcont.Tbl_Complains.Add(tbl_Complains);
            dbcont.SaveChanges();
            return Redirect(redirectURL);
        }

        public JsonResult GetCompainById(string id)
        {
            try
            {
                var genFormation = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id.ToString() == id);
                if (genFormation != null)
                {
                    return Json(genFormation, JsonRequestBehavior.AllowGet);
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

        public ActionResult ComplainUpdate(Tbl_Complains tbl_Complains, HttpPostedFileBase FileName)
        {
            try
            {
                var existingobj = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id == tbl_Complains.Id);
                if (FileName != null)
                {
                    if (FileName.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FileName.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Compains"), fileName);
                        FileName.SaveAs(path);
                        tbl_Complains.FileName = fileName;
                    }
                }
                else
                {
                    tbl_Complains.FileName = existingobj.FileName;
                }
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Complains);
                    dbcont.SaveChanges();
                }
                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Record Update Successfully!');location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Some Error Occure!');location.replace('" + url + "')</script>");
            }
        }

        public ActionResult DeleteComplain(int id)
        {
            try
            {
                var apporecord = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id == id);
                if (apporecord != null)
                {
                    dbcont.Tbl_Complains.Remove(apporecord);
                    dbcont.SaveChanges();
                    string url = this.Request.UrlReferrer.AbsoluteUri;
                    return Content("<script language='javascript' type='text/javascript'>alert('Record deleted successfully');location.replace('" + url + "')</script>");
                }
                else
                {
                    string url = this.Request.UrlReferrer.AbsolutePath;
                    return Content("<script language='javascript' type='text/javascript'>alert('Record have not deleted');location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ViewComplain(int id)
        {
            Tbl_Complains tbl_Complains = dbcont.Tbl_Complains.FirstOrDefault(x => x.Id == id);
            return View(tbl_Complains);
        }
    }
}