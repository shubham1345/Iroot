using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class SaprateProDataController : Controller
    {
        private GeneralDBContext db = new GeneralDBContext();
        private GeneralDBContext dbcont = new GeneralDBContext();
        // GET: SaprateProData
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaprateProData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            // string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var AllReneData = dbcont.tbl_PersonalDetails.Where(x => x.Vowscheck == "yes" && x.IsTransfer != "yes" && x.VowsStatus == "15").ToList();
                ViewBag.AllReneData = AllReneData;
            }
            else
            {
                var AllReneData = dbcont.tbl_PersonalDetails
                .Where(x => x.Vowscheck == "yes" && x.IsTransfer != "yes" && x.VowsStatus == "15" && x.CreatedBy == currentUser).ToList();
                ViewBag.AllReneData = AllReneData;
            }

            if (Session["username"].ToString() == "admin")
            {
                var AllReneData1 = dbcont.tbl_PersonalDetails.Where(x => x.Vowscheck == "yes" && x.IsTransfer != "yes" && x.VowsStatus == "14").ToList();
                ViewBag.AllReneData1 = AllReneData1;
            }
            else
            {
                var AllReneData1 = dbcont.tbl_PersonalDetails
                .Where(x => x.Vowscheck == "yes" && x.IsTransfer != "yes" && x.VowsStatus == "14" && x.CreatedBy == currentUser).ToList();
                ViewBag.AllReneData1 = AllReneData1;
            }

            if (Session["username"].ToString() == "admin")
            {
                var AllData = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer != "yes").ToList();
                ViewBag.AllData = AllData;
            }
            else
            {
                var AllData = dbcont.tbl_PersonalDetails
                .Where(x => x.IsTransfer != "yes" && x.CreatedBy == currentUser).ToList();
                ViewBag.AllData = AllData;
            }
            return View();
        }
        public ActionResult SaprateProstaticData(string FromDate, string ToDate, string Province)
        {
            var objStatusYear13 = dbcont.Tbl_formationsStatusYear.Where(x => x.Id == 8).ToList();

            StringBuilder Header = new StringBuilder();
            StringBuilder Body = new StringBuilder();
            DateTime firstDay = new DateTime();
            //DateTime firstday1 = new DateTime();
            //string[] firstDay1 = null;
            //string[] lastday1 = null;
            DateTime lastDay = new DateTime();
            DateTime lastDay1 = new DateTime();
            DateTime firstDay1 = new DateTime();

            if (string.IsNullOrEmpty(FromDate) && string.IsNullOrEmpty(ToDate))
            {
                int year = DateTime.Now.Year;
                //firstDay1 = ("01/01/" + year);
                firstDay = Convert.ToDateTime("01/01/" + year);
                //firstDay1 = firstDay.ToString().Split('/');
                //firstDay1 = (firstDay).ToShortDateString();
                //lastday1 = ("31/12/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
                //lastday1 = lastDay.ToString().Split('/');

            }
            else
            {
                firstDay = Convert.ToDateTime(FromDate);

                lastDay = Convert.ToDateTime(ToDate);
                lastDay1 = Convert.ToDateTime(ToDate);
                firstDay1 = firstDay;

            }
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic2").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();
            List<string> DyKey1 = new List<string>();
            List<string> DyKey2 = new List<string>();
            List<string> DyKey3 = new List<string>();
            List<string> DyKey4 = new List<string>();
            List<string> DyKey5 = new List<string>();
            List<string> DyKey6 = new List<string>();
            if (configData != null)
            {
                var data1 = configData.Where(x => x.strConfigKey == "DyKey1").Select(x => x.strConfigValue).ToList();
                if (data1 != null)
                {
                    string[] tempList = data1[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey1.Add(tempList[i]);
                    }
                }
                var data2 = configData.Where(x => x.strConfigKey == "DyKey2").Select(x => x.strConfigValue).ToList();
                if (data2 != null)
                {
                    string[] tempList = data2[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey2.Add(tempList[i]);
                    }
                }
                var data3 = configData.Where(x => x.strConfigKey == "DyKey3").Select(x => x.strConfigValue).ToList();
                if (data3 != null)
                {
                    string[] tempList = data3[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey3.Add(tempList[i]);
                    }
                }
                var data4 = configData.Where(x => x.strConfigKey == "DyKey4").Select(x => x.strConfigValue).ToList();
                if (data4 != null)
                {
                    string[] tempList = data4[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey4.Add(tempList[i]);
                    }
                }
                var data5 = configData.Where(x => x.strConfigKey == "DyKey5").Select(x => x.strConfigValue).ToList();
                if (data5 != null)
                {
                    string[] tempList = data5[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey5.Add(tempList[i]);
                    }
                }
                var data6 = configData.Where(x => x.strConfigKey == "DyKey6").Select(x => x.strConfigValue).ToList();
                if (data6 != null)
                {
                    string[] tempList = data6[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey6.Add(tempList[i]);
                    }
                }
            }
            #region Generate Header
            Header.Append("<thead>");
            Header.Append("<tr>");
            Header.Append("<th></th>");
            Header.Append("<th colspan='6' scope='colgroup'>" + HomeController.GetControlTextByControlId("Brothers") + "</th>");
            Header.Append("<th colspan='3' scope='colgroup'>" + HomeController.GetControlTextByControlId("Novices") + "</th>");
            Header.Append("<th></th>");
            Header.Append("<th colspan='3' scope='colgroup'>" + HomeController.GetControlTextByControlId("Candidates") + "</th>");
            Header.Append("</tr>");
            Header.Append("<tr>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Year") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("TV") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("TV") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Total") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Died") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Left") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Grand Total") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("1st Year Novices") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("2nd Year Novices") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Total Novices") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Total Brothers + Novices") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Pre-Novitiate") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Candidates") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Total Candidates") + "</th>");
            Header.Append("</tr>");
            Header.Append("</thead>");
            Body.Append(Header);
            #endregion

            #region Body
            Dictionary<string, string> Reportdata = new Dictionary<string, string>();
            int yearsDiff = lastDay.Year - firstDay.Year;
            Reportdata.Add(Convert.ToString(firstDay.Year), "");
            for (int i = 1; i <= yearsDiff; i++)
            {
                Reportdata.Add(Convert.ToString(firstDay.Year + i), "");
            }

            var allTbl_formationsDetails = dbcont.Tbl_formationsDetails.ToList();

            var alltbl_Passed = dbcont.tbl_Passed.ToList();
            var allTbl_Transfer = dbcont.Tbl_Transfer.ToList();
            var allTbl_RenewalVows = dbcont.Tbl_RenewalVows.ToList();
            var alltbl_SeperationFromTheCongregation = dbcont.tbl_SeperationFromTheCongregation.ToList();
            int GrandTotal1 = 0;
            int GrandTotal2 = 0;
            int GrandTotal4 = 0;
            int GrandTotal5 = 0;
            List<Tbl_formationsDetails> TotalTempRene = new List<Tbl_formationsDetails>();
            List<Tbl_formationsDetails> TotalFinalRene = new List<Tbl_formationsDetails>();
            List<Tbl_formationsDetails> Total1stNov = new List<Tbl_formationsDetails>();
            List<Tbl_formationsDetails> Total2ndNov = new List<Tbl_formationsDetails>();
            List<Tbl_formationsDetails> TotalPreNov = new List<Tbl_formationsDetails>();
            List<Tbl_formationsDetails> TotalCandidates = new List<Tbl_formationsDetails>();
            int TotalTempRene1 = 0;
            int TotalTempRene11 = 0;
            int TotalFinalRene1 = 0;
            int TotalFinalRene11 = 0;
            int TotalDeath = 0;
            int TotalSepration = 0;
            int Total1stNov1 = 0;
            int Total1stNov11 = 0;
            int Total2ndNov1 = 0;
            int Total2ndNov11 = 0;
            int TotalPreNov1 = 0;
            int TotalPreNov11 = 0;
            int TotalCandidates1 = 0;
            int TotalCandidates11 = 0;
            int yearcnt = 0;

            var objStatusYear = dbcont.Tbl_formationsStatusYear.ToList();
            List<Tbl_formationsStatusYear> objStatusYear1 = new List<Tbl_formationsStatusYear>();

            bool isCurrentYear = true;
            foreach (var item in Reportdata)
            {
                yearcnt++;

                if (Reportdata.Count == yearcnt)
                {
                    isCurrentYear = true;
                    //firstDay = new DateTime(Convert.ToInt32(item.Key), 1, 1);
                    firstDay1 = new DateTime(Convert.ToInt32(item.Key), 1, 1);
                    //lastDay = lastDay1;
                }
                else if (yearcnt == 1)
                {
                    isCurrentYear = false;
                    //lastDay = firstDay.AddMonths(12 - firstDay.Month).AddDays(31 - firstDay.Day);
                    lastDay1 = firstDay1.AddMonths(12 - firstDay1.Month).AddDays(31 - firstDay1.Day);

                    DateTime dateTime;
                    //objStatusYear1 = objStatusYear.Where(x => DateTime.TryParse(x.StatusYear, out dateTime) && dateTime >= (firstDay1) && dateTime <= lastDay1 && x.Status == "Active").ToList();

                    objStatusYear1 = objStatusYear.Where(x => Convert.ToDateTime(x.StatusYear) >= firstDay1 && Convert.ToDateTime(x.StatusYear) <= lastDay1 && x.Status.ToLower().ToString().Trim() == "active").ToList();


                }
                else
                {
                    isCurrentYear = false;
                    //firstDay = new DateTime(Convert.ToInt32(item.Key), 1, 1);
                    firstDay1 = new DateTime(Convert.ToInt32(item.Key), 1, 1);
                    var endMonthtDate = new DateTime(Convert.ToInt32(item.Key), 12, 1);
                    lastDay1 = endMonthtDate.AddMonths(1).AddDays(-1);

                    DateTime dateTime;
                    //objStatusYear1 = objStatusYear.Where(x => DateTime.TryParse(x.StatusYear, out dateTime) && dateTime >= (firstDay1) && dateTime <= lastDay1 && x.Status == "Active").ToList();

                    objStatusYear1 = objStatusYear.Where(x => Convert.ToDateTime(x.StatusYear) >= firstDay1 && Convert.ToDateTime(x.StatusYear) <= lastDay1 && x.Status.ToLower().ToString().Trim() == "active").ToList();
                }


                Body.Append("<tr>");
                Body.Append("<td>" + item.Key + "</td>");

                #region 1 col
                string currentUser = Convert.ToString(Session["username"]);
                //TV
                //var TotalTempRene = allTbl_RenewalVows.Where(x => Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay && (x.DeathCheck != "Active" || x.SapCheck != "Active")).ToList();
                //var Total2ndNov = allTbl_formationsDetails.Where(x => Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay && (x.Diedcheck != "Active" || x.Sapcheck != "Active") && x.Status != "0").ToList();
                if (string.IsNullOrEmpty(Province))
                {
                    //var from_date = FromDate.Split('/');
                    //foreach(var items in allTbl_formationsDetails)
                    //{
                    //    if(items.VowsDate != null || items.VowsDate != "")
                    //    {
                    //        var date = items.VowsDate.Split('/');
                    //        if(Convert.ToDateTime(date[2].TrimStart('0')) >= Convert.ToDateTime(firstDay1[2].TrimStart('0')) && Convert.ToDateTime())
                    //    }
                    //}

                    DateTime dateTime;
                    if (isCurrentYear)
                    {
                        TotalTempRene = allTbl_formationsDetails.Where(x => DateTime.TryParse(x.VowsDate, out dateTime) && dateTime >= (firstDay) && dateTime <= lastDay && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.Status != "0").ToList();
                        TotalTempRene1 = TotalTempRene.Where(x => DyKey1.Contains(x.StageOfFormation)).Count();
                        TotalTempRene11 = TotalTempRene.Where(x => x.ProvinceName == Province && DyKey1.Contains(x.StageOfFormation)).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        TotalTempRene = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id)).ToList();
                        TotalTempRene1 = TotalTempRene.Where(x => DyKey1.Contains(x.StageOfFormation)).Count();
                        TotalTempRene11 = TotalTempRene.Where(x => x.ProvinceName == Province && DyKey1.Contains(x.StageOfFormation)).Count();
                    }
                }
                else
                {
                    DateTime date1;
                    if (isCurrentYear)
                    {
                        TotalTempRene = allTbl_formationsDetails.Where(x => DateTime.TryParse(x.VowsDate, out date1) && date1 >= firstDay && date1 <= lastDay && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.Status != "0" && x.ProvinceName == Province).ToList();
                        TotalTempRene1 = TotalTempRene.Where(x => DyKey1.Contains(x.StageOfFormation)).Count();
                        TotalTempRene11 = TotalTempRene.Where(x => x.ProvinceName == Province && DyKey1.Contains(x.StageOfFormation)).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        TotalTempRene = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id) && x.ProvinceName == Province).ToList();
                        TotalTempRene1 = TotalTempRene.Where(x => DyKey1.Contains(x.StageOfFormation)).Count();
                        TotalTempRene11 = TotalTempRene.Where(x => x.ProvinceName == Province && DyKey1.Contains(x.StageOfFormation)).Count();

                    }
                }


                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalTempRene1 + "</td>");
                    GrandTotal1 += TotalTempRene1;
                }
                else
                {
                    Body.Append("<td>" + TotalTempRene11 + "</td>");
                    GrandTotal1 += TotalTempRene11;
                }

                // FV
                //var TotalFinalRene = allTbl_RenewalVows.Where(x => Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay && (x.DeathCheck != "Active" || x.SapCheck != "Active")).ToList();
                if (string.IsNullOrEmpty(Province))
                {
                    DateTime date2;
                    if (isCurrentYear)
                    {
                        TotalFinalRene = allTbl_formationsDetails.Where(x => DateTime.TryParse(x.VowsDate, out date2) && date2 >= firstDay && date2 <= lastDay && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.Sapcheck == null && x.Status != "0").ToList();
                        TotalFinalRene1 = TotalFinalRene.Where(x => DyKey2.Contains(x.StageOfFormation)).Count();
                        TotalFinalRene11 = TotalFinalRene.Where(x => x.ProvinceName == Province && DyKey2.Contains(x.StageOfFormation)).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        TotalFinalRene = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id)).ToList();
                        TotalFinalRene1 = TotalFinalRene.Where(x => DyKey2.Contains(x.StageOfFormation)).Count();
                        TotalFinalRene11 = TotalFinalRene.Where(x => x.ProvinceName == Province && DyKey2.Contains(x.StageOfFormation)).Count();

                    }
                }
                else
                {
                    DateTime date5;
                    if (isCurrentYear)
                    {
                        TotalFinalRene = allTbl_formationsDetails.Where(x => DateTime.TryParse(x.VowsDate, out date5) && date5 >= firstDay && date5 <= lastDay && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.Sapcheck == null && x.Status != "0" && x.ProvinceName == Province).ToList();
                        TotalFinalRene1 = TotalFinalRene.Where(x => DyKey2.Contains(x.StageOfFormation)).Count();
                        TotalFinalRene11 = TotalFinalRene.Where(x => x.ProvinceName == Province && DyKey2.Contains(x.StageOfFormation)).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        TotalFinalRene = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id) && x.ProvinceName == Province).ToList();
                        TotalFinalRene1 = TotalFinalRene.Where(x => DyKey2.Contains(x.StageOfFormation)).Count();
                        TotalFinalRene11 = TotalFinalRene.Where(x => x.ProvinceName == Province && DyKey2.Contains(x.StageOfFormation)).Count();

                    }
                }

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalFinalRene1 + "</td>");
                    GrandTotal2 += TotalFinalRene1;
                }
                else
                {
                    Body.Append("<td>" + TotalFinalRene11 + "</td>");
                    GrandTotal2 += TotalFinalRene11;
                }

                //Total
                var Totalcalculate = TotalTempRene1 + TotalFinalRene1;
                var TotalcalculateCU = TotalTempRene11 + TotalFinalRene11;
                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Totalcalculate + "</td>");
                    // GrandTotal3 += Totalcalculate;
                }
                else
                {
                    Body.Append("<td>" + TotalcalculateCU + "</td>");
                    // GrandTotal3 += Totalcalculate;
                }

                ////Death
                //var Total1stNov = allTbl_formationsDetails.Where(x => Convert.ToDateTime(x.FromDate) >= firstDay && Convert.ToDateTime(x.FromDate) <= lastDay && (x.Diedcheck != "Active" || x.Sapcheck != "Active") && x.Status != "0").ToList();

                //int TotalDeath = alltbl_Passed.Where(x => Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                var year = "";
                if (FromDate == "")
                {
                    year = DateTime.Now.Year.ToString();
                }
                else
                {
                    DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                    year = item.Key;// date.Year.ToString();
                }
                //DateTime dt = Convert.ToDateTime(FromDate);
                //year = dt.Year.ToString();
                if (string.IsNullOrEmpty(Province))
                {

                    TotalDeath = alltbl_Passed.Where(x => x.Added_Year == year).Count();
                }
                else
                {
                    TotalDeath = alltbl_Passed.Where(x => x.Added_Year == year && x.ProvinceName == Province).Count();
                }
                if (Session["username"].ToString() == "admin")
                {

                    //TotalDeath = alltbl_Passed.Count();
                    Body.Append("<td>" + TotalDeath + "</td>");
                    GrandTotal4 += TotalDeath;
                }
                else
                {
                    TotalDeath = alltbl_Passed.Where(x => x.ProvinceName == currentUser).Count();
                    Body.Append("<td>" + TotalDeath + "</td>");
                    GrandTotal4 += TotalDeath;
                }

                ////Left
                //int TotalSepration = alltbl_SeperationFromTheCongregation.Where(x => Convert.ToDateTime(x.SeperationDate) >= firstDay && Convert.ToDateTime(x.SeperationDate) <= lastDay).Count();
                if (string.IsNullOrEmpty(Province))
                {

                    TotalSepration = alltbl_SeperationFromTheCongregation.Where(x => x.Added_Year == year).Count();
                }
                else
                {
                    TotalSepration = alltbl_SeperationFromTheCongregation.Where(x => x.Added_Year == year && x.ProvinceName == Province).Count();

                }
                if (Session["username"].ToString() == "admin")
                {

                    //TotalSepration = alltbl_SeperationFromTheCongregation.Count();
                    Body.Append("<td>" + TotalSepration + "</td>");
                    GrandTotal5 += TotalSepration;
                }
                else
                {
                    TotalSepration = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == currentUser).Count();
                    Body.Append("<td>" + TotalSepration + "</td>");
                    GrandTotal5 += TotalSepration;
                }

                ////GrandTotal
                int Totalcalculate2 = TotalSepration + TotalDeath;
                int TotalGrand = Totalcalculate2 + Totalcalculate;
                int TotalGrandCU = Totalcalculate2 + TotalcalculateCU;
                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalGrand + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalGrandCU + "</td>");
                }
                //Clear
                //1stNov

                if (string.IsNullOrEmpty(Province))
                {
                    DateTime date4;
                    if (isCurrentYear)
                    {
                        Total1stNov = allTbl_formationsDetails.Where(x => DateTime.TryParse(x.FromDate, out date4) && date4 >= firstDay && date4 <= lastDay && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.Status != "0").ToList();
                        Total1stNov1 = Total1stNov.Where(x => DyKey3.Contains(x.StageOfFormation)).Count();
                        Total1stNov11 = Total1stNov.Where(x => DyKey3.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        Total1stNov = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id)).ToList();
                        Total1stNov1 = Total1stNov.Where(x => DyKey3.Contains(x.StageOfFormation)).Count();
                        Total1stNov11 = Total1stNov.Where(x => DyKey3.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                }
                else
                {
                    DateTime date6;
                    if (isCurrentYear)
                    {
                        Total1stNov = allTbl_formationsDetails.Where(x => DateTime.TryParse(x.FromDate, out date6) && date6 >= firstDay && date6 <= lastDay && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.Status != "0" && x.ProvinceName == Province).ToList();
                        Total1stNov1 = Total1stNov.Where(x => DyKey3.Contains(x.StageOfFormation)).Count();
                        Total1stNov11 = Total1stNov.Where(x => DyKey3.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        Total1stNov = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id) && x.ProvinceName == Province).ToList();
                        Total1stNov1 = Total1stNov.Where(x => DyKey3.Contains(x.StageOfFormation)).Count();
                        Total1stNov11 = Total1stNov.Where(x => DyKey3.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                }

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Total1stNov1 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Total1stNov11 + "</td>");
                }

                ////2ndNov

                if (string.IsNullOrEmpty(Province))
                {
                    DateTime date7;
                    if (isCurrentYear)
                    {
                        Total2ndNov = allTbl_formationsDetails.Where(x => DateTime.TryParse(x.FromDate, out date7) && date7 >= firstDay && date7 <= lastDay && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.Status != "0").ToList();
                        Total2ndNov1 = Total2ndNov.Where(x => DyKey4.Contains(x.StageOfFormation)).Count();
                        Total2ndNov11 = Total2ndNov.Where(x => DyKey4.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        Total2ndNov = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id)).ToList();
                        Total2ndNov1 = Total2ndNov.Where(x => DyKey4.Contains(x.StageOfFormation)).Count();
                        Total2ndNov11 = Total2ndNov.Where(x => DyKey4.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                }

                else
                {
                    DateTime date8;
                    if (isCurrentYear)
                    {
                        Total2ndNov = allTbl_formationsDetails.Where(x => DateTime.TryParse(x.FromDate, out date8) && date8 >= firstDay && date8 <= lastDay && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.Status != "0" && x.ProvinceName == Province).ToList();
                        Total2ndNov1 = Total2ndNov.Where(x => DyKey4.Contains(x.StageOfFormation)).Count();
                        Total2ndNov11 = Total2ndNov.Where(x => DyKey4.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        Total2ndNov = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id) && x.ProvinceName == Province).ToList();
                        Total2ndNov1 = Total2ndNov.Where(x => DyKey4.Contains(x.StageOfFormation)).Count();
                        Total2ndNov11 = Total2ndNov.Where(x => DyKey4.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                }

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Total2ndNov1 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Total2ndNov11 + "</td>");
                }

                //TotalNov
                int Totalcalculate3 = Total1stNov1 + Total2ndNov1;
                int Totalcalculate3CU = Total1stNov11 + Total2ndNov11;

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Totalcalculate3 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Totalcalculate3CU + "</td>");
                }

                //TotalBrothers&Nov
                int Totalcalculate4 = TotalGrand + Totalcalculate3;
                int Totalcalculate4CU = TotalGrandCU + Totalcalculate3CU;
                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Totalcalculate4 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Totalcalculate4CU + "</td>");
                }

                ////PreNov

                if (string.IsNullOrEmpty(Province))
                {
                    DateTime date9;
                    if (isCurrentYear)
                    {
                        TotalPreNov = allTbl_formationsDetails.Where(x => x.Diedcheck != "Active" && x.Sapcheck != "Active" && DateTime.TryParse(x.FromDate, out date9) && date9 >= firstDay && date9 <= lastDay && x.Status != "0").ToList();
                        TotalPreNov1 = TotalPreNov.Where(x => DyKey5.Contains(x.StageOfFormation)).Count();
                        TotalPreNov11 = TotalPreNov.Where(x => DyKey5.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        TotalPreNov = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id)).ToList();
                        TotalPreNov1 = TotalPreNov.Where(x => DyKey5.Contains(x.StageOfFormation)).Count();
                        TotalPreNov11 = TotalPreNov.Where(x => DyKey5.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                }
                else
                {
                    DateTime date10;
                    if (isCurrentYear)
                    {
                        TotalPreNov = allTbl_formationsDetails.Where(x => x.Diedcheck != "Active" && x.Sapcheck != "Active" && DateTime.TryParse(x.FromDate, out date10) && date10 >= firstDay && date10 <= lastDay && x.Status != "0" && x.ProvinceName == Province).ToList();
                        TotalPreNov1 = TotalPreNov.Where(x => DyKey5.Contains(x.StageOfFormation)).Count();
                        TotalPreNov11 = TotalPreNov.Where(x => DyKey5.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        TotalPreNov = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id) && x.ProvinceName == Province).ToList();
                        TotalPreNov1 = TotalPreNov.Where(x => DyKey5.Contains(x.StageOfFormation)).Count();
                        TotalPreNov11 = TotalPreNov.Where(x => DyKey5.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                }


                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalPreNov1 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalPreNov11 + "</td>");
                }

                ////Candidates

                if (string.IsNullOrEmpty(Province))
                {
                    DateTime date11;
                    if (isCurrentYear)
                    {
                        TotalCandidates = allTbl_formationsDetails.Where(x => x.Diedcheck != "Active" && x.Sapcheck != "Active" && DateTime.TryParse(x.FromDate, out date11) && date11 >= firstDay && date11 <= lastDay && x.Status != "0").ToList();
                        TotalCandidates1 = TotalCandidates.Where(x => DyKey6.Contains(x.StageOfFormation)).Count();
                        TotalCandidates11 = TotalCandidates.Where(x => DyKey6.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        TotalCandidates = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id)).ToList();
                        TotalCandidates1 = TotalCandidates.Where(x => DyKey6.Contains(x.StageOfFormation)).Count();
                        TotalCandidates11 = TotalCandidates.Where(x => DyKey6.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();

                    }
                }
                else
                {
                    DateTime date12;
                    if (isCurrentYear)
                    {
                        TotalCandidates = allTbl_formationsDetails.Where(x => x.Diedcheck != "Active" && x.Sapcheck != "Active" && DateTime.TryParse(x.FromDate, out date12) && date12 >= firstDay && date12 <= lastDay && x.Status != "0" && x.ProvinceName == Province).ToList();
                        TotalCandidates1 = TotalCandidates.Where(x => DyKey6.Contains(x.StageOfFormation)).Count();
                        TotalCandidates11 = TotalCandidates.Where(x => DyKey6.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }
                    else
                    {
                        var formationsDetailsIds = objStatusYear1.Select(x => x.formationsDetailsId);
                        TotalCandidates = allTbl_formationsDetails.Where(x => formationsDetailsIds.Contains(x.Id) && x.ProvinceName == Province).ToList();
                        TotalCandidates1 = TotalCandidates.Where(x => DyKey6.Contains(x.StageOfFormation)).Count();
                        TotalCandidates11 = TotalCandidates.Where(x => DyKey6.Contains(x.StageOfFormation) && x.ProvinceName == currentUser).Count();
                    }

                }

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalCandidates1 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalCandidates11 + "</td>");
                }

                ////TotalCandidates
                var Totalcalculate5 = TotalPreNov1 + TotalCandidates1;
                var Totalcalculate5CU = TotalPreNov11 + TotalCandidates11;
                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Totalcalculate5 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Totalcalculate5CU + "</td>");
                }

                #endregion
            }
            #endregion
            return Json(Body.ToString(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult SaprateProstaticData1(string province)
        {
            StringBuilder Header = new StringBuilder();
            StringBuilder Body = new StringBuilder();
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic2").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();
            List<string> DyKey1 = new List<string>();
            List<string> DyKey2 = new List<string>();
            List<string> DyKey3 = new List<string>();
            List<string> DyKey4 = new List<string>();
            List<string> DyKey5 = new List<string>();
            List<string> DyKey6 = new List<string>();
            if (configData != null)
            {
                var data1 = configData.Where(x => x.strConfigKey == "DyKey1").Select(x => x.strConfigValue).ToList();
                if (data1 != null)
                {
                    string[] tempList = data1[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey1.Add(tempList[i]);
                    }
                }
                var data2 = configData.Where(x => x.strConfigKey == "DyKey2").Select(x => x.strConfigValue).ToList();
                if (data2 != null)
                {
                    string[] tempList = data2[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey2.Add(tempList[i]);
                    }
                }
                var data3 = configData.Where(x => x.strConfigKey == "DyKey3").Select(x => x.strConfigValue).ToList();
                if (data3 != null)
                {
                    string[] tempList = data3[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey3.Add(tempList[i]);
                    }
                }
                var data4 = configData.Where(x => x.strConfigKey == "DyKey4").Select(x => x.strConfigValue).ToList();
                if (data4 != null)
                {
                    string[] tempList = data4[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey4.Add(tempList[i]);
                    }
                }
                var data5 = configData.Where(x => x.strConfigKey == "DyKey5").Select(x => x.strConfigValue).ToList();
                if (data5 != null)
                {
                    string[] tempList = data5[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey5.Add(tempList[i]);
                    }
                }
                var data6 = configData.Where(x => x.strConfigKey == "DyKey6").Select(x => x.strConfigValue).ToList();
                if (data6 != null)
                {
                    string[] tempList = data6[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey6.Add(tempList[i]);
                    }
                }
            }
            #region Generate Header
            Header.Append("<thead>");
            Header.Append("<tr>");
            Header.Append("<th></th>");
            Header.Append("<th colspan='6' scope='colgroup'>Brothers</th>");
            Header.Append("<th colspan='3' scope='colgroup'>Novices</th>");
            Header.Append("<th></th>");
            Header.Append("<th colspan='3' scope='colgroup'>Candidates</th>");
            Header.Append("</tr>");
            Header.Append("<tr>");
            Header.Append("<th scope='col'>Year</th>");
            Header.Append("<th scope='col'>TV</th>");
            Header.Append("<th scope='col'>FT</th>");
            Header.Append("<th scope='col'>Total</th>");
            Header.Append("<th scope='col'>Died</th>");
            Header.Append("<th scope='col'>Left</th>");
            Header.Append("<th scope='col'>Grand Total</th>");
            Header.Append("<th scope='col'>1st Year Novices</th>");
            Header.Append("<th scope='col'>2nd Year Novices</th>");
            Header.Append("<th scope='col'>Total Novices</th>");
            Header.Append("<th scope='col'>Total Brothers + Novices</th>");
            Header.Append("<th scope='col'>Pre-Novitiate</th>");
            Header.Append("<th scope='col'>Candidates</th>");
            Header.Append("<th scope='col'>Total Candidates</th>");
            Header.Append("</tr>");
            Header.Append("</thead>");
            Body.Append(Header);
            #endregion

            #region Body
            Dictionary<string, string> Reportdata = new Dictionary<string, string>();
            Reportdata.Add(DateTime.Now.Year.ToString(), "");

            var allTbl_formationsDetails = dbcont.Tbl_formationsDetails.ToList();
            var alltbl_Passed = dbcont.tbl_Passed.ToList();
            var allTbl_Transfer = dbcont.Tbl_Transfer.ToList();
            var allTbl_RenewalVows = dbcont.Tbl_RenewalVows.ToList();
            var alltbl_SeperationFromTheCongregation = dbcont.tbl_SeperationFromTheCongregation.ToList();

            foreach (var item in Reportdata)
            {
                Body.Append("<tr>");
                Body.Append("<td>" + item.Key + "</td>");

                #region 1 col
                string currentUser = Convert.ToString(Session["username"]);
                //TV
                //var TotalTempRene = allTbl_RenewalVows.Where(x => x.CurrentStatus == "14" && x.DeathCheck != "Active" && x.SapCheck != "Active" && x.ProvinceName == province).Count();
                //var TotalTempRene1 = allTbl_RenewalVows.Where(x => x.ProvinceName == currentUser && x.CurrentStatus == "14" && x.DeathCheck != "Active" && x.SapCheck != "Active").Count();
                var TotalTempRene = allTbl_formationsDetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == province && x.Status != "0").Count();

                var TotalTempRene1 = allTbl_formationsDetails.Where(x => x.ProvinceName == currentUser && x.Diedcheck != "Active" && x.Sapcheck != "Active").Count();

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalTempRene + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalTempRene1 + "</td>");
                }

                //FV
                //var TotalFinalRene = allTbl_RenewalVows.Where(x => x.CurrentStatus == "15" && x.DeathCheck != "Active" && x.SapCheck != "Active" && x.ProvinceName == province).Count();
                //var TotalFinalRene1 = allTbl_RenewalVows.Where(x => x.ProvinceName == currentUser && x.CurrentStatus == "15").Count();

                var TotalFinalRene = allTbl_formationsDetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.Diedcheck != "Active" && x.Diedcheck != "Active" && x.ProvinceName == province && x.Sapcheck == null && x.Status != "0").Count();
                var TotalFinalRene1 = allTbl_formationsDetails.Where(x => x.ProvinceName == currentUser).Count();
                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalFinalRene + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalFinalRene1 + "</td>");
                }

                //Total
                var Totalcalculate = TotalTempRene + TotalFinalRene;
                var Totalcalculate1 = TotalTempRene1 + TotalFinalRene1;

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Totalcalculate + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Totalcalculate1 + "</td>");
                }

                //Death
                int TotalDeath = alltbl_Passed.Where(x => x.ProvinceName == province).Count();
                var TotalDeath1 = alltbl_Passed.Where(x => x.ProvinceName == currentUser).Count();

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalDeath + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalDeath1 + "</td>");
                }


                //Left
                var TotalSepration = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province).Count();
                var TotalSepration1 = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == currentUser).Count();

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalSepration + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalSepration1 + "</td>");
                }

                //GrandTotal
                var Totalcalculate2 = TotalDeath + TotalSepration;
                var TotalGrand = Totalcalculate + Totalcalculate2;

                var Totalcalculate22 = TotalDeath1 + TotalSepration1;
                var TotalGrand2 = Totalcalculate1 + Totalcalculate22;

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalGrand + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalGrand2 + "</td>");
                }

                //1stNov
                //var Total1stNov = allTbl_formationsDetails.Where(x => x.CurrentStatus == "13" && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == province && x.Status != "0").Count();
                //var Total1stNov1 = allTbl_formationsDetails.Where(x => x.CurrentStatus == "13" && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == currentUser && x.Status != "0").Count();

                var Total1stNov = allTbl_formationsDetails.Where(x => DyKey3.Contains(x.StageOfFormation) && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == province && x.Status != "0").Count();
                var Total1stNov1 = allTbl_formationsDetails.Where(x => x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == currentUser && x.Status != "0").Count();

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Total1stNov + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Total1stNov1 + "</td>");
                }

                //2ndNov
                //var Total2ndNov = allTbl_formationsDetails.Where(x => x.CurrentStatus == "14" && x.Diedcheck != "Active" && x.Sapcheck != "Active"  && x.ProvinceName == province && x.Status != "0").Count();
                //var Total2ndNov2 = allTbl_formationsDetails.Where(x => x.CurrentStatus == "14" && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == currentUser && x.Status != "0").Count();

                var Total2ndNov = allTbl_formationsDetails.Where(x => DyKey4.Contains(x.StageOfFormation) && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == province && x.Status != "0").Count();
                var Total2ndNov2 = allTbl_formationsDetails.Where(x => x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == currentUser && x.Status != "0").Count();

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Total2ndNov + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Total2ndNov2 + "</td>");
                }

                //TotalNov
                var Totalcalculate3 = Total1stNov + Total2ndNov;
                var Totalcalculate33 = Total1stNov1 + Total2ndNov2;

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Totalcalculate3 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Totalcalculate33 + "</td>");
                }

                //TotalBrothers&Nov
                var Totalcalculate4 = TotalGrand + Totalcalculate3;
                var Totalcalculate44 = TotalGrand2 + Totalcalculate33;

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Totalcalculate4 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Totalcalculate44 + "</td>");
                }

                //PreNov
                //var TotalPreNov = allTbl_formationsDetails.Where(x => x.CurrentStatus == "12" && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == province && x.Status != "0").Count();
                //var TotalPreNov1 = allTbl_formationsDetails.Where(x => x.CurrentStatus == "12" && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == currentUser && x.Status != "0").Count();

                var TotalPreNov = allTbl_formationsDetails.Where(x => DyKey5.Contains(x.StageOfFormation) && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == province && x.Status != "0").Count();
                var TotalPreNov1 = allTbl_formationsDetails.Where(x => x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == currentUser && x.Status != "0").Count();
                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalPreNov + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalPreNov1 + "</td>");
                }

                //Candidates
                //var TotalCandidates = allTbl_formationsDetails.Where(x => x.CurrentStatus == "11" && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == province && x.Status != "0").Count();
                //var TotalCandidates1 = allTbl_formationsDetails.Where(x => x.CurrentStatus == "11" && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == currentUser && x.Status != "0").Count();

                var TotalCandidates = allTbl_formationsDetails.Where(x => DyKey6.Contains(x.StageOfFormation) && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == province && x.Status != "0").Count();
                var TotalCandidates1 = allTbl_formationsDetails.Where(x => x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == currentUser && x.Status != "0").Count();

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + TotalCandidates + "</td>");
                }
                else
                {
                    Body.Append("<td>" + TotalCandidates1 + "</td>");
                }

                //TotalCandidates
                var Totalcalculate5 = TotalPreNov + TotalCandidates;
                var Totalcalculate55 = TotalPreNov1 + TotalCandidates1;

                if (Session["username"].ToString() == "admin")
                {
                    Body.Append("<td>" + Totalcalculate5 + "</td>");
                }
                else
                {
                    Body.Append("<td>" + Totalcalculate55 + "</td>");
                }
                #endregion
            }
            #endregion
            return Json(Body.ToString(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult TableData(string province)
        {
            string currentUser = Convert.ToString(Session["username"]);
            var AllMemberDataVows = dbcont.tbl_PersonalDetails;
            List<Formationmembers> allRecords = new List<Formationmembers>();
            var data = dbcont.tbl_PersonalDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Vowscheck == "yes")
           .ToList().Select(x => new { x.MemberID }).Distinct().ToList();
            foreach (var memberid in data)
            {
                var check = AllMemberDataVows
                    .Where(x => x.MemberID == memberid.MemberID)
                    .Where(x => x.CurrentStatus != "Novitiate2ndY")
                    .ToList();
                if (check.Count() == 0)
                {
                    var data1 = AllMemberDataVows
                        .Where(x => x.MemberID == memberid.MemberID)
                        .Select(x => new Formationmembers { Name = x.Name, MemberId = x.MemberID, ProvinceName = x.ProvinceName, FileNo = x.FileNo, VowsStatus = x.VowsStatus, CurrentCommunity = x.CurrentCommunity, DOB = x.DOB }).FirstOrDefault();
                    allRecords.Add(data1);
                }
            }

            if (Session["username"].ToString() == "admin")
            {
                if (province != "0")
                {
                    allRecords = allRecords.Where(x => x.ProvinceName == province).Distinct().ToList();
                }
                else
                {
                    allRecords = allRecords.ToList();
                }

                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords1 = allRecords.Where(x => x.ProvinceName == currentUser).ToList();
                return Json(allRecords1, JsonRequestBehavior.AllowGet);
            }
        }
    }
}