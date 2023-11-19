using Generalate.Helpers;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class AllProvinceReportsController : Controller
    {
        private GeneralDBContext db = new GeneralDBContext();
        private GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllProvinceReports()
        {
            return View();
        }

        public JsonResult GetReportAll(string FromDate, string ToDate)
        {
            StringBuilder Header = new StringBuilder();
            StringBuilder Body = new StringBuilder();
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();

            int year;

            if (string.IsNullOrEmpty(FromDate) && string.IsNullOrEmpty(ToDate))
            {
                year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(FromDate);
                lastDay = Convert.ToDateTime(ToDate);
                DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                year = date.Year;
                ViewBag.Year = date.Year;
            }
            var Allprovince = db.tbl_Province.ToList();
            var IsOrdiation = db.tblConfigSetting.Where(x => x.strPurpose == "ShowOrdiation").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();
            int isOrd = 0;
            if (IsOrdiation != null)
            {
                if (Convert.ToInt32(IsOrdiation[0].strConfigValue) == 1)
                {
                    isOrd = 1;
                }
            }
            #region Generate Header
            Header.Append("<thead>");
            Header.Append("<tr>");
            Header.Append("<th colspan='2' rowspan='3' scope='colgroup'>" + HomeController.GetControlTextByControlId("Province") + "</th>");
            Header.Append("<th colspan='11' scope='colgroup'>" + HomeController.GetControlTextByControlId("Variation of Professed Sisters in " + year + "") + "</th>");
            if (isOrd == 1)
            {
                Header.Append("<th colspan='7' scope='colgroup'>" + HomeController.GetControlTextByControlId("Variation of Novices (1st and 2nd year) in " + year + "") + "</th>");

                Header.Append("<th colspan='5' scope='colgroup'>" + HomeController.GetControlTextByControlId("Variation of Ordained Bros in " + year + " included in “Professed Brothers") + "”</th>");
            }
            Header.Append("<th colspan='2' scope='colgroup'>" + HomeController.GetControlTextByControlId("TOTAL MEMBERS") + "</th>");
            Header.Append("</tr>");
            Header.Append("<tr>");
            Header.Append("<th colspan='2' scope='colgroup col'>" + HomeController.GetControlTextByControlId("Professsion (+)") + "</th>");
            Header.Append("<th colspan='2' scope='colgroup col'>" + HomeController.GetControlTextByControlId("Death (-)") + "</th>");
            Header.Append("<th colspan='2' scope='colgroup col'>" + HomeController.GetControlTextByControlId("Departure (-)") + "</th>");
            Header.Append("<th colspan='2' scope='colgroup col'>" + HomeController.GetControlTextByControlId("Trans. of Province") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Var.") + "</th>");
            Header.Append("<th colspan='2' scope='colgroup col'>" + HomeController.GetControlTextByControlId("PROFESSED") + "</th>");


            Header.Append("<th colspan='2' scope='colgroup col'>" + HomeController.GetControlTextByControlId("NOVICES") + "</th>");
            if (isOrd == 1)
            {
                Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Entries") + "</th>");
                Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("1st Prof") + "</th>");
                Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Death") + "</th>");
                Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Departures") + "</th>");
                Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Var.") + "</th>");
                Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Ordi.") + "</th>");
                Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Death") + "</th>");
                Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Departures") + "</th>");
                Header.Append("<th colspan='2' scope='colgroup col'>" + HomeController.GetControlTextByControlId("Ordained Brothers") + "</th>");
            }

            Header.Append("<th colspan='2' scope='colgroup col'>" + HomeController.GetControlTextByControlId("Total Brothers + Novices") + "</th>");
            Header.Append("</tr>");
            Header.Append("<tr>");
            //Header.Append("<th scope='col' colspan='2' scope='colgroup'></th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("1e") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("Perp") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("T.V.") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("P.V.") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("T.V.") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("P.V.") + "</th>");
            Header.Append("<th scope='col'>(-)</th>");
            Header.Append("<th scope='col'>(+)</th>");
            Header.Append("<th scope='col'></th>");
            Header.Append("<th scope='col'>" + (FromDate == "" ? firstDay.ToString("dd/MM/yyyy") : FromDate).ToString() + "</th>");
            Header.Append("<th scope='col'>" + (ToDate == "" ? lastDay.ToString("dd/MM/yyyy") : ToDate).ToString() + "</th>");


            if (isOrd == 1)
            {
                Header.Append("<th scope='col'>(+)</th>");
                Header.Append("<th scope='col'>(-)</th>");
                Header.Append("<th scope='col'>(-)</th>");
                Header.Append("<th scope='col'>(-)</th>");
                Header.Append("<th scope='col'></th>");
                Header.Append("<th scope='col'>" + (FromDate == "" ? firstDay.ToString("dd/MM/yyyy") : FromDate).ToString() + "</th>");
                Header.Append("<th scope='col'>" + (ToDate == "" ? lastDay.ToString("dd/MM/yyyy") : ToDate).ToString() + "</th>");
                Header.Append("<th scope='col'>(+)</th>");
                Header.Append("<th scope='col'>(-)</th>");
                Header.Append("<th scope='col'>(-)</th>");

            }
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("1st Nov") + "</th>");
            Header.Append("<th scope='col'>" + HomeController.GetControlTextByControlId("2nd Nov") + "</th>");
            Header.Append("<th scope='col'>" + (FromDate == "" ? firstDay.ToString("dd/MM/yyyy") : FromDate).ToString() + "</th>");
            Header.Append("<th scope='col'>" + (ToDate == "" ? lastDay.ToString("dd/MM/yyyy") : ToDate).ToString() + "</th>");
            Header.Append("</tr>");
            Header.Append("</thead>");
            Body.Append(Header);
            #endregion

            #region Body
            Dictionary<string, string> Reportdata = new Dictionary<string, string>();
            foreach (var item in Allprovince)
            {
                Reportdata.Add(item.ProvinceName, item.Place);
            }
            //Reportdata.Add("Central Administration-ADC", "ADC");
            //Reportdata.Add("Brazzaville-BRA", "BRA");
            //Reportdata.Add("Canada-CAN", "CAN");
            //Reportdata.Add("Spain-ESP", "ESP");
            //Reportdata.Add("France-FRA", "FRA");
            //Reportdata.Add("Bengaluru-INB", "INB");
            //Reportdata.Add("Delhi-IND", "IND");
            //Reportdata.Add("North East India-INE", "INE");
            //Reportdata.Add("Hyderabad-INH", "INH");
            //Reportdata.Add("Italy-ITA", "ITA");
            //Reportdata.Add("Trichy-INT", "INT");
            //Reportdata.Add("Yercaud-INY", "INY");
            //Reportdata.Add("Kinshasa-KIN", "KIN");
            //Reportdata.Add("Malaysia-Singapur-MAL", "MAL");
            //Reportdata.Add("Province Of East Africa-PEA", "PEA");
            //Reportdata.Add("Senegal-SEN", "SEN");
            //Reportdata.Add("Thailand-THA", "THA");

            var alltbl_PersonalDetails = dbcont.tbl_PersonalDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.IsTransfer != "yes").ToList();
            //var allTbl_formationsDetails = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Status != "0").ToList();

            DateTime deathDate = DateTime.Now;
            var alltbl_Passed = dbcont.tbl_Passed.ToList();
            Dictionary<string, tbl_Passed> deathDetailsDict = new Dictionary<string, tbl_Passed>();
            foreach(tbl_Passed passed in alltbl_Passed)
            {
                if(DateTime.TryParse(passed.Date, out deathDate) && deathDate.Year == year)
                    deathDetailsDict.Add(passed.MemberID, passed);
            }

            var allTbl_Transfer = dbcont.Tbl_Transfer.ToList();

            //Dictionary<string, Tbl_Transfer> Transferdict = new Dictionary<string, Tbl_Transfer>();
            //DateTime transferdate;
            //foreach(Tbl_Transfer tbl_Transfer in allTbl_Transfer)
            //{
            //    if (DateTime.TryParse(tbl_Transfer.CreatedDate, out transferdate) && transferdate.Year == year)
            //        Transferdict.Add(tbl_Transfer.MemberUnicId, tbl_Transfer);
            //}

            var allVowsRenewal = dbcont.Tbl_RenewalVows.ToList();
            var alltbl_SeperationFromTheCongregation = dbcont.tbl_SeperationFromTheCongregation.ToList();

            Dictionary<string, tbl_SeperationFromTheCongregation> seperationdict = new Dictionary<string, tbl_SeperationFromTheCongregation>();
            DateTime sepratindate = DateTime.Now;
            foreach(tbl_SeperationFromTheCongregation tbl_SeperationFromTheCongregation in alltbl_SeperationFromTheCongregation)
            {
                if (DateTime.TryParse(tbl_SeperationFromTheCongregation.SeperationDate, out sepratindate) && sepratindate.Year == year)
                    seperationdict.Add(tbl_SeperationFromTheCongregation.MemberID, tbl_SeperationFromTheCongregation);
            }

            int GrandTotal1 = 0;
            int GrandTotal2 = 0;
            int GrandTotal3 = 0;
            int GrandTotal4 = 0;
            int GrandTotal5 = 0;
            int GrandTotal6 = 0;
            int GrandTotal7 = 0;
            int GrandTotal8 = 0;
            int GrandTotal9 = 0;
            int GrandTotal10 = 0;
            int GrandTotal11 = 0;
            int GrandTotal12 = 0;
            int GrandTotal13 = 0;
            int GrandTotal14 = 0;
            int GrandTotal15 = 0;
            int GrandTotal16 = 0;
            int GrandTotal17 = 0;
            int GrandTotal18 = 0;
            int GrandTotal19 = 0;
            int GrandTotal20 = 0;
            int GrandTotal21 = 0;
            int GrandTotal22 = 0;
            int GrandTotal23 = 0;
            int GrandTotal24 = 0;
            int GrandTotal25 = 0;

            Dictionary<string, string> configData = GetConfingSettingsDict();
            List<string> DyKey1 = GetConfigValuesList(configData, "DyKey1");
            List<string> DyKey2 = GetConfigValuesList(configData, "DyKey2");
            //List<string> DyKey3 = GetConfigValuesList(configData, "DyKey3");
            //List<string> DyKey4 = GetConfigValuesList(configData, "DyKey4");
            //List<string> DyKey5 = GetConfigValuesList(configData, "DyKey5");
            //List<string> DyKey6 = GetConfigValuesList(configData, "DyKey6");
            //List<string> DyKey7 = GetConfigValuesList(configData, "DyKey7");
            List<string> DyKey8 = GetConfigValuesList(configData, "DyKey8");
            List<string> DyKey9 = GetConfigValuesList(configData, "DyKey9");
            //List<string> DyKey10 = GetConfigValuesList(configData, "DyKey10");
            //List<string> DyKey11 = GetConfigValuesList(configData, "DyKey11");
            //List<string> DyKey12 = GetConfigValuesList(configData, "DyKey12");
            List<string> DyKey13 = GetConfigValuesList(configData, "DyKey13");
            List<string> DyKey14 = GetConfigValuesList(configData, "DyKey14");
            List<string> DyKey15 = GetConfigValuesList(configData, "DyKey15");
            //List<string> DyKey16 = GetConfigValuesList(configData, "DyKey16");

            var allTbl_formationsDetails = dbcont.Tbl_formationsDetails.Where(x => (DyKey1.Contains(x.StageOfFormation) || DyKey2.Contains(x.StageOfFormation))).OrderByDescending(x => x.StageOfFormation).ToList();
            var alltblformaion = dbcont.Tbl_formationsDetails.Where(x => DyKey8.Contains(x.StageOfFormation) || DyKey9.Contains(x.StageOfFormation)).ToList();

            List<ProfessionDetails> professionDetails = new List<ProfessionDetails>();

            //var MemberInCandi = allTbl_formationsDetails.Where(x => DyKey3.Contains(x.StageOfFormation) && x.Status == "1" ).Select(x => x.MemberId).ToList();
            //var MemberInNovi = allTbl_formationsDetails.Where(x => x.Status == "1" && (DyKey4.Contains(x.StageOfFormation)) && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null).Select(x => x.MemberId).ToList();
            //var MemberInDead = alltbl_Passed.Select(x => x.MemberID).ToList();
            //var MemberInSep = alltbl_SeperationFromTheCongregation.Select(x => x.MemberID).ToList();
            //var MemberInNovIst = allTbl_formationsDetails.Where(x => DyKey6.Contains(x.StageOfFormation) && x.Status == "1").Select(x => x.MemberId).ToList();
            //var MemberInNovIInd = allTbl_formationsDetails.Where(x => DyKey5.Contains(x.StageOfFormation) && x.Status == "1").Select(x => x.MemberId).ToList();
            //var allPersionalDetails = alltbl_PersonalDetails.Where(x => x.IsDeleted == false && !(MemberInNovIst.Contains(x.MemberID)) && !(MemberInNovIInd.Contains(x.MemberID)) && !(MemberInCandi.Contains(x.MemberID)) && !(MemberInDead.Contains(x.MemberID)) && !(MemberInSep.Contains(x.MemberID)) && x.Diedcheck == null && x.Sapcheck == null && x.IsTransfer != "yes" && x.Archivecheck != "yes" /*&& x.CurrentStatus != null && x.CurrentStatus != "11" && x.CurrentStatus != "12"*/).ToList();



            foreach (var item in Reportdata)
            {
                var province = db.tbl_Province.FirstOrDefault(x => x.Place == item.Value);
                //var province = db.tbl_Province.FirstOrDefault();

                Body.Append("<tr>");
                Body.Append("<td>" + item.Key + "</td>");
                Body.Append("<td>" + item.Value + "</td>");

                #region 1 col
                if (/*item.Value == "ADC"*/true)
                {
                    string provinceId = province.Id.ToString();
                    int Total1Pro = 0;
                    int TotalPerP = 0;
                    int TotalDeathTV = 0;
#pragma warning disable CS0219 // The variable 'TotalDeathTV1' is assigned but its value is never used
                    int TotalDeathTV1 = 0;
#pragma warning restore CS0219 // The variable 'TotalDeathTV1' is assigned but its value is never used
                    int TotalDeathPV = 0;
                    int TallForVT = 0;
                    int TolalForVP = 0;
                    //int allTransminus = 0;
                    Dictionary<string, Tbl_formationsDetails> finalVowsDict = new Dictionary<string, Tbl_formationsDetails>();
                    Dictionary<string, Tbl_formationsDetails> firstVowsDict = new Dictionary<string, Tbl_formationsDetails>();
                    foreach (Tbl_formationsDetails formationDetail in allTbl_formationsDetails)
                    {
                        if (!string.IsNullOrWhiteSpace(formationDetail.ProvinceName) && formationDetail.ProvinceName.Equals(provinceId))
                        {
                            DateTime vowsDate = DateTime.Now;
                            DateTime.TryParse(formationDetail.VowsDate, out vowsDate);

                            if (DyKey2.Contains(formationDetail.StageOfFormation) &&
                                (formationDetail.Status == "1" && vowsDate.Year == year 
                                || formationDetail.Status == "0" && vowsDate.Year == year))
                            {
                                if (deathDetailsDict.ContainsKey(formationDetail.MemberId) && !finalVowsDict.ContainsKey(formationDetail.MemberId))
                                {
                                    TotalDeathPV++;
                                }
                                else if (seperationdict.ContainsKey(formationDetail.MemberId))
                                {
                                    TallForVT++;
                                }
                                //else if (Transferdict.ContainsKey(formationDetail.MemberId))
                                //{
                                //    allTransminus++;
                                //}
                                else
                                {
                                    //Final Vows
                                    TotalPerP++;
                                }

                                if(!finalVowsDict.ContainsKey(formationDetail.MemberId))
                                    finalVowsDict.Add(formationDetail.MemberId, formationDetail);
                            }
                            else if (DyKey1.Contains(formationDetail.StageOfFormation) &&
                                (formationDetail.Status == "1" && vowsDate.Year == year
                               || formationDetail.Status == "0" && vowsDate.Year == year) && !finalVowsDict.ContainsKey(formationDetail.MemberId))
                            {
                                if (deathDetailsDict.ContainsKey(formationDetail.MemberId) && !firstVowsDict.ContainsKey(formationDetail.MemberId))
                                {
                                    TotalDeathTV++;
                                }
                                else if (seperationdict.ContainsKey(formationDetail.MemberId))
                                {
                                    TolalForVP++;
                                }
                                else
                                {
                                    //First Vows
                                    Total1Pro++;
                                }

                                if(!firstVowsDict.ContainsKey(formationDetail.MemberId))
                                    firstVowsDict.Add(formationDetail.MemberId, formationDetail);
                            }
                        }
                    }

                    //DateTime dat;
                    //int Total1Pro = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && DyKey1.Contains(x.StageOfFormation)  && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.Status != "0" && DateTime.TryParse(x.VowsDate,out dat) && dat >= firstDay && dat <= lastDay).Count();
                    Body.Append("<td>" + Total1Pro + "</td>"); 
                    GrandTotal1 += Total1Pro;

                    //DateTime date1;
                    //int TotalPerP = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && DyKey2.Contains(x.StageOfFormation) && x.Diedcheck != "Active" && x.Sapcheck != "Active" && DateTime.TryParse(x.VowsDate, out date1) && date1 >= firstDay && date1 <= lastDay && x.Status != "0").Count();
                    Body.Append("<td>" + TotalPerP + "</td>"); // TotalPerP
                    GrandTotal2 += TotalPerP;

                    //DateTime date2;
                   // TotalDeathTV = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == "Active" && DateTime.TryParse(x.VowsDate,out date2) && date2 >= firstDay && date2 <= lastDay).Count();
                    Body.Append("<td>" + TotalDeathTV + "</td>"); // TotalPassaed1stPro
                    GrandTotal3 += TotalDeathTV;

                    //DateTime date3;
                   //var DeathPV = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && DyKey2.Contains(x.StageOfFormation) && x.Diedcheck == "Active" && DateTime.TryParse(x.VowsDate,out date3) && date3 >= firstDay && date3 <= lastDay);
                   // TotalDeathPV = TotalDeathPV + DeathPV.Count();
                    //int DeathVP = allVowsRenewal.Where(x => x.ProvinceName == province.Id.ToString() && DyKey4.Contains(x.CurrentStatus) /*x.CurrentStatus == "15"*/ && x.DeathCheck == "Active" && Convert.ToDateTime(x.Surname) >= firstDay && Convert.ToDateTime(x.Surname) <= lastDay).Count();
                    Body.Append("<td>" + TotalDeathPV + "</td>"); // TotalPassaedPerPro
                    GrandTotal4 += TotalDeathPV;


                    //DateTime date4;
                    //int TallForVT = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && DyKey1.Contains(x.CurrentStatus) /*x.CurrentStatus == "14"*/ && x.Sapcheck == "Active" && DateTime.TryParse(x.VowsDate,out date4) && date4 >= firstDay && date4 <= lastDay).Count();
                    Body.Append("<td>" + TallForVT + "</td>");
                    GrandTotal5 += TallForVT;

                    //DateTime date5;
                    //int TolalForVP = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && DyKey2.Contains(x.CurrentStatus)  && x.Sapcheck == "Active" && DateTime.TryParse(x.VowsDate,out date5) && date5 >= firstDay && date5 <= lastDay).Count();
                    Body.Append("<td>" + TolalForVP + "</td>");
                    GrandTotal6 += TolalForVP;

                    DateTime trandate;
                    int allTransminus = allTbl_Transfer.Where(x => x.OldProvinceId == province.MyId && DateTime.TryParse(x.CreatedDate,out trandate) && trandate.Year == year).Count();
                    Body.Append("<td>" + allTransminus + "</td>");
                    GrandTotal7 += allTransminus;

                    DateTime tranminusdate;
                    int allTransplus = allTbl_Transfer.Where(x => x.NewProvinceId == province.MyId && DateTime.TryParse(x.CreatedDate,out tranminusdate) && tranminusdate.Year == year).Count();
                    Body.Append("<td>" + allTransplus + "</td>");
                    GrandTotal8 += allTransplus;

                    //Variations
                    //int TotalProffesspls = Total1Pro + TotalPerP + allTransplus;
                    //int TotalProffessmns = DeathVT + DeathVP + TolalForVP + TallForVT;
                    //int Totalcalculate = TotalProffesspls - TotalProffessmns;
                    //Body.Append("<td>" + Totalcalculate + "</td>");
                    //GrandTotal9 += Totalcalculate; 

                    int TotalProffesspls = Total1Pro + TotalPerP;
                    int total1 = TotalProffesspls + allTransplus;
                    int TotalProffessmns = TotalDeathTV + TotalDeathPV;
                    int total2 = TolalForVP + TallForVT;
                    int Gtotal = TotalProffessmns + total2;
                    int Totalcalculate = total1 - Gtotal;
                    Body.Append("<td>" + Totalcalculate + "</td>");
                    GrandTotal9 += Totalcalculate;

                    int totalproffess01011 = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.Diedcheck == null && x.Sapcheck== null && x.Archivecheck == null && DyKey1.Contains(x.StageOfFormation) && x.Status != "0").Count();
                    int totalproffess01012 = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && DyKey2.Contains(x.StageOfFormation) && x.Status == "1").Count();
                    int totalproffess0101 = totalproffess01011 + totalproffess01012 - Totalcalculate;
                    //int TotalProffess0101 = allPersionalDetails.Where(x => x.ProvinceName == province.Id.ToString()).Count();
                    Body.Append("<td>" + totalproffess0101 + "</td>");
                    GrandTotal10 += totalproffess0101;

                    int TotalProffesspls1 = Total1Pro + TotalPerP + allTransplus;
                    int TotalProffessmns1 = TotalDeathTV + TotalDeathPV + TolalForVP + TallForVT;
                    int Totalcalculate1 = TotalProffesspls1 - TotalProffessmns1;
                    int TotalProffess3112 = totalproffess0101 + Totalcalculate1;
                    Body.Append("<td>" + TotalProffess3112 + "</td>");
                    GrandTotal11 += TotalProffess3112;

                    //Novices

                    int TotalNov0101 = alltblformaion.Where(x => x.ProvinceName == province.Id.ToString() && DyKey8.Contains(x.StageOfFormation) && x.Status == "1" ).Count();
                    Body.Append("<td>" + TotalNov0101 + "</td>");
                    GrandTotal17 += TotalNov0101;

                    int TotalNov3112 = alltblformaion.Where(x => x.ProvinceName == province.Id.ToString() && DyKey9.Contains(x.StageOfFormation) && x.Status != "0").Count();
                    Body.Append("<td>" + TotalNov3112 + "</td>");
                    GrandTotal18 += TotalNov3112;

                    //int TotalBroNov3112 = TotalOrdination + (TotalOrdiDepart + TotalOrdiDeath - TotalOrdination) + TotalOrdi0101;
                    int TotalBroNov3112 = TotalNov0101 + TotalNov3112;
                    Body.Append("<td>" + TotalBroNov3112 + "</td>");
                    GrandTotal25 += TotalBroNov3112;

                    //Brothers & sisters
                    int TotalBroNov0101 = TotalProffess3112 + TotalNov0101 + TotalNov3112;
                    Body.Append("<td>" + TotalBroNov0101 + "</td>");
                    GrandTotal24 += TotalBroNov0101;

                   


                    if (isOrd == 1)
                    {
                        DateTime date6;
                        int TotalEnter = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && DyKey8.Contains(x.StageOfFormation)  && x.Diedcheck != "Active" && x.Sapcheck != "Active" && DateTime.TryParse(x.FromDate,out date6) && date6 >= firstDay && date6 <= lastDay && x.Status != "0").Count();
                        Body.Append("<td>" + TotalEnter + "</td>");
                        GrandTotal12 += TotalEnter;

                        DateTime date7;
                        int TotalNovTo1st = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && DyKey9.Contains(x.StageOfFormation) && x.Diedcheck != "Active" && x.Sapcheck != "Active" && DateTime.TryParse(x.FromDate,out date7) && date7 >= firstDay && date7 <= lastDay && x.Status != "0").Count();
                        Body.Append("<td>" + TotalNovTo1st + "</td>");
                        GrandTotal13 += TotalNovTo1st;

                        var year1 = "";
                        if (FromDate == "")
                        {
                            year1 = DateTime.Now.Year.ToString();
                        }
                        else
                        {
                            DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                            year1 = date.Year.ToString();
                        }

                        //int TotalNovDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && DyKey10.Contains(x.CurrentStatusFor)/*(x.CurrentStatusFor == "13" || x.CurrentStatusFor == "14")*/ && Convert.ToDateTime(x.Date) >= firstDay && Convert.ToDateTime(x.Date) <= lastDay).Count();
                        int TotalNovDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && x.Added_Year == year1).Count();
                        Body.Append("<td>" + TotalNovDeath + "</td>");
                        GrandTotal14 += TotalNovDeath;

                        int TotalNovDepart = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && x.Added_Year == year1).Count();
                        Body.Append("<td>" + TotalNovDepart + "</td>");
                        GrandTotal15 += TotalNovDepart;

                        int TotalNovVarmns = TotalNovTo1st + TotalNovDeath + TotalNovDepart;
                        int TotalVarforNov = TotalEnter - TotalNovVarmns;
                        Body.Append("<td>" + TotalVarforNov + "</td>");
                        GrandTotal16 += TotalVarforNov;




                    }





                    int TotalOrdination = 0;
                    int TotalOrdiDeath = 0;
                    int TotalOrdiDepart = 0;
                    int TotalOrdi0101 = 0;
                    if (isOrd == 1)
                    {
                        DateTime date8;
                        TotalOrdination = allTbl_formationsDetails.Where(x => x.ProvinceName == province.Id.ToString() && DyKey13.Contains(x.StageOfFormation)/*(x.StageOfFormation == "17" || x.StageOfFormation == "19")*/ && x.Diedcheck != "Active" && x.Sapcheck != "Active" && DateTime.TryParse(x.FromDate,out date8) && date8 >= firstDay && date8 <= lastDay && x.Status != "0").Count();
                        Body.Append("<td>" + TotalOrdination + "</td>");
                        GrandTotal19 += TotalOrdination;

                        DateTime date9;
                        TotalOrdiDeath = alltbl_Passed.Where(x => x.ProvinceName == province.Id.ToString() && DyKey14.Contains(x.CurrentStatusFor)/*(x.CurrentStatusFor == "17" || x.CurrentStatusFor == "19")*/ && DateTime.TryParse(x.Date,out date9) && date9 >= firstDay && date9 <= lastDay).Count();
                        Body.Append("<td>" + TotalOrdiDeath + "</td>");
                        GrandTotal20 += TotalOrdiDeath;

                        DateTime date10;
                        TotalOrdiDepart = alltbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == province.Id.ToString() && DyKey15.Contains(x.StageOFFormation)/*(x.StageOFFormation == "17" || x.StageOFFormation == "19")*/ && DateTime.TryParse(x.SeperationDate,out date10) && date10 >= firstDay && date10 <= lastDay).Count();
                        Body.Append("<td>" + TotalOrdiDepart + "</td>");
                        GrandTotal21 += TotalOrdiDepart;

                        TotalOrdi0101 = alltbl_PersonalDetails.Where(x => x.ProvinceName == province.Id.ToString() && x.IsTransfer != "yes" && DyKey1.Contains(x.CurrentStatus) /*x.CurrentStatus == "13" && x.CurrentStatus == "14"*/).Count();
                        Body.Append("<td>" + TotalOrdi0101 + "</td>");
                        GrandTotal22 += TotalOrdi0101;

                        int TotalOrdimns = TotalOrdiDepart + TotalOrdiDeath;
                        int TotalOrdipls = TotalOrdimns - TotalOrdination;
                        int TotalOrdi3112 = TotalOrdipls + TotalOrdi0101;
                        Body.Append("<td>" + TotalOrdi3112 + "</td>");
                        GrandTotal23 += TotalOrdi3112;


                    }




                }

                #endregion
            }

            Body.Append("<tr>");
            Body.Append("<td><b>Total :</b></td>");
            Body.Append("<td></td>");
            Body.Append("<td><b>" + GrandTotal1 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal2 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal3 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal4 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal5 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal6 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal7 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal8 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal9 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal10 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal11 + "</b></td>");

            Body.Append("<td><b>" + GrandTotal17 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal18 + "</b></td>");

            if (isOrd == 1)
            {
                Body.Append("<td><b>" + GrandTotal12 + "</b></td>");
                Body.Append("<td><b>" + GrandTotal13 + "</b></td>");
                Body.Append("<td><b>" + GrandTotal14 + "</b></td>");
                Body.Append("<td><b>" + GrandTotal15 + "</b></td>");
                Body.Append("<td><b>" + GrandTotal16 + "</b></td>");
                Body.Append("<td><b>" + GrandTotal19 + "</b></td>");
                Body.Append("<td><b>" + GrandTotal20 + "</b></td>");
                Body.Append("<td><b>" + GrandTotal21 + "</b></td>");
                Body.Append("<td><b>" + GrandTotal22 + "</b></td>");
                Body.Append("<td><b>" + GrandTotal23 + "</b></td>");
            }
            Body.Append("<td><b>" + GrandTotal25 + "</b></td>");
            Body.Append("<td><b>" + GrandTotal24 + "</b></td>");
            Body.Append("</tr>");
            #endregion
            return Json(Body.ToString(), JsonRequestBehavior.AllowGet);
        }

        public class ProfessionDetails
        {
            public string MemberId { get; set; }

            public string ProvinceName { get; set; }
            public string ProvinceId { get; set; }
            public string Stageofformation { get; set; }
        }

        public Dictionary<string, string> GetConfingSettingsDict()
        {
            List<tblConfigSetting> settings = new HomeController().GetConfingSettings();
            Dictionary<string, string> settingsDict = new Dictionary<string, string>();
            foreach(tblConfigSetting setting in settings)
            {
                if (setting.strPurpose.Equals("ReportProvinceStatistic"))
                {
                    settingsDict.Add(setting.strConfigKey, setting.strConfigValue);
                }
            }

            return settingsDict;
        }

        public List<string> GetConfigValuesList(Dictionary<string, string> configData, string key)
        {
            List<string> configValues = new List<string>();
            if(configData != null)
            {
                var data = configData.ContainsKey(key) ? configData[key] : null;
                if (data != null)
                {
                    string[] tempList = data.Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        configValues.Add(tempList[i]);
                    }
                }
            }

            return configValues;
        }
    }
}