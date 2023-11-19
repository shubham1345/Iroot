using ClosedXML.Excel;
using Generalate.Helpers;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class RolePermissionController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: RolePermission
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RolePermission()
        {
            List<SelectListItem> roleslist = new List<SelectListItem>();
            roleslist.Add(new SelectListItem { Text = "admin", Value = "1" });
            roleslist.Add(new SelectListItem { Text = "brothers", Value = "2" });
            roleslist.Add(new SelectListItem { Text = "staff", Value = "3" });
            var alProvince = dbcont.tbl_Province.ToList();
            ViewBag.Roles = dbcont.Tbl_UserRole.ToList();
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var alProvince1 = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
                ViewBag.Provinces = alProvince1;
            }
            else
            {
                var alProvince1 = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == currentUser).ToList();
                ViewBag.Provinces = alProvince1;
            }

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult SaveUpdateRolePermissions(List<RolePagePermission> data)
        {
            if (data.Count() > 0)
            {
                //delete all roles
                var rolename = data.FirstOrDefault().RoleName;
                var provinceId = data.FirstOrDefault().provinceId;
                var allrolePermission = dbcont.RolePagePermissions.Where(x => x.RoleName == rolename && x.provinceId == provinceId).ToList();
                dbcont.RolePagePermissions.RemoveRange(allrolePermission);
                dbcont.SaveChanges();
                //delete all entiry for role

                foreach (var item in data)
                {
                    if (item.PageName != "on")
                    {
                        item.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        dbcont.RolePagePermissions.Add(item);
                    }
                }
                dbcont.SaveChanges();
            }
            return Json(true);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult SaveUpdateTabsPermissions(List<TabPermissions> data)
        {
            if (data.Count() > 0)
            {
                //delete all roles
                var rolename = data.FirstOrDefault().RoleName;
                var provinceId = data.FirstOrDefault().provinceId;
                var allrolePermission = dbcont.Tbl_TabPermissions.Where(x => x.RoleName == rolename && x.provinceId == provinceId).ToList();
                dbcont.Tbl_TabPermissions.RemoveRange(allrolePermission);
                dbcont.SaveChanges();
                //delete all entiry for role

                foreach (var item in data)
                {
                    if (item.TabName != "on")
                    {
                        item.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        dbcont.Tbl_TabPermissions.Add(item);
                    }
                }
                dbcont.SaveChanges();
            }
            return Json(true);
        }

        public JsonResult GetAllPageByRoleName(string roleName, string provinceId)
        {
            String createdby = Convert.ToString(Session["createdby"]);
            var allrolePermission = dbcont.RolePagePermissions.Where(x => x.RoleName == roleName && x.provinceId == provinceId && x.CreatedBy == createdby).ToList();
            return Json(allrolePermission, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllTabByRoleName(string roleName, string provinceId)
        {
            String createdby = Convert.ToString(Session["createdby"]);
            var allrolePermission = dbcont.Tbl_TabPermissions.Where(x => x.RoleName == roleName && x.provinceId == provinceId && x.CreatedBy == createdby).ToList();
            return Json(allrolePermission, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MultiLanguage()
        {
            var allLanguage = dbcont.Tbl_MultiLanguage.ToList();
            ViewBag.allLanguage = allLanguage;
            return View();
        }

        [HttpPost]
        public ActionResult AddLanguage(MultiLanguage multiLanguage)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                dbcont.Tbl_MultiLanguage.Add(multiLanguage);
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
        public ActionResult UpdateLanguage(MultiLanguage multiLanguage)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.Tbl_MultiLanguage.FirstOrDefault(x => x.id == multiLanguage.id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(multiLanguage);
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
        public JsonResult GetLanguageById(string language)
        {
            var languageData = dbcont.Tbl_MultiLanguage.FirstOrDefault(x => x.id.ToString() == language);
            return Json(languageData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteLAnguageById(string language)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_MultiLanguage.FirstOrDefault(e => e.id.ToString() == language);
                if (data != null)
                {
                    dbcont.Tbl_MultiLanguage.Remove(data);
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
        #region Pagination For Heading
        public ActionResult AddHeadingGrid()
        {
            var allLanguage = dbcont.Tbl_MultiLanguage.ToList();
            ViewBag.allLanguage = allLanguage;
            string query = "select name from sys.tables";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Generalate"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cmd.Dispose();
            ViewBag.TableList = new SelectList(dt.Rows);
            List<string> TableList = new List<string>();
            if (dt!=null && dt.Rows.Count > 0)
            {
                for (int i =0; i< dt.Rows.Count; i++)
                {
                    TableList.Add(Convert.ToString(dt.Rows[i][0]));
                }
            }
            ViewBag.TableList = TableList;
            return View();
        }
        
        public JsonResult GetAllColName(string tblName)
        {
            var allLanguage = dbcont.Tbl_MultiLanguage.ToList();
            ViewBag.allLanguage = allLanguage;
            string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + tblName + "'";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Generalate"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cmd.Dispose();
            ViewBag.TableList = new SelectList(dt.Rows);
            List<string> TableList = new List<string>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TableList.Add(Convert.ToString(dt.Rows[i][0]));
                }
            }
            
            return Json(TableList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveAllColName(string tblTableName,string ParameterName, string AliseName,string FrenchName, string PageCodes, string IsShow)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;

            try
            {
                if (tblTableName != "")
                {
                    string[] ParameterNameLst = ParameterName.Split(',');
                    string[] AliseNameLst = AliseName.Split(',');
                    string[] FrenchNameLst = FrenchName.Split(',');
                    string[] PageCodesLst = PageCodes.Split(',');
                    string[] IsShowLst = IsShow.Split(',');
                    for (int i = 0; i < ParameterNameLst.Count() ; i++)
                    {
                        tblAllTableParameterAlise tblAllTableParameterAlise = new tblAllTableParameterAlise();
                        tblAllTableParameterAlise.TableName = tblTableName;
                        tblAllTableParameterAlise.ParameterName = ParameterNameLst[i];
                        tblAllTableParameterAlise.AliasName = AliseNameLst[i];
                        tblAllTableParameterAlise.FrenchName = FrenchNameLst[i];
                        tblAllTableParameterAlise.PageCode = PageCodesLst[i];
                        tblAllTableParameterAlise.IsShow = Convert.ToInt32(IsShowLst[i]);
                        dbcont.tblAllTableParameterAlise.Add(tblAllTableParameterAlise);
                        dbcont.SaveChanges();
                    }
                }
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //Uplopad Multiplelanguage Excel File

        public int UploadLanguageExcelFile()
        {
            int status = 0;
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
#pragma warning disable CS0168 // The variable 'fname' is declared but never used
                        string fname;
#pragma warning restore CS0168 // The variable 'fname' is declared but never used

                        if ((file != null) && (file.ContentLength != 0) && !string.IsNullOrEmpty(file.FileName))
                        {
                            string fileName = file.FileName;
                            string fileContentType = file.ContentType;
                            byte[] fileBytes = new byte[file.ContentLength];
                            var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                            if (data > 0)
                            {
                                XLWorkbook Workbook = new XLWorkbook();
                                try
                                {
                                    Workbook = new XLWorkbook(file.InputStream);
                                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                                {
                                    return 0;
                                }
                                //var workSheet;
                                //try
                                //{

                                var workSheet = Workbook.Worksheet(1);
                                //workSheet.Cell("A").Value = "A1";
                                //workSheet.Cell("b").Value = "aa1";
                                //workSheet.Cell("c").Value = "Af1";


                                //}
                                //catch
                                //{
                                //    return 0;
                                //}
                                workSheet.FirstRow().Delete();//if you want to remove ist row

                                foreach (var row in workSheet.RowsUsed())
                                {


                                    row.Cell(1).Value.ToString();
                                    MultiLanguage multiLanguage = new MultiLanguage();

                                    multiLanguage.ControlId = row.Cell(1).Value.ToString();
                                    multiLanguage.ControlText = row.Cell(2).Value.ToString();
                                    multiLanguage.Language = "EN";
                                    multiLanguage.FranchText = row.Cell(3).Value.ToString();
                                    multiLanguage.Language2 = "FN";
                                    multiLanguage.SpanishText = row.Cell(4).Value.ToString();
                                    multiLanguage.Language3 = "SP";
                                    multiLanguage.ItalyText = row.Cell(5).Value.ToString();
                                    multiLanguage.Language4 = "IT";
                                    multiLanguage.GermanText = row.Cell(6).Value.ToString();
                                    multiLanguage.Language5 = "GR";
                                    multiLanguage.CreatedDate = DateTime.Now.ToString();

                                    dbcont.Tbl_MultiLanguage.Add(multiLanguage);
                                    dbcont.SaveChanges();
                                 

                                }
                                status = 1;
                            }
                        }
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    return 0;
                }
            }
            return status;
        }

        #region UserRole
        //add user role
        public ActionResult UserRole()
        {

            var data = dbcont.Tbl_UserRole.ToList();
            ViewBag.userrole = data;
            return View();
        }

        public ActionResult GetUserRoleById(int Id)
        {
            var data = dbcont.Tbl_UserRole.FirstOrDefault(x => x.Userrole_Id == Id);
            if(data != null)
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        
        public ActionResult AddUserRole(Tbl_UserRole tbl_UserRole)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                dbcont.Tbl_UserRole.Add(tbl_UserRole);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
        }

        public ActionResult UpdateUserRole(Tbl_UserRole tbl_UserRole)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_UserRole.FirstOrDefault(x => x.Userrole_Id == tbl_UserRole.Userrole_Id);
                if(data != null)
                {
                    dbcont.Entry(data).CurrentValues.SetValues(tbl_UserRole);
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }

            

        }

        public ActionResult DeleteUserRole(int id)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            var data = dbcont.Tbl_UserRole.FirstOrDefault(x => x.Userrole_Id == id);
            if(data != null)
            {
                dbcont.Tbl_UserRole.Remove(data);
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
        #endregion

        //role permission new design
        public ActionResult AddRolePermission()
        {
            var userrole = dbcont.Tbl_UserRole.ToList();
            ViewBag.Userrole = userrole;

            var topmenu = dbcont.Tbl_Topmenuheader.ToList();
            ViewBag.Topmenu = topmenu;

            var submenu = dbcont.Tbl_Submenuhead.ToList();
            //ViewBag.submenu = submenu;
            var data = dbcont.Tbl_UserRole.ToList();
            ViewBag.userrole = data;
            string currentUser = Convert.ToString(Session["username"]);
            string currentuserid = Convert.ToString(Session["userid"]);
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            List<Tbl_UserLogins> allpass = new List<Tbl_UserLogins>();
            var allProvince = dbcont.tbl_Province.ToList();
            List<tbl_PersonalDetails> allmembers = new List<tbl_PersonalDetails>();
            if (Convert.ToString(Session["username"]) == "admin")
            {
                allmembers = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes").ToList();
            }
            else
            {
                allmembers = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes" && x.ProvinceName == currentUser).ToList();
            }

            ViewBag.allmembers = allmembers;

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

           

            return View();
        }

        public JsonResult GetGeneralatedata(string provinceid)
        {
            if(provinceid == "0")
            {
                var provincedata = dbcont.tbl_Province.FirstOrDefault(x => x.ProvinceName == "Administration Centrale" || x.ProvinceName == "CENTRAL ADMINISTRATION");

                var personeldata = dbcont.tbl_PersonalDetails.Where(x => x.ProvinceName == provincedata.Id.ToString()).ToList();

                return Json(personeldata, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var provincelist = dbcont.tbl_Province.FirstOrDefault(x => x.MyId == provinceid);
                var personeldetails = dbcont.tbl_PersonalDetails.Where(x => x.ProvinceName == provincelist.Id.ToString()).ToList();
                return Json(personeldetails, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult GetAllProvinceData()
        {
            var data = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region TopMenuheader

        public ActionResult TopMenu()
        {
            var userrole = dbcont.Tbl_Topmenuheader.ToList();
            ViewBag.userrole = userrole;

            return View();
        }

        public ActionResult AddTopmenu(Tbl_Topmenuheader tbl_Topmenuheader)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                dbcont.Tbl_Topmenuheader.Add(tbl_Topmenuheader);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
        }

        public JsonResult GetTopmenuById(int id)
        {
            var data = dbcont.Tbl_Topmenuheader.FirstOrDefault(x => x.Header_id == id);
            if(data != null)
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateTopMenu(Tbl_Topmenuheader tbl_Topmenuheader)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_Topmenuheader.FirstOrDefault(x => x.Header_id == tbl_Topmenuheader.Header_id);
                if(data != null)
                {
                    dbcont.Entry(data).CurrentValues.SetValues(tbl_Topmenuheader);
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
        }

        public ActionResult DeleteTopmenuheader(int id)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
             var data   = dbcont.Tbl_Topmenuheader.FirstOrDefault(x => x.Header_id == id);
            if(data != null)
            {
                dbcont.Tbl_Topmenuheader.Remove(data);
                dbcont.SaveChanges();
                setcookies("202");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            else
            {
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
        }

        #endregion

        #region

        public ActionResult SubmenuHeader()
        {
            var Topmenu = dbcont.Tbl_Topmenuheader.ToList();
            ViewBag.Topmenu = Topmenu;

            var tblsubenu = dbcont.Tbl_Submenuhead.ToList();
            List<Tbl_Submenuhead> Tbl_Submenuhead = new List<Tbl_Submenuhead>();
            foreach(var item in tblsubenu)
            {
                
                Tbl_Submenuhead.Add(new Tbl_Submenuhead
                {
                    Submenu_Id = item.Submenu_Id,
                    Topmenu_Id = item.Topmenu_Id,
                    Submenu_Name = item.Submenu_Name,
                    Topmenu_Name = Topmenu.FirstOrDefault(x => x.Header_id == item.Topmenu_Id)?.Header_Name,
                    Page_name = item.Page_name
                });
            }
            ViewBag.submenu = Tbl_Submenuhead;

            return View();
        }

        public ActionResult AddSubmenu(Tbl_Submenuhead tbl_Submenuhead,HttpPostedFileBase file)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                if(file != null)
                {
                    if(file.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~Image/TopmenuIcons"), filename);
                        file.SaveAs(path);
                        tbl_Submenuhead.File_Name = filename;
                    }
                }

                dbcont.Tbl_Submenuhead.Add(tbl_Submenuhead);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
        }

        public JsonResult GetSubmenuById(int id)
        {
            var data = dbcont.Tbl_Submenuhead.FirstOrDefault(x => x.Submenu_Id == id);
            if(data != null)
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateSubmenu(Tbl_Submenuhead tbl_Submenuhead,HttpPostedFileBase file)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_Submenuhead.FirstOrDefault(x => x.Submenu_Id == tbl_Submenuhead.Submenu_Id);
                if(data != null)
                {
                    if (file != null)
                    {
                        if (file.ContentLength > 0)
                        {
                            var filename = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Image/TopmenuIcons"), filename);
                            file.SaveAs(path);
                            tbl_Submenuhead.File_Name = filename;
                        }
                    }
                    else
                    {
                        tbl_Submenuhead.File_Name = data.File_Name;
                    }

                    dbcont.Entry(data).CurrentValues.SetValues(tbl_Submenuhead);
                    dbcont.SaveChanges();
                    setcookies("200");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("200");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
        }

        public ActionResult DeleteSubmenu(int id)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            var data = dbcont.Tbl_Submenuhead.FirstOrDefault(x => x.Submenu_Id == id);
            if(data != null)
            {
                dbcont.Tbl_Submenuhead.Remove(data);
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

        #endregion

        public JsonResult GetsubmenuHeaderById(int id)
        {
            var topmenu = dbcont.Tbl_Topmenuheader.FirstOrDefault(x => x.Header_id == id);
            if(topmenu != null)
            {
                var tblsubmenu = dbcont.Tbl_Submenuhead.Where(x => x.Topmenu_Id == topmenu.Header_id).ToList();
                List<Tbl_Submenuhead> Tbl_Submenuhead = new List<Tbl_Submenuhead>();
                foreach(var item in tblsubmenu)
                {
                    Tbl_Submenuhead.Add(new Tbl_Submenuhead
                    {
                        Submenu_Id = item.Submenu_Id,
                        Topmenu_Id = item.Topmenu_Id,
                        Submenu_Name = item.Submenu_Name,
                        Topmenu_Name = topmenu.Header_Name,
                        Page_name = item.Page_name
                    });
                }
                var submenu = dbcont.Tbl_Submenuhead.ToList();
                ViewBag.submenu = submenu;
                return Json(Tbl_Submenuhead, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(topmenu, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetsubmenutabsById(int id,int roleid)
        {
            try
            {
                var submenuHeader = dbcont.Tbl_Submenuhead.FirstOrDefault(x => x.Submenu_Id == id);
                if (submenuHeader != null)
                {
                    var tbl_Submenutabs = dbcont.Tbl_SubmenuTabs.Where(x => x.Submenu_Id == submenuHeader.Submenu_Id).ToList();
                    List<Tbl_SubmenuTabs> tbl_SubmenuTabs = new List<Tbl_SubmenuTabs>();
                    List<Tbl_TopMenuPermission> subMenuTabwithActive = new List<Tbl_TopMenuPermission>();
                    foreach (var item in tbl_Submenutabs)
                    {
                        tbl_SubmenuTabs.Add(new Tbl_SubmenuTabs
                        {
                            SubmenuTabsId = item.SubmenuTabsId,
                            Submenu_Id = item.Submenu_Id,
                            Submenutab_Name = item.Submenutab_Name
                        });
                        //var topMenuResult = dbcont.Tbl_TopMenuPermission.Where(tp => tp.PageName == item.Submenutab_Name && tp.HasPermission == true && tp.RoleId == roleid.ToString()).FirstOrDefault();

                        var topMenuResult = dbcont.Tbl_TopMenuPermission.Where(tp => tp.PageName == item.Submenutab_Name && tp.HasPermission == true && tp.RoleId == roleid.ToString() && tp.ParentId == item.Submenu_Id).FirstOrDefault();

                        if (topMenuResult != null)
                        {
                            subMenuTabwithActive.Add(
                                new Tbl_TopMenuPermission
                                {
                                    TopMenu_Id = item.Submenu_Id,
                                    PageName = item.Submenutab_Name,
                                    HasPermission = topMenuResult.HasPermission,
                                    Createpermission = topMenuResult.Createpermission,
                                    Editpermission = topMenuResult.Editpermission,
                                    Deletepermission = topMenuResult.Deletepermission,
                                    Viewpermission = topMenuResult.Viewpermission

                                }
                                );
                        }
                        else
                        {
                            subMenuTabwithActive.Add(
                           new Tbl_TopMenuPermission
                           {
                               TopMenu_Id = item.Submenu_Id,
                               PageName = item.Submenutab_Name,
                               HasPermission = false,
                               Createpermission = false,
                               Editpermission = false,
                               Deletepermission = false,
                               Viewpermission = false

                           }
                           );
                        }
                    }

                    return Json(subMenuTabwithActive, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(submenuHeader, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }


        //addtopmenupermission
        [HttpPost]
        [AllowAnonymous]
        public JsonResult SaveTopmenuPersmission(List<Tbl_TopMenuPermission> data)
        {
            var topmenudata = dbcont.Tbl_TopMenuPermission.ToList();
            var topmenheader = dbcont.Tbl_Submenuhead.ToList();
            var submenuTab = dbcont.Tbl_SubmenuTabs.ToList();
            if (data.Count() > 0)
            {
                //delete all roles
                var rolename = data.FirstOrDefault().RoleName;
                //var allrolePermission = dbcont.Tbl_TopMenuPermission.Where(x => x.RoleName == rolename).ToList();
                //dbcont.Tbl_TopMenuPermission.RemoveRange(allrolePermission);
                //dbcont.SaveChanges();
                //delete all entiry for role

                foreach (var item in data)
                {
                    var topheader = submenuTab.FirstOrDefault(x => x.Submenutab_Name == item.PageName && x.Submenu_Id == item.ParentId);
                    var topmenu = topmenudata.FirstOrDefault(x => x.RoleId == item.RoleId && x.ParentId == item.ParentId && x.PageName.Trim().ToUpper() == topheader.Submenutab_Name.Trim().ToUpper());
                    var pagename = topmenheader.Where(x => x.Submenu_Id == item.ParentId).Select(x => x.Page_name).FirstOrDefault();
                    //item.PageViewName = pagename;

                    if (topmenu !=null)
                    {
                        item.TopMenu_Id = topmenu.TopMenu_Id;
                        item.PageViewName = topheader.PageViewURL;// topmenu.PageViewName;
                        item.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        dbcont.Entry(topmenu).CurrentValues.SetValues(item);
                        dbcont.SaveChanges();
                    }
                    else
                    {
                        //item.TopMenu_Id = topmenu.TopMenu_Id;
                        item.PageViewName = topheader.PageViewURL;
                        item.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        dbcont.Tbl_TopMenuPermission.Add(item);
                    }
                   
                    
                }
                dbcont.SaveChanges();
            }
            return Json(true);
        }
         
        public JsonResult GetRolepermissionById(int id)
        {
            var userrole = dbcont.Tbl_UserRole.FirstOrDefault(x => x.Userrole_Id == id)?.Role_Name;
            if(userrole != null)
            {
                var data = dbcont.Tbl_UserLogins.Where(x => x.UserRole == userrole).ToList();
                var tblpersoneldata = dbcont.tbl_PersonalDetails.ToList();
                List<tbl_PersonalDetails> tbl_PersonalDetails = new List<tbl_PersonalDetails>();
                if (data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var memberid = tblpersoneldata.FirstOrDefault(x => x.MemberID == item.MemberId);
                        if (memberid != null)
                        {
                            tbl_PersonalDetails.Add(new tbl_PersonalDetails
                            {
                                MemberID = item.MemberId,
                                Name = memberid.Name,
                                SirName = memberid.SirName
                            });
                        }
                    }
                }
                return Json(tbl_PersonalDetails, JsonRequestBehavior.AllowGet);
          
            }
            else
            {
                return Json(userrole, JsonRequestBehavior.AllowGet);
            }
        }

    }
}