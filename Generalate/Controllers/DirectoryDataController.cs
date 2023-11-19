using Generalate.Models;
using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    public class DirectoryDataController : Controller
    {
        private GeneralDBContext db = new GeneralDBContext();
        private GeneralDBContext dbcont = new GeneralDBContext();
#pragma warning disable CS0169 // The field 'DirectoryDataController.currentyear' is never used
        private int currentyear;
#pragma warning restore CS0169 // The field 'DirectoryDataController.currentyear' is never used

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DirectoryData()
        {
            return View();
        }

        public JsonResult GetProvinceData(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province).ToList();

                foreach (var item in allProvinceName)
                {
                    alldata.Add(new Formationmembers
                    {
                        Name = item.ProvinceName
                    });
                }
                return Json(alldata.Where(x => x.Name != "").ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province).ToList();

                foreach (var item in allProvinceName)
                {
                    alldata.Add(new Formationmembers
                    {
                        Name = item.ProvinceName
                    });
                }
                return Json(alldata.Where(x => x.Name != "").ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetProvinceData1(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province).ToList();

                foreach (var item in allProvinceName)
                {
                    alldata.Add(new Formationmembers
                    {
                        Name = item.ProvinceName
                    });
                }
                return Json(alldata.Where(x => x.Name != "").ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province).ToList();

                foreach (var item in allProvinceName)
                {
                    alldata.Add(new Formationmembers
                    {
                        Name = item.ProvinceName
                    });
                }
                return Json(alldata.Where(x => x.Name != "").ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCommunityData(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentUser = Convert.ToString(Session["username"]);
            string currentloginid = Convert.ToString(Session["loginuserid"]);



            var query = db.Tbl_Cong.Where(w => w.ProvinceName == province && w.ActiveCkeck == "Active");

            if (currentUser != "admin")
                query = query.Where(w => w.ProvinceName == currentUser);

            var alldata = query.Select(item => new Formationmembers
            {
                Name = item.ProvinceName,
                CongregationName = item.CongregationName,
                CommCode = item.CommCode,
                Place = item.Place
            }).ToList();

            alldata.ForEach(fe =>
                {

                    fe.Name = fe.Name ?? string.Empty;
                    fe.CommCode = fe.CommCode ?? string.Empty;
                    fe.CongregationName = fe.CongregationName ?? string.Empty;
                    fe.Place = fe.Place ?? string.Empty;

                });

            return Json(alldata, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetEmailandPhone(string province, string fromdate, string todate)
        {

            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {


                var alldata = (from personal in dbcont.tbl_PersonalDetails

                               join primary in dbcont.tbl_Primarydetails on personal.MemberID
                               equals primary.MemberId into tempPrimary
                               from primary in tempPrimary.DefaultIfEmpty()

                               join f in dbcont.Tbl_formationsDetails on personal.MemberID
                               equals f.MemberId into TempFd
                               from Fd in TempFd.DefaultIfEmpty()

                               join pass in dbcont.tbl_Passed on personal.MemberID
                               equals pass.MemberID into Temppass
                               from pass in Temppass.DefaultIfEmpty()

                               join sepa in dbcont.tbl_SeperationFromTheCongregation
                               on personal.MemberID equals sepa.MemberID into Tempsepa
                               from sepa in Tempsepa.DefaultIfEmpty()

                               where pass == null
                               && sepa == null
                               && Fd.Diedcheck != "Active"
                               && Fd.Sapcheck != "Active"
                               && (province != "0" && personal.ProvinceName == province)
                               select new PrimaryDataViewModel()
                               {
                                   Name = personal.Name ?? string.Empty,
                                   SurName = personal.SirName ?? string.Empty,
                                   emailid = primary.emailid ?? personal.EmailID ?? string.Empty,
                                   mobilenumber = primary.mobilenumber ?? personal.Mobile ?? string.Empty,
                                   MemberId = personal.MemberID,
                                   Provincename = primary.ProvinceName ?? string.Empty,
                               }
                          ).ToList();


                alldata = alldata.GroupBy(g => g.MemberId)
                    .SelectMany(s => s.OrderByDescending(o => o.emailid).Take(1)).ToList();


                return Json(alldata, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var alldata = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == currentuser && x.ProvinceName == province)

                    .OrderBy(x => x.Knowname).Select(s => new tbl_Primarydetails()
                    {
                        Knowname = s.Knowname,
                        SurName = s.SurName,
                        emailid = s.emailid,
                    });

                return Json(alldata, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetPerpetualVows(string province, string fromdate, string todate)
        {
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);

            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();

            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }

            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic3")
                .Where(x => x.strConfigKey == "DyKey4")
                .Where(x => x.strConfigValue != null)
                .Select(x => x.strConfigValue).ToList();

            List<string> DyKey1 = configData.SelectMany(x => x.Split(',')).ToList();

            configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic3")
                .Where(x => x.strConfigKey == "DyKey5")
                .Where(x => x.strConfigValue != null)
                .Select(x => x.strConfigValue).ToList();

            List<string> DyKey2 = configData.SelectMany(x => x.Split(',')).ToList();
            List<Formationmembers> alldata = new List<Formationmembers>();

            if (Session["username"].ToString() == "admin")
            {


                var data = dbcont.Tbl_formationsDetails.Where(x => DyKey1.Contains(x.StageOfFormation))
                    .Where(w => province != "0" && w.ProvinceName == province).ToList();

                var memberIds = data.Select(s => s.MemberId).ToList();

                var data2 = dbcont.Tbl_formationsDetails.Where(x => memberIds.Contains(x.MemberId) && DyKey2.Contains(x.StageOfFormation)).ToList();



                foreach (var item in data)
                {
                    var Fvows = data2.FirstOrDefault(x => x.MemberId.ToString() == item.MemberId);

                    if (Fvows == null)
                        continue;

                    if (dbcont.tbl_Passed.Any(a => a.MemberID == item.MemberId))
                        continue;

                    if (dbcont.tbl_SeperationFromTheCongregation.Any(a => a.MemberID == item.MemberId))
                        continue;


                    var MemberData = dbcont.tbl_PersonalDetails.Where(w => w.MemberID == item.MemberId
                    && (province != "0" && w.ProvinceName == province)).FirstOrDefault();

                    if (MemberData == null)
                        continue;

                    alldata.Add(new Formationmembers()
                    {
                        FileNo = MemberData.FileNo,
                        Name = item.Name,
                        DOB = dbcont.tbl_Primarydetails.Where(w => w.MemberId == item.MemberId).Select(s => s.DOB).FirstOrDefault(),
                        Surname1 = MemberData.SirName,
                        Surname = MemberData.SirName,
                        FirstVowDate = Fvows.VowsDate,
                        FinalVowDate = item.VowsDate

                    });

                }

                return Json(alldata, JsonRequestBehavior.AllowGet);
            }


            var data3 = dbcont.Tbl_RenewalVows.Where(x => x.CurrentStatus == "1stProfession" && x.ProvinceName == currentuser).ToList();

            var alldata2 = new List<Tbl_RenewalVows>();
            foreach (var item in data3)
            {
                alldata2.Add(new Tbl_RenewalVows()
                {
                    FileNo = item.FileNo,
                    Name = item.Name,
                    // DOB = memberDetails.DOB,
                    Surname = item.Surname,

                });
            }
            return Json(alldata2, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetTemporaryVows(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic3").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

            List<string> DyKey2 = new List<string>();
            if (configData != null)
            {

                var data2 = configData.Where(x => x.strConfigKey == "DyKey5").Select(x => x.strConfigValue).ToList();
                if (data2 != null)
                {
                    string[] tempList = data2[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey2.Add(tempList[i]);
                    }
                }
            }
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var Tbl_RenewalVows = dbcont.Tbl_formationsDetails;
                List<Formationmembers> allRecords = new List<Formationmembers>();

                var data = dbcont.Tbl_formationsDetails.Where(x => x.ProvinceName == province && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.Status == "1" && DyKey2.Contains(x.StageOfFormation)).ToList();

                var alldatamem = dbcont.tbl_PersonalDetails.Where(x => x.ProvinceName == province).ToList();
                List<Formationmembers> alldata = new List<Formationmembers>();
                foreach (var memberid in data)
                {

                    {

                        {
                            var MemberData = alldatamem.FirstOrDefault(x => x.MemberID.ToString() == memberid.MemberId);
                            alldata.Add(new Formationmembers()
                            {
                                FileNo = MemberData.FileNo ?? string.Empty,
                                Name = memberid.Name ?? string.Empty,
                                Surname = MemberData.SirName,
                                DOB = MemberData.DOB ?? string.Empty,
                                FirstVowDate = memberid.VowsDate ?? string.Empty,
                            });
                        }
                    }
                }
                return Json(alldata, JsonRequestBehavior.AllowGet);
            }

            else
            {
                var Tbl_RenewalVows = dbcont.Tbl_RenewalVows;
                List<Formationmembers> allRecords = new List<Formationmembers>();

                var data = dbcont.Tbl_RenewalVows.Where(x => x.ProvinceName == province && x.ProvinceName == currentuser && x.DeathCheck == null && x.SapCheck == null && x.Archivecheck == null)
               .ToList().Select(x => new { x.MemberId }).ToList();

                var alldatamem = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == province && x.ProvinceName == currentuser).ToList();
                List<Formationmembers> alldata = new List<Formationmembers>();
                foreach (var memberid in data)
                {
                    var check = Tbl_RenewalVows.Where(x => x.MemberId == memberid.MemberId)
                    .Where(x => !DyKey2.Contains(x.CurrentStatus)/* x.CurrentStatus != "14"*/).ToList();
                    if (check.Count() == 0)
                    {
                        var data1 = Tbl_RenewalVows.Where(x => x.MemberId == memberid.MemberId)
                        .Select(x => new Formationmembers { Name = x.Name, Surname = x.Surname, FileNo = x.FileNo, MemberId = x.MemberId, ProvinceName = x.ProvinceName, Createdby = x.CreatedBy }).FirstOrDefault();
                        allRecords.Add(data1);

                        foreach (var item in allRecords)
                        {
                            var MemberData = alldatamem.FirstOrDefault(x => x.MemberId.ToString() == item.MemberId);
                            alldata.Add(new Formationmembers()
                            {
                                FileNo = item.FileNo ?? string.Empty,
                                Name = item.Name ?? string.Empty,
                                Surname = item.Surname ?? string.Empty,
                                DOB = MemberData.DOB ?? string.Empty,
                            });
                        }
                    }
                }
                return Json(alldata, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetProvinceAddress(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);


            var query = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active"
            && x.Id.ToString() == province);



            if (currentuser != "admin")
                query = query.Where(w => w.ProvinceName == currentuser);

            var alldata = query.Where(w => w.Place != null).Select(s => new Formationmembers
            {
                Place = s.Place
            }).ToList();


            return Json(alldata, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetProvinceMobile(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province).ToList();

                foreach (var item in allProvinceName)
                {
                    alldata.Add(new Formationmembers
                    {
                        Phone = item.Phone
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province && x.ProvinceName == currentuser).ToList();

                foreach (var item in allProvinceName)
                {
                    alldata.Add(new Formationmembers
                    {
                        Phone = item.Phone
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetProvinceEmail(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province).ToList();

                foreach (var item in allProvinceName)
                {
                    alldata.Add(new Formationmembers
                    {
                        EmailId = item.EmailId
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province && x.Id.ToString() == currentuser).ToList();

                foreach (var item in allProvinceName)
                {
                    alldata.Add(new Formationmembers
                    {
                        EmailId = item.EmailId
                    });
                }
                return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEternalBrothers(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["loginuserid"]);
            if (Session["username"].ToString() == "admin")
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var alleternal = dbcont.tbl_Passed.Where(x => x.ProvinceName.ToString() == province).ToList();

                foreach (var item in alleternal)
                {
                    alldata.Add(new Formationmembers
                    {
                        Name = item.Name ?? string.Empty,
                        Date = item.Date ?? string.Empty,
                        Place = item.LastPlaceRites ?? string.Empty,
                        Reason = item.Cause ?? string.Empty,
                    });
                }
                return Json(alldata.Where(x => x.Name != "").ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Formationmembers> alldata = new List<Formationmembers>();
                var alleternal = dbcont.tbl_Passed.Where(x => x.ProvinceName.ToString() == province && x.ProvinceName == currentuser).ToList();

                foreach (var item in alleternal)
                {
                    alldata.Add(new Formationmembers
                    {
                        Name = item.Name ?? string.Empty,
                        Date = item.Date ?? string.Empty,
                        Place = item.LastPlaceRites ?? string.Empty,
                        Reason = item.Cause ?? string.Empty,
                    });
                }
                return Json(alldata.Where(x => x.Name != "").ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get1stnovitiate(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic3").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

            List<string> DyKey1 = new List<string>();
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
            }
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var Tbl_formationsDetails = dbcont.Tbl_formationsDetails;
                List<Formationmembers> allRecords = new List<Formationmembers>();

                // var data = dbcont.Tbl_formationsDetails.Where(x => x.ProvinceName == province && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && DyKey1.Contains(x.StageOfFormation))
                //.ToList().Select(x => new { x.MemberId }).ToList();


                var data = dbcont.Tbl_formationsDetails.Where(x => x.ProvinceName == province && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && DyKey1.Contains(x.StageOfFormation) && x.Status == "1").ToList();

                //var alldatamem = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == province).ToList();
                var alldatamem = dbcont.tbl_PersonalDetails.Where(x => x.ProvinceName == province).ToList();
                List<Formationmembers> alldata = new List<Formationmembers>();
                //foreach (var memberid in data)
                //{
                //    var check = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                //    .Where(x => DyKey1.Contains(x.StageOfFormation) /*x.StageOfFormation != "13"*/).ToList();
                //    if (check.Count() > 0)
                //    {
                //        var data1 = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                //        .Select(x => new Formationmembers { Name = x.Name, MemberId = x.MemberId, ProvinceName = x.ProvinceName, Createdby = x.CreatedBy });
                //        //allRecords.Add(data1);

                //        foreach (var item in data1)
                //        {
                //            var MemberData = alldatamem.FirstOrDefault(x => x.MemberId.ToString() == item.MemberId);
                //            alldata.Add(new Formationmembers()
                //            {
                //                FileNo = item.FileNo,
                //                Name = item.Name,
                //                Surname = item.Surname,
                //                DOB = MemberData.DOB,
                //            });
                //        }
                //    }
                //}



                foreach (var item in data)
                {
                    var MemberData = alldatamem.FirstOrDefault(x => x.MemberID.ToString() == item.MemberId);
                    alldata.Add(new Formationmembers()
                    {
                        Name = item.Name,

                    });
                }



                return Json(alldata, JsonRequestBehavior.AllowGet);
            }

            else
            {
                var Tbl_formationsDetails = dbcont.Tbl_formationsDetails;
                List<Formationmembers> allRecords = new List<Formationmembers>();

                var data = dbcont.Tbl_formationsDetails.Where(x => x.ProvinceName == province && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.CreatedBy == currentUserid)
               .ToList().Select(x => new { x.MemberId }).ToList();

                var alldatamem = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == province && x.ProvinceName == currentuser).ToList();
                List<Formationmembers> alldata = new List<Formationmembers>();
                foreach (var memberid in data)
                {
                    var check = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                    .Where(x => !DyKey1.Contains(x.StageOfFormation) /*x.CurrentStatus != "13"*/).ToList();
                    if (check.Count() == 0)
                    {
                        var data1 = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                        .Select(x => new Formationmembers { Name = x.Name, MemberId = x.MemberId, ProvinceName = x.ProvinceName, Createdby = x.CreatedBy }).FirstOrDefault();
                        allRecords.Add(data1);

                        foreach (var item in allRecords)
                        {
                            var MemberData = alldatamem.FirstOrDefault(x => x.MemberId.ToString() == item.MemberId);
                            alldata.Add(new Formationmembers()
                            {
                                FileNo = item.FileNo,
                                Name = item.Name,
                                Surname = item.Surname,
                                DOB = MemberData.DOB,
                            });
                        }
                    }
                }
                return Json(alldata, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get2ndnovitiate(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic3").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

            List<string> DyKey1 = new List<string>();
            if (configData != null)
            {
                var data1 = configData.Where(x => x.strConfigKey == "DyKey2").Select(x => x.strConfigValue).ToList();
                if (data1 != null)
                {
                    string[] tempList = data1[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey1.Add(tempList[i]);
                    }
                }
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var Tbl_formationsDetails = dbcont.Tbl_formationsDetails;
                List<Formationmembers> allRecords = new List<Formationmembers>();

                var data = dbcont.Tbl_formationsDetails.Where(x => x.ProvinceName == province && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.Status == "1" && DyKey1.Contains(x.StageOfFormation)).ToList();

                //var alldatamem = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == province).ToList();
                var alldatamem = dbcont.tbl_PersonalDetails.Where(x => x.ProvinceName == province).ToList();
                List<Formationmembers> alldata = new List<Formationmembers>();
                //foreach (var memberid in data)
                //{
                //    var check = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                //    .Where(x => DyKey1.Contains(x.StageOfFormation)/* x.StageOfFormation != "14"*/).ToList();
                //    if (check.Count() > 0)
                //    {
                //        var data1 = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                //        .Select(x => new Formationmembers { Name = x.Name, MemberId = x.MemberId, ProvinceName = x.ProvinceName, Createdby = x.CreatedBy });
                //       // allRecords.Add(data1);

                //        foreach (var item in data1)
                //        {
                //            var MemberData = alldatamem.FirstOrDefault(x => x.MemberId.ToString() == item.MemberId);
                //            alldata.Add(new Formationmembers()
                //            {
                //                FileNo = item.FileNo,
                //                Name = item.Name,
                //                Surname = item.Surname,
                //                DOB = MemberData.DOB,
                //            });
                //        }
                //    }
                //}


                foreach (var item in data)
                {
                    //var MemberData = alldatamem.FirstOrDefault(x => x.MemberID.ToString() == item.MemberId);
                    alldata.Add(new Formationmembers()
                    {
                        Name = item.Name,

                    });
                }

                return Json(alldata, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var Tbl_formationsDetails = dbcont.Tbl_formationsDetails;
                List<Formationmembers> allRecords = new List<Formationmembers>();

                var data = dbcont.Tbl_formationsDetails.Where(x => x.ProvinceName == currentuser && x.ProvinceName == province && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null)
               .ToList().Select(x => new { x.MemberId }).ToList();

                List<Formationmembers> alldata = new List<Formationmembers>();
                foreach (var memberid in data)
                {
                    var check = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                    .Where(x => !DyKey1.Contains(x.StageOfFormation)/* x.StageOfFormation != "14"*/).ToList();
                    if (check.Count() == 0)
                    {
                        var data1 = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                        .Select(x => new Formationmembers { Name = x.Name, MemberId = x.MemberId });
                        //allRecords.Add(data1);

                        foreach (var item in data1)
                        {
                            alldata.Add(new Formationmembers()
                            {
                                Name = item.Name,
                            });
                        }
                    }
                }
                return Json(alldata, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPreNovitiate(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic3").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

            List<string> DyKey1 = new List<string>();
            if (configData != null)
            {
                var data1 = configData.Where(x => x.strConfigKey == "DyKey3").Select(x => x.strConfigValue).ToList();
                if (data1 != null)
                {
                    string[] tempList = data1[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey1.Add(tempList[i]);
                    }
                }
            }
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var Tbl_formationsDetails = dbcont.Tbl_formationsDetails;
                List<Formationmembers> allRecords = new List<Formationmembers>();

                var data = dbcont.Tbl_formationsDetails.Where(x => x.ProvinceName == province && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.Status == "1" && DyKey1.Contains(x.StageOfFormation)).ToList();

                var alldatamem = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == province).ToList();
                List<Formationmembers> alldata = new List<Formationmembers>();

                foreach (var item in data)
                {
                    //var MemberData = alldatamem.FirstOrDefault(x => x.MemberID.ToString() == item.MemberId);
                    alldata.Add(new Formationmembers()
                    {
                        Name = item.Name,

                    });
                }

                return Json(alldata, JsonRequestBehavior.AllowGet);
            }

            else
            {
                var Tbl_formationsDetails = dbcont.Tbl_formationsDetails;
                List<Formationmembers> allRecords = new List<Formationmembers>();

                var data = dbcont.Tbl_formationsDetails.Where(x => x.ProvinceName == province && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.CreatedBy == currentUserid)
               .ToList().Select(x => new { x.MemberId }).ToList();

                var alldatamem = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == province && x.ProvinceName == currentuser).ToList();
                List<Formationmembers> alldata = new List<Formationmembers>();
                foreach (var memberid in data)
                {
                    var check = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                    .Where(x => !DyKey1.Contains(x.StageOfFormation)/* x.StageOfFormation != "11" && x.StageOfFormation != "12"*/).ToList();
                    if (check.Count() == 0)
                    {
                        var data1 = Tbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                        .Select(x => new Formationmembers { Name = x.Name, MemberId = x.MemberId, ProvinceName = x.ProvinceName, Createdby = x.CreatedBy });
                        // allRecords.Add(data1);

                        foreach (var item in data1)
                        {
                            var MemberData = alldatamem.FirstOrDefault(x => x.MemberId.ToString() == item.MemberId);
                            alldata.Add(new Formationmembers()
                            {
                                FileNo = item.FileNo,
                                Name = item.Name,
                                Surname = item.Surname,
                                DOB = MemberData.DOB,
                            });
                        }
                    }
                }
                return Json(alldata, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetForPlace(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<FORMATIONANDCOMMUNITIESViewModel>();
            var allComAddress = dbcont.Tbl_Cong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == province).ToList();

            var allforcomname = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.ProvinceName == province).ToList();
            var allmember = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == province).ToList();
            var allmemberappo = dbcont.Appointments.Where(x => x.ProvinceName == province).ToList();

            foreach (var item in allComAddress)
            {
                var brotherData = (from fd in allforcomname
                                   join pd in allmember on fd.MemberId equals pd.MemberId
                                   join am in allmemberappo on pd.MemberId equals am.MemberId

                                   where am.CommunityType == item.CongregationName
                                   select new BrothersData
                                   {
                                       MemberId = pd.MemberId,
                                       Knowname = pd.Knowname,
                                       SurName = pd.SurName,
                                       mobilenumber = pd.mobilenumber,
                                       emailid = pd.emailid,
                                       DesignationType = am.DesignationType
                                   }).ToList();

                allData.Add(new FORMATIONANDCOMMUNITIESViewModel
                {
                    CommunityName = item.CongregationName ?? string.Empty,
                    CommunityCode = item.CommCode ?? string.Empty,
                    ComAddress = item.Address ?? string.Empty,
                    ComEmailId = item.EmailId ?? string.Empty,
                    ComPhone = item.Phone ?? string.Empty,
                    Place = item.Place ?? string.Empty,
                    BrotherData = brotherData
                });
            }
            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetComOutSideBro(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }

            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<FORMATIONANDCOMMUNITIESViewModel>();
            var prodata = db.tbl_Province.FirstOrDefault(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province);
            var allComAddress = dbcont.ComOutSide.Where(x => x.ActiveCkeck == "Active" && x.OtherProvince == prodata.ProvinceName);

            var allforcomname = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null).ToList();
            var allmember = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == province).ToList();
            var allmemberappo = dbcont.Appointments.Where(x => x.ProvinceName == province).ToList();

            foreach (var item in allComAddress)
            {
                var brotherData = (from fd in allforcomname.Where(x => x.Community == item.CommunityName).ToList()
                                   join pd in db.tbl_Primarydetails on fd.MemberId equals pd.MemberId
                                   join am in allmemberappo on pd.MemberId equals am.MemberId
                                   select new BrothersData
                                   {
                                       MemberId = pd.MemberId,
                                       Knowname = pd.Knowname,
                                       SurName = pd.SurName,
                                       mobilenumber = pd.mobilenumber,
                                       emailid = pd.emailid,
                                       DesignationType = am.DesignationType
                                   }).ToList();

                allData.Add(new FORMATIONANDCOMMUNITIESViewModel
                {
                    CommunityName = item.CommunityName,
                    CommunityCode = item.ComCode,
                    ComAddress = item.Address,
                    ComEmailId = item.EmailId,
                    ComPhone = item.Phone,
                    Place = item.Place,
                    BrotherData = brotherData
                });

            }
            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInstituteCommunity(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<InstituteAndCommunity>();
            var allDiocese = dbcont.tbl_Diocese.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == province).ToList();
            var allDioCommunity = dbcont.tbl_DioceseCom.Where(x => x.ProvinceName == province).ToList();
            var allDioInst = dbcont.tbl_DioceseInst.Where(x => x.ProvinceName == province).ToList();

            foreach (var item in allDiocese)
            {
                var comNames = (from cn in allDiocese.Where(x => x.DioId == item.DioId).ToList()
                                join dc in allDioCommunity on cn.DioId equals dc.DioId
                                select new Community { CommunityName = dc.ComName }).ToList();

                int instcount = (from cn in allDiocese.Where(x => x.DioId == item.DioId).ToList()
                                 join dc in allDioInst on cn.DioId equals dc.DioId
                                 select new { InstCount = dc.InstName }).Count();

                int totalInstCount = 0;
                totalInstCount += instcount;

                int comcount = (from cn in allDiocese.Where(x => x.DioId == item.DioId).ToList()
                                join dc in allDioCommunity on cn.DioId equals dc.DioId
                                select new { CommunityCount = dc.ComName }).Count();

                int totalComCount = 0;
                totalComCount += comcount;

                allData.Add(new InstituteAndCommunity
                {
                    State = item.State,
                    DioceseName = item.DioceseName,
                    Community = comNames,
                    InstCount = instcount,
                    CommunityCount = comcount,
                    TotalInstCount = totalInstCount,
                    TotalCommunityCount = totalComCount,
                });
            }

            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProCommission(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<ProvinceCommission>();
            var prodata = db.tbl_Province.FirstOrDefault(x => x.ActiveCkeck == "Active" && x.Id.ToString() == province);
            var allProcomData = dbcont.tbl_ProCommission.Where(x => x.ProId == prodata.MyId).ToList();

            var afterGroup = allProcomData.GroupBy(x => x.ResponsibilityName).Select(x => x).ToList();

            foreach (var item in afterGroup)
            {

                string key = item.Key;
                List<MemberData> memberdata = new List<MemberData>();
                foreach (var item2 in item.OrderBy(x => x.DesignationName))
                {
                    memberdata.Add(new MemberData
                    {
                        MemberName = item2.MemberName,
                        DesignationName = item2.DesignationName
                    });
                }

                allData.Add(new ProvinceCommission
                {
                    Responsibility = key,
                    MemberData = memberdata
                });
            }
            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTotalCalculation(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic3").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

            List<string> DyKey1 = new List<string>();
            List<string> DyKey2 = new List<string>();
            List<string> DyKey3 = new List<string>();
            List<string> DyKey4 = new List<string>();
            List<string> DyKey5 = new List<string>();
            if (configData != null)
            {
                var data10 = configData.Where(x => x.strConfigKey == "DyKey1").Select(x => x.strConfigValue).ToList();
                if (data10 != null)
                {
                    string[] tempList = data10[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey1.Add(tempList[i]);
                    }
                }
                var data11 = configData.Where(x => x.strConfigKey == "DyKey2").Select(x => x.strConfigValue).ToList();
                if (data11 != null)
                {
                    string[] tempList = data11[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey2.Add(tempList[i]);
                    }
                }
                var data12 = configData.Where(x => x.strConfigKey == "DyKey3").Select(x => x.strConfigValue).ToList();
                if (data12 != null)
                {
                    string[] tempList = data12[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey3.Add(tempList[i]);
                    }
                }
                var data13 = configData.Where(x => x.strConfigKey == "DyKey4").Select(x => x.strConfigValue).ToList();
                if (data13 != null)
                {
                    string[] tempList = data13[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey4.Add(tempList[i]);
                    }
                }
                var data14 = configData.Where(x => x.strConfigKey == "DyKey5").Select(x => x.strConfigValue).ToList();
                if (data14 != null)
                {
                    string[] tempList = data14[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey5.Add(tempList[i]);
                    }
                }
            }
            //TotalPerVows
            //var TotalPerVows = dbcont.Tbl_RenewalVows.Where(x => DyKey4.Contains(x.CurrentStatus) /*x.CurrentStatus == "15"*/ && x.DeathCheck != "Active" && x.SapCheck != "Active" && x.ProvinceName == province).Count();
            var TotalPerVows = dbcont.Tbl_formationsDetails.Where(x => DyKey4.Contains(x.StageOfFormation) /*x.CurrentStatus == "15"*/ && x.Diedcheck != "Active" && x.Sapcheck != "Active" && x.ProvinceName == province && x.Status == "1").Count();
            //TotalTempVows
            var allTbl_RenewalVows = dbcont.Tbl_formationsDetails;
            int TotalTempVows = 0;
            var data = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.ProvinceName == province && x.Status == "1" && DyKey5.Contains(x.StageOfFormation)).ToList();
            foreach (var memberid in data)
            {
                var check = allTbl_RenewalVows.Where(x => x.MemberId == memberid.MemberId)
                    .Where(x => DyKey5.Contains(x.StageOfFormation) /*x.CurrentStatus != "14"*/).ToList();
                //if (check.Count() == 0)
                //{
                //    TotalTempVows += 1;
                //}
                TotalTempVows = TotalTempVows + check.Count();
            }
            //Total no of brothers
            //var TotalNoBrothers = db.tbl_PersonalDetails
            //.Where(x => x.IsDeleted == false && x.Diedcheck == null && x.Sapcheck == null
            //&& x.IsTransfer != "yes" && x.Archivecheck != "yes"&& x.ProvinceName == province)
            //.Select(x => new { x.Name, x.MemberID, x.ProvinceName, x.ProvinceCode }).Distinct().Count();
            //Total2ndNov
            var allTbl_formationsDetails = dbcont.Tbl_formationsDetails;
            int Total2ndNov = 0;
            var data1 = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.ProvinceName == province && x.Status == "1" && DyKey2.Contains(x.StageOfFormation)).ToList();
            foreach (var memberid in data1)
            {
                var check = allTbl_formationsDetails.Where(x => x.MemberId == memberid.MemberId)
                    .Where(x => DyKey2.Contains(x.StageOfFormation)/* x.StageOfFormation != "14"*/).ToList();

                //if (check.Count() == 0)
                //{
                //    Total2ndNov += 1;
                //}
                Total2ndNov = Total2ndNov + check.Count();
            }
            //Total1stNov
            var allTbl_formationsDetails1 = dbcont.Tbl_formationsDetails;
            int Total1stNov = 0;
            var data2 = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.ProvinceName == province && x.Status == "1" && DyKey1.Contains(x.StageOfFormation)).ToList();
            foreach (var memberid in data2)
            {
                var check = allTbl_formationsDetails1.Where(x => x.MemberId == memberid.MemberId)
                    .Where(x => DyKey1.Contains(x.StageOfFormation)/* x.StageOfFormation != "13"*/).ToList();
                //if (check.Count() == 0)
                //{
                //    Total1stNov += 1;
                //}
                Total1stNov = Total1stNov + check.Count();
            }
            //TotalPreNov.
            var allTbl_formationsDetails12 = dbcont.Tbl_formationsDetails;
            int TotalPreNov = 0;
            var data3 = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.ProvinceName == province && x.Status == "1").Distinct().ToList();
            foreach (var memberid in data3)
            {
                var check = allTbl_formationsDetails12.Where(x => x.MemberId == memberid.MemberId)
                    .Where(x => !DyKey3.Contains(x.StageOfFormation)/* x.StageOfFormation != "11" && x.StageOfFormation != "12"*/).ToList();
                if (check.Count() == 0)
                {
                    TotalPreNov += 1;
                }
            }

            List<Formationmembers> alldata = new List<Formationmembers>();
            alldata.Add(new Formationmembers
            {
                TotalPerVows = TotalPerVows,
                TotalTempVows = TotalTempVows,
                TotalNoBrothers = TotalPerVows + TotalTempVows,
                Total2ndNov = Total2ndNov,
                Total1stNov = Total1stNov,
                TotalPreNov = TotalPreNov,
            });

            return Json(alldata.ToList(), JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetAllAgeCalculation123(string province, string fromdate, string todate)
        //{
        //    var currentyear = System.DateTime.Now.Year;
        //    DateTime firstDay = new DateTime();
        //    DateTime lastDay = new DateTime();
        //    if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
        //    {
        //        int year = DateTime.Now.Year;
        //        firstDay = Convert.ToDateTime("01/01/" + year);
        //        lastDay = Convert.ToDateTime("31/12/" + year);
        //    }
        //    else
        //    {
        //        firstDay = Convert.ToDateTime(fromdate);
        //        lastDay = Convert.ToDateTime(todate);
        //    }

        //    string currentUserid = Convert.ToString(Session["loginuserid"]);
        //    string CurrentUser = Convert.ToString(Session["username"]);
        //    List<Agecalculation> alldata = new List<Agecalculation>();
        //    var allPrimaryMan = dbcont.tbl_Primarydetails.Where(x => x.Ordination != null && x.ProvinceName == province).ToList();

        //        foreach (var item in allPrimaryMan)
        //        {
        //            var perYear = item.Ordination.Substring(item.Ordination.Length - 4);
        //            int yearDiff = currentyear - Convert.ToInt32(perYear);
        //            alldata.Add(new Agecalculation
        //            {
        //                OldBrother = item.Knowname,
        //                SurName = item.Baptismialname,
        //                Date = item.Ordination,
        //                Year = yearDiff
        //            });
        //        }
        //        var data = alldata.OrderByDescending(X => X.Year).ToList().FirstOrDefault();
        //        return Json(data, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetProvinceSuperior(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }

            List<Tbl_ProvinceCouncil> alldata = new List<Tbl_ProvinceCouncil>();
            var allProcomData = dbcont.Tbl_ProvinceCouncil.Where(x => x.FromDate == fromdate && x.ToDate == todate && x.ProvinceName == province).ToList();

            foreach (var item in allProcomData)
            {
                alldata.Add(new Tbl_ProvinceCouncil
                {
                    MemberName = item.MemberName,
                    DesignationName = item.DesignationName,
                });
            }
            return Json(alldata.Where(x => x.MemberName != "").ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistSec(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<DistSector>();

            var allDistSec = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == province).ToList();

            foreach (var item in allDistSec)
            {
                var data = db.Tbl_Cong.Where(x => x.ActiveCkeck == "Active" && x.DisSec == item.Id.ToString()).ToList();
                List<CommunityData> comdata = new List<CommunityData>();

                foreach (var item1 in data)
                {

                    comdata.Add(new CommunityData
                    {
                        CommunityName = item1.CongregationName,
                        CommunityCode = item1.CommCode,
                        ComAddress = item1.Address,
                        ComEmailId = item1.EmailId,
                        ComPhone = item1.Phone,
                        Place = item1.Place,
                    });
                }
                allData.Add(new DistSector
                {
                    DistName = item.DistSecName,
                    CommunityData = comdata
                });
            }

            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetForDistSec(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<DistSecCommunityData>();
            var allDistSec = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == province).ToList();

            var allforcomname = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.ProvinceName == province).ToList();
            var allmember = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == province).ToList();
            var allmemberappo = dbcont.Appointments.Where(x => x.ProvinceName == province).ToList();

            foreach (var item in allDistSec)
            {
                var allComAddress = db.Tbl_Cong.Where(x => x.ActiveCkeck == "Active" && x.DisSec == item.Id.ToString()).ToList();
                List<FormationCommunities> forData = new List<FormationCommunities>();
                foreach (var item1 in allComAddress)
                {
                    List<BrothersData1> brotherData = new List<BrothersData1>();
                    brotherData = (from fd in allforcomname.Where(x => x.Community == item1.CongregationName).ToList()
                                   join pd in allmember on fd.MemberId equals pd.MemberId
                                   join am in allmemberappo on pd.MemberId equals am.MemberId
                                   select new BrothersData1
                                   {
                                       MemberId = pd.MemberId,
                                       Knowname = pd.Knowname,
                                       SurName = pd.SurName,
                                       mobilenumber = pd.mobilenumber,
                                       emailid = pd.emailid,
                                       DesignationType = am.DesignationType
                                   }).ToList();

                    forData.Add(new FormationCommunities
                    {
                        CommunityName = item1.CongregationName,
                        CommunityCode = item1.CommCode,
                        ComAddress = item1.Address,
                        ComEmailId = item1.EmailId,
                        ComPhone = item1.Phone,
                        Place = item1.Place,
                        BrotherData1 = brotherData
                    });
                }
                allData.Add(new DistSecCommunityData
                {
                    DistName = item.DistSecName,
                    FormationCommunities = forData
                });
            }
            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistSecComission(string province, string fromdate, string todate)
        {
            DateTime firstDay = new DateTime();
            DateTime lastDay = new DateTime();
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                int year = DateTime.Now.Year;
                firstDay = Convert.ToDateTime("01/01/" + year);
                lastDay = Convert.ToDateTime("31/12/" + year);
            }
            else
            {
                firstDay = Convert.ToDateTime(fromdate);
                lastDay = Convert.ToDateTime(todate);
            }
            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<DistSecCommission>();
            var allData1 = new List<Responsibilities>();

            var allDistSec = dbcont.tbl_DistSector.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == province).ToList();

            foreach (var item in allDistSec)
            {
                var allDistSecCommission = dbcont.tbl_DistSecCommission.Where(x => x.DistSecId == item.Id.ToString()).ToList();
                var afterGroup = allDistSecCommission.GroupBy(x => x.ResponsibilityName).Select(x => x).ToList();
                foreach (var item1 in afterGroup)
                {
                    string key = item1.Key;
                    List<MemberData1> memberdata = new List<MemberData1>();
                    foreach (var item2 in item1.OrderBy(x => x.DesignationName))
                    {
                        memberdata.Add(new MemberData1
                        {
                            MemberName = item2.MemberName,
                            DesignationName = item2.DesignationName
                        });
                    }
                    allData1.Add(new Responsibilities
                    {
                        Responsibility = key,
                        MemberData1 = memberdata
                    });

                }
                allData.Add(new DistSecCommission
                {
                    DistSecName = item.DistSecName,
                    Responsibilities = allData1,
                });
            }

            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }

        private class DistSector
        {
            public string DistName { get; set; }
            public List<CommunityData> CommunityData { get; set; }
        }
        public class CommunityData
        {
            public string Place { get; set; }
            public string CommunityName { get; set; }
            public string CommunityCode { get; set; }
            public string ComAddress { get; set; }
            public string ComEmailId { get; set; }
            public string ComPhone { get; set; }
        }
        public class DistSecCommunityData
        {
            public string DistName { get; set; }
            public List<FormationCommunities> FormationCommunities { get; set; }
        }
        public class FormationCommunities
        {
            public string Place { get; set; }
            public string CommunityName { get; set; }
            public string CommunityCode { get; set; }
            public string ComAddress { get; set; }
            public string ComEmailId { get; set; }
            public string ComPhone { get; set; }
            public List<BrothersData1> BrotherData1 { get; set; }
        }
        public class BrothersData1
        {
            public string MemberId { get; set; }
            public string Knowname { get; set; }
            public string SurName { get; set; }
            public string mobilenumber { get; set; }
            public string emailid { get; set; }
            public string DesignationType { get; set; }
        }
        public class DistSecCommission
        {
            public string DistSecName { get; set; }
            public List<Responsibilities> Responsibilities { get; set; }
        }
        public class Responsibilities
        {
            public string Responsibility { get; set; }
            public List<MemberData1> MemberData1 { get; set; }
        }
        public class MemberData1
        {
            public string AllMemberName { get; set; }
            public string MemberName { get; set; }
            public string DesignationName { get; set; }
        }

        public class PrimaryDataViewModel
        {
            public string Name { get; set; }

            public string SurName { get; set; }

            public string emailid { get; set; }

            public string mobilenumber { get; set; }

            public string Provincename { get; set; }

            public string MemberId { get; set; }
        }

    }
}

