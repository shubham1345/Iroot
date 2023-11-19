using Generalate.Helpers;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class AllProvinceDataController : Controller
    {
        private GeneralDBContext db = new GeneralDBContext();
        private GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllProvinceData()
        {
            return View();
        }

        [HttpGet]
        public JsonResult AllProvinceDataReport(string FromDate, string ToDate)
        {
            StringBuilder Header = new StringBuilder();
            StringBuilder Body = new StringBuilder();
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            var datalist = dbcont.DataListItems.Where(x => x.DataListName == "Stage of Formation" || x.DataListName == "StageOfFormation").ToList();
            var allStageOfFormation = datalist.Where(x => x.intRank != 1).OrderBy(x => x.Name).ToList();
            var FilterStageOfVows = dbcont.Tbl_ProfessionDetails.ToList();
            var FilterStageOfFormation = allStageOfFormation.Except(allStageOfFormation.Where(x => x.Name.Contains("Vows")).ToList()).ToList();
            
            string langCode = Convert.ToString(System.Web.HttpContext.Current.Session["CurrentLang"]);
            List<MultiLanguage> allLangs = System.Web.HttpContext.Current.Session["Language"] as List<MultiLanguage>;


            if (string.IsNullOrEmpty(FromDate) && string.IsNullOrEmpty(ToDate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(FromDate);
                lastDay = Convert.ToDateTime(ToDate);
            }
            List<int> TotalSumFormation = new List<int>();
            List<int> TotalSumProfession = new List<int>();
            #region Generate Header
            Header.Append("<thead>");
            Header.Append("<tr>");
            Header.Append("<th>"+ HomeController.GetControlTextByControlId("Province") +"</th>");
            Header.Append("<th></th>");

            Header.Append("<th colspan='"+ Convert.ToString(FilterStageOfFormation==null?1: FilterStageOfFormation.Count()) + "'>" + HomeController.GetControlTextByControlId("Formation") + "</th>");
            Header.Append("<th colspan='"+ Convert.ToString(FilterStageOfVows == null?1: FilterStageOfVows.Count()) + "'>" + HomeController.GetControlTextByControlId("Profession") + "</th>");
            //Header.Append("<th>Grand Total Prof. + Nov.</th>");
            //Header.Append("<th>Sep. T.V</th>");
            //Header.Append("<th>Sep. P.V</th>");
            //Header.Append("<th>Total Profes</th>");
            //Header.Append("<th colspan='2' scope='colgroup'>Novices</th>");
            //Header.Append("<th>Grand Total Prof + Nov</th>");
            Header.Append("<th colspan='3' scope='colgroup'>" + HomeController.GetControlTextByControlId("All Separation") + "</th>");
            Header.Append("<th>" + HomeController.GetControlTextByControlId("Death") + "</th>");
            Header.Append("<th colspan='2' scope='colgroup'>" + HomeController.GetControlTextByControlId("Transferts") + "</th>");
            Header.Append("</tr>");
            Header.Append("<tr>");
            Header.Append("<th scope='col'></th>");
            Header.Append("<th scope='col'></th>");

            if(langCode == "EN")
            {
                foreach (var item in FilterStageOfFormation)
                {
                    
                    {
                        Header.Append("<th scope='col'>" + item.Name + "</th>");
                        TotalSumFormation.Add(0);
                    }
                   
                }
                foreach (var item in FilterStageOfVows)
                {
                    Header.Append("<th scope='col'>" + item.Name + "</th>");
                    TotalSumProfession.Add(0);
                }
            }
            else
            {
                foreach (var item in FilterStageOfFormation)
                {
                    
                    {
                        Header.Append("<th scope='col'>" + item.Name_French + "</th>");
                        TotalSumFormation.Add(0);
                    }
                    
                }
                foreach (var item in FilterStageOfVows)
                {
                    Header.Append("<th scope='col'>" + item.Name_French + "</th>");
                    TotalSumProfession.Add(0);
                }
            }

            
            //Header.Append("<th scope='col'>" + (FromDate == "" ? firstDay.ToString("dd/MM/yyyy") : FromDate).ToString() + "</th>");
            //Header.Append("<th scope='col'>" + (FromDate == "" ? firstDay.ToString("dd/MM/yyyy") : FromDate).ToString() + "</th>");
            //Header.Append("<th scope='col'>( - )</th>");
            //Header.Append("<th scope='col'>( - )</th>");
            //Header.Append("<th scope='col'>" + (ToDate == "" ? lastDay.ToString("dd/MM/yyyy") : ToDate).ToString() + "</th>");
            //Header.Append("<th scope='col'> 1st Y. ( + )</th>");
            //Header.Append("<th scope='col'> 2nd Y. ( + )</th>");
            //Header.Append("<th scope='col'>" + (ToDate == "" ? lastDay.ToString("dd/MM/yyyy") : ToDate).ToString() + "</th>");
            Header.Append("<th scope='col'>Nov</th>");
            Header.Append("<th scope='col'>VT</th>");
            Header.Append("<th scope='col'>VP</th>");
            Header.Append("<th scope='col'></th>");
            Header.Append("<th scope='col'>(-)</th>");
            Header.Append("<th scope='col'>(+)</th>");
            Header.Append("</tr>");
            Header.Append("</thead>");
            //Header.Append("<thead>");
            //Header.Append("<tr>");
            //Header.Append("<th>Provinces</th>");
            //Header.Append("<th></th>");

            //Header.Append("<th>Total Prof.</th>");
            //Header.Append("<th>Grand Total Prof. + Nov.</th>");
            //Header.Append("<th>Sep. T.V</th>");
            //Header.Append("<th>Sep. P.V</th>");
            //Header.Append("<th>Total Profes</th>");
            //Header.Append("<th colspan='2' scope='colgroup'>Novices</th>");
            //Header.Append("<th>Grand Total Prof + Nov</th>");
            //Header.Append("<th colspan='3' scope='colgroup'>All Separation</th>");
            //Header.Append("<th>Death</th>");
            //Header.Append("<th colspan='2' scope='colgroup'>Transferts</th>");
            //Header.Append("</tr>");
            //Header.Append("<tr>");
            //Header.Append("<th scope='col'></th>");
            //Header.Append("<th scope='col'></th>");
            //Header.Append("<th scope='col'>" + (FromDate == "" ? firstDay.ToString("dd/MM/yyyy") : FromDate).ToString() + "</th>");
            //Header.Append("<th scope='col'>" + (FromDate == "" ? firstDay.ToString("dd/MM/yyyy") : FromDate).ToString() + "</th>");
            //Header.Append("<th scope='col'>( - )</th>");
            //Header.Append("<th scope='col'>( - )</th>");
            //Header.Append("<th scope='col'>" + (ToDate == "" ? lastDay.ToString("dd/MM/yyyy") : ToDate).ToString() + "</th>");
            //Header.Append("<th scope='col'> 1st Y. ( + )</th>");
            //Header.Append("<th scope='col'> 2nd Y. ( + )</th>");
            //Header.Append("<th scope='col'>" + (ToDate == "" ? lastDay.ToString("dd/MM/yyyy") : ToDate).ToString() + "</th>");
            //Header.Append("<th scope='col'>Nov</th>");
            //Header.Append("<th scope='col'>VT</th>");
            //Header.Append("<th scope='col'>VP</th>");
            //Header.Append("<th scope='col'></th>");
            //Header.Append("<th scope='col'>(-)</th>");
            //Header.Append("<th scope='col'>(+)</th>");
            //Header.Append("</tr>");
            //Header.Append("</thead>");
            Body.Append(Header);
            #endregion
            var Allprovince = db.tbl_Province.ToList();
            #region Body
            Dictionary<string, string> Reportdata = new Dictionary<string, string>();
            foreach(var item in Allprovince)
            {
                Reportdata.Add(item.ProvinceName, item.Place);
            }
            //Reportdata.Add("Central Administer", "ADC");
            //Reportdata.Add("Brazzaville", "BRA");
            //Reportdata.Add("Canada", "CAN");
            //Reportdata.Add("Spain", "ESP");
            //Reportdata.Add("France", "FRA");
            //Reportdata.Add("Bengaluru", "INB");
            //Reportdata.Add("Delhi", "IND");
            //Reportdata.Add("North East India", "INE");
            //Reportdata.Add("Hyderabad", "INH");
            //Reportdata.Add("Italy", "ITA");
            //Reportdata.Add("Trichy", "INT");
            //Reportdata.Add("Yercaud", "INY");
            //Reportdata.Add("Kinshasa", "KIN");
            //Reportdata.Add("Malaysia-Singapur", "MAL");
            //Reportdata.Add("Province Of East Africa", "PEA");
            //Reportdata.Add("Senegal", "SEN");
            //Reportdata.Add("Thailand", "THA");

            var allTbl_formationsDetails = dbcont.Tbl_formationsDetails.ToList();
            var alltbl_Passed = dbcont.tbl_Passed.ToList();
            var allTbl_Transfer = dbcont.Tbl_Transfer.ToList();
            var allTbl_RenewalVows = dbcont.Tbl_RenewalVows.ToList();
            var alltbl_SeperationFromTheCongregation = dbcont.tbl_SeperationFromTheCongregation.ToList();
            
#pragma warning disable CS0219 // The variable 'totalTotalPro' is assigned but its value is never used
            int totalTotalPro = 0;
#pragma warning restore CS0219 // The variable 'totalTotalPro' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'totalGrandTotalproNov' is assigned but its value is never used
            int totalGrandTotalproNov = 0;
#pragma warning restore CS0219 // The variable 'totalGrandTotalproNov' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'totalTP' is assigned but its value is never used
            int totalTP = 0;
#pragma warning restore CS0219 // The variable 'totalTP' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'totalPP' is assigned but its value is never used
            int totalPP = 0;
#pragma warning restore CS0219 // The variable 'totalPP' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'TotalTotalProfes' is assigned but its value is never used
            int TotalTotalProfes = 0;
#pragma warning restore CS0219 // The variable 'TotalTotalProfes' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'totalNovices1stY' is assigned but its value is never used
            int totalNovices1stY = 0;
#pragma warning restore CS0219 // The variable 'totalNovices1stY' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'totalNovices2stY' is assigned but its value is never used
            int totalNovices2stY = 0;
#pragma warning restore CS0219 // The variable 'totalNovices2stY' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'totalGrandTotalproNov2' is assigned but its value is never used
            int totalGrandTotalproNov2 = 0;
#pragma warning restore CS0219 // The variable 'totalGrandTotalproNov2' is assigned but its value is never used
            int totalDepartNov = 0;
            int totalDepartVT = 0;
            int totalDepartVP = 0;
            int totalDeath = 0;
            int totalTransfersplus = 0;
            int totalTransfersminus = 0;
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "DashboardCount").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();
            //AllMembers
            List<string> VT = new List<string>();
            List<string> NovForId = new List<string>();
            List<string> VP = new List<string>();

            if (configData != null)
            {
                var condiForId = configData.Where(x => x.strConfigKey == "Novitiate").Select(x => x.strConfigValue).ToList();
                if (condiForId != null)
                {
                    string[] tempList = condiForId[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        NovForId.Add(tempList[i]);
                    }
                }
                var VtId = configData.Where(x => x.strConfigKey == "TemporaryVows").Select(x => x.strConfigValue).ToList();
                if (VtId != null)
                {
                    string[] tempList = VtId[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        VT.Add(tempList[i]);
                    }
                }
                var VPId = configData.Where(x => x.strConfigKey == "PerpetualVows").Select(x => x.strConfigValue).ToList();
                if (VPId != null)
                {
                    string[] tempList = VPId[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        VP.Add(tempList[i]);
                    }
                }
            }

            foreach (var item in Reportdata)
            {
                var province = db.tbl_Province.FirstOrDefault(x => x.Place == item.Value);
                //var province = db.tbl_Province.FirstOrDefault();

                Body.Append("<tr>");
                Body.Append("<td>" + item.Key + "</td>");
                Body.Append("<td>" + item.Value + "</td>");

#pragma warning disable CS0219 // The variable 'TotalProt' is assigned but its value is never used
                int TotalProt = 0;
#pragma warning restore CS0219 // The variable 'TotalProt' is assigned but its value is never used
                int cntFormation = 0;
                int cntProfession = 0;
                #region 1 col
                foreach (var item2 in FilterStageOfFormation)
                {
                    
                    {
                        if (string.IsNullOrEmpty(FromDate) && string.IsNullOrEmpty(ToDate))
                        {
                            int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == item2.FormationId) && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && x.Status != "0").Count();
                            Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                            TotalSumFormation[cntFormation] += TotalPro;
                        }
                        else
                        {
                            int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == item2.FormationId) && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay && x.Status != "0").Count();
                            Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                            TotalSumFormation[cntFormation] += TotalPro;
                        }
                        cntFormation++;
                    }
                    
                }
                foreach (var item3 in FilterStageOfVows)
                {
                    if (string.IsNullOrEmpty(FromDate) && string.IsNullOrEmpty(ToDate))
                    {
                        int TotalPro = allTbl_formationsDetails.Where(x =>x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == item3.Id.ToString()) && x.Sapcheck == null && x.Diedcheck == null &&  x.Archivecheck == null && x.Status != "0").Count();
                        //int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == item3.Id.ToString()) && x.Status == "0").Count();
                        Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                        TotalSumProfession[cntProfession] += TotalPro;
                    }
                    else
                    {
                        int TotalPro = allTbl_formationsDetails.Where(x =>x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == item3.Id.ToString()) && x.Sapcheck == null && x.Diedcheck == null  && Convert.ToDateTime(x.VowsDate) >= firstDay && Convert.ToDateTime(x.VowsDate) <= lastDay && x.Status != "0").Count();
                        Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                        TotalSumProfession[cntProfession] += TotalPro;
                    }
                    cntProfession++;
                }
                //int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //totalTotalPro += TotalPro;

                //int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //totalGrandTotalproNov += GrandTotalProNav;

                //var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //.ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //int TallForTP = 0;
                //foreach (var memberid in TotalPro1)
                //{
                //    var check = allTbl_formationsDetails
                //        .Where(x => x.MemberId == memberid.MemberId)
                //        .Where(x => x.StageOfFormation != "14")
                //        .ToList();
                //    if (check.Count() == 0)
                //    {
                //        TallForTP += 1;
                //    }
                //}

                //Body.Append("<td>" + TallForTP + "</td>");
                //totalTP += TallForTP;

                //int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //Body.Append("<td>" + TallForPP + "</td>");
                //totalTP += TallForPP;

                //var totaldata = TallForTP + TallForPP;
                //int totalProfs = TotalProt - totaldata;  //totalProfs
                //Body.Append("<td>" + totalProfs + "</td>");
                //TotalTotalProfes += totalProfs;

                //int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //totalNovices1stY += Novices1stY;

                //int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //totalNovices2stY += Novices2stY;

                //int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //totalGrandTotalproNov2 += GrandTotalProfNov;
                
                if (string.IsNullOrEmpty(FromDate) && string.IsNullOrEmpty(ToDate))
                {
                    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && NovForId.Contains(x.StageOFFormation)).Count();
                    Body.Append("<td>" + allNOV + "</td>");
                    totalDepartNov += allNOV;

                    int allVT = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && VT.Contains(x.StageOFFormation)).Count(); ;
                    Body.Append("<td>" + allVT + "</td>");
                    totalDepartVT += allVT;

                    int allVP = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && VP.Contains(x.StageOFFormation)).Count();
                    Body.Append("<td>" + allVP + "</td>");
                    totalDepartVP += allVP;

                    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString()).Count();
                    Body.Append("<td>" + allDeath + "</td>");
                    totalDeath += allDeath;
                }
                else
                {
                    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && NovForId.Contains(x.StageOFFormation) && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                    Body.Append("<td>" + allNOV + "</td>");
                    totalDepartNov += allNOV;

                    int allVT = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && VT.Contains(x.StageOFFormation) && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                    Body.Append("<td>" + allVT + "</td>");
                    totalDepartVT += allVT;

                    int allVP = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && VP.Contains(x.StageOFFormation) && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                    Body.Append("<td>" + allVP + "</td>");
                    totalDepartVP += allVP;

                    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                    Body.Append("<td>" + allDeath + "</td>");
                    totalDeath += allDeath;
                }
                    

                    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                    Body.Append("<td>" + allminus + "</td>");
                    totalTransfersminus += allminus;

                    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                    Body.Append("<td>" + allPlus + "</td>");
                    totalTransfersplus += allPlus;

                #region

                //if (item.Value == "BRA")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "CAN")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "ESP")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "FRA")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "INB")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "IND")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;

                //}
                //if (item.Value == "INE")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;

                //}
                //if (item.Value == "INH")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "ITA")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;

                //}
                //if (item.Value == "INT")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "INY")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "KIN")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "MAL")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "PEA")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "SEN")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                //if (item.Value == "THA")
                //{
                //    int TotalPro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "17" || x.StageOfFormation == "15") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + TotalPro + "</td>"); // Total Prov
                //    totalTotalPro += TotalPro;

                //    int GrandTotalProNav = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && (x.StageOfFormation == "13" || x.StageOfFormation == "14" || x.StageOfFormation == "15" || x.StageOfFormation == "17") && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + GrandTotalProNav + "</td>"); // Total GrandTotalProNav
                //    totalGrandTotalproNov += GrandTotalProNav;

                //    var TotalPro1 = db.Tbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active")
                //    .ToList().Select(x => new { x.MemberId }).Distinct().ToList();
                //    int TallForTP = 0;
                //    foreach (var memberid in TotalPro1)
                //    {
                //        var check = allTbl_formationsDetails
                //            .Where(x => x.MemberId == memberid.MemberId)
                //            .Where(x => x.StageOfFormation != "14")
                //            .ToList();
                //        if (check.Count() == 0)
                //        {
                //            TallForTP += 1;
                //        }
                //    }

                //    Body.Append("<td>" + TallForTP + "</td>");
                //    totalTP += TallForTP;

                //    int TallForPP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.CurrentStatus == "15" && x.SapCheck == "Active" && x.DeathCheck == null && x.Archivecheck == null && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + TallForPP + "</td>");
                //    totalTP += TallForPP;

                //    var totaldata = TallForTP + TallForPP;
                //    int totalProfs = TotalPro - totaldata;  //totalProfs
                //    Body.Append("<td>" + totalProfs + "</td>");
                //    TotalTotalProfes += totalProfs;

                //    int Novices1stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "13" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices1stY + "</td>"); // Novices1stY
                //    totalNovices1stY += Novices1stY;

                //    int Novices2stY = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOfFormation == "14" && x.Sapcheck == null && x.Diedcheck == null && x.Archivecheck == null && Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay).Count();
                //    Body.Append("<td>" + Novices2stY + "</td>"); // Novices2stY
                //    totalNovices2stY += Novices2stY;

                //    int GrandTotalProfNov = totalProfs + Novices1stY + Novices2stY;
                //    Body.Append("<td>" + GrandTotalProfNov + "</td>");
                //    totalGrandTotalproNov2 += GrandTotalProfNov;

                //    int allNOV = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.StageOFFormation == "14" || x.StageOFFormation == "13" && Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                //    Body.Append("<td>" + allNOV + "</td>");
                //    totalDepartNov += allNOV;

                //    int allVT = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "14" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVT + "</td>");
                //    totalDepartVT += allVT;

                //    int allVP = allTbl_RenewalVows.Where(x => x.ProvinceName == province.Id.ToString() && x.SapCheck == "Active" && x.CurrentStatus == "15" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                //    Body.Append("<td>" + allVP + "</td>");
                //    totalDepartVP += allVP;

                //    int allDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                //    Body.Append("<td>" + allDeath + "</td>");
                //    totalDeath += allDeath;

                //    int allminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allminus + "</td>");
                //    totalTransfersminus += allminus;

                //    int allPlus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId).Count();
                //    Body.Append("<td>" + allPlus + "</td>");
                //    totalTransfersplus += allPlus;
                //}
                #endregion

                #endregion
            }
            Body.Append("<tr>");
            Body.Append("<td><b>Total :</b></td>");
            Body.Append("<td></td>");
            foreach (var item in TotalSumFormation)
            {
                Body.Append("<td><b>" + item.ToString() + "</b></td>");
            }
            foreach (var item in TotalSumProfession)
            {
                Body.Append("<td><b>" + item.ToString() + "</b></td>");
            }
            //Body.Append("<td><b>" + totalTotalPro + "</b></td>");
            //Body.Append("<td><b>" + totalGrandTotalproNov + "</b></td>");
            //Body.Append("<td><b>" + totalTP + "</b></td>");
            //Body.Append("<td><b>" + totalPP + "</b></td>");
            //Body.Append("<td><b>" + TotalTotalProfes + "</b></td>");
            //Body.Append("<td><b>" + totalNovices1stY + "</b></td>");
            //Body.Append("<td><b>" + totalNovices2stY + "</b></td>");
            //Body.Append("<td><b>" + totalGrandTotalproNov2 + "</b></td>");
            Body.Append("<td><b>" + totalDepartNov + "</b></td>");
            Body.Append("<td><b>" + totalDepartVT + "</b></td>");
            Body.Append("<td><b>" + totalDepartVP + "</b></td>");
            Body.Append("<td><b>" + totalDeath + "</b></td>");
            Body.Append("<td><b>" + totalTransfersminus + "</b></td>");
            Body.Append("<td><b>" + totalTransfersplus + "</b></td>");
            Body.Append("<tr>");
            #endregion
            return Json(Body.ToString(), JsonRequestBehavior.AllowGet);
        }

    }
}