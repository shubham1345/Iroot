using ClosedXML.Excel;
using Generalate.Helpers;
using Generalate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class CommunityController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: Community
        public async Task<ActionResult> CommunityInstitution()
        {
            
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var allProvince = dbcont.tbl_Province.ToList();
                List<Tbl_Cong> alldata = new List<Tbl_Cong>();

                var allins = await dbcont.Tbl_Cong.Where(x => x.Status == 1).OrderBy(x => x.CongregationName).ToListAsync();
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
                List<Tbl_Cong> alldata = new List<Tbl_Cong>();

                var allins = dbcont.Tbl_Cong.Where(x => x.ProvinceName == currentUser && x.Status == 1).ToList();
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
        public async Task<ActionResult> Create(string Id)
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
                if (!string.IsNullOrEmpty(Id))
                {
                    var communityName = dbcont.Tbl_Cong.Where(x => x.Id.ToString() == Id).FirstOrDefault().CongregationName;
                    var allAppointments = dbcont.Appointments.Where(x => x.CommunityType.Contains(communityName) && x.Status == "Active").ToList();
                    ViewBag.Appointments = allAppointments;
                    var AppointmentDetailToInst = dbcont.Appointments.Where(x => x.CommunityType == communityName && x.Status == "Active" && x.DesignationType == "Local Superior").ToList();
                    ViewBag.AppointmentDetailToInst = AppointmentDetailToInst;
                }
                ViewBag.CoutryDataListItems = countryDataListItems;
                ViewBag.DioceseId = dbcont.tbl_Diocese.Count() + 1;
                if (Id != null && Id != "")
                {
                    BindViewBag();
                    Tbl_Cong Tbl_Cong = await dbcont.Tbl_Cong.FirstOrDefaultAsync(e => e.Id.ToString() == Id);
                    List<tbl_CommunityGallery> tbl_CommunityGallery = dbcont.Tbl_CommunityGallery.Where(x => x.MainID == Tbl_Cong.CommId).ToList();
                    List<tblCommunityImportantDates> tblCommunityImportantDates = dbcont.tblCommunityImportantDates.Where(x => x.MainID == Tbl_Cong.CommId).ToList();
                    ViewBag.tbl_ProvinceGallery = JsonConvert.SerializeObject(tbl_CommunityGallery);
                    ViewBag.tblProvienceImportantDates = JsonConvert.SerializeObject(tblCommunityImportantDates);
                    return View(Tbl_Cong);
                }
                else
                {
                    BindViewBag();
                    ViewBag.CommId = dbcont.Tbl_Cong.Count() + 1;
                    ViewBag.tbl_ProvinceGallery = JsonConvert.SerializeObject(null);
                    ViewBag.tblProvienceImportantDates = JsonConvert.SerializeObject(null);
                    var userName = Session["username"].ToString();
                    string GetCurrentUserName = dbcont.Tbl_UserLogins.Where(x => x.UserName.ToUpper() == userName.ToUpper()).Select(x => x.UserRole).FirstOrDefault().ToString();
                    int GetCurrentUserRoleId = Convert.ToInt32(dbcont.Tbl_UserRole.Where(x => x.Role_Name.ToUpper() == GetCurrentUserName.ToUpper()).Select(x => x.Userrole_Id).FirstOrDefault());
                    string CurrentPageName = "Community";
                    int topMenuId = dbcont.Tbl_Topmenuheader.Where(x => x.Header_Name.ToUpper().Trim() == CurrentPageName.ToUpper().Trim()).Select(x => x.Header_id).FirstOrDefault();
                    int Submenu_Id = dbcont.Tbl_Submenuhead.Where(x => x.Submenu_Name.ToUpper() == CurrentPageName.ToUpper() && x.Topmenu_Id == topMenuId).Select(x => x.Submenu_Id).FirstOrDefault();
                   
                    var RolePermissionTage = (from m in dbcont.Tbl_TopMenuPermission.ToList()
                                              from n in dbcont.Tbl_Submenuhead.ToList()
                                              where m.ParentId == n.Submenu_Id && Convert.ToInt32(m.RoleId) == GetCurrentUserRoleId && m.ParentId == Submenu_Id
                                              && Convert.ToUInt32(m.HasPermission) == 1
                                              select new Tbl_RolePermission
                                              {
                                                  TagName = m.PageName,
                                                  Url = m.PageViewName
                                              }).ToList();
                    Session["RolePermissionTage"] = RolePermissionTage.ToList();
                     return View(new Tbl_Cong());
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
        public async Task<ActionResult> Create(Tbl_Cong tbl_Cong, HttpPostedFileBase File, string[] Activities, string Operation, string[] Names, string[] Days, string[] Months, string[] Title, HttpPostedFileBase[] files, string[] spanImgName)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            //Operation = "Edit";
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            try
            {
                if (Operation == "Edit" && Operation != null)
                {
                    Tbl_Cong tbl_CongPast = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id == tbl_Cong.Id);

                    tblCommunityImportantDates tblCommunityImportantDatesMain = new tblCommunityImportantDates();
                    tbl_CommunityGallery tbl_CommunityGalleryMain = new tbl_CommunityGallery();
                    List<tbl_CommunityGallery> tbl_CommunityGallery = dbcont.Tbl_CommunityGallery.Where(x => x.MainID == tbl_Cong.CommId).ToList();
                    List<tblCommunityImportantDates> tblCommunityImportantDates = dbcont.tblCommunityImportantDates.Where(x => x.MainID == tbl_Cong.CommId).ToList();
                    if (tbl_CongPast != null)
                    {
                        tbl_Cong.CreatedBy = tbl_CongPast.CreatedBy;
                        tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
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
                    if (tblCommunityImportantDates.Count > 0)
                    {
                        for (int i = 0; i < tblCommunityImportantDates.Count; i++)
                        {
                            tblCommunityImportantDates tblCommunityImportantDatesPast = dbcont.tblCommunityImportantDates.Where(x => x.MainID == tbl_Cong.CommId).FirstOrDefault();
                            dbcont.tblCommunityImportantDates.Remove(tblCommunityImportantDatesPast);
                            dbcont.SaveChanges();
                        }
                    }
                    tblCommunityImportantDatesMain.MainID = tbl_Cong.CommId;
                    if (Names != null)
                    {
                        for (int j = 0; j < Names.Count(); j++)
                        {
                            tblCommunityImportantDatesMain.Name = Names[j];
                            tblCommunityImportantDatesMain.Day = Convert.ToInt32((Days[j]).Replace("\"", "").ToString());
                            tblCommunityImportantDatesMain.Month = Convert.ToInt32((Months[j]).Replace("\"", "").ToString());
                            tblCommunityImportantDatesMain.IsActive = 1;
                            dbcont.tblCommunityImportantDates.Add(tblCommunityImportantDatesMain);
                            await dbcont.SaveChangesAsync();
                        }
                    }
                    if (tbl_CommunityGallery.Count > 0)
                    {
                        for (int i = 0; i < tbl_CommunityGallery.Count; i++)
                        {
                            tbl_CommunityGallery tbl_CommunityGalleryPast = dbcont.Tbl_CommunityGallery.Where(x => x.MainID == tbl_Cong.CommId).FirstOrDefault();
                            dbcont.Tbl_CommunityGallery.Remove(tbl_CommunityGalleryPast);
                            dbcont.SaveChanges();
                        }
                    }
                    tbl_CommunityGalleryMain.MainID = tbl_Cong.CommId;
                    int Count = 0;
                    if (spanImgName != null)
                    {
                        for (int k = 0; k < spanImgName.Count(); k++)
                        {
                            if (spanImgName[k] != "")
                            {
                                tbl_CommunityGalleryMain.IsActive = 1;
                                tbl_CommunityGalleryMain.FileName = spanImgName[k];
                                tbl_CommunityGalleryMain.Title = Title[Count];
                                dbcont.Tbl_CommunityGallery.Add(tbl_CommunityGalleryMain);
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
                                    var path = Path.Combine(Server.MapPath("~/Image/CommunityInstitutionGallery"), fileName);
                                    file.SaveAs(path);
                                    tbl_CommunityGalleryMain.IsActive = 1;
                                    tbl_CommunityGalleryMain.FileName = fileName;
                                }
                                tbl_CommunityGalleryMain.Title = Title[Count];
                                dbcont.Tbl_CommunityGallery.Add(tbl_CommunityGalleryMain);
                                await dbcont.SaveChangesAsync();
                                Count++;
                            }
                        }
                    }
                    dbcont.Entry(tbl_CongPast).CurrentValues.SetValues(tbl_Cong);
                    dbcont.SaveChanges();
                    return RedirectToAction("CommunityInstitution", "Community");
                }
                else
                {
                    tbl_CommunityGallery tbl_Province = new tbl_CommunityGallery();
                    tblCommunityImportantDates tblProvienceImportantDates = new tblCommunityImportantDates();
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
                        tbl_Province.MainID = tbl_Cong.CommId;
                        tblProvienceImportantDates.MainID = tbl_Cong.CommId;

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
                                        var path = Path.Combine(Server.MapPath("~/Image/CommunityInstitutionGallery"), fileName);
                                        file.SaveAs(path);
                                        tbl_Province.IsActive = 1;
                                        tbl_Province.FileName = fileName;
                                    }
                                    tbl_Province.Title = Title[i];
                                    dbcont.Tbl_CommunityGallery.Add(tbl_Province);
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
                                dbcont.tblCommunityImportantDates.Add(tblProvienceImportantDates);
                                await dbcont.SaveChangesAsync();
                            }
                        }
                        tbl_Cong.CreatedBy = currentloginuserid;
                        tbl_Cong.Activities = Activities == null ? "" : String.Join(",", Activities);
                        dbcont.Tbl_Cong.Add(tbl_Cong);
                        await dbcont.SaveChangesAsync();

                    }
                    return RedirectToAction("CommunityInstitution", "Community");
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
        public async Task<ActionResult> GetGrid(string name, int? firstItem, int? lastItem, string SearchTxt, Tbl_Cong tbl_ParisInstitutionDetails, string archieve)
       {
#pragma warning disable CS0219 // The variable 'Html' is assigned but its value is never used
            string Html = "";
#pragma warning restore CS0219 // The variable 'Html' is assigned but its value is never used
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            ViewBag.StartIndex = firstItem;
            var status = !string.IsNullOrEmpty(archieve) ? 3 : 1;
            var status2 = !string.IsNullOrEmpty(archieve) ? 3 : 0;
            var ColumnShow = dbcont.tblUserDynamicConfiguration.Where(x => x.CurrentUser == currentUser && x.ListType == "4").FirstOrDefault();
            ViewBag.ColumnShowComm = ColumnShow == null ? "" : Convert.ToString(ColumnShow.ListData);
            if (Session["username"].ToString() == "admin")
            {

                var allProvince = dbcont.tbl_Province.ToList();
                List<Tbl_Cong> alldata = new List<Tbl_Cong>();
                List<string> provinceId = new List<string>();
                List<string> provincetxtId = new List<string>();
                if (!string.IsNullOrEmpty("SearchTxt"))
                {
                    provincetxtId = allProvince.Where(x => x.ProvinceName.ToLower().Contains(SearchTxt.ToLower())).Select(i => i.Id.ToString()).ToList();
                }
                
                provinceId = allProvince.Select(i => i.Id.ToString()).ToList();
                var com = dbcont.Tbl_Cong;
                
                var provinceName = dbcont.tbl_Province.Select(x=> x.Id.ToString()).ToList();
                
                var allins = await dbcont.Tbl_Cong.Where(x => (x.Status == status || x.Status == status2) && provinceName.Contains(x.ProvinceName) && (x.CongregationName.Contains(SearchTxt) || x.Phone.Contains(SearchTxt) || x.CommCode.Contains(SearchTxt) || x.DisSec.Contains(SearchTxt) || x.Place.Contains(SearchTxt) || x.Country.Contains(SearchTxt) || x.EmailId.Contains(SearchTxt) || x.PostalCode.Contains(SearchTxt) || x.Continent.Contains(SearchTxt) || x.CommunityType.Contains(SearchTxt)  || x.Diocese.Contains(SearchTxt) || x.Activities.Contains(SearchTxt) || x.Address.Contains(SearchTxt) || x.Vission.Contains(SearchTxt) || x.Mission.Contains(SearchTxt) || x.StartDate.Contains(SearchTxt) || x.EndDate.Contains(SearchTxt) || x.SuspensionDate.Contains(SearchTxt) || x.RestartDate.Contains(SearchTxt) || x.Remark.Contains(SearchTxt) || (provincetxtId.Contains(x.ProvinceName)) || x.ProvinceName.ToLower().Contains(SearchTxt.ToLower())) && (provinceId.Contains(x.ProvinceName))).OrderBy(x => x.CongregationName).ToListAsync();
                if (allins != null && allins.Count != 0)
                {
                    ViewBag.allinstitutionTotalCount = allins.Count();
                }
                else
                {
                    ViewBag.allinstitutionTotalCount = 0;
                }
                if (firstItem != null && lastItem != null)
                {
                    int from = Convert.ToInt32(firstItem);
                    int To = Convert.ToInt32(lastItem);
                    var filteredData = allins.Skip(Math.Max(0, from - 1)).Take(To - (from - 1));
                    allins = filteredData.ToList();
                }

                foreach (var item in allins)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName||x.ProvinceName==item.ProvinceName);

                    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                    alldata.Add(item);
                }

                ViewBag.allinstitution = alldata;
            }
            else
            {
                var allProvince = dbcont.tbl_Province.ToList();
                List<Tbl_Cong> alldata = new List<Tbl_Cong>();

                var allins = await dbcont.Tbl_Cong.Where(x => x.ProvinceName == currentUser && (x.Status == status || x.Status == status2) && (x.CongregationName.Contains(SearchTxt) || x.Phone.Contains(SearchTxt) || x.CommCode.Contains(SearchTxt) || x.DisSec.Contains(SearchTxt) || x.Place.Contains(SearchTxt) || x.Country.Contains(SearchTxt) || x.EmailId.Contains(SearchTxt) || x.PostalCode.Contains(SearchTxt) || x.Continent.Contains(SearchTxt) || x.CommunityType.Contains(SearchTxt) || x.Diocese.Contains(SearchTxt) || x.Activities.Contains(SearchTxt) || x.Address.Contains(SearchTxt) || x.Vission.Contains(SearchTxt) || x.Mission.Contains(SearchTxt) || x.StartDate.Contains(SearchTxt) || x.EndDate.Contains(SearchTxt) || x.SuspensionDate.Contains(SearchTxt) || x.RestartDate.Contains(SearchTxt) || x.Remark.Contains(SearchTxt))).OrderBy(x => x.CongregationName).ToListAsync();
                if (allins != null && allins.Count != 0)
                {
                    ViewBag.allinstitutionTotalCount = allins.Count();
                }
                else
                {
                    ViewBag.allinstitutionTotalCount = 0;
                }
                if (firstItem != null && lastItem != null)
                {
                    int from = Convert.ToInt32(firstItem);
                    int To = Convert.ToInt32(lastItem);
                    var filteredData = allins.Skip(Math.Max(0, from - 1)).Take(To - (from - 1));
                    allins = filteredData.ToList();
                }

                foreach (var item in allins)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName || x.ProvinceName == item.ProvinceName);

                    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                    alldata.Add(item);
                }

                ViewBag.allinstitution = alldata;
            }
            return PartialView("_InstitutionCreatedList");
            //return Json(new { Url = Url.Action("_InstitutionCreatedList", ViewBag.allinstitution) });
        }
        [HttpPost]
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ActionResult> GetStatisticCommunity()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["Generalate"].ConnectionString);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("sp_GetStatisticCommunity", con2);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@flag", 0);
            SqlDataAdapter da2 = new SqlDataAdapter();
            da2.SelectCommand = cmd2;
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con2.Close();
            cmd2.Dispose();
            ViewBag.StatisticCommunity = dt2;
            return PartialView("_ViewStatisticCommunity");
        }

        [HttpPost]
        public ActionResult CommunityList(string Provincename)
        {
            string currentUser = Convert.ToString(Session["username"]);
            var data = dbcont.tblUserDynamicConfiguration.Where(x => x.CurrentUser == currentUser && x.ListType == "3").FirstOrDefault();
            ViewBag.ColumnShowExp = data == null ? "" : Convert.ToString(data.ListData);

            List<string> provinceId = new List<string>();

            var data1 = dbcont.tbl_Province.ToList();
            provinceId = data1.Select(i => i.Id.ToString()).ToList();

            var Filterprovince = dbcont.tbl_Province.FirstOrDefault(x => x.ProvinceName == Provincename);
            var id = Filterprovince.Id.ToString();

            var FilterCongdata = dbcont.Tbl_Cong.Where(x => x.ProvinceName == id ).ToList();
            ViewBag.CommunityList = FilterCongdata;
            ViewBag.Provincename = Provincename;
            return PartialView("_ParticularCommunity");

        }

        [HttpGet]
        public FileResult ExportFilterCommunityDatatoExcel(string ProvinceName)
        {
            string currentUser = Convert.ToString(Session["username"]);


            List<string> provinceId = new List<string>();

            var data1 = dbcont.tbl_Province.ToList();
            provinceId = data1.Select(i => i.Id.ToString()).ToList();

            var Filterprovince = dbcont.tbl_Province.FirstOrDefault(x => x.ProvinceName == ProvinceName);
            var id = Filterprovince.Id.ToString();

            var FilterCongdata = dbcont.Tbl_Cong.Where(x => x.ProvinceName == id).ToList();
            DataTable dt = new DataTable();
            int count = 1;
            var data = dbcont.tblUserDynamicConfiguration.Where(x => x.CurrentUser == currentUser && x.ListType == "3").FirstOrDefault();
            string ValidCols = data == null ? "" : Convert.ToString(data.ListData);
            string[] ColumnsArr = ValidCols.Split(',');

            foreach(string col in ColumnsArr)
            {
                if(col == "1")
                {
                    dt.Columns.Add("S_No.", typeof(System.String));
                }
               
                if (col == "2")
                {
                    dt.Columns.Add("Congregation Name", typeof(System.String));
                }
                if (col == "3")
                {
                    dt.Columns.Add("Community Code", typeof(System.String));
                }
                if (col == "4")
                {
                    dt.Columns.Add("Place", typeof(System.String));
                }
                if (col == "5")
                {
                    dt.Columns.Add("Phone", typeof(System.String));
                }
                if (col == "6")
                {
                    dt.Columns.Add("Country", typeof(System.String));
                }
                if (col == "7")
                {
                    dt.Columns.Add("Email Id", typeof(System.String));
                }
                if (col == "8")
                {
                    dt.Columns.Add("Comm ID", typeof(System.String));
                }
            }

            foreach(var item in data1)
            {
                DataRow row = dt.NewRow();
                if (ColumnsArr.Contains("1"))
                {
                    row["SrNO"] = count;

                }
                if (ColumnsArr.Contains("2"))
                {
                    row["Congregation Name"] = count;

                }
                if (ColumnsArr.Contains("3"))
                {
                    row["Community Code"] = count;

                }
                if (ColumnsArr.Contains("4"))
                {
                    row["Place"] = count;

                }
                if (ColumnsArr.Contains("5"))
                {
                    row["Phone"] = count;

                }
                if (ColumnsArr.Contains("6"))
                {
                    row["Country"] = count;

                }
                if (ColumnsArr.Contains("7"))
                {
                    row["Email Id"] = count;

                }
                if (ColumnsArr.Contains("8"))
                {
                    row["Comm ID"] = count;

                }

                dt.Rows.Add(row);
                count++;
            }

            using (XLWorkbook wb = new XLWorkbook()) //Install ClosedXml from Nuget for XLWorkbook
            {

                wb.Worksheets.Add(dt, "sheet1");
                using (MemoryStream stream = new MemoryStream()) //using System.IO;  
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelFile.xlsx");
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetGridForProv(string name, sbyte? firstItem, sbyte? lastItem, string SearchTxt, Tbl_Cong tbl_ParisInstitutionDetails, string archieve)
        {
#pragma warning disable CS0219 // The variable 'Html' is assigned but its value is never used
            string Html = "";
#pragma warning restore CS0219 // The variable 'Html' is assigned but its value is never used
            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            ViewBag.StartIndex = firstItem;
            var status = !string.IsNullOrEmpty(archieve) ? 3 : 1;
            
            {

                var allProvince = dbcont.tbl_Province.Where(x => x.Id.ToString() == name).ToList();
                List<Tbl_Cong> alldata = new List<Tbl_Cong>();
                List<string> provinceId = new List<string>();
                if (!string.IsNullOrEmpty("SearchTxt"))
                {
                    provinceId = allProvince.Where(x => x.ProvinceName.ToLower().Contains(SearchTxt.ToLower())).Select(i => i.Id.ToString()).ToList();
                }
                else
                {
                    provinceId = allProvince.Select(i => i.Id.ToString()).ToList();
                }
                var com = dbcont.Tbl_Cong;
                var allins = await dbcont.Tbl_Cong.Where(x => x.Status == status && x.ProvinceName == name && (x.CongregationName.Contains(SearchTxt) || x.Phone.Contains(SearchTxt) || x.ProvinceName.ToLower().Contains(SearchTxt.ToLower()) || provinceId.Contains(x.ProvinceName))).OrderBy(x => x.CongregationName).ToListAsync();
                ViewBag.TotalDataCount = allins == null ? 0 : allins.Count();
                if (firstItem != null && lastItem != null)
                {
                    sbyte from = Convert.ToSByte(firstItem);
                    sbyte To = Convert.ToSByte(lastItem);
                    var filteredData = allins.Skip(Math.Max(0, from - 1)).Take(To - (from - 1));
                    allins = filteredData.ToList();
                }

                foreach (var item in allins)
                {
                    var provDetails = allProvince.FirstOrDefault(x => x.Id.ToString() == item.ProvinceName || x.ProvinceName == item.ProvinceName);

                    item.ProvinceName = provDetails == null ? "Not Exist" : provDetails.ProvinceName;
                    alldata.Add(item);
                }

                ViewBag.allinstitution = alldata;
            }
            
            return PartialView("_CommunityGridForProv");
            //return Json(new { Url = Url.Action("_InstitutionCreatedList", ViewBag.allinstitution) });
        }

        public async Task<ActionResult> Edit(int Id)
        {
            BindViewBag();
            Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails = await dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return View(tbl_ParisInstitutionDetails);
        }

        public async Task<ActionResult> CommunityMember(int Id)
        {
            
            Tbl_ParisInstitutionDetails tbl_ParisInstitutionDetails = await dbcont.Tbl_ParisInstitutionDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return View(tbl_ParisInstitutionDetails);
        }
        public ActionResult DeleteParisInstitutionDetails(string Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                Tbl_Cong genralobj = dbcont.Tbl_Cong.FirstOrDefault(e => e.Id.ToString() == Id);
                if (genralobj != null)
                {
                    dbcont.Tbl_Cong.Remove(genralobj);
                    dbcont.SaveChanges();
                    return RedirectToAction("CommunityInstitution", "Community");
                    //return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    return RedirectToAction("CommunityInstitution", "Community");
                    //return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                return Json("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
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
    }
}