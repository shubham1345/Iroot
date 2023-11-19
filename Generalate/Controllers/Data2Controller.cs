using Generalate.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Generalate.Helpers;
using System.Collections.Generic;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class Data2Controller : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        public ActionResult DataItem2()
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentUserid = Convert.ToString(Session["loginuserid"]);

            var allDataList = dbcont.DataLists2.ToList();
            ViewBag.allDataList = allDataList;

            if (Session["username"].ToString() == "admin")
            {
                List<AppointmentData> allAppo = new List<AppointmentData>();
                List<AppointmentData> allAppodata = new List<AppointmentData>();
                allAppo = dbcont.AppointmentData.ToList();
                var allProvince = dbcont.tbl_Province.Where(x=> x.ActiveCkeck == "Active").ToList();
                foreach (var item in allAppo)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);
                    allAppodata.Add(new AppointmentData
                    {
                        Date = item.Date,
                        DataListItemName = item.DataListItemName,
                        ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName,
                        Description = item.Description

                    });
                }
                ViewBag.allAppo = allAppodata;
            }
            else
            {
                var allAppo = dbcont.AppointmentData.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allAppo = allAppo;
            }

            if (Session["username"].ToString() == "admin")
            {
                var allRenewal = dbcont.DataListItems2.ToList();
                ViewBag.allRenewal = allRenewal;
            }
            else
            {
                var allRenewal = dbcont.DataListItems2.Where(x => x.ProvinceName == currentUser).ToList();
                ViewBag.allRenewal = allRenewal;
            }

            var allNewsLetter = dbcont.NewsLetter.ToList();
            ViewBag.allNewsLetter = allNewsLetter;

            return View();
        }

        public ActionResult UserDataItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DataItemSave(string name)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                DataLists2 dataList = new DataLists2()
                {
                    Name = name
                };
                dataList.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.DataLists2.Add(dataList);
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
        public ActionResult AppointmentSave(AppointmentData AppointmentData)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                AppointmentData.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.AppointmentData.Add(AppointmentData);
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
        public JsonResult GetAppoById(int id)
        {
            try
            {
                var data = dbcont.AppointmentData.FirstOrDefault(e => e.Id == id);
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
        public ActionResult AppointmentUpdate(AppointmentData AppointmentData)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.AppointmentData.FirstOrDefault(e => e.Id == AppointmentData.Id);
                if (existingobj != null)
                {
                    AppointmentData.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(AppointmentData);
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
        public ActionResult AppointmentDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.AppointmentData.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.AppointmentData.Remove(data);
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
        public ActionResult RenewalSave(DataListItems2 DataListItems2, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Renewal"), fileName);
                        File.SaveAs(path);
                        DataListItems2.File = fileName;
                    }
                }
                DataListItems2.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.DataListItems2.Add(DataListItems2);
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
        public ActionResult UpdateRenewal(DataListItems2 DataListItems2, HttpPostedFileBase File)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(File.FileName);
                        var path = Path.Combine(Server.MapPath("~/Image/Renewal"), fileName);
                        File.SaveAs(path);
                        DataListItems2.File = fileName;
                    }
                }
                var existingobj = dbcont.DataListItems2.FirstOrDefault(e => e.Id == DataListItems2.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(DataListItems2);
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
        public JsonResult GetRenewalById(int id)
        {
            try
            {
                var data = dbcont.DataListItems2.FirstOrDefault(e => e.Id == id);
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
        public ActionResult RenewalDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.DataListItems2.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.DataListItems2.Remove(data);
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
        public ActionResult ChangePassword()
        {
            string currentUser = Convert.ToString(Session["username"]);
            string currentuserid = Convert.ToString(Session["userid"]);
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            List<Tbl_UserLogins> allpass = new List<Tbl_UserLogins>();
            var allProvince = dbcont.tbl_Province.ToList();
            List<tbl_PersonalDetails> allmembers = new List<tbl_PersonalDetails>();
           if(Convert.ToString(Session["username"]) == "admin")
            {
                allmembers = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes").ToList();
            }
            else
            {
                allmembers = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes" && x.ProvinceName == currentUser).ToList();
            }
           
            ViewBag.allmembers = allmembers;

            var userrole = dbcont.Tbl_UserRole.ToList();
            ViewBag.TblUserrole = userrole;

            if (Session["username"].ToString() == "admin")
            {
                var allpassadmin = dbcont.Tbl_UserLogins.ToList();
                List<Tbl_UserLogins> allpassadminList = new List<Tbl_UserLogins>();
                foreach (var item in allpassadmin)
                {
                    var createdBy = allpassadmin.FirstOrDefault(x => x.Id.ToString() == item.CreatedBy);
                    item.CreatedBy = createdBy == null ? "Not Exist" : createdBy.LoginUserName;

                    var provinceDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.UserName);
                    if (provinceDetails != null)
                    {
                        var persionalDetails = allmembers.FirstOrDefault(x => x.MemberID.ToString() == item.MemberId);
                        item.UserName = provinceDetails.ProvinceName;
                        item.MemberId = persionalDetails == null ? "Not Exist" : persionalDetails.Name;
                    }
                    else
                    {
                        item.UserName = "Not Exist";
                    }
                    allpassadminList.Add(item);
                }
                ViewBag.allpassadmin = allpassadminList;
            }
            else
            {
                var allpassadmin = dbcont.Tbl_UserLogins.Where(x => x.CreatedBy == currentuserid).ToList();
                List<Tbl_UserLogins> allpassadminList = new List<Tbl_UserLogins>();
                foreach (var item in allpassadmin)
                {
                    var createdBy = allpassadmin.FirstOrDefault(x => x.Id.ToString() == item.CreatedBy);
                    item.CreatedBy = createdBy == null ? "Not Exist" : createdBy.LoginUserName;

                    var provinceDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.UserName);
                    if (provinceDetails != null)
                    {
                        var persionalDetails = allmembers.FirstOrDefault(x => x.MemberID.ToString() == item.MemberId);
                        item.UserName = provinceDetails.ProvinceName;
                        item.MemberId = persionalDetails == null ? "Not Exist" : persionalDetails.Name;
                    }
                    else
                    {
                        item.UserName = "";
                    }
                    allpassadminList.Add(item);
                }
                ViewBag.allpassadmin = allpassadminList;
            }

            //if (Session["username"].ToString() == "admin")
            //{
            //    var AllProvince = dbcont.tbl_Province.ToList();
            //    ViewBag.AllProvince = AllProvince;
            //}
            //else
            //{
            //    var AllProvince = dbcont.tbl_Province.Where(x => x.ProvinceName == currentUser).ToList();
            //    ViewBag.AllProvince = AllProvince;
            //}
            return View();
        }
        [HttpPost]
        public ActionResult AddPassword(Tbl_UserLogins userlogin)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var alreadtExist = dbcont.Tbl_UserLogins.FirstOrDefault(x => x.UserName == userlogin.UserName && x.LoginUserName == userlogin.LoginUserName && x.MemberId == userlogin.MemberId);
                if (alreadtExist == null)
                {
                    userlogin.CreatedBy = Session["userid"].ToString();
                    dbcont.Tbl_UserLogins.Add(userlogin);
                    dbcont.SaveChanges();
                    setcookies("200");
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
        public JsonResult GetPassById(int id)
        {
            try
            {
                var data = dbcont.Tbl_UserLogins.FirstOrDefault(e => e.Id == id);
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
        public ActionResult PasswordUpdate(Tbl_UserLogins Tbl_UserLogins)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.Tbl_UserLogins.FirstOrDefault(e => e.Id == Tbl_UserLogins.Id);
                if (existingobj != null)
                {
                    Tbl_UserLogins.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_UserLogins);
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
        public ActionResult PasswordDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var apporecord = dbcont.Tbl_UserLogins.FirstOrDefault(e => e.Id == id);
                if (apporecord != null)
                {
                    dbcont.Tbl_UserLogins.Remove(apporecord);
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
        public JsonResult GetPassByIdForNew(int id)
        {
            try
            {
                var data = dbcont.Tbl_UserLogins.FirstOrDefault(e => e.Id == id);
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
        public ActionResult ChangesPassword2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateNewPass(Tbl_UserLogins Tbl_UserLogins)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                string loginuser = Session["username"].ToString();
                var existingobj = dbcont.Tbl_UserLogins.FirstOrDefault(e => e.UserName == loginuser);
                if (existingobj != null)
                {
                    if (existingobj.UserPassword == Tbl_UserLogins.Spare1)
                    {
                        existingobj.UserPassword = Tbl_UserLogins.UserPassword;
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
        public JsonResult EncryptionPass(int id)
        {
            var data = dbcont.Tbl_UserLogins.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                string filename = data.LoginUserName + "_Encryption.key";
                string fileAddress = Server.MapPath(@"\EncryptionFiles\" + filename);
                string newPath = Path.GetFullPath(fileAddress);
                string encptedPaswword = Convert.ToString(Guid.NewGuid());

                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(encptedPaswword);
                string encrypted = Convert.ToBase64String(b);

                if (System.IO.File.Exists(fileAddress))
                {
                    System.IO.File.Delete(fileAddress);
                }

                // Create a new file     
                using (FileStream fs = System.IO.File.Create(fileAddress))
                {
                    // Add some text to file 

                    Byte[] title = new UTF8Encoding(true).GetBytes(encrypted);
                    fs.Write(title, 0, title.Length);

                    data.EncrptedInfo = encrypted;
                    data.EncrptedInfoFile = filename;
                    dbcont.SaveChanges();
                }

            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUserPassword(int id)
        {
            var data = dbcont.Tbl_UserLogins.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                return Json(data.UserPassword, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("201", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllProvinceMember()
        {
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.tbl_PersonalDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes")
                                 .Select(x => new { x.Name, x.SirName, x.MemberID }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.tbl_PersonalDetails
                         .Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null  && x.IsTransfer != "yes" && x.ProvinceName == currentUser)
                         .Select(x => new { x.Name, x.SirName, x.MemberID }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllProvinceMember1(string province)
        {
            var checkpro = dbcont.tbl_Province.FirstOrDefault(x => x.Id.ToString() == province);
           // var checkGen = dbcont.tbl_Congregation.Where(x => x.Id.ToString() == province);
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);

            if (checkpro != null)
            {
                if (Session["username"].ToString() == "admin")
                {
                    var allRecords = dbcont.tbl_PersonalDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes" && x.ProvinceName == province)
                                     .Select(x => new { x.Name, x.SirName, x.MemberID }).ToList();
                    return Json(allRecords, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var allRecords = dbcont.tbl_PersonalDetails
                             .Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes" && x.ProvinceName == currentUser)
                             .Select(x => new { x.Name, x.SirName, x.MemberID }).ToList();
                    return Json(allRecords, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (Session["username"].ToString() == "admin")
                {
                    List<AppointmentsData> data = new List<AppointmentsData>();
                    var checkGen = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.EnterbyId == province && x.EnterbyId == currentUser).ToList();
                    foreach (var item in checkGen)
                    {
                        var allRecords1 = dbcont.Appointments.Where(x => x.InstitutionType == item.Id.ToString() && x.ProvinceName == currentUser).ToList();
                        foreach (var item1 in allRecords1)
                        {
                            var allNamedata = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID == item1.MemberId);
                            data.Add(new AppointmentsData()
                            {
                                Name = allNamedata.Name,
                                SirName = allNamedata.SirName,
                                MemberID = item1.MemberId,
                            });
                        }
                    }
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    List<AppointmentsData> data = new List<AppointmentsData>();
                    var checkGen = dbcont.Tbl_ParisInstitutionDetails.Where(x => x.EnterbyId == province).ToList();
                    foreach (var item in checkGen)
                    {
                        var allRecords1 = dbcont.Appointments.Where(x => x.InstitutionType == item.Id.ToString() && x.ProvinceName == currentUser);
                        foreach (var item1 in allRecords1)
                        {
                            var allNamedata = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID == item1.MemberId);
                            data.Add(new AppointmentsData()
                            {
                                Name = allNamedata.Name,
                                SirName = allNamedata.SirName,
                                MemberID = item1.MemberId,
                            });
                        }
                    }
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
        }
        public JsonResult GetAllProvinceStaff()
        {
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allRecords = dbcont.StaffDetails
                                 .Select(x => new { x.StaffNameName, x.MyId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = dbcont.StaffDetails.Where(x=> x.EnterbyId == currentUser)
                         .Select(x => new { x.StaffNameName, x.MyId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllProvinceStaff1(string province)
        {
            var checkpro = dbcont.tbl_Province.FirstOrDefault(x => x.Id.ToString() == province);
            // var checkGen = dbcont.tbl_Congregation.Where(x => x.Id.ToString() == province);
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);

            // if (checkpro != null)
            // {
            if (Session["username"].ToString() == "admin")
            {
                if(checkpro != null)
                {
                    var allRecords = dbcont.StaffDetails.Where(x => x.EnterbyId == checkpro.MyId)
                                .Select(x => new { x.StaffNameName, x.Id }).ToList();
                    return Json(allRecords, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var allRecords = dbcont.StaffDetails.Where(x => x.EnterbyId == province)
                                .Select(x => new { x.StaffNameName, x.Id }).ToList();
                    return Json(allRecords, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (checkpro != null)
                {
                    var allRecords = dbcont.StaffDetails.Where(x => x.EnterbyId == currentUser && x.EnterbyId == checkpro.MyId)
                                .Select(x => new { x.StaffNameName, x.Id }).ToList();
                    return Json(allRecords, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var allRecords = dbcont.StaffDetails.Where(x => x.CreatedBy == currentUserid && x.EnterbyId == province)
                                .Select(x => new { x.StaffNameName, x.Id }).ToList();
                    return Json(allRecords, JsonRequestBehavior.AllowGet);
                }
            }
        }
        public JsonResult GetAllRenewalById1(string id)
        {
            var RenewalDatas = dbcont.DataListItems2.Where(x => x.Id.ToString() == id).ToList();
            var allProvince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
            List<DataListItems2> allrenewalData = new List<DataListItems2>();
            foreach (var item in RenewalDatas)
            {
                var provincenames = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName);
                allrenewalData.Add(new DataListItems2
                {
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                    DataListName = item.DataListName,
                    DataListItemName = item.DataListItemName,
                    ProvinceName = provincenames.ProvinceName,
                    Description = item.Description,
                    File = item.File
                });
            }
            return Json(allrenewalData, JsonRequestBehavior.AllowGet);
        }
        public void setcookies(string code)
        {
            HttpCookie cookie = new HttpCookie("iscode", code);
            Response.Cookies.Add(cookie);
        }
        public class AppointmentsData
        {
            public string Name { get; set; }
            public string MemberID { get; set; }
            public string SirName { get; set; }
          
        }
    }
}