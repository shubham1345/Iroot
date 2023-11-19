using Generalate.Helpers;
using Generalate.Models;
using Generalate.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class RenewalVowsController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        public ActionResult ViewRenewalVows(string id)
        {
            string currentUser = Convert.ToString(Session["username"]);
            string loginuser = Convert.ToString(Session["loginuserid"]);

            if (Session["username"].ToString() == "admin")
            {
                var AllMemberdata = dbcont.Tbl_RenewalVows.Where(x => x.ProvinceName == id.ToString()).ToList();
                ViewBag.AllMemberdata2 = AllMemberdata;
            }
            else
            {
                var AllMemberdata = dbcont.Tbl_RenewalVows.Where(x => x.ProvinceName == currentUser && x.ProvinceName == id.ToString()).ToList();
                ViewBag.AllMemberdata2 = AllMemberdata;
            }

            //Uri URI = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            //string UriData = HttpUtility.ParseQueryString(URI.Query).Get("myId"); // current provinceid

            ////var allProvince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
            ////var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == UriData);

            //ViewBag.MyurlId = UriData;
            return View();
        }
        public ActionResult ViewRenewalVows2()
        {
            string currentUser = Convert.ToString(Session["username"]);
            string loginuser = Convert.ToString(Session["loginuserid"]);

            if (Session["username"].ToString() == "admin")
            {
                var AllMemberdata = dbcont.Tbl_RenewalVows.ToList();
                ViewBag.AllMemberdata2 = AllMemberdata;
            }
            else
            {
                var AllMemberdata = dbcont.Tbl_RenewalVows.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.AllMemberdata2 = AllMemberdata;
            }

            Uri URI = new Uri(this.Request.UrlReferrer.AbsoluteUri);
            string UriData = HttpUtility.ParseQueryString(URI.Query).Get("myId"); // current provinceid

            //var allProvince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
            //var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == UriData);

            ViewBag.MyurlId = UriData;
            return View();
        }
        public JsonResult GetAllRenewalVows(JqueryDatatableParam param, string provinceName, string Name)
        {
            try
            {
                string currentUser = Convert.ToString(Session["username"]);
                string loginuser = Convert.ToString(Session["loginuserid"]);
                var getAlldata = dbcont.Tbl_RenewalVows.ToList();

                if (Session["username"].ToString() != "admin")
                {
                    getAlldata = getAlldata.Where(x => x.ProvinceName == currentUser).ToList();

                }
                if (provinceName != null && provinceName != "" && provinceName != "0")
                {
                    getAlldata = getAlldata.Where(x => x.ProvinceName == provinceName).ToList();
                }
                if (Name != null && Name != "")
                {
                    getAlldata = getAlldata.Where(x => x.Name == Name).ToList();
                }
                if (!string.IsNullOrEmpty(param.sSearch))
                {
                    //getAlldata = getAlldata.Where(x => x.ProvinceName.ToLower().Contains(param.sSearch.ToLower())
                    //                              || x.FileNo.ToLower().Contains(param.sSearch.ToLower())).ToList();
                }
                var data = getAlldata.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
                //return Json(data, JsonRequestBehavior.AllowGet);
                var totalRecords = getAlldata.Count();
                return Json(new
                {
                    param.sEcho,
                    iTotalRecords = totalRecords,
                    iTotalDisplayRecords = totalRecords,
                    aaData = data
                }, JsonRequestBehavior.AllowGet);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return null;
                //throw;
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RenewalVows(string MemberId)
        {
            // var data = dbcont.Tbl_formationsDetails.Where(x => x.StageOfFormation == "PerpetualProfession").Where(x => x.MemberId==MemberId).ToList();
            string currentUser = Convert.ToString(Session["username"]);
            string loginuser = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                var AllMemberdata = dbcont.tbl_PersonalDetails.ToList();
                ViewBag.AllMemberdata = AllMemberdata;
            }
            else
            {
                var AllMemberdata = dbcont.tbl_PersonalDetails.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.AllMemberdata = AllMemberdata;
            }

            return View();
        }
        public JsonResult GetRenewvalVowsByName(string name)
        {
            var AllMemberid = dbcont.tbl_PersonalDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Name == name).ToList();

            if (AllMemberid != null)
            {
                string memId = AllMemberid[0].MemberID;
                var allFormationData = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == memId).ToList();
                var allProfesionalFormationData = allFormationData.Where(x => x.StageOfFormation.Contains("5")).ToList();
                var AllMemberdata = dbcont.Tbl_RenewalVows.Where(x => x.Name == name).ToList();
                return Json(new { AllMemberdata, allProfesionalFormationData }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string memId = "ABCCC";
                var allFormationData = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == memId).ToList();
                var allProfesionalFormationData = allFormationData.Where(x => x.StageOfFormation.Contains("5")).ToList();
                var AllMemberdata = dbcont.Tbl_RenewalVows.Where(x => x.Name == name).ToList();
                return Json(new { AllMemberdata, allProfesionalFormationData }, JsonRequestBehavior.AllowGet);
            }


            //return Json(AllMemberdata , JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult AddRenewalVows(data data)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;

            if (data != null)
            {
                var alldetails = dbcont.Tbl_formationsDetails.ToList();
                var isavailable = alldetails.Where(x => x.StageOfFormation == "5").FirstOrDefault(x => x.Name == data.Name);//PerpetualProfession
                if (isavailable == null)
                {
                    string FileName = string.Empty;
                    var isAvailableRenew = dbcont.Tbl_RenewalVows.FirstOrDefault(x => x.MyId == data.CurrentStatus && x.Name == data.Name);
                    if (isAvailableRenew != null)
                    {
                        dbcont.Tbl_RenewalVows.Remove(isAvailableRenew);
                        dbcont.SaveChanges();
                    }
                    try
                    {
                        var pic2 = System.Web.HttpContext.Current.Request.Files["FileName"];
                        if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                        {
                            var pic = System.Web.HttpContext.Current.Request.Files["FileName"];
                            HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                            var fileName = Path.GetFileName(filebase.FileName);
                            FileName = fileName;
                            var path = Path.Combine(Server.MapPath("~/Image/RenewalImages/"), fileName);
                            filebase.SaveAs(path);
                        }
                        Tbl_RenewalVows tbl_RenewalVows = new Tbl_RenewalVows()
                        {
                            ProvinceName = data.ProvinceName,
                            MemberId = data.MemberId,
                            FileNo = data.FileNo,
                            CurrentStatus = data.CurrentStatus,
                            Check = data.IsChecked,
                            Duration = data.Duration,
                            Name = data.Name,
                            Superior = data.Superior,
                            Witness = data.Witness,
                            Surname = data.Date,
                            ToDate = data.ToDate,
                            RenewalYear = data.RenewalYear,
                            RenVowsDoc = FileName
                        };
                        tbl_RenewalVows.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        dbcont.Tbl_RenewalVows.Add(tbl_RenewalVows);
                        dbcont.SaveChanges();

                        string[] names = tbl_RenewalVows.Name.Split(' ');
                        string name = names[0];
                        var dataUpdate = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.Name.Contains(name));
                        if (dataUpdate != null)
                        {
                            dataUpdate.Vowscheck = tbl_RenewalVows.Check;
                            dataUpdate.VowsStatus = tbl_RenewalVows.CurrentStatus;
                            dbcont.SaveChanges();
                        }
                        setcookies("200");
                        return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                    }
                    catch (Exception)
                    {
                        setcookies("204");
                        return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                        throw;
                    }
                }
            }
            return null;
        }

        public JsonResult GetRenewalVows(int id)
        {
            try
            {
                var renewal = dbcont.Tbl_RenewalVows.FirstOrDefault(e => e.Id == id);
                if (renewal != null)
                {
                    return Json(renewal, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateRenewalVows(Tbl_RenewalVows Tbl_RenewalVows, HttpPostedFileBase RenVowsDoc)
        {
            var existingobj = dbcont.Tbl_RenewalVows.FirstOrDefault(e => e.Id == Tbl_RenewalVows.Id);
            string url = this.Request.UrlReferrer.AbsolutePath + "?id=" + existingobj.ProvinceName;

            try
            {
                if (RenVowsDoc != null)
                {
                    if (RenVowsDoc.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(RenVowsDoc.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/RenewalImages/"), fileName);
                        RenVowsDoc.SaveAs(path);
                        Tbl_RenewalVows.RenVowsDoc = fileName;
                    }
                }
                else
                {
                    Tbl_RenewalVows.RenVowsDoc = existingobj.RenVowsDoc == null ? "" : existingobj.RenVowsDoc;
                }

                if (existingobj != null)
                {
                    Tbl_RenewalVows.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_RenewalVows);
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
        public ActionResult DeleteRenewalVows(int id)
        {
            var data = dbcont.Tbl_RenewalVows.FirstOrDefault(e => e.Id == id);
            string url = this.Request.UrlReferrer.AbsolutePath + "?id=" + data.ProvinceName;
            try
            {
                if (data != null)
                {
                    dbcont.Tbl_RenewalVows.Remove(data);
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