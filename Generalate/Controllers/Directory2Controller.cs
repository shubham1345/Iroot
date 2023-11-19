using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class Directory2Controller : Controller
    {
        private GeneralDBContext db = new GeneralDBContext();
        private GeneralDBContext dbcont = new GeneralDBContext();
        // GET: Directory2
        public ActionResult Directory2()
        {

            ViewBag.Allprovince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active");
            var provincelist = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").OrderBy(x => x.MyId).ToList();
            var totalprovince1 = provincelist.Count();
            var totalcount1 = totalprovince1 / 2;
            var pronamee = provincelist.Skip(0).Take(10).ToList();
            var proname1 = provincelist.Skip(totalcount1).Take(totalcount1).ToList();
            ViewBag.proname = pronamee;
            ViewBag.proname1 = proname1;
            return View();
        }
        public JsonResult ProvinceListswithGen(string fromdate, string todate)
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

                List<Formationmembers> alldata = new List<Formationmembers>();
                List<Formationmembers> alldata1 = new List<Formationmembers>();
            var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();

                var totalprovince = allProvinceName.Count();
            var totalcount = totalprovince / 2;
            var data = allProvinceName.Skip(0).Take(10).ToList();
            var data1 = allProvinceName.Skip(totalcount).Take(totalcount).ToList();


            foreach (var item in data)
            {
                alldata.Add(new Formationmembers
                {
                    Name = item.ProvinceName,
                    ProvinceCode = item.Place
                });
            }
            return Json(alldata, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProvinceListswithGen3(string fromdate,string todate)
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

            List<Formationmembers> alldata = new List<Formationmembers>();
            //List<Formationmembers> alldata1 = new List<Formationmembers>();
            var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();

            var totalprovince = allProvinceName.Count();
            var totalcount = totalprovince / 2;
            var data = allProvinceName.Skip(0).Take(10).ToList();
            var data1 = allProvinceName.Skip(totalcount).Take(totalcount).ToList();


            string html = "";
            html += "<div class='row1'>";
            html += "<div class='column1'>";
            html += "<table>";
            html += "<thead>";
            html += "<tr>";
            html += "<th>" + HomeController.GetControlTextByControlId("Province_Name") +"</th>";
            html += "<th>"+HomeController.GetControlTextByControlId("Code") +"</th>";
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            foreach(var item in data)
            {
                html += "<tr>";
                html += "<td>"+HomeController.GetControlTextByControlId( item.ProvinceName)+"</td>";
                html += "<td>"+HomeController.GetControlTextByControlId( item.Place)+"</td>";
                html += "<tr>";
            }
            html += "</tbody>";
            html += "</table>";
            html += "</div>";
            html += "<div class='column1'>";
            html += "<table>";
            html += "<thead>";
            html += "<tr>";
            html += "<th>" + HomeController.GetControlTextByControlId("Province_Name") + "</th>";
            html += "<th>" + HomeController.GetControlTextByControlId("Code") + "</th>";
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            foreach (var item in data1)
            {
                html += "<tr>";
                html += "<td>" +HomeController.GetControlTextByControlId( item.ProvinceName )+ "</td>";
                html += "<td>" +HomeController.GetControlTextByControlId( item.Place )+ "</td>";
                html += "<tr>";
            }
            html += "</tbody>";
            html += "</table>";
            html += "</div>";
            html += "</div>";



            //foreach (var item in data1)
            //{
            //    alldata.Add(new Formationmembers
            //    {
            //        Name = item.ProvinceName,
            //        ProvinceCode = item.Place
            //    });
            //}

            return Json(html, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProvinceListswithGen2(string fromdate, string todate)
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

            List<Formationmembers> alldata = new List<Formationmembers>();
            var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();

            var totalprovince = allProvinceName.Count();
            var totalcount = totalprovince / 2;
            var data = allProvinceName.Skip(0).Take(10).ToList();
            var data1 = allProvinceName.Skip(totalcount).Take(totalcount).ToList();


            string html = "";
            html += "<div class='row1'>";
            html += "<div class='column1'>";
            html += "<table>";
            html += "<thead>";
            html += "<tr>";
            html += "<th>" + HomeController.GetControlTextByControlId("Province_Name") + "</th>";
            html += "<th>" + HomeController.GetControlTextByControlId("Code") + "</th>";
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            foreach (var item in data)
            {
                html += "<tr>";
                html += "<td>" + item.ProvinceName + "</td>";
                html += "<td>" + item.Place + "</td>";
                html += "<tr>";
            }
            html += "</tbody>";
            html += "</table>";
            html += "</div>";
            html += "<div class='column1'>";
            html += "<table>";
            html += "<thead>";
            html += "<tr>";
            html += "<th>" + HomeController.GetControlTextByControlId("Province_Name") + "</th>";
            html += "<th>" + HomeController.GetControlTextByControlId("Code") + "</th>";
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            foreach (var item in data1)
            {
                html += "<tr>";
                html += "<td>" + item.ProvinceName + "</td>";
                html += "<td>" + item.Place + "</td>";
                html += "<tr>";
            }
            html += "</tbody>";
            html += "</table>";
            html += "</div>";
            html += "</div>";

          
            return Json(html, JsonRequestBehavior.AllowGet);
        }

       

        public JsonResult GeneralateallData(string fromdate, string todate)
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

            var tblsuperiorgeneral = dbcont.GeneralMember.ToList();
            var tblcongregation = dbcont.tbl_Congregation.ToList();
            var tblprimarydetails = dbcont.tbl_Primarydetails.ToList();
            var tbltreaserer = dbcont.GeneralTreasurer.ToList();
            var tblsecretary = dbcont.GeneralSecretary.ToList();
            var tblprovince = dbcont.tbl_Province.FirstOrDefault(x => x.ProvinceName.ToLower() == "Administration Centrale".ToLower() || x.ProvinceName.ToLower() == "CENTRAL ADMINISTRATION");

            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<AllProvinceData>();
            var allgeneraldata = new List<AllProvinceData>();
            ProvinceCouncil Generaltreaserer = new ProvinceCouncil();
            ProvinceCouncil superiorgeneral = new ProvinceCouncil();
            ProvinceCouncil GeneralSecretary = new ProvinceCouncil();
            ProvinceCouncil totalmember = new ProvinceCouncil();

            var allProvince = dbcont.tbl_Congregation.FirstOrDefault(x=> x.FamilyBelongsTo == null);

            var allCouncil = db.MeetingMinutes.Where(x=> x.GenId == allProvince.Id.ToString()).ToList();
                List<ProvinceCouncil> allData1 = new List<ProvinceCouncil>();
                foreach (var items in allCouncil)
                {
                string[] names = items.Name.Split(' ');
                string name = names[0];
                var allmember = dbcont.tbl_Primarydetails.ToList().LastOrDefault(x => x.Knowname == name);

                allData1.Add(new ProvinceCouncil
                    {
                        CouncilMember = items.Name,
                        MemPhone = allmember == null ? string.Empty : allmember.mobilenumber,
                        MemEmail = allmember == null ? string.Empty : allmember.emailid,
                        Designation = items.Designation,
                    });
                }

                //allData.Add(new AllProvinceData
                //{
                //    ProvinceName = allProvince.CongregationName,
                //    Address = allProvince.Address,
                //    Telephone = allProvince.Phone,
                //    EmailId = allProvince.Email,
                //    Fax = allProvince.Fax,
                //    website = allProvince.Website,
                //    ProvinceCouncils = allData1
                //});

            //superior General
            //var generalsuperior = tblsuperiorgeneral.FirstOrDefault(x => x.GenId == allProvince.Id.ToString());
            var generalsuperior = tblsuperiorgeneral.FirstOrDefault(x => x.GenId == allProvince.Id.ToString() && x.Status == "0");
            string[] spnames = generalsuperior.Name.Split(' ');
            string sprname = spnames[0];
            var memberdetails = tblprimarydetails.FirstOrDefault(x => x.Knowname == sprname);

            superiorgeneral.CouncilMember = generalsuperior.Name;
            superiorgeneral.MemPhone = memberdetails == null ? string.Empty : memberdetails.mobilenumber;
            superiorgeneral.MemEmail = memberdetails == null ? string.Empty : memberdetails.emailid;
            superiorgeneral.Designation = generalsuperior.Designation;

            //treaserer
            var generaltreaserer = tbltreaserer.FirstOrDefault(x => x.GenId == allProvince.Id.ToString());
            if(generaltreaserer != null)
            {
                string[] trname = generaltreaserer.Name.Split(' ');
                string trename = trname[0];
                var treaserermember = tblprimarydetails.FirstOrDefault(x => x.Knowname == trename);
                Generaltreaserer.CouncilMember = generaltreaserer.Name;
                Generaltreaserer.MemPhone = treaserermember == null ? string.Empty : treaserermember.mobilenumber;
                Generaltreaserer.MemEmail = treaserermember == null ? string.Empty : treaserermember.emailid;
                Generaltreaserer.Designation = generaltreaserer.Designation;
            }

            //Secretary
            var generalsecretary = tblsecretary.FirstOrDefault(x => x.GenId == allProvince.Id.ToString());
            if(generalsecretary != null)
            {
                string[] sename = generalsecretary.Name.Split(' ');
                string srname = sename[0];
                var secretarymember = tblprimarydetails.FirstOrDefault(x => x.Knowname == srname);
                GeneralSecretary.CouncilMember = generalsecretary.Name;
                GeneralSecretary.MemEmail = secretarymember == null ? string.Empty : secretarymember.mobilenumber;
                GeneralSecretary.MemEmail = secretarymember == null ? string.Empty : secretarymember.emailid;
                GeneralSecretary.Designation = generalsecretary.Designation;
            }



            allgeneraldata.Add(new AllProvinceData
            {
                superiorgeneral = superiorgeneral,
                Generaltreaserer = Generaltreaserer,
                GeneralSecretary = GeneralSecretary,
                Generalcouncil = allData1,
                ProvinceName = tblprovince.ProvinceName,
                Provincecode = tblprovince.Place,
                Congregation = allProvince.CongregationName,
                Congregation_id = allProvince.CongreId,
                Congregation_Country = allProvince.Country,
                Address = allProvince.Address,
                Telephone = allProvince.Phone,
                EmailId = allProvince.Email,
                Fax =allProvince.Fax,
                website = allProvince.Website,

            });



            return Json(allgeneraldata.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetallProvinceData(string fromdate, string todate)
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
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic4").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

            List<string> DyKey1 = new List<string>();
            List<string> DyKey2 = new List<string>();
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
                if (data1 != null)
                {
                    string[] tempList = data2[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey2.Add(tempList[i]);
                    }
                }
            }

            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<AllProvinceData>();
            var allProvince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").OrderBy(x =>x.MyId).ToList();
            var tblformationdetails = dbcont.Tbl_formationsDetails.ToList();
            var tblprimarydetails = dbcont.tbl_Primarydetails.ToList();
            var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
            var tblappointments = dbcont.Appointments.ToList();
            var tblcong = dbcont.Tbl_Cong.ToList();
            var provincesuperior = dbcont.Tbl_ProGeneralMember.ToList();
            var counsilprovince = dbcont.Tbl_ProGeneralCouncil.ToList();
            var treaserer = dbcont.Tbl_ProGeneralTreaserer.ToList();
            var secretary = dbcont.Tbl_ProGeneralSecretary.ToList();
            var tblcongdetails = dbcont.Tbl_Cong.ToList();
            

            foreach (var item in allProvince)
            {
                var allCouncil = db.Tbl_ProvinceCouncil.Where(x => x.ProvinceName == item.Id.ToString()).ToList();
                
                List<ProvinceCouncil> allData1 = new List<ProvinceCouncil>();
                foreach (var items in allCouncil)
                {
                    allData1.Add(new ProvinceCouncil
                    {
                        CouncilMember = items.MemberName,
                        Designation = items.DesignationName,
                    });
                }
                //Province Superior
                var provincialsuperior = provincesuperior.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                List<ProvinceCouncil> prosuperior = new List<ProvinceCouncil>();
                foreach(var sup in provincialsuperior)
                {
                    prosuperior.Add(new ProvinceCouncil
                    {
                        CouncilMember = sup.Name,
                        Designation = sup.Designation
                    });
                }

                //Councile Province
                var provincecouncil = counsilprovince.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                List<ProvinceCouncil> procouncil = new List<ProvinceCouncil>();
                foreach(var cou in provincecouncil)
                {
                    procouncil.Add(new ProvinceCouncil
                    {
                        CouncilMember = cou.Name,
                        Designation = cou.Designation
                    });
                }

                //treaserer
                var treasererdetails = treaserer.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                List<ProvinceCouncil> protreaser = new List<ProvinceCouncil>();
                foreach(var tre in treasererdetails)
                {
                    protreaser.Add(new ProvinceCouncil
                    {
                        CouncilMember = tre.Name,
                        Designation = tre.Designation
                    });
                }

                //secretary
                var secretarydetails = secretary.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                List<ProvinceCouncil> prosecretary = new List<ProvinceCouncil>();
                foreach(var sec in secretarydetails)
                {
                    prosecretary.Add(new ProvinceCouncil
                    {
                        CouncilMember = sec.Name,
                        Designation = sec.Designation
                    });
                }

               // var allforcomname = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.ProvinceName == item.Id.ToString()).ToList();
                var allmember = tblprimarydetails.Where(x => x.ProvinceName == item.Id.ToString()).ToList();
                List<Appointments> allappodata = new List<Appointments>();
                foreach(var appo in tblappointments)
                {
                    if(appo.ProvinceName != null)
                    {
                        var proname = appo.ProvinceName.Split('|');
                        allappodata.Add(new Appointments
                        {
                            Id = appo.Id,
                            CommunityType = appo.CommunityType,
                            Status = appo.Status,
                            ProvinceName = proname[0],
                            MemberId = appo.MemberId,
                            Name = appo.Name,
                            DesignationType = appo.DesignationType
                        });
                    }
                   
                }
                //outsideprovince
                var outsideprovince = allappodata.Where(x => x.AppointmentType == "OSPro" && x.Status == "Active" && x.ProvinceName == item.Id.ToString()).ToList();

                var allmemberappo = allappodata.Where(x => x.ProvinceName == item.Id.ToString() && x.Status == "Active").ToList();
                //var allComAddress = tblcong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == item.Id.ToString()).OrderBy(x => x.Country).ToList();
                var allComAddress = tblcong.Where(x => x.Status == 1 && x.ProvinceName == item.Id.ToString()).ToList();
                List<CommunityDetails> ComData = new List<CommunityDetails>();
                foreach (var item1 in allComAddress)
                {
                    //    List<AppointmentsMember> brotherData1 = new List<AppointmentsMember>();
                    //var communitydata = allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList();
                    //if(communitydata.Count > 0)
                    //{
                    //    foreach (var com in communitydata)
                    //    {
                    //        var personeldata = allmember.FirstOrDefault(x => x.MemberId == com.MemberId);
                    //        if (personeldata != null)
                    //        {
                    //            brotherData1.Add(new AppointmentsMember
                    //            {
                    //                MemberName = personeldata.Knowname,
                    //                SurName = personeldata.SurName,
                    //                Designation = com.Description,
                    //                MemPhone = personeldata.mobilenumber,
                    //                MemEmail = personeldata.emailid
                    //            });
                    //        }

                    //    }
                    //}
                   

                    List<AppointmentsMember> brotherData = new List<AppointmentsMember>();
                    brotherData = (from fd in allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList()
                                   join pd in allmember on fd.MemberId equals pd.MemberId
                                   select new AppointmentsMember
                                   {
                                       MemberName = pd.Knowname,
                                       SurName = pd.SurName,
                                       Designation = fd.DesignationType,
                                       MemPhone = pd.mobilenumber,
                                       MemEmail = pd.emailid,
                                   }).ToList();

                    
                    var totalprovince = brotherData.Count();
                    List<AppointmentsMember> data = new List<AppointmentsMember>();
                    List<AppointmentsMember> data1 = new List<AppointmentsMember>();
                    if(totalprovince > 10)
                    {
                        var totalcount = totalprovince / 2;
                         data = brotherData.Skip(0).Take(10).ToList();
                         data1 = brotherData.Skip(totalcount).Take(totalcount).ToList();
                    }
                    else
                    {
                        data = brotherData.ToList();
                    }
                    

                    ComData.Add(new CommunityDetails
                    {
                        CommunityName = item1.CongregationName,
                        CommunityCode = item1.CommCode,
                        CommunityPlace = item1.Place,
                        CommunityAddress = item1.Address,
                        CommunityPhone = item1.Phone,
                        CommunityEmailId = item1.EmailId,
                        AppointmentsMember = data,
                        Appointment = data1,
                        CommunityCountry = item1.Country
                    });
                }

                var allmembersinpro = tblpersoneldetails.Where(x => x.ProvinceName == item.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes").ToList();
                List<AllMembers> allbrotherData = new List<AllMembers>();
                foreach (var members in allmembersinpro)
                {
                    Tbl_Cong congs = new Tbl_Cong();

                    if (members.ProvinceName != null)
                    {
                        var allmembers = tblprimarydetails.LastOrDefault(x => x.MemberId == members.MemberID && x.ProvinceName == item.Id.ToString());
                        //var data = tblformationdetails.Where(x => x.MemberId == members.MemberID).ToList();
                        //var finalvowdata = data.FirstOrDefault(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == null &&  x.Archivecheck == null);
                        var finalvow = dbcont.Tbl_formationsDetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == item.Id.ToString() && x.Diedcheck == null  && x.Archivecheck == null).FirstOrDefault();
                        var Firstvows = dbcont.Tbl_formationsDetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == item.Id.ToString() && x.Diedcheck == null  && x.Archivecheck == null).FirstOrDefault();
                        var communitucode = tblappointments.FirstOrDefault(x => x.MemberId == members.MemberID && x.Status == "Active");
                        if(communitucode != null)
                        {
                            congs = tblcongdetails.FirstOrDefault(x => x.CongregationName == communitucode.CommunityType);
                        }

                        allbrotherData.Add(new AllMembers
                        {
                            ProMemberName = members.Name,
                            ProSurName = members.SirName,
                            DateOfBirth = allmembers==null?string.Empty:allmembers.DOB,
                            ProCountry = allmembers ==null ?string.Empty:allmembers.country,
                            ProFirstVows = Firstvows == null?string.Empty: Firstvows.VowsDate,
                            ProFinalVows = finalvow == null?string.Empty: finalvow.VowsDate,
                            ProMemCode = congs == null?string.Empty:congs.CommCode
                        });
                    }
                }

                var allProCommission = dbcont.tbl_ProCommission.Where(x => x.ProId == item.MyId).ToList();
                var afterGroup = allProCommission.GroupBy(x => x.ResponsibilityName).Select(x => x).ToList();
                var Responsibility = new List<Responsibility>();
                foreach (var item1 in afterGroup)
                    {
                        string key = item1.Key;
                        List<ProvinceComission> memberdata = new List<ProvinceComission>();
                        foreach (var item2 in item1.OrderBy(x => x.DesignationName))
                        {
                        string[] names = item2.MemberName.Split(' ');
                        string name = names[0];
                        var allmember1 = tblprimarydetails.LastOrDefault(x => x.Knowname.Contains(name));

                        memberdata.Add(new ProvinceComission
                            {
                                ComisMemName = item2.MemberName,
                                ComisDesignation = item2.DesignationName,
                                ComisAddress = allmember1 == null? "" : allmember1.city,
                                ComisPlace = allmember1 == null ? "" : allmember1.district,
                                Comisstate = allmember1 == null ? "" : allmember1.state,
                                ComisPin = allmember1 == null ? "" : allmember1.pin,
                                ComisCountry = allmember1 == null ? "" : allmember1.country,
                                ComisEmail = allmember1 == null ? "" : allmember1.emailid,
                                ComisTelephone = allmember1 == null ? "" : allmember1.mobilenumber,
                            });
                        }
                        Responsibility.Add(new Responsibility
                        {
                            ResponsibilityName = key,
                            ProvinceComission = memberdata
                        });
                    }

                List<AppointmentsMember> osprovince = new List<AppointmentsMember>();
                List<AppointmentsMember> outdata1 = new List<AppointmentsMember>();
                List<Appointments> osprovince1 = new List<Appointments>();
                List<Appointments> osprovince2 = new List<Appointments>();

                var totalcounts = outsideprovince.Count() / 2;
                osprovince1 = outsideprovince.Skip(0).Take(totalcounts).ToList();
                osprovince2 = outsideprovince.Skip(totalcounts).Take(totalcounts).ToList();
                foreach (var ospro in osprovince1)
                {
                    var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                    //if(primarydata != null)
                    {
                        osprovince.Add(new AppointmentsMember
                        {
                            MemberName = ospro.Name,
                            SurName = primarydata == null ? string.Empty : primarydata.SurName
                        });
                    }

                }
                foreach (var ospro in osprovince2)
                {
                    var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                    //if(primarydata != null)
                    {
                        outdata1.Add(new AppointmentsMember
                        {
                            MemberName = ospro.Name,
                            SurName = primarydata == null ? string.Empty : primarydata.SurName
                        });
                    }

                }

                allData.Add(new AllProvinceData
                {
                    ProvinceName = item.ProvinceName,
                    Provincecode = item.Place,
                    Address = item == null ? " " : item.Place1,
                    Telephone = item == null ? " " : item.Phone,
                    EmailId = item == null ? " " : item.EmailId,
                    Fax = item == null ? " " : item.Fax,
                    ProvinceSuperior = prosuperior,
                    ProvinceCouncilor = procouncil,
                    ProvinceCouncils = allData1,
                    Treaserer = protreaser,
                    Secretary = prosecretary,
                    CommunityDetails = ComData,
                    AllMembers = allbrotherData,
                    Responsibility = Responsibility,
                    provsuperiorcnt = prosuperior.Count(),
                    procouncilcnt = procouncil.Count(),
                    protreasecnt = protreaser.Count(),
                    proseccnt = prosecretary.Count(),
                    Outsideprovince = osprovince,
                    Outsideprovince1 = outdata1,
                    ospcount = osprovince.Count()
                });
            }
            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetallGenCouncilData(string fromdate, string todate)
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

            var allData = new List<AllGeneralatedata>();
            var FGeneralateName = dbcont.tbl_Congregation.Where(x => x.FamilyBelongsTo == "Yes").ToList();

            foreach (var item in FGeneralateName)
            {
                var allProCommission = dbcont.MeetingMinutes.Where(x => x.GenId == item.Id.ToString()).ToList();
                var afterGroup = allProCommission.GroupBy(x => x.Designation).Select(x => x).ToList();
                var GenDesignation = new List<GenDesignation>();
                foreach (var item1 in afterGroup)
                {
                    string key = item1.Key;
                    List<GenCouncil> memberdata = new List<GenCouncil>();
                    foreach (var item2 in item1.OrderBy(x => x.Designation))
                    {
                        memberdata.Add(new GenCouncil
                        {
                            ComisMemName = item2 == null ? " " : item2.Name,
                        });
                    }
                    GenDesignation.Add(new GenDesignation
                    {
                        Designation = key,
                        GenCouncil = memberdata
                    });
                }

                allData.Add(new AllGeneralatedata
                {
                    FGeneralateName = item == null ? " " : item.CongregationName,
                    Telephone = item == null ? " " : item.Phone,
                    EmailId = item == null ? " " : item.Email,
                    Fax = item == null ? " " : item.Fax,
                    Address = item == null ? " " : item.Address,
                    Country = item == null ? " " : item.Country,
                    GenDesignation = GenDesignation,
                   // AllGeneralatedata1 = allData1
                });
            }
            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetallGenCouncilData1(string fromdate, string todate)
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
            var allData1 = new List<AllGeneralatedata1>();
            var GeneralateName = dbcont.tbl_Congregation.FirstOrDefault(x => x.FamilyBelongsTo == null);
            allData1.Add(new AllGeneralatedata1
            {
                GeneralateName = GeneralateName == null ? string.Empty : GeneralateName.CongregationName,
                Telephone = GeneralateName == null ? string.Empty : GeneralateName.Phone,
                EmailId = GeneralateName == null ? string.Empty : GeneralateName.Email,
                Fax = GeneralateName == null ? string.Empty : GeneralateName.Fax,
                Country = GeneralateName == null ? " " : GeneralateName.Country,
                Address = GeneralateName == null ? string.Empty : GeneralateName.Address
            });

            return Json(allData1.ToList(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetProvinceData(string fromdate,string todate,string provinceid)
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

            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic4").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

            List<string> DyKey1 = new List<string>();
            List<string> DyKey2 = new List<string>();
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
                if (data1 != null)
                {
                    string[] tempList = data2[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey2.Add(tempList[i]);
                    }
                }
            }

            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<AllProvinceData>();
            var tblformationdetails = dbcont.Tbl_formationsDetails.ToList();
            var tblprimarydetails = dbcont.tbl_Primarydetails.ToList();
            var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
            var tblappointments = dbcont.Appointments.ToList();
            var tblcong = dbcont.Tbl_Cong.ToList();
            var provincesuperior = dbcont.Tbl_ProGeneralMember.ToList();
            var counsilprovince = dbcont.Tbl_ProGeneralCouncil.ToList();
            var treaserer = dbcont.Tbl_ProGeneralTreaserer.ToList();
            var secretary = dbcont.Tbl_ProGeneralSecretary.ToList();
            var tblcongdetails = dbcont.Tbl_Cong.ToList();

            var chcarstoremove = new string[] { "[","]","\""};

            var tblprovince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
            string[] provincename = provinceid.Split(',');

            for (int i = 0; i < provincename.Count(); i++)
            {
                int count = 0;
                var prname = provincename[i];
                foreach(var c in chcarstoremove)
                {
                    prname = prname.Replace(c, string.Empty);
                }
                
                var provincedata = tblprovince.FirstOrDefault(x => x.Id.ToString() == prname);
                if (provincedata != null)
                {

                    //Province Superior
                    var provincialsuperior = provincesuperior.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> prosuperior = new List<ProvinceCouncil>();
                    foreach (var sup in provincialsuperior)
                    {
                        count = count + 1;
                        prosuperior.Add(new ProvinceCouncil
                        {
                            CouncilMember = sup.Name,
                            Designation = sup.Designation,
                            count = count 
                        });
                    }

                    //Councile Province
                    var provincecouncil = counsilprovince.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> procouncil = new List<ProvinceCouncil>();
                    foreach (var cou in provincecouncil)
                    {
                        procouncil.Add(new ProvinceCouncil
                        {
                            CouncilMember = cou.Name,
                            Designation = cou.Designation
                        });
                    }

                    //treaserer
                    var treasererdetails = treaserer.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> protreaser = new List<ProvinceCouncil>();
                    foreach (var tre in treasererdetails)
                    {
                        protreaser.Add(new ProvinceCouncil
                        {
                            CouncilMember = tre.Name,
                            Designation = tre.Designation
                        });
                    }

                    //secretary
                    var secretarydetails = secretary.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> prosecretary = new List<ProvinceCouncil>();
                    foreach (var sec in secretarydetails)
                    {
                        prosecretary.Add(new ProvinceCouncil
                        {
                            CouncilMember = sec.Name,
                            Designation = sec.Designation
                        });
                    }

                    //community details
                    var allmember = tblprimarydetails.Where(x => x.ProvinceName == provincedata.Id.ToString()).ToList();
                    List<Appointments> allappodata = new List<Appointments>();
                    foreach (var appo in tblappointments)
                    {
                        if (appo.ProvinceName != null)
                        {
                            var proname = appo.ProvinceName.Split('|');
                            allappodata.Add(new Appointments
                            {
                                Id = appo.Id,
                                CommunityType = appo.CommunityType,
                                Status = appo.Status,
                                ProvinceName = proname[0],
                                MemberId = appo.MemberId,
                                Name = appo.Name,
                                DesignationType = appo.DesignationType,
                                AppointmentType = appo.AppointmentType
                            });
                        }

                    }
                    //outsideprovince
                    var outsideprovince = allappodata.Where(x => x.AppointmentType == "OSPro" && x.Status == "Active" && x.ProvinceName == provincedata.Id.ToString()).ToList();
                    var allmemberappo = allappodata.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Status == "Active").ToList();
                    //var allComAddress = tblcong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == item.Id.ToString()).OrderBy(x => x.Country).ToList();
                    var allComAddress = tblcong.Where(x => x.Status == 1 && x.ProvinceName == provincedata.Id.ToString()).OrderBy(x => x.CommCode).ToList();
                    List<CommunityDetails> ComData = new List<CommunityDetails>();
                    foreach (var item1 in allComAddress)
                    {
                        List<AppointmentsMember> brotherData = new List<AppointmentsMember>();
                        brotherData = (from fd in allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList()
                                       join pd in allmember on fd.MemberId equals pd.MemberId
                                       select new AppointmentsMember
                                       {
                                           MemberName = pd.Knowname,
                                           SurName = pd.SurName,
                                           Designation = fd.DesignationType,
                                           MemPhone = pd.mobilenumber,
                                           MemEmail = pd.emailid,
                                       }).ToList();

                        var totalprovince = brotherData.Count();
                        List<AppointmentsMember> data = new List<AppointmentsMember>();
                        List<AppointmentsMember> data1 = new List<AppointmentsMember>();
                        if (totalprovince > 10)
                        {
                            var totalcount = totalprovince / 2;
                             data = brotherData.Skip(0).Take(10).ToList();
                             data1 = brotherData.Skip(totalcount).Take(totalcount).ToList();
                        }
                        else
                        {
                            data = brotherData.ToList();
                        }
                       

                        ComData.Add(new CommunityDetails
                        {
                            CommunityName = item1.CongregationName,
                            CommunityCode = item1.CommCode,
                            CommunityPlace = item1.Place,
                            CommunityAddress = item1.Address,
                            CommunityPhone = item1.Phone,
                            CommunityEmailId = item1.EmailId,
                            AppointmentsMember = data,
                            Appointment = data1,
                            CommunityCountry = item1.Country
                        });
                    }

                    //active members
                    var allmembersinpro = tblpersoneldetails.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes").ToList();
                    List<AllMembers> allbrotherData = new List<AllMembers>();
                    foreach (var members in allmembersinpro)
                    {
                        Tbl_Cong congs = new Tbl_Cong();

                        if (members.ProvinceName != null)
                        {
                            var allmembers = tblprimarydetails.LastOrDefault(x => x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString());
                            //var data = tblformationdetails.Where(x => x.MemberId == members.MemberID).ToList();
                            //var finalvowdata = data.FirstOrDefault(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == null &&  x.Archivecheck == null);
                            var finalvow = tblformationdetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                            var Firstvows = tblformationdetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                            var communitucode = tblappointments.FirstOrDefault(x => x.MemberId == members.MemberID && x.Status == "Active");
                            if (communitucode != null)
                            {
                                congs = tblcongdetails.FirstOrDefault(x => x.CongregationName == communitucode.CommunityType);
                            }

                            allbrotherData.Add(new AllMembers
                            {
                                ProMemberName = members.Name,
                                ProSurName = members.SirName,
                                DateOfBirth = allmembers == null ? string.Empty : allmembers.DOB,
                                ProCountry = allmembers == null ? string.Empty : allmembers.country,
                                ProFirstVows = Firstvows == null ? string.Empty : Firstvows.VowsDate,
                                ProFinalVows = finalvow == null ? string.Empty : finalvow.VowsDate,
                                ProMemCode = congs == null ? string.Empty : congs.CommCode
                            });
                        }
                    }
                    //outsideprovince
                    List<AppointmentsMember> osprovince = new List<AppointmentsMember>();
                    List<AppointmentsMember> outdata1 = new List<AppointmentsMember>();
                    List<Appointments> osprovince1 = new List<Appointments>();
                    List<Appointments> osprovince2 = new List<Appointments>();

                    var totalcounts = outsideprovince.Count() / 2;
                    osprovince1 = outsideprovince.Skip(0).Take(totalcounts).ToList();
                    osprovince2 = outsideprovince.Skip(totalcounts).Take(totalcounts).ToList();
                    foreach (var ospro in osprovince1)
                    {
                        var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                        //if(primarydata != null)
                        {
                            osprovince.Add(new AppointmentsMember
                            {
                                MemberName = ospro.Name,
                                SurName = primarydata == null ? string.Empty : primarydata.SurName
                            });
                        }
                       
                    }
                    foreach (var ospro in osprovince2)
                    {
                        var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                        //if(primarydata != null)
                        {
                            outdata1.Add(new AppointmentsMember
                            {
                                MemberName = ospro.Name,
                                SurName = primarydata == null ? string.Empty : primarydata.SurName
                            });
                        }

                    }

                    allData.Add(new AllProvinceData
                    {
                        ProvinceName = provincedata.ProvinceName,
                        Provincecode = provincedata.Place,
                        Address = provincedata == null ? " " : provincedata.Place1,
                        Telephone = provincedata == null ? " " : provincedata.Phone,
                        EmailId = provincedata == null ? " " : provincedata.EmailId,
                        Fax = provincedata == null ? " " : provincedata.Fax,
                        ProvinceSuperior = prosuperior,
                        ProvinceCouncilor = procouncil,
                        Treaserer = protreaser,
                        Secretary = prosecretary,
                        CommunityDetails = ComData,
                        AllMembers = allbrotherData,
                        provsuperiorcnt = prosuperior.Count(),
                        procouncilcnt = procouncil.Count(),
                        protreasecnt = protreaser.Count(),
                        proseccnt = prosecretary.Count(),
                        Outsideprovince = osprovince,
                        Outsideprovince1 = outdata1,
                        ospcount = osprovince.Count()
                    });

                }
            }


            return Json(allData.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PrintprovinceData(string provinceid)
        {
            try
            {
                var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic4").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

                List<string> DyKey1 = new List<string>();
                List<string> DyKey2 = new List<string>();
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
                    if (data1 != null)
                    {
                        string[] tempList = data2[0].Split(',');
                        for (int i = 0; i < tempList.Count(); i++)
                        {
                            DyKey2.Add(tempList[i]);
                        }
                    }
                }

                string currentloginid = Convert.ToString(Session["loginuserid"]);
                var allData = new List<AllProvinceData>();
                var tblformationdetails = dbcont.Tbl_formationsDetails.ToList();
                var tblprimarydetails = dbcont.tbl_Primarydetails.ToList();
                var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
                var tblappointments = dbcont.Appointments.ToList();
                var tblcong = dbcont.Tbl_Cong.ToList();
                var provincesuperior = dbcont.Tbl_ProGeneralMember.ToList();
                var counsilprovince = dbcont.Tbl_ProGeneralCouncil.ToList();
                var treaserer = dbcont.Tbl_ProGeneralTreaserer.ToList();
                var secretary = dbcont.Tbl_ProGeneralSecretary.ToList();
                var tblcongdetails = dbcont.Tbl_Cong.ToList();

                var chcarstoremove = new string[] { "[", "]", "\"" };

                var tblprovince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
                string[] provincename = provinceid.Split(',');

                for (int i = 0; i < provincename.Count(); i++)
                {
                    int count = 0;
                    var prname = provincename[i];
                    foreach (var c in chcarstoremove)
                    {
                        prname = prname.Replace(c, string.Empty);
                    }

                    var provincedata = tblprovince.FirstOrDefault(x => x.MyId == prname);
                    if (provincedata != null)
                    {

                        //Province Superior
                        var provincialsuperior = provincesuperior.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> prosuperior = new List<ProvinceCouncil>();
                        foreach (var sup in provincialsuperior)
                        {
                            count = count + 1;
                            prosuperior.Add(new ProvinceCouncil
                            {
                                CouncilMember = sup.Name,
                                Designation = sup.Designation,
                                count = count
                            });
                        }

                        //Councile Province
                        var provincecouncil = counsilprovince.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> procouncil = new List<ProvinceCouncil>();
                        foreach (var cou in provincecouncil)
                        {
                            procouncil.Add(new ProvinceCouncil
                            {
                                CouncilMember = cou.Name,
                                Designation = cou.Designation
                            });
                        }

                        //treaserer
                        var treasererdetails = treaserer.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> protreaser = new List<ProvinceCouncil>();
                        foreach (var tre in treasererdetails)
                        {
                            protreaser.Add(new ProvinceCouncil
                            {
                                CouncilMember = tre.Name,
                                Designation = tre.Designation
                            });
                        }

                        //secretary
                        var secretarydetails = secretary.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> prosecretary = new List<ProvinceCouncil>();
                        foreach (var sec in secretarydetails)
                        {
                            prosecretary.Add(new ProvinceCouncil
                            {
                                CouncilMember = sec.Name,
                                Designation = sec.Designation
                            });
                        }

                        //community details
                        var allmember = tblprimarydetails.Where(x => x.ProvinceName == provincedata.Id.ToString()).ToList();
                        List<Appointments> allappodata = new List<Appointments>();
                        foreach (var appo in tblappointments)
                        {
                            if (appo.ProvinceName != null)
                            {
                                var proname = appo.ProvinceName.Split('|');
                                allappodata.Add(new Appointments
                                {
                                    Id = appo.Id,
                                    CommunityType = appo.CommunityType,
                                    Status = appo.Status,
                                    ProvinceName = proname[0],
                                    MemberId = appo.MemberId,
                                    Name = appo.Name,
                                    DesignationType = appo.DesignationType,
                                    AppointmentType = appo.AppointmentType
                                });
                            }

                        }
                        //outsideprovince
                        var outsideprovince = allappodata.Where(x => x.AppointmentType == "OSPro" && x.Status == "Active" && x.ProvinceName == provincedata.Id.ToString()).ToList();
                        var allmemberappo = allappodata.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Status == "Active").ToList();
                        //var allComAddress = tblcong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == item.Id.ToString()).OrderBy(x => x.Country).ToList();
                        var allComAddress = tblcong.Where(x => x.Status == 1 && x.ProvinceName == provincedata.Id.ToString()).OrderBy(x => x.CommCode).ToList();
                        List<CommunityDetails> ComData = new List<CommunityDetails>();
                        foreach (var item1 in allComAddress)
                        {
                            List<AppointmentsMember> brotherData = new List<AppointmentsMember>();
                            brotherData = (from fd in allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList()
                                           join pd in allmember on fd.MemberId equals pd.MemberId
                                           select new AppointmentsMember
                                           {
                                               MemberName = pd.Knowname,
                                               SurName = pd.SurName,
                                               Designation = fd.DesignationType,
                                               MemPhone = pd.mobilenumber,
                                               MemEmail = pd.emailid,
                                           }).ToList();

                            var totalprovince = brotherData.Count();
                            List<AppointmentsMember> data = new List<AppointmentsMember>();
                            List<AppointmentsMember> data1 = new List<AppointmentsMember>();
                            if (totalprovince > 10)
                            {
                                var totalcount = totalprovince / 2;
                                data = brotherData.Skip(0).Take(10).ToList();
                                data1 = brotherData.Skip(totalcount).Take(totalcount).ToList();
                            }
                            else
                            {
                                data = brotherData.ToList();
                            }


                            ComData.Add(new CommunityDetails
                            {
                                CommunityName = item1.CongregationName,
                                CommunityCode = item1.CommCode,
                                CommunityPlace = item1.Place,
                                CommunityAddress = item1.Address,
                                CommunityPhone = item1.Phone,
                                CommunityEmailId = item1.EmailId,
                                AppointmentsMember = data,
                                Appointment = data1,
                                CommunityCountry = item1.Country
                            });
                        }

                        //active members
                        var allmembersinpro = tblpersoneldetails.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes").ToList();
                        List<AllMembers> allbrotherData = new List<AllMembers>();
                        foreach (var members in allmembersinpro)
                        {
                            Tbl_Cong congs = new Tbl_Cong();

                            if (members.ProvinceName != null)
                            {
                                var allmembers = tblprimarydetails.LastOrDefault(x => x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString());
                                //var data = tblformationdetails.Where(x => x.MemberId == members.MemberID).ToList();
                                //var finalvowdata = data.FirstOrDefault(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == null &&  x.Archivecheck == null);
                                var finalvow = tblformationdetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                var Firstvows = tblformationdetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                var communitucode = tblappointments.FirstOrDefault(x => x.MemberId == members.MemberID && x.Status == "Active");
                                if (communitucode != null)
                                {
                                    congs = tblcongdetails.FirstOrDefault(x => x.CongregationName == communitucode.CommunityType);
                                }

                                allbrotherData.Add(new AllMembers
                                {
                                    ProMemberName = members.Name,
                                    ProSurName = members.SirName,
                                    DateOfBirth = allmembers == null ? string.Empty : allmembers.DOB,
                                    ProCountry = allmembers == null ? string.Empty : allmembers.country,
                                    ProFirstVows = Firstvows == null ? string.Empty : Firstvows.VowsDate,
                                    ProFinalVows = finalvow == null ? string.Empty : finalvow.VowsDate,
                                    ProMemCode = congs == null ? string.Empty : congs.CommCode
                                });
                            }
                        }
                        //outsideprovince
                        List<AppointmentsMember> osprovince = new List<AppointmentsMember>();
                        List<AppointmentsMember> outdata1 = new List<AppointmentsMember>();
                        List<Appointments> osprovince1 = new List<Appointments>();
                        List<Appointments> osprovince2 = new List<Appointments>();

                        var totalcounts = outsideprovince.Count() / 2;
                        osprovince1 = outsideprovince.Skip(0).Take(totalcounts).ToList();
                        osprovince2 = outsideprovince.Skip(totalcounts).Take(totalcounts).ToList();
                        foreach (var ospro in osprovince1)
                        {
                            var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                            //if(primarydata != null)
                            {
                                osprovince.Add(new AppointmentsMember
                                {
                                    MemberName = ospro.Name,
                                    SurName = primarydata == null ? string.Empty : primarydata.SurName
                                });
                            }

                        }
                        foreach (var ospro in osprovince2)
                        {
                            var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                            //if(primarydata != null)
                            {
                                outdata1.Add(new AppointmentsMember
                                {
                                    MemberName = ospro.Name,
                                    SurName = primarydata == null ? string.Empty : primarydata.SurName
                                });
                            }

                        }

                        allData.Add(new AllProvinceData
                        {
                            ProvinceName = provincedata.ProvinceName,
                            Provincecode = provincedata.Place,
                            Address = provincedata == null ? " " : provincedata.Place1,
                            Telephone = provincedata == null ? " " : provincedata.Phone,
                            EmailId = provincedata == null ? " " : provincedata.EmailId,
                            Fax = provincedata == null ? " " : provincedata.Fax,
                            ProvinceSuperior = prosuperior,
                            ProvinceCouncilor = procouncil,
                            Treaserer = protreaser,
                            Secretary = prosecretary,
                            CommunityDetails = ComData,
                            AllMembers = allbrotherData,
                            provsuperiorcnt = prosuperior.Count(),
                            procouncilcnt = procouncil.Count(),
                            protreasecnt = protreaser.Count(),
                            proseccnt = prosecretary.Count(),
                            Outsideprovince = osprovince,
                            Outsideprovince1 = outdata1,
                            ospcount = osprovince.Count()
                        });

                    }
                }

                ViewBag.provincedata = allData.ToList();
#pragma warning disable CS0219 // The variable 'footer' is assigned but its value is never used
                string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\"" +
#pragma warning restore CS0219 // The variable 'footer' is assigned but its value is never used
                   " --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";

                //return new Rotativa.ViewAsPdf("PrintprovinceData", allData.ToList())
                //{
                //    //FileName = "FDLSReport.pdf",
                //    //PageMargins = new Rotativa.Options.Margins(10,5,10,5),
                //    //PageSize = Rotativa.Options.Size.A5,
                //    //PageOrientation = Rotativa.Options.Orientation.Portrait,
                //    CustomSwitches = footer

                //};
                return View();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                throw;
            }
        }

        public ActionResult Printdata()
        {
            //var report = new Rotativa.ActionAsPdf("Directory2");
            //return report;
            //var allProvinceName = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();

            //var totalprovince = allProvinceName.Count();
            //var totalcount = totalprovince / 2;
            //var data = allProvinceName.Skip(0).Take(10).ToList();
            //var data1 = allProvinceName.Skip(totalcount).Take(totalcount).ToList();
            //ViewBag.data = data;
            //ViewBag.data1 = data1;
            string provinceid = "Belg-BEL/1";
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic4").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

            List<string> DyKey1 = new List<string>();
            List<string> DyKey2 = new List<string>();
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
                if (data1 != null)
                {
                    string[] tempList = data2[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey2.Add(tempList[i]);
                    }
                }
            }

            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<AllProvinceData>();
            var tblformationdetails = dbcont.Tbl_formationsDetails.ToList();
            var tblprimarydetails = dbcont.tbl_Primarydetails.ToList();
            var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
            var tblappointments = dbcont.Appointments.ToList();
            var tblcong = dbcont.Tbl_Cong.ToList();
            var provincesuperior = dbcont.Tbl_ProGeneralMember.ToList();
            var counsilprovince = dbcont.Tbl_ProGeneralCouncil.ToList();
            var treaserer = dbcont.Tbl_ProGeneralTreaserer.ToList();
            var secretary = dbcont.Tbl_ProGeneralSecretary.ToList();
            var tblcongdetails = dbcont.Tbl_Cong.ToList();

            var chcarstoremove = new string[] { "[", "]", "\"" };

            var tblprovince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
            string[] provincename = provinceid.Split(',');

            for (int i = 0; i < provincename.Count(); i++)
            {
                int count = 0;
                var prname = provincename[i];
                foreach (var c in chcarstoremove)
                {
                    prname = prname.Replace(c, string.Empty);
                }

                var provincedata = tblprovince.FirstOrDefault(x => x.MyId == prname);
                if (provincedata != null)
                {

                    //Province Superior
                    var provincialsuperior = provincesuperior.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> prosuperior = new List<ProvinceCouncil>();
                    foreach (var sup in provincialsuperior)
                    {
                        count = count + 1;
                        prosuperior.Add(new ProvinceCouncil
                        {
                            CouncilMember = sup.Name,
                            Designation = sup.Designation,
                            count = count
                        });
                    }

                    //Councile Province
                    var provincecouncil = counsilprovince.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> procouncil = new List<ProvinceCouncil>();
                    foreach (var cou in provincecouncil)
                    {
                        procouncil.Add(new ProvinceCouncil
                        {
                            CouncilMember = cou.Name,
                            Designation = cou.Designation
                        });
                    }

                    //treaserer
                    var treasererdetails = treaserer.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> protreaser = new List<ProvinceCouncil>();
                    foreach (var tre in treasererdetails)
                    {
                        protreaser.Add(new ProvinceCouncil
                        {
                            CouncilMember = tre.Name,
                            Designation = tre.Designation
                        });
                    }

                    //secretary
                    var secretarydetails = secretary.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> prosecretary = new List<ProvinceCouncil>();
                    foreach (var sec in secretarydetails)
                    {
                        prosecretary.Add(new ProvinceCouncil
                        {
                            CouncilMember = sec.Name,
                            Designation = sec.Designation
                        });
                    }

                    //community details
                    var allmember = tblprimarydetails.Where(x => x.ProvinceName == provincedata.Id.ToString()).ToList();
                    List<Appointments> allappodata = new List<Appointments>();
                    foreach (var appo in tblappointments)
                    {
                        if (appo.ProvinceName != null)
                        {
                            var proname = appo.ProvinceName.Split('|');
                            allappodata.Add(new Appointments
                            {
                                Id = appo.Id,
                                CommunityType = appo.CommunityType,
                                Status = appo.Status,
                                ProvinceName = proname[0],
                                MemberId = appo.MemberId,
                                Name = appo.Name,
                                DesignationType = appo.DesignationType,
                                AppointmentType = appo.AppointmentType
                            });
                        }

                    }
                    //outsideprovince
                    var outsideprovince = allappodata.Where(x => x.AppointmentType == "OSPro" && x.Status == "Active" && x.ProvinceName == provincedata.Id.ToString()).ToList();
                    var allmemberappo = allappodata.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Status == "Active").ToList();
                    //var allComAddress = tblcong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == item.Id.ToString()).OrderBy(x => x.Country).ToList();
                    var allComAddress = tblcong.Where(x => x.Status == 1 && x.ProvinceName == provincedata.Id.ToString()).OrderBy(x => x.CommCode).ToList();
                    List<CommunityDetails> ComData = new List<CommunityDetails>();
                    foreach (var item1 in allComAddress)
                    {
                        List<AppointmentsMember> brotherData = new List<AppointmentsMember>();
                        brotherData = (from fd in allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList()
                                       join pd in allmember on fd.MemberId equals pd.MemberId
                                       select new AppointmentsMember
                                       {
                                           MemberName = pd.Knowname,
                                           SurName = pd.SurName,
                                           Designation = fd.DesignationType,
                                           MemPhone = pd.mobilenumber,
                                           MemEmail = pd.emailid,
                                       }).ToList();

                        var totalprovince = brotherData.Count();
                        List<AppointmentsMember> data = new List<AppointmentsMember>();
                        List<AppointmentsMember> data1 = new List<AppointmentsMember>();
                        if (totalprovince > 10)
                        {
                            var totalcount = totalprovince / 2;
                            data = brotherData.Skip(0).Take(10).ToList();
                            data1 = brotherData.Skip(totalcount).Take(totalcount).ToList();
                        }
                        else
                        {
                            data = brotherData.ToList();
                        }


                        ComData.Add(new CommunityDetails
                        {
                            CommunityName = item1.CongregationName,
                            CommunityCode = item1.CommCode,
                            CommunityPlace = item1.Place,
                            CommunityAddress = item1.Address,
                            CommunityPhone = item1.Phone,
                            CommunityEmailId = item1.EmailId,
                            AppointmentsMember = data,
                            Appointment = data1,
                            CommunityCountry = item1.Country
                        });
                    }

                    //active members
                    var allmembersinpro = tblpersoneldetails.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes").ToList();
                    List<AllMembers> allbrotherData = new List<AllMembers>();
                    foreach (var members in allmembersinpro)
                    {
                        Tbl_Cong congs = new Tbl_Cong();

                        if (members.ProvinceName != null)
                        {
                            var allmembers = tblprimarydetails.LastOrDefault(x => x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString());
                            //var data = tblformationdetails.Where(x => x.MemberId == members.MemberID).ToList();
                            //var finalvowdata = data.FirstOrDefault(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == null &&  x.Archivecheck == null);
                            var finalvow = tblformationdetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                            var Firstvows = tblformationdetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                            var communitucode = tblappointments.FirstOrDefault(x => x.MemberId == members.MemberID && x.Status == "Active");
                            if (communitucode != null)
                            {
                                congs = tblcongdetails.FirstOrDefault(x => x.CongregationName == communitucode.CommunityType);
                            }

                            allbrotherData.Add(new AllMembers
                            {
                                ProMemberName = members.Name,
                                ProSurName = members.SirName,
                                DateOfBirth = allmembers == null ? string.Empty : allmembers.DOB,
                                ProCountry = allmembers == null ? string.Empty : allmembers.country,
                                ProFirstVows = Firstvows == null ? string.Empty : Firstvows.VowsDate,
                                ProFinalVows = finalvow == null ? string.Empty : finalvow.VowsDate,
                                ProMemCode = congs == null ? string.Empty : congs.CommCode
                            });
                        }
                    }
                    //outsideprovince
                    List<AppointmentsMember> osprovince = new List<AppointmentsMember>();
                    List<AppointmentsMember> outdata1 = new List<AppointmentsMember>();
                    List<Appointments> osprovince1 = new List<Appointments>();
                    List<Appointments> osprovince2 = new List<Appointments>();

                    var totalcounts = outsideprovince.Count() / 2;
                    osprovince1 = outsideprovince.Skip(0).Take(totalcounts).ToList();
                    osprovince2 = outsideprovince.Skip(totalcounts).Take(totalcounts).ToList();
                    foreach (var ospro in osprovince1)
                    {
                        var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                        //if(primarydata != null)
                        {
                            osprovince.Add(new AppointmentsMember
                            {
                                MemberName = ospro.Name,
                                SurName = primarydata == null ? string.Empty : primarydata.SurName
                            });
                        }

                    }
                    foreach (var ospro in osprovince2)
                    {
                        var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                        //if(primarydata != null)
                        {
                            outdata1.Add(new AppointmentsMember
                            {
                                MemberName = ospro.Name,
                                SurName = primarydata == null ? string.Empty : primarydata.SurName
                            });
                        }

                    }

                    allData.Add(new AllProvinceData
                    {
                        ProvinceName = provincedata.ProvinceName,
                        Provincecode = provincedata.Place,
                        Address = provincedata == null ? " " : provincedata.Place1,
                        Telephone = provincedata == null ? " " : provincedata.Phone,
                        EmailId = provincedata == null ? " " : provincedata.EmailId,
                        Fax = provincedata == null ? " " : provincedata.Fax,
                        ProvinceSuperior = prosuperior,
                        ProvinceCouncilor = procouncil,
                        Treaserer = protreaser,
                        Secretary = prosecretary,
                        CommunityDetails = ComData,
                        AllMembers = allbrotherData,
                        provsuperiorcnt = prosuperior.Count(),
                        procouncilcnt = procouncil.Count(),
                        protreasecnt = protreaser.Count(),
                        proseccnt = prosecretary.Count(),
                        Outsideprovince = osprovince,
                        Outsideprovince1 = outdata1,
                        ospcount = osprovince.Count()
                    });

                }
            }

            ViewBag.provincedata = allData.ToList();


            return View(allData.ToList());
        }

        public ActionResult PrintReport(string ProvinceId,string fromdate,string todate)
        {
            try
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
                //string provinceid = "Belg-BEL/1";
                var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic4").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

                List<string> DyKey1 = new List<string>();
                List<string> DyKey2 = new List<string>();
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
                    if (data1 != null)
                    {
                        string[] tempList = data2[0].Split(',');
                        for (int i = 0; i < tempList.Count(); i++)
                        {
                            DyKey2.Add(tempList[i]);
                        }
                    }
                }

                var provincelist = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").OrderBy(x => x.MyId).ToList();
                var totalprovince1 = provincelist.Count();
                var totalcount1 = totalprovince1 / 2;
                var pronamee = provincelist.Skip(0).Take(10).ToList();
                var proname1 = provincelist.Skip(totalcount1).Take(totalcount1).ToList();
                ViewBag.proname = pronamee;
                ViewBag.proname1 = proname1;

                string currentloginid = Convert.ToString(Session["loginuserid"]);
                var allData = new List<AllProvinceData>();
                var tblformationdetails = dbcont.Tbl_formationsDetails.ToList();
                var tblprimarydetails = dbcont.tbl_Primarydetails.ToList();
                var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
                var tblappointments = dbcont.Appointments.ToList();
                var tblcong = dbcont.Tbl_Cong.ToList();
                var provincesuperior = dbcont.Tbl_ProGeneralMember.ToList();
                var counsilprovince = dbcont.Tbl_ProGeneralCouncil.ToList();
                var treaserer = dbcont.Tbl_ProGeneralTreaserer.ToList();
                var secretary = dbcont.Tbl_ProGeneralSecretary.ToList();
                var tblcongdetails = dbcont.Tbl_Cong.ToList();

                if (ProvinceId != "")
                {
                    var chcarstoremove = new string[] { "[", "]", "\"" };

                    var tblprovince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
                    string[] provincename = ProvinceId.Split(',');

                    for (int i = 0; i < provincename.Count(); i++)
                    {
                        int count = 0;
                        var prname = provincename[i];
                        foreach (var c in chcarstoremove)
                        {
                            prname = prname.Replace(c, string.Empty);
                        }

                        var provincedata = tblprovince.FirstOrDefault(x => x.MyId == prname);
                        if (provincedata != null)
                        {

                            //Province Superior
                            var provincialsuperior = provincesuperior.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                            List<ProvinceCouncil> prosuperior = new List<ProvinceCouncil>();
                            foreach (var sup in provincialsuperior)
                            {
                                count = count + 1;
                                prosuperior.Add(new ProvinceCouncil
                                {
                                    CouncilMember = sup.Name,
                                    Designation = sup.Designation,
                                    count = count
                                });
                            }

                            //Councile Province
                            var provincecouncil = counsilprovince.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                            List<ProvinceCouncil> procouncil = new List<ProvinceCouncil>();
                            foreach (var cou in provincecouncil)
                            {
                                procouncil.Add(new ProvinceCouncil
                                {
                                    CouncilMember = cou.Name,
                                    Designation = cou.Designation
                                });
                            }

                            //treaserer
                            var treasererdetails = treaserer.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                            List<ProvinceCouncil> protreaser = new List<ProvinceCouncil>();
                            foreach (var tre in treasererdetails)
                            {
                                protreaser.Add(new ProvinceCouncil
                                {
                                    CouncilMember = tre.Name,
                                    Designation = tre.Designation
                                });
                            }

                            //secretary
                            var secretarydetails = secretary.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                            List<ProvinceCouncil> prosecretary = new List<ProvinceCouncil>();
                            foreach (var sec in secretarydetails)
                            {
                                prosecretary.Add(new ProvinceCouncil
                                {
                                    CouncilMember = sec.Name,
                                    Designation = sec.Designation
                                });
                            }

                            //community details
                            var allmember = tblprimarydetails.Where(x => x.ProvinceName == provincedata.Id.ToString()).ToList();
                            List<Appointments> allappodata = new List<Appointments>();
                            foreach (var appo in tblappointments)
                            {
                                if (appo.ProvinceName != null)
                                {
                                    var proname = appo.ProvinceName.Split('|');
                                    allappodata.Add(new Appointments
                                    {
                                        Id = appo.Id,
                                        CommunityType = appo.CommunityType,
                                        Status = appo.Status,
                                        ProvinceName = proname[0],
                                        MemberId = appo.MemberId,
                                        Name = appo.Name,
                                        DesignationType = appo.DesignationType,
                                        AppointmentType = appo.AppointmentType
                                    });
                                }

                            }
                            //outsideprovince
                            var outsideprovince = allappodata.Where(x => x.AppointmentType == "OSPro" && x.Status == "Active" && x.ProvinceName == provincedata.Id.ToString()).ToList();
                            var allmemberappo = allappodata.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Status == "Active").ToList();
                            //var allComAddress = tblcong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == item.Id.ToString()).OrderBy(x => x.Country).ToList();
                            var allComAddress = tblcong.Where(x => x.Status == 1 && x.ProvinceName == provincedata.Id.ToString()).OrderBy(x => x.CommCode).ToList();
                            List<CommunityDetails> ComData = new List<CommunityDetails>();
                            foreach (var item1 in allComAddress)
                            {
                                List<AppointmentsMember> brotherData = new List<AppointmentsMember>();
                                brotherData = (from fd in allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList()
                                               join pd in allmember on fd.MemberId equals pd.MemberId
                                               select new AppointmentsMember
                                               {
                                                   MemberName = pd.Knowname,
                                                   SurName = pd.SurName,
                                                   Designation = fd.DesignationType,
                                                   MemPhone = pd.mobilenumber,
                                                   MemEmail = pd.emailid,
                                               }).ToList();

                                var totalprovince = brotherData.Count();
                                List<AppointmentsMember> data = new List<AppointmentsMember>();
                                List<AppointmentsMember> data1 = new List<AppointmentsMember>();
                                if (totalprovince > 10)
                                {
                                    var totalcount = totalprovince / 2;
                                    data = brotherData.Skip(0).Take(10).ToList();
                                    data1 = brotherData.Skip(totalcount).Take(totalcount).ToList();
                                }
                                else
                                {
                                    data = brotherData.ToList();
                                }


                                ComData.Add(new CommunityDetails
                                {
                                    CommunityName = item1.CongregationName,
                                    CommunityCode = item1.CommCode,
                                    CommunityPlace = item1.Place,
                                    CommunityAddress = item1.Address,
                                    CommunityPhone = item1.Phone,
                                    CommunityEmailId = item1.EmailId,
                                    AppointmentsMember = data,
                                    Appointment = data1,
                                    CommunityCountry = item1.Country
                                });
                            }

                            //active members
                            var allmembersinpro = tblpersoneldetails.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes").ToList();
                            List<AllMembers> allbrotherData = new List<AllMembers>();
                            foreach (var members in allmembersinpro)
                            {
                                Tbl_Cong congs = new Tbl_Cong();

                                if (members.ProvinceName != null)
                                {
                                    var allmembers = tblprimarydetails.LastOrDefault(x => x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString());
                                    //var data = tblformationdetails.Where(x => x.MemberId == members.MemberID).ToList();
                                    //var finalvowdata = data.FirstOrDefault(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == null &&  x.Archivecheck == null);
                                    var finalvow = tblformationdetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                    var Firstvows = tblformationdetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                    var communitucode = tblappointments.FirstOrDefault(x => x.MemberId == members.MemberID && x.Status == "Active");
                                    if (communitucode != null)
                                    {
                                        congs = tblcongdetails.FirstOrDefault(x => x.CongregationName == communitucode.CommunityType);
                                    }

                                    allbrotherData.Add(new AllMembers
                                    {
                                        ProMemberName = members.Name,
                                        ProSurName = members.SirName,
                                        DateOfBirth = allmembers == null ? string.Empty : allmembers.DOB,
                                        ProCountry = allmembers == null ? string.Empty : allmembers.country,
                                        ProFirstVows = Firstvows == null ? string.Empty : Firstvows.VowsDate,
                                        ProFinalVows = finalvow == null ? string.Empty : finalvow.VowsDate,
                                        ProMemCode = congs == null ? string.Empty : congs.CommCode
                                    });
                                }
                            }
                            //outsideprovince
                            List<AppointmentsMember> osprovince = new List<AppointmentsMember>();
                            List<AppointmentsMember> outdata1 = new List<AppointmentsMember>();
                            List<Appointments> osprovince1 = new List<Appointments>();
                            List<Appointments> osprovince2 = new List<Appointments>();

                            var totalcounts = outsideprovince.Count() / 2;
                            osprovince1 = outsideprovince.Skip(0).Take(totalcounts).ToList();
                            osprovince2 = outsideprovince.Skip(totalcounts).Take(totalcounts).ToList();
                            foreach (var ospro in osprovince1)
                            {
                                var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                                //if(primarydata != null)
                                {
                                    osprovince.Add(new AppointmentsMember
                                    {
                                        MemberName = ospro.Name,
                                        SurName = primarydata == null ? string.Empty : primarydata.SurName
                                    });
                                }

                            }
                            foreach (var ospro in osprovince2)
                            {
                                var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                                //if(primarydata != null)
                                {
                                    outdata1.Add(new AppointmentsMember
                                    {
                                        MemberName = ospro.Name,
                                        SurName = primarydata == null ? string.Empty : primarydata.SurName
                                    });
                                }

                            }

                            allData.Add(new AllProvinceData
                            {
                                ProvinceName = provincedata.ProvinceName,
                                Provincecode = provincedata.Place,
                                Address = provincedata == null ? " " : provincedata.Place1,
                                Telephone = provincedata == null ? " " : provincedata.Phone,
                                EmailId = provincedata == null ? " " : provincedata.EmailId,
                                Fax = provincedata == null ? " " : provincedata.Fax,
                                ProvinceSuperior = prosuperior,
                                ProvinceCouncilor = procouncil,
                                Treaserer = protreaser,
                                Secretary = prosecretary,
                                CommunityDetails = ComData,
                                AllMembers = allbrotherData,
                                provsuperiorcnt = prosuperior.Count(),
                                procouncilcnt = procouncil.Count(),
                                protreasecnt = protreaser.Count(),
                                proseccnt = prosecretary.Count(),
                                Outsideprovince = osprovince,
                                Outsideprovince1 = outdata1,
                                ospcount = osprovince.Count()
                            });

                        }
                    }

                    ViewBag.provincedata = allData.ToList();

                    var json = new JavaScriptSerializer().Serialize(allData.ToList());
                    var bytes = System.Text.Encoding.UTF8.GetBytes(json);
                    var memstream = new System.IO.MemoryStream(bytes);


#pragma warning disable CS0219 // The variable 'footer' is assigned but its value is never used
                    string footer = "--print-media-type --footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\"" +
#pragma warning restore CS0219 // The variable 'footer' is assigned but its value is never used
                       " --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";
                    //var provinceid = "Belg-BEL/1";
                    return new RazorPDF.PdfResult("Printdata")
                    {
                        //FileName = "FDLSReport.pdf",
                        //PageMargins = new Rotativa.Options.Margins(10,5,10,5),
                        //PageSize = Rotativa.Options.Size.A5,
                        //PageOrientation = Rotativa.Options.Orientation.Portrait,
                        //CustomSwitches = footer

                    };

                }
                else
                {
                    var tblsuperiorgeneral = dbcont.GeneralMember.ToList();
                    var tblcongregation = dbcont.tbl_Congregation.ToList();
                    var tbltreaserer = dbcont.GeneralTreasurer.ToList();
                    var tblsecretary = dbcont.GeneralSecretary.ToList();
                    var tblprovince = dbcont.tbl_Province.FirstOrDefault(x => x.ProvinceName.ToLower() == "Administration Centrale".ToLower() || x.ProvinceName.ToLower() == "CENTRAL ADMINISTRATION");

                    var allgeneraldata = new List<AllProvinceData>();
                    ProvinceCouncil Generaltreaserer = new ProvinceCouncil();
                    ProvinceCouncil superiorgeneral = new ProvinceCouncil();
                    ProvinceCouncil GeneralSecretary = new ProvinceCouncil();
                    ProvinceCouncil totalmember = new ProvinceCouncil();

                    var allProvince = dbcont.tbl_Congregation.FirstOrDefault(x => x.FamilyBelongsTo == null);

                    var allCouncil = db.MeetingMinutes.Where(x => x.GenId == allProvince.Id.ToString()).ToList();
                    List<ProvinceCouncil> allData1 = new List<ProvinceCouncil>();
                    foreach (var items in allCouncil)
                    {
                        string[] names = items.Name.Split(' ');
                        string name = names[0];
                        var allmember = dbcont.tbl_Primarydetails.ToList().LastOrDefault(x => x.Knowname == name);

                        allData1.Add(new ProvinceCouncil
                        {
                            CouncilMember = items.Name,
                            MemPhone = allmember == null ? string.Empty : allmember.mobilenumber,
                            MemEmail = allmember == null ? string.Empty : allmember.emailid,
                            Designation = items.Designation,
                        });
                    }


                    //superior General
                    var generalsuperior = tblsuperiorgeneral.FirstOrDefault(x => x.GenId == allProvince.Id.ToString());
                    string[] spnames = generalsuperior.Name.Split(' ');
                    string sprname = spnames[0];
                    var memberdetails = tblprimarydetails.FirstOrDefault(x => x.Knowname == sprname);

                    superiorgeneral.CouncilMember = generalsuperior.Name;
                    superiorgeneral.MemPhone = memberdetails == null ? string.Empty : memberdetails.mobilenumber;
                    superiorgeneral.MemEmail = memberdetails == null ? string.Empty : memberdetails.emailid;
                    superiorgeneral.Designation = generalsuperior.Designation;

                    //treaserer
                    var generaltreaserer = tbltreaserer.FirstOrDefault(x => x.GenId == allProvince.Id.ToString());
                    if (generaltreaserer != null)
                    {
                        string[] trname = generaltreaserer.Name.Split(' ');
                        string trename = trname[0];
                        var treaserermember = tblprimarydetails.FirstOrDefault(x => x.Knowname == trename);
                        Generaltreaserer.CouncilMember = generaltreaserer.Name;
                        Generaltreaserer.MemPhone = treaserermember == null ? string.Empty : treaserermember.mobilenumber;
                        Generaltreaserer.MemEmail = treaserermember == null ? string.Empty : treaserermember.emailid;
                        Generaltreaserer.Designation = generaltreaserer.Designation;
                    }

                    //Secretary
                    var generalsecretary = tblsecretary.FirstOrDefault(x => x.GenId == allProvince.Id.ToString());
                    if (generalsecretary != null)
                    {
                        string[] sename = generalsecretary.Name.Split(' ');
                        string srname = sename[0];
                        var secretarymember = tblprimarydetails.FirstOrDefault(x => x.Knowname == srname);
                        GeneralSecretary.CouncilMember = generalsecretary.Name;
                        GeneralSecretary.MemEmail = secretarymember == null ? string.Empty : secretarymember.mobilenumber;
                        GeneralSecretary.MemEmail = secretarymember == null ? string.Empty : secretarymember.emailid;
                        GeneralSecretary.Designation = generalsecretary.Designation;
                    }



                    allgeneraldata.Add(new AllProvinceData
                    {
                        superiorgeneral = superiorgeneral,
                        Generaltreaserer = Generaltreaserer,
                        GeneralSecretary = GeneralSecretary,
                        Generalcouncil = allData1,
                        ProvinceName = tblprovince.ProvinceName,
                        Provincecode = tblprovince.Place,
                        Congregation = allProvince.CongregationName,
                        Congregation_id = allProvince.CongreId,
                        Congregation_Country = allProvince.Country,
                        Address = allProvince.Address,
                        Telephone = allProvince.Phone,
                        EmailId = allProvince.Email,
                        Fax = allProvince.Fax,
                        website = allProvince.Website,

                    });


                    //provincedata
                    foreach (var item in provincelist)
                    {
                        var allCouncil1 = db.Tbl_ProvinceCouncil.Where(x => x.ProvinceName == item.Id.ToString()).ToList();

                        List<ProvinceCouncil> allData11 = new List<ProvinceCouncil>();
                        foreach (var items in allCouncil1)
                        {
                            allData1.Add(new ProvinceCouncil
                            {
                                CouncilMember = items.MemberName,
                                Designation = items.DesignationName,
                            });
                        }
                        //Province Superior
                        var provincialsuperior = provincesuperior.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> prosuperior = new List<ProvinceCouncil>();
                        foreach (var sup in provincialsuperior)
                        {
                            prosuperior.Add(new ProvinceCouncil
                            {
                                CouncilMember = sup.Name,
                                Designation = sup.Designation
                            });
                        }

                        //Councile Province
                        var provincecouncil = counsilprovince.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> procouncil = new List<ProvinceCouncil>();
                        foreach (var cou in provincecouncil)
                        {
                            procouncil.Add(new ProvinceCouncil
                            {
                                CouncilMember = cou.Name,
                                Designation = cou.Designation
                            });
                        }

                        //treaserer
                        var treasererdetails = treaserer.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> protreaser = new List<ProvinceCouncil>();
                        foreach (var tre in treasererdetails)
                        {
                            protreaser.Add(new ProvinceCouncil
                            {
                                CouncilMember = tre.Name,
                                Designation = tre.Designation
                            });
                        }

                        //secretary
                        var secretarydetails = secretary.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> prosecretary = new List<ProvinceCouncil>();
                        foreach (var sec in secretarydetails)
                        {
                            prosecretary.Add(new ProvinceCouncil
                            {
                                CouncilMember = sec.Name,
                                Designation = sec.Designation
                            });
                        }

                        // var allforcomname = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.ProvinceName == item.Id.ToString()).ToList();
                        var allmember = tblprimarydetails.Where(x => x.ProvinceName == item.Id.ToString()).ToList();
                        List<Appointments> allappodata = new List<Appointments>();
                        foreach (var appo in tblappointments)
                        {
                            if (appo.ProvinceName != null)
                            {
                                var proname = appo.ProvinceName.Split('|');
                                allappodata.Add(new Appointments
                                {
                                    Id = appo.Id,
                                    CommunityType = appo.CommunityType,
                                    Status = appo.Status,
                                    ProvinceName = proname[0],
                                    MemberId = appo.MemberId,
                                    Name = appo.Name,
                                    DesignationType = appo.DesignationType
                                });
                            }

                        }
                        //outsideprovince
                        var outsideprovince = allappodata.Where(x => x.AppointmentType == "OSPro" && x.Status == "Active" && x.ProvinceName == item.Id.ToString()).ToList();

                        var allmemberappo = allappodata.Where(x => x.ProvinceName == item.Id.ToString() && x.Status == "Active").ToList();
                        //var allComAddress = tblcong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == item.Id.ToString()).OrderBy(x => x.Country).ToList();
                        var allComAddress = tblcong.Where(x => x.Status == 1 && x.ProvinceName == item.Id.ToString()).ToList();
                        List<CommunityDetails> ComData = new List<CommunityDetails>();
                        foreach (var item1 in allComAddress)
                        {

                            List<AppointmentsMember> brotherData = new List<AppointmentsMember>();
                            brotherData = (from fd in allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList()
                                           join pd in allmember on fd.MemberId equals pd.MemberId
                                           select new AppointmentsMember
                                           {
                                               MemberName = pd.Knowname,
                                               SurName = pd.SurName,
                                               Designation = fd.DesignationType,
                                               MemPhone = pd.mobilenumber,
                                               MemEmail = pd.emailid,
                                           }).ToList();

                            var totalprovince = brotherData.Count();
                            var totalcount = totalprovince / 2;
                            var data = brotherData.Skip(0).Take(10).ToList();
                            var data1 = brotherData.Skip(totalcount).Take(totalcount).ToList();

                            ComData.Add(new CommunityDetails
                            {
                                CommunityName = item1.CongregationName,
                                CommunityCode = item1.CommCode,
                                CommunityPlace = item1.Place,
                                CommunityAddress = item1.Address,
                                CommunityPhone = item1.Phone,
                                CommunityEmailId = item1.EmailId,
                                AppointmentsMember = data,
                                Appointment = data1,
                                CommunityCountry = item1.Country
                            });
                        }

                        var allmembersinpro = tblpersoneldetails.Where(x => x.ProvinceName == item.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes").ToList();
                        List<AllMembers> allbrotherData = new List<AllMembers>();
                        foreach (var members in allmembersinpro)
                        {
                            Tbl_Cong congs = new Tbl_Cong();

                            if (members.ProvinceName != null)
                            {
                                var allmembers = tblprimarydetails.LastOrDefault(x => x.MemberId == members.MemberID && x.ProvinceName == item.Id.ToString());
                                //var data = tblformationdetails.Where(x => x.MemberId == members.MemberID).ToList();
                                //var finalvowdata = data.FirstOrDefault(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == null &&  x.Archivecheck == null);
                                var finalvow = dbcont.Tbl_formationsDetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == item.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                var Firstvows = dbcont.Tbl_formationsDetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == item.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                var communitucode = tblappointments.FirstOrDefault(x => x.MemberId == members.MemberID && x.Status == "Active");
                                if (communitucode != null)
                                {
                                    congs = tblcongdetails.FirstOrDefault(x => x.CongregationName == communitucode.CommunityType);
                                }

                                allbrotherData.Add(new AllMembers
                                {
                                    ProMemberName = members.Name,
                                    ProSurName = members.SirName,
                                    DateOfBirth = allmembers == null ? string.Empty : allmembers.DOB,
                                    ProCountry = allmembers == null ? string.Empty : allmembers.country,
                                    ProFirstVows = Firstvows == null ? string.Empty : Firstvows.VowsDate,
                                    ProFinalVows = finalvow == null ? string.Empty : finalvow.VowsDate,
                                    ProMemCode = congs == null ? string.Empty : congs.CommCode
                                });
                            }
                        }

                        var allProCommission = dbcont.tbl_ProCommission.Where(x => x.ProId == item.MyId).ToList();
                        var afterGroup = allProCommission.GroupBy(x => x.ResponsibilityName).Select(x => x).ToList();
                        var Responsibility = new List<Responsibility>();
                        foreach (var item1 in afterGroup)
                        {
                            string key = item1.Key;
                            List<ProvinceComission> memberdata = new List<ProvinceComission>();
                            foreach (var item2 in item1.OrderBy(x => x.DesignationName))
                            {
                                string[] names = item2.MemberName.Split(' ');
                                string name = names[0];
                                var allmember1 = tblprimarydetails.LastOrDefault(x => x.Knowname.Contains(name));

                                memberdata.Add(new ProvinceComission
                                {
                                    ComisMemName = item2.MemberName,
                                    ComisDesignation = item2.DesignationName,
                                    ComisAddress = allmember1 == null ? "" : allmember1.city,
                                    ComisPlace = allmember1 == null ? "" : allmember1.district,
                                    Comisstate = allmember1 == null ? "" : allmember1.state,
                                    ComisPin = allmember1 == null ? "" : allmember1.pin,
                                    ComisCountry = allmember1 == null ? "" : allmember1.country,
                                    ComisEmail = allmember1 == null ? "" : allmember1.emailid,
                                    ComisTelephone = allmember1 == null ? "" : allmember1.mobilenumber,
                                });
                            }
                            Responsibility.Add(new Responsibility
                            {
                                ResponsibilityName = key,
                                ProvinceComission = memberdata
                            });
                        }

                        List<AppointmentsMember> osprovince = new List<AppointmentsMember>();
                        List<AppointmentsMember> outdata1 = new List<AppointmentsMember>();
                        List<Appointments> osprovince1 = new List<Appointments>();
                        List<Appointments> osprovince2 = new List<Appointments>();

                        var totalcounts = outsideprovince.Count() / 2;
                        osprovince1 = outsideprovince.Skip(0).Take(totalcounts).ToList();
                        osprovince2 = outsideprovince.Skip(totalcounts).Take(totalcounts).ToList();
                        foreach (var ospro in osprovince1)
                        {
                            var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                            //if(primarydata != null)
                            {
                                osprovince.Add(new AppointmentsMember
                                {
                                    MemberName = ospro.Name,
                                    SurName = primarydata == null ? string.Empty : primarydata.SurName
                                });
                            }

                        }
                        foreach (var ospro in osprovince2)
                        {
                            var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                            //if(primarydata != null)
                            {
                                outdata1.Add(new AppointmentsMember
                                {
                                    MemberName = ospro.Name,
                                    SurName = primarydata == null ? string.Empty : primarydata.SurName
                                });
                            }

                        }

                        allData.Add(new AllProvinceData
                        {
                            ProvinceName = item.ProvinceName,
                            Provincecode = item.Place,
                            Address = item == null ? " " : item.Place1,
                            Telephone = item == null ? " " : item.Phone,
                            EmailId = item == null ? " " : item.EmailId,
                            Fax = item == null ? " " : item.Fax,
                            ProvinceSuperior = prosuperior,
                            ProvinceCouncilor = procouncil,
                            ProvinceCouncils = allData1,
                            Treaserer = protreaser,
                            Secretary = prosecretary,
                            CommunityDetails = ComData,
                            AllMembers = allbrotherData,
                            Responsibility = Responsibility,
                            provsuperiorcnt = prosuperior.Count(),
                            procouncilcnt = procouncil.Count(),
                            protreasecnt = protreaser.Count(),
                            proseccnt = prosecretary.Count(),
                            Outsideprovince = osprovince,
                            Outsideprovince1 = outdata1,
                            ospcount = osprovince.Count()
                        });
                    }

                    ViewBag.Generalatedata = allgeneraldata.ToList();
                    ViewBag.Provincedata = allData.ToList();

                    string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\"" +
                      " --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";
                    //var provinceid = "Belg-BEL/1";

                    return new Rotativa.ViewAsPdf("PrintGenereralatedata")
                    {
                        //FileName = "FDLSReport.pdf",
                        //PageMargins = new Rotativa.Options.Margins(10,5,10,5),
                        //PageSize = Rotativa.Options.Size.A5,
                        //PageOrientation = Rotativa.Options.Orientation.Portrait,
                        CustomSwitches = footer

                    };


                }
                //return View();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                throw;
            }



            //var report = new Rotativa.ViewAsPdf("Printdata", allData.ToList());
            //return report;
        }

        public ActionResult PrintGenereralatedata()
        {
            return View();
        }

        public ActionResult PrintRazorpdf(string ProvinceId, string fromdate, string todate)
        {
            try
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
                //string provinceid = "Belg-BEL/1";
                var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic4").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

                List<string> DyKey1 = new List<string>();
                List<string> DyKey2 = new List<string>();
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
                    if (data1 != null)
                    {
                        string[] tempList = data2[0].Split(',');
                        for (int i = 0; i < tempList.Count(); i++)
                        {
                            DyKey2.Add(tempList[i]);
                        }
                    }
                }

                var provincelist = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").OrderBy(x => x.MyId).ToList();
                var totalprovince1 = provincelist.Count();
                var totalcount1 = totalprovince1 / 2;
                var pronamee = provincelist.Skip(0).Take(10).ToList();
                var proname1 = provincelist.Skip(totalcount1).Take(totalcount1).ToList();
                ViewBag.proname = pronamee;
                ViewBag.proname1 = proname1;

                string currentloginid = Convert.ToString(Session["loginuserid"]);
                var allData = new List<AllProvinceData>();
                var tblformationdetails = dbcont.Tbl_formationsDetails.ToList();
                var tblprimarydetails = dbcont.tbl_Primarydetails.ToList();
                var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
                var tblappointments = dbcont.Appointments.ToList();
                var tblcong = dbcont.Tbl_Cong.ToList();
                var provincesuperior = dbcont.Tbl_ProGeneralMember.ToList();
                var counsilprovince = dbcont.Tbl_ProGeneralCouncil.ToList();
                var treaserer = dbcont.Tbl_ProGeneralTreaserer.ToList();
                var secretary = dbcont.Tbl_ProGeneralSecretary.ToList();
                var tblcongdetails = dbcont.Tbl_Cong.ToList();

                if (ProvinceId != "")
                {
                    var chcarstoremove = new string[] { "[", "]", "\"" };

                    var tblprovince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
                    string[] provincename = ProvinceId.Split(',');

                    for (int i = 0; i < provincename.Count(); i++)
                    {
                        int count = 0;
                        var prname = provincename[i];
                        foreach (var c in chcarstoremove)
                        {
                            prname = prname.Replace(c, string.Empty);
                        }

                        var provincedata = tblprovince.FirstOrDefault(x => x.MyId == prname);
                        if (provincedata != null)
                        {

                            //Province Superior
                            var provincialsuperior = provincesuperior.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                            List<ProvinceCouncil> prosuperior = new List<ProvinceCouncil>();
                            foreach (var sup in provincialsuperior)
                            {
                                count = count + 1;
                                prosuperior.Add(new ProvinceCouncil
                                {
                                    CouncilMember = sup.Name,
                                    Designation = sup.Designation,
                                    count = count
                                });
                            }

                            //Councile Province
                            var provincecouncil = counsilprovince.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                            List<ProvinceCouncil> procouncil = new List<ProvinceCouncil>();
                            foreach (var cou in provincecouncil)
                            {
                                procouncil.Add(new ProvinceCouncil
                                {
                                    CouncilMember = cou.Name,
                                    Designation = cou.Designation
                                });
                            }

                            //treaserer
                            var treasererdetails = treaserer.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                            List<ProvinceCouncil> protreaser = new List<ProvinceCouncil>();
                            foreach (var tre in treasererdetails)
                            {
                                protreaser.Add(new ProvinceCouncil
                                {
                                    CouncilMember = tre.Name,
                                    Designation = tre.Designation
                                });
                            }

                            //secretary
                            var secretarydetails = secretary.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                            List<ProvinceCouncil> prosecretary = new List<ProvinceCouncil>();
                            foreach (var sec in secretarydetails)
                            {
                                prosecretary.Add(new ProvinceCouncil
                                {
                                    CouncilMember = sec.Name,
                                    Designation = sec.Designation
                                });
                            }

                            //community details
                            var allmember = tblprimarydetails.Where(x => x.ProvinceName == provincedata.Id.ToString()).ToList();
                            List<Appointments> allappodata = new List<Appointments>();
                            foreach (var appo in tblappointments)
                            {
                                if (appo.ProvinceName != null)
                                {
                                    var proname = appo.ProvinceName.Split('|');
                                    allappodata.Add(new Appointments
                                    {
                                        Id = appo.Id,
                                        CommunityType = appo.CommunityType,
                                        Status = appo.Status,
                                        ProvinceName = proname[0],
                                        MemberId = appo.MemberId,
                                        Name = appo.Name,
                                        DesignationType = appo.DesignationType,
                                        AppointmentType = appo.AppointmentType
                                    });
                                }

                            }
                            //outsideprovince
                            var outsideprovince = allappodata.Where(x => x.AppointmentType == "OSPro" && x.Status == "Active" && x.ProvinceName == provincedata.Id.ToString()).ToList();
                            var allmemberappo = allappodata.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Status == "Active").ToList();
                            //var allComAddress = tblcong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == item.Id.ToString()).OrderBy(x => x.Country).ToList();
                            var allComAddress = tblcong.Where(x => x.Status == 1 && x.ProvinceName == provincedata.Id.ToString()).OrderBy(x => x.CommCode).ToList();
                            List<CommunityDetails> ComData = new List<CommunityDetails>();
                            foreach (var item1 in allComAddress)
                            {
                                List<AppointmentsMember> brotherData = new List<AppointmentsMember>();
                                brotherData = (from fd in allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList()
                                               join pd in allmember on fd.MemberId equals pd.MemberId
                                               select new AppointmentsMember
                                               {
                                                   MemberName = pd.Knowname,
                                                   SurName = pd.SurName,
                                                   Designation = fd.DesignationType,
                                                   MemPhone = pd.mobilenumber,
                                                   MemEmail = pd.emailid,
                                               }).ToList();

                                var totalprovince = brotherData.Count();
                                List<AppointmentsMember> data = new List<AppointmentsMember>();
                                List<AppointmentsMember> data1 = new List<AppointmentsMember>();
                                if (totalprovince > 10)
                                {
                                    var totalcount = totalprovince / 2;
                                    data = brotherData.Skip(0).Take(10).ToList();
                                    data1 = brotherData.Skip(totalcount).Take(totalcount).ToList();
                                }
                                else
                                {
                                    data = brotherData.ToList();
                                }


                                ComData.Add(new CommunityDetails
                                {
                                    CommunityName = item1.CongregationName,
                                    CommunityCode = item1.CommCode,
                                    CommunityPlace = item1.Place,
                                    CommunityAddress = item1.Address,
                                    CommunityPhone = item1.Phone,
                                    CommunityEmailId = item1.EmailId,
                                    AppointmentsMember = data,
                                    Appointment = data1,
                                    CommunityCountry = item1.Country
                                });
                            }

                            //active members
                            var allmembersinpro = tblpersoneldetails.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes").ToList();
                            List<AllMembers> allbrotherData = new List<AllMembers>();
                            foreach (var members in allmembersinpro)
                            {
                                Tbl_Cong congs = new Tbl_Cong();

                                if (members.ProvinceName != null)
                                {
                                    var allmembers = tblprimarydetails.LastOrDefault(x => x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString());
                                    //var data = tblformationdetails.Where(x => x.MemberId == members.MemberID).ToList();
                                    //var finalvowdata = data.FirstOrDefault(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == null &&  x.Archivecheck == null);
                                    var finalvow = tblformationdetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                    var Firstvows = tblformationdetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                    var communitucode = tblappointments.FirstOrDefault(x => x.MemberId == members.MemberID && x.Status == "Active");
                                    if (communitucode != null)
                                    {
                                        congs = tblcongdetails.FirstOrDefault(x => x.CongregationName == communitucode.CommunityType);
                                    }

                                    allbrotherData.Add(new AllMembers
                                    {
                                        ProMemberName = members.Name,
                                        ProSurName = members.SirName,
                                        DateOfBirth = allmembers == null ? string.Empty : allmembers.DOB,
                                        ProCountry = allmembers == null ? string.Empty : allmembers.country,
                                        ProFirstVows = Firstvows == null ? string.Empty : Firstvows.VowsDate,
                                        ProFinalVows = finalvow == null ? string.Empty : finalvow.VowsDate,
                                        ProMemCode = congs == null ? string.Empty : congs.CommCode
                                    });
                                }
                            }
                            //outsideprovince
                            List<AppointmentsMember> osprovince = new List<AppointmentsMember>();
                            List<AppointmentsMember> outdata1 = new List<AppointmentsMember>();
                            List<Appointments> osprovince1 = new List<Appointments>();
                            List<Appointments> osprovince2 = new List<Appointments>();

                            var totalcounts = outsideprovince.Count() / 2;
                            osprovince1 = outsideprovince.Skip(0).Take(totalcounts).ToList();
                            osprovince2 = outsideprovince.Skip(totalcounts).Take(totalcounts).ToList();
                            foreach (var ospro in osprovince1)
                            {
                                var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                                //if(primarydata != null)
                                {
                                    osprovince.Add(new AppointmentsMember
                                    {
                                        MemberName = ospro.Name,
                                        SurName = primarydata == null ? string.Empty : primarydata.SurName
                                    });
                                }

                            }
                            foreach (var ospro in osprovince2)
                            {
                                var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                                //if(primarydata != null)
                                {
                                    outdata1.Add(new AppointmentsMember
                                    {
                                        MemberName = ospro.Name,
                                        SurName = primarydata == null ? string.Empty : primarydata.SurName
                                    });
                                }

                            }

                            allData.Add(new AllProvinceData
                            {
                                ProvinceName = provincedata.ProvinceName,
                                Provincecode = provincedata.Place,
                                Address = provincedata == null ? " " : provincedata.Place1,
                                Telephone = provincedata == null ? " " : provincedata.Phone,
                                EmailId = provincedata == null ? " " : provincedata.EmailId,
                                Fax = provincedata == null ? " " : provincedata.Fax,
                                ProvinceSuperior = prosuperior,
                                ProvinceCouncilor = procouncil,
                                Treaserer = protreaser,
                                Secretary = prosecretary,
                                CommunityDetails = ComData,
                                AllMembers = allbrotherData,
                                provsuperiorcnt = prosuperior.Count(),
                                procouncilcnt = procouncil.Count(),
                                protreasecnt = protreaser.Count(),
                                proseccnt = prosecretary.Count(),
                                Outsideprovince = osprovince,
                                Outsideprovince1 = outdata1,
                                ospcount = osprovince.Count()
                            });

                        }
                    }

                    ViewBag.provincedata = allData.ToList();
#pragma warning disable CS0219 // The variable 'footer' is assigned but its value is never used
                    string footer = "--print-media-type --footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\"" +
#pragma warning restore CS0219 // The variable 'footer' is assigned but its value is never used
                       " --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";
                    //var provinceid = "Belg-BEL/1";
                    

                }
                //return new RazorPDF.PdfResult("PrintRazorpdf")
                //{
                //    //FileName = "FDLSReport.pdf",
                //    //PageMargins = new Rotativa.Options.Margins(10,5,10,5),
                //    //PageSize = Rotativa.Options.Size.A5,
                //    //PageOrientation = Rotativa.Options.Orientation.Portrait,
                //    //CustomSwitches = footer

                //};

                return new RazorPDF.PdfResult(allData.ToList(), "PrintRazorpdf");
                //return View();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                throw;
            }
        }

        public ActionResult PrintpdfusingItextsharp(string ProvinceId, string fromdate, string todate)
        {
            var configData = db.tblConfigSetting.Where(x => x.strPurpose == "ReportProvinceStatistic4").Select(x => new { x.strConfigKey, x.strConfigValue }).ToList();

            List<string> DyKey1 = new List<string>();
            List<string> DyKey2 = new List<string>();
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
                if (data1 != null)
                {
                    string[] tempList = data2[0].Split(',');
                    for (int i = 0; i < tempList.Count(); i++)
                    {
                        DyKey2.Add(tempList[i]);
                    }
                }
            }

            var provincelist = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").OrderBy(x => x.MyId).ToList();
            var totalprovince1 = provincelist.Count();
            var totalcount1 = totalprovince1 / 2;
            var pronamee = provincelist.Skip(0).Take(10).ToList();
            var proname1 = provincelist.Skip(totalcount1).Take(totalcount1).ToList();
            ViewBag.proname = pronamee;
            ViewBag.proname1 = proname1;

            string currentloginid = Convert.ToString(Session["loginuserid"]);
            var allData = new List<AllProvinceData>();
            var tblformationdetails = dbcont.Tbl_formationsDetails.ToList();
            var tblprimarydetails = dbcont.tbl_Primarydetails.ToList();
            var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
            var tblappointments = dbcont.Appointments.ToList();
            var tblcong = dbcont.Tbl_Cong.ToList();
            var provincesuperior = dbcont.Tbl_ProGeneralMember.ToList();
            var counsilprovince = dbcont.Tbl_ProGeneralCouncil.ToList();
            var treaserer = dbcont.Tbl_ProGeneralTreaserer.ToList();
            var secretary = dbcont.Tbl_ProGeneralSecretary.ToList();
            var tblcongdetails = dbcont.Tbl_Cong.ToList();

            if (ProvinceId != "")
            {
                var chcarstoremove = new string[] { "[", "]", "\"" };

                var tblprovince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
                string[] provincename = ProvinceId.Split(',');

                for (int i = 0; i < provincename.Count(); i++)
                {
                    int count = 0;
                    var prname = provincename[i];
                    foreach (var c in chcarstoremove)
                    {
                        prname = prname.Replace(c, string.Empty);
                    }

                    var provincedata = tblprovince.FirstOrDefault(x => x.Id.ToString() == prname);
                    if (provincedata != null)
                    {

                        //Province Superior
                        var provincialsuperior = provincesuperior.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> prosuperior = new List<ProvinceCouncil>();
                        foreach (var sup in provincialsuperior)
                        {
                            count = count + 1;
                            prosuperior.Add(new ProvinceCouncil
                            {
                                CouncilMember = sup.Name,
                                Designation = sup.Designation,
                                count = count
                            });
                        }

                        //Councile Province
                        var provincecouncil = counsilprovince.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> procouncil = new List<ProvinceCouncil>();
                        foreach (var cou in provincecouncil)
                        {
                            procouncil.Add(new ProvinceCouncil
                            {
                                CouncilMember = cou.Name,
                                Designation = cou.Designation
                            });
                        }

                        //treaserer
                        var treasererdetails = treaserer.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> protreaser = new List<ProvinceCouncil>();
                        foreach (var tre in treasererdetails)
                        {
                            protreaser.Add(new ProvinceCouncil
                            {
                                CouncilMember = tre.Name,
                                Designation = tre.Designation
                            });
                        }

                        //secretary
                        var secretarydetails = secretary.Where(x => x.ProvinceId == provincedata.Id.ToString() && x.Status == "0").ToList();
                        List<ProvinceCouncil> prosecretary = new List<ProvinceCouncil>();
                        foreach (var sec in secretarydetails)
                        {
                            prosecretary.Add(new ProvinceCouncil
                            {
                                CouncilMember = sec.Name,
                                Designation = sec.Designation
                            });
                        }

                        //community details
                        var allmember = tblprimarydetails.Where(x => x.ProvinceName == provincedata.Id.ToString()).ToList();
                        List<Appointments> allappodata = new List<Appointments>();
                        foreach (var appo in tblappointments)
                        {
                            if (appo.ProvinceName != null)
                            {
                                var proname = appo.ProvinceName.Split('|');
                                allappodata.Add(new Appointments
                                {
                                    Id = appo.Id,
                                    CommunityType = appo.CommunityType,
                                    Status = appo.Status,
                                    ProvinceName = proname[0],
                                    MemberId = appo.MemberId,
                                    Name = appo.Name,
                                    DesignationType = appo.DesignationType,
                                    AppointmentType = appo.AppointmentType
                                });
                            }

                        }
                        //outsideprovince
                        var outsideprovince = allappodata.Where(x => x.AppointmentType == "OSPro" && x.Status == "Active" && x.ProvinceName == provincedata.Id.ToString()).ToList();
                        var allmemberappo = allappodata.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Status == "Active").ToList();
                        //var allComAddress = tblcong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == item.Id.ToString()).OrderBy(x => x.Country).ToList();
                        var allComAddress = tblcong.Where(x => x.Status == 1 && x.ProvinceName == provincedata.Id.ToString()).OrderBy(x => x.CommCode).ToList();
                        List<CommunityDetails> ComData = new List<CommunityDetails>();
                        foreach (var item1 in allComAddress)
                        {
                            List<AppointmentsMember> brotherData = new List<AppointmentsMember>();
                            brotherData = (from fd in allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList()
                                           join pd in allmember on fd.MemberId equals pd.MemberId
                                           select new AppointmentsMember
                                           {
                                               MemberName = pd.Knowname,
                                               SurName = pd.SurName,
                                               Designation = fd.DesignationType,
                                               MemPhone = pd.mobilenumber,
                                               MemEmail = pd.emailid,
                                           }).ToList();

                            var totalprovince = brotherData.Count();
                            List<AppointmentsMember> data = new List<AppointmentsMember>();
                            List<AppointmentsMember> data1 = new List<AppointmentsMember>();
                            if (totalprovince > 10)
                            {
                                var totalcount = totalprovince / 2;
                                data = brotherData.Skip(0).Take(10).ToList();
                                data1 = brotherData.Skip(totalcount).Take(totalcount).ToList();
                            }
                            else
                            {
                                data = brotherData.ToList();
                            }


                            ComData.Add(new CommunityDetails
                            {
                                CommunityName = item1.CongregationName,
                                CommunityCode = item1.CommCode,
                                CommunityPlace = item1.Place,
                                CommunityAddress = item1.Address,
                                CommunityPhone = item1.Phone,
                                CommunityEmailId = item1.EmailId,
                                AppointmentsMember = data,
                                Appointment = data1,
                                CommunityCountry = item1.Country
                            });
                        }

                        //active members
                        var allmembersinpro = tblpersoneldetails.Where(x => x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes").ToList();
                        List<AllMembers> allbrotherData = new List<AllMembers>();
                        foreach (var members in allmembersinpro)
                        {
                            Tbl_Cong congs = new Tbl_Cong();

                            if (members.ProvinceName != null)
                            {
                                var allmembers = tblprimarydetails.LastOrDefault(x => x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString());
                                //var data = tblformationdetails.Where(x => x.MemberId == members.MemberID).ToList();
                                //var finalvowdata = data.FirstOrDefault(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == null &&  x.Archivecheck == null);
                                var finalvow = tblformationdetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                var Firstvows = tblformationdetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == provincedata.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                                var communitucode = tblappointments.FirstOrDefault(x => x.MemberId == members.MemberID && x.Status == "Active");
                                if (communitucode != null)
                                {
                                    congs = tblcongdetails.FirstOrDefault(x => x.CongregationName == communitucode.CommunityType);
                                }

                                allbrotherData.Add(new AllMembers
                                {
                                    ProMemberName = members.Name,
                                    ProSurName = members.SirName,
                                    DateOfBirth = allmembers == null ? string.Empty : allmembers.DOB,
                                    ProCountry = allmembers == null ? string.Empty : allmembers.country,
                                    ProFirstVows = Firstvows == null ? string.Empty : Firstvows.VowsDate,
                                    ProFinalVows = finalvow == null ? string.Empty : finalvow.VowsDate,
                                    ProMemCode = congs == null ? string.Empty : congs.CommCode
                                });
                            }
                        }
                        //outsideprovince
                        List<AppointmentsMember> osprovince = new List<AppointmentsMember>();
                        List<AppointmentsMember> outdata1 = new List<AppointmentsMember>();
                        List<Appointments> osprovince1 = new List<Appointments>();
                        List<Appointments> osprovince2 = new List<Appointments>();

                        var totalcounts = outsideprovince.Count() / 2;
                        osprovince1 = outsideprovince.Skip(0).Take(totalcounts).ToList();
                        osprovince2 = outsideprovince.Skip(totalcounts).Take(totalcounts).ToList();
                        foreach (var ospro in osprovince1)
                        {
                            var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                            //if(primarydata != null)
                            {
                                osprovince.Add(new AppointmentsMember
                                {
                                    MemberName = ospro.Name,
                                    SurName = primarydata == null ? string.Empty : primarydata.SurName
                                });
                            }

                        }
                        foreach (var ospro in osprovince2)
                        {
                            var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                            //if(primarydata != null)
                            {
                                outdata1.Add(new AppointmentsMember
                                {
                                    MemberName = ospro.Name,
                                    SurName = primarydata == null ? string.Empty : primarydata.SurName
                                });
                            }

                        }

                        allData.Add(new AllProvinceData
                        {
                            ProvinceName = provincedata.ProvinceName,
                            Provincecode = provincedata.Place,
                            Address = provincedata == null ? " " : provincedata.Place1,
                            Telephone = provincedata == null ? " " : provincedata.Phone,
                            EmailId = provincedata == null ? " " : provincedata.EmailId,
                            Fax = provincedata == null ? " " : provincedata.Fax,
                            ProvinceSuperior = prosuperior,
                            ProvinceCouncilor = procouncil,
                            Treaserer = protreaser,
                            Secretary = prosecretary,
                            CommunityDetails = ComData,
                            AllMembers = allbrotherData,
                            provsuperiorcnt = prosuperior.Count(),
                            procouncilcnt = procouncil.Count(),
                            protreasecnt = protreaser.Count(),
                            proseccnt = prosecretary.Count(),
                            Outsideprovince = osprovince,
                            Outsideprovince1 = outdata1,
                            ospcount = osprovince.Count()
                        });

                    }
                }

                ViewBag.provincedata = allData.ToList();
#pragma warning disable CS0219 // The variable 'footer' is assigned but its value is never used
                string footer = "--print-media-type --footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\"" +
#pragma warning restore CS0219 // The variable 'footer' is assigned but its value is never used
                   " --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";
                //var provinceid = "Belg-BEL/1";
                var resultdata = allData.ToList();
                var htmlviewstr = Renderviewtostring(ControllerContext, "~/Views/Directory2/Printdata.cshtml", resultdata);

                using (MemoryStream stream = new MemoryStream())
                {
                    StringReader sr = new StringReader(htmlviewstr);
                    Document pdfDoc = new Document(PageSize.A5, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    return File(stream.ToArray(), "application/pdf", "ProvinceReport.pdf");
                }

            }
            else
            {
                var tblsuperiorgeneral = dbcont.GeneralMember.ToList();
                var tblcongregation = dbcont.tbl_Congregation.ToList();
                var tbltreaserer = dbcont.GeneralTreasurer.ToList();
                var tblsecretary = dbcont.GeneralSecretary.ToList();
                var tblprovince = dbcont.tbl_Province.FirstOrDefault(x => x.ProvinceName.ToLower() == "Administration Centrale".ToLower() || x.ProvinceName.ToLower() == "CENTRAL ADMINISTRATION");

                var allgeneraldata = new List<AllProvinceData>();
                ProvinceCouncil Generaltreaserer = new ProvinceCouncil();
                ProvinceCouncil superiorgeneral = new ProvinceCouncil();
                ProvinceCouncil GeneralSecretary = new ProvinceCouncil();
                ProvinceCouncil totalmember = new ProvinceCouncil();

                var allProvince = dbcont.tbl_Congregation.FirstOrDefault(x => x.FamilyBelongsTo == null);

                var allCouncil = db.MeetingMinutes.Where(x => x.GenId == allProvince.Id.ToString()).ToList();
                List<ProvinceCouncil> allData1 = new List<ProvinceCouncil>();
                foreach (var items in allCouncil)
                {
                    string[] names = items.Name.Split(' ');
                    string name = names[0];
                    var allmember = dbcont.tbl_Primarydetails.ToList().LastOrDefault(x => x.Knowname == name);

                    allData1.Add(new ProvinceCouncil
                    {
                        CouncilMember = items.Name,
                        MemPhone = allmember == null ? string.Empty : allmember.mobilenumber,
                        MemEmail = allmember == null ? string.Empty : allmember.emailid,
                        Designation = items.Designation,
                    });
                }


                //superior General
                var generalsuperior = tblsuperiorgeneral.FirstOrDefault(x => x.GenId == allProvince.Id.ToString() && x.Status =="0");
                string[] spnames = generalsuperior.Name.Split(' ');
                string sprname = spnames[0];
                var memberdetails = tblprimarydetails.FirstOrDefault(x => x.Knowname == sprname);

                superiorgeneral.CouncilMember = generalsuperior.Name;
                superiorgeneral.MemPhone = memberdetails == null ? string.Empty : memberdetails.mobilenumber;
                superiorgeneral.MemEmail = memberdetails == null ? string.Empty : memberdetails.emailid;
                superiorgeneral.Designation = generalsuperior.Designation;

                //treaserer
                var generaltreaserer = tbltreaserer.FirstOrDefault(x => x.GenId == allProvince.Id.ToString());
                if (generaltreaserer != null)
                {
                    string[] trname = generaltreaserer.Name.Split(' ');
                    string trename = trname[0];
                    var treaserermember = tblprimarydetails.FirstOrDefault(x => x.Knowname == trename);
                    Generaltreaserer.CouncilMember = generaltreaserer.Name;
                    Generaltreaserer.MemPhone = treaserermember == null ? string.Empty : treaserermember.mobilenumber;
                    Generaltreaserer.MemEmail = treaserermember == null ? string.Empty : treaserermember.emailid;
                    Generaltreaserer.Designation = generaltreaserer.Designation;
                }

                //Secretary
                var generalsecretary = tblsecretary.FirstOrDefault(x => x.GenId == allProvince.Id.ToString());
                if (generalsecretary != null)
                {
                    string[] sename = generalsecretary.Name.Split(' ');
                    string srname = sename[0];
                    var secretarymember = tblprimarydetails.FirstOrDefault(x => x.Knowname == srname);
                    GeneralSecretary.CouncilMember = generalsecretary.Name;
                    GeneralSecretary.MemEmail = secretarymember == null ? string.Empty : secretarymember.mobilenumber;
                    GeneralSecretary.MemEmail = secretarymember == null ? string.Empty : secretarymember.emailid;
                    GeneralSecretary.Designation = generalsecretary.Designation;
                }



                allgeneraldata.Add(new AllProvinceData
                {
                    superiorgeneral = superiorgeneral,
                    Generaltreaserer = Generaltreaserer,
                    GeneralSecretary = GeneralSecretary,
                    Generalcouncil = allData1,
                    ProvinceName = tblprovince.ProvinceName,
                    Provincecode = tblprovince.Place,
                    Congregation = allProvince.CongregationName,
                    Congregation_id = allProvince.CongreId,
                    Congregation_Country = allProvince.Country,
                    Address = allProvince.Address,
                    Telephone = allProvince.Phone,
                    EmailId = allProvince.Email,
                    Fax = allProvince.Fax,
                    website = allProvince.Website,

                });


                //provincedata
                foreach (var item in provincelist)
                {
                    var allCouncil1 = db.Tbl_ProvinceCouncil.Where(x => x.ProvinceName == item.Id.ToString()).ToList();

                    List<ProvinceCouncil> allData11 = new List<ProvinceCouncil>();
                    foreach (var items in allCouncil1)
                    {
                        allData1.Add(new ProvinceCouncil
                        {
                            CouncilMember = items.MemberName,
                            Designation = items.DesignationName,
                        });
                    }
                    //Province Superior
                    var provincialsuperior = provincesuperior.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> prosuperior = new List<ProvinceCouncil>();
                    foreach (var sup in provincialsuperior)
                    {
                        prosuperior.Add(new ProvinceCouncil
                        {
                            CouncilMember = sup.Name,
                            Designation = sup.Designation
                        });
                    }

                    //Councile Province
                    var provincecouncil = counsilprovince.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> procouncil = new List<ProvinceCouncil>();
                    foreach (var cou in provincecouncil)
                    {
                        procouncil.Add(new ProvinceCouncil
                        {
                            CouncilMember = cou.Name,
                            Designation = cou.Designation
                        });
                    }

                    //treaserer
                    var treasererdetails = treaserer.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> protreaser = new List<ProvinceCouncil>();
                    foreach (var tre in treasererdetails)
                    {
                        protreaser.Add(new ProvinceCouncil
                        {
                            CouncilMember = tre.Name,
                            Designation = tre.Designation
                        });
                    }

                    //secretary
                    var secretarydetails = secretary.Where(x => x.ProvinceId == item.Id.ToString() && x.Status == "0").ToList();
                    List<ProvinceCouncil> prosecretary = new List<ProvinceCouncil>();
                    foreach (var sec in secretarydetails)
                    {
                        prosecretary.Add(new ProvinceCouncil
                        {
                            CouncilMember = sec.Name,
                            Designation = sec.Designation
                        });
                    }

                    // var allforcomname = dbcont.Tbl_formationsDetails.Where(x => x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.ProvinceName == item.Id.ToString()).ToList();
                    var allmember = tblprimarydetails.Where(x => x.ProvinceName == item.Id.ToString()).ToList();
                    List<Appointments> allappodata = new List<Appointments>();
                    foreach (var appo in tblappointments)
                    {
                        if (appo.ProvinceName != null)
                        {
                            var proname = appo.ProvinceName.Split('|');
                            allappodata.Add(new Appointments
                            {
                                Id = appo.Id,
                                CommunityType = appo.CommunityType,
                                Status = appo.Status,
                                ProvinceName = proname[0],
                                MemberId = appo.MemberId,
                                Name = appo.Name,
                                DesignationType = appo.DesignationType
                            });
                        }

                    }
                    //outsideprovince
                    var outsideprovince = allappodata.Where(x => x.AppointmentType == "OSPro" && x.Status == "Active" && x.ProvinceName == item.Id.ToString()).ToList();

                    var allmemberappo = allappodata.Where(x => x.ProvinceName == item.Id.ToString() && x.Status == "Active").ToList();
                    //var allComAddress = tblcong.Where(x => x.ActiveCkeck == "Active" && x.ProvinceName == item.Id.ToString()).OrderBy(x => x.Country).ToList();
                    var allComAddress = tblcong.Where(x => x.Status == 1 && x.ProvinceName == item.Id.ToString()).ToList();
                    List<CommunityDetails> ComData = new List<CommunityDetails>();
                    foreach (var item1 in allComAddress)
                    {

                        List<AppointmentsMember> brotherData = new List<AppointmentsMember>();
                        brotherData = (from fd in allmemberappo.Where(x => x.CommunityType == item1.CongregationName).ToList()
                                       join pd in allmember on fd.MemberId equals pd.MemberId
                                       select new AppointmentsMember
                                       {
                                           MemberName = pd.Knowname,
                                           SurName = pd.SurName,
                                           Designation = fd.DesignationType,
                                           MemPhone = pd.mobilenumber,
                                           MemEmail = pd.emailid,
                                       }).ToList();

                        var totalprovince = brotherData.Count();
                        List<AppointmentsMember> data = new List<AppointmentsMember>();
                        List<AppointmentsMember> data1 = new List<AppointmentsMember>();
                        if (totalprovince > 10)
                        {

                        var totalcount = totalprovince / 2;
                        data = brotherData.Skip(0).Take(10).ToList();
                         data1 = brotherData.Skip(totalcount).Take(totalcount).ToList();
                        }
                        else
                        {
                            data = brotherData.ToList();

                        }


                        

                        ComData.Add(new CommunityDetails
                        {
                            CommunityName = item1.CongregationName,
                            CommunityCode = item1.CommCode,
                            CommunityPlace = item1.Place,
                            CommunityAddress = item1.Address,
                            CommunityPhone = item1.Phone,
                            CommunityEmailId = item1.EmailId,
                            AppointmentsMember = data,
                            Appointment = data1,
                            CommunityCountry = item1.Country
                        });
                    }

                    var allmembersinpro = tblpersoneldetails.Where(x => x.ProvinceName == item.Id.ToString() && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null && x.IsTransfer != "yes").ToList();
                    List<AllMembers> allbrotherData = new List<AllMembers>();
                    foreach (var members in allmembersinpro)
                    {
                        Tbl_Cong congs = new Tbl_Cong();

                        if (members.ProvinceName != null)
                        {
                            var allmembers = tblprimarydetails.LastOrDefault(x => x.MemberId == members.MemberID && x.ProvinceName == item.Id.ToString());
                            //var data = tblformationdetails.Where(x => x.MemberId == members.MemberID).ToList();
                            //var finalvowdata = data.FirstOrDefault(x => DyKey1.Contains(x.StageOfFormation) && x.Diedcheck == null &&  x.Archivecheck == null);
                            var finalvow = dbcont.Tbl_formationsDetails.Where(x => DyKey1.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == item.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                            var Firstvows = dbcont.Tbl_formationsDetails.Where(x => DyKey2.Contains(x.StageOfFormation) && x.MemberId == members.MemberID && x.ProvinceName == item.Id.ToString() && x.Diedcheck == null && x.Archivecheck == null).FirstOrDefault();
                            var communitucode = tblappointments.FirstOrDefault(x => x.MemberId == members.MemberID && x.Status == "Active");
                            if (communitucode != null)
                            {
                                congs = tblcongdetails.FirstOrDefault(x => x.CongregationName == communitucode.CommunityType);
                            }

                            allbrotherData.Add(new AllMembers
                            {
                                ProMemberName = members.Name,
                                ProSurName = members.SirName,
                                DateOfBirth = allmembers == null ? string.Empty : allmembers.DOB,
                                ProCountry = allmembers == null ? string.Empty : allmembers.country,
                                ProFirstVows = Firstvows == null ? string.Empty : Firstvows.VowsDate,
                                ProFinalVows = finalvow == null ? string.Empty : finalvow.VowsDate,
                                ProMemCode = congs == null ? string.Empty : congs.CommCode
                            });
                        }
                    }

                    var allProCommission = dbcont.tbl_ProCommission.Where(x => x.ProId == item.MyId).ToList();
                    var afterGroup = allProCommission.GroupBy(x => x.ResponsibilityName).Select(x => x).ToList();
                    var Responsibility = new List<Responsibility>();
                    foreach (var item1 in afterGroup)
                    {
                        string key = item1.Key;
                        List<ProvinceComission> memberdata = new List<ProvinceComission>();
                        foreach (var item2 in item1.OrderBy(x => x.DesignationName))
                        {
                            string[] names = item2.MemberName.Split(' ');
                            string name = names[0];
                            var allmember1 = tblprimarydetails.LastOrDefault(x => x.Knowname.Contains(name));

                            memberdata.Add(new ProvinceComission
                            {
                                ComisMemName = item2.MemberName,
                                ComisDesignation = item2.DesignationName,
                                ComisAddress = allmember1 == null ? "" : allmember1.city,
                                ComisPlace = allmember1 == null ? "" : allmember1.district,
                                Comisstate = allmember1 == null ? "" : allmember1.state,
                                ComisPin = allmember1 == null ? "" : allmember1.pin,
                                ComisCountry = allmember1 == null ? "" : allmember1.country,
                                ComisEmail = allmember1 == null ? "" : allmember1.emailid,
                                ComisTelephone = allmember1 == null ? "" : allmember1.mobilenumber,
                            });
                        }
                        Responsibility.Add(new Responsibility
                        {
                            ResponsibilityName = key,
                            ProvinceComission = memberdata
                        });
                    }

                    List<AppointmentsMember> osprovince = new List<AppointmentsMember>();
                    List<AppointmentsMember> outdata1 = new List<AppointmentsMember>();
                    List<Appointments> osprovince1 = new List<Appointments>();
                    List<Appointments> osprovince2 = new List<Appointments>();

                    var totalcounts = outsideprovince.Count() / 2;
                    osprovince1 = outsideprovince.Skip(0).Take(totalcounts).ToList();
                    osprovince2 = outsideprovince.Skip(totalcounts).Take(totalcounts).ToList();
                    foreach (var ospro in osprovince1)
                    {
                        var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                        //if(primarydata != null)
                        {
                            osprovince.Add(new AppointmentsMember
                            {
                                MemberName = ospro.Name,
                                SurName = primarydata == null ? string.Empty : primarydata.SurName
                            });
                        }

                    }
                    foreach (var ospro in osprovince2)
                    {
                        var primarydata = tblprimarydetails.FirstOrDefault(x => x.MemberId == ospro.MemberId);
                        //if(primarydata != null)
                        {
                            outdata1.Add(new AppointmentsMember
                            {
                                MemberName = ospro.Name,
                                SurName = primarydata == null ? string.Empty : primarydata.SurName
                            });
                        }

                    }

                    allData.Add(new AllProvinceData
                    {
                        ProvinceName = item.ProvinceName,
                        Provincecode = item.Place,
                        Address = item == null ? " " : item.Place1,
                        Telephone = item == null ? " " : item.Phone,
                        EmailId = item == null ? " " : item.EmailId,
                        Fax = item == null ? " " : item.Fax,
                        ProvinceSuperior = prosuperior,
                        ProvinceCouncilor = procouncil,
                        ProvinceCouncils = allData1,
                        Treaserer = protreaser,
                        Secretary = prosecretary,
                        CommunityDetails = ComData,
                        AllMembers = allbrotherData,
                        Responsibility = Responsibility,
                        provsuperiorcnt = prosuperior.Count(),
                        procouncilcnt = procouncil.Count(),
                        protreasecnt = protreaser.Count(),
                        proseccnt = prosecretary.Count(),
                        Outsideprovince = osprovince,
                        Outsideprovince1 = outdata1,
                        ospcount = osprovince.Count()
                    });
                }

                ViewBag.Generalatedata = allgeneraldata.ToList();
                ViewBag.Provincedata = allData.ToList();

                var resultdata = allData.ToList();
                var htmlviewstr = Renderviewtostring(ControllerContext, "~/Views/Directory2/PrintGenereralatedata.cshtml", resultdata);

                using (MemoryStream stream = new MemoryStream())
                {
                    StringReader sr = new StringReader(htmlviewstr);
                    Document pdfDoc = new Document(PageSize.A5, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    return File(stream.ToArray(), "application/pdf", "ProvinceReport.pdf");
                }


            }


        }
        static string Renderviewtostring(ControllerContext context, string viewpath,object model = null)
        {
            ViewEngineResult viewEngineResult = null;
            viewEngineResult = ViewEngines.Engines.FindView(context, viewpath, null);

            if(viewEngineResult == null)
            {
                throw new System.IO.FileNotFoundException("View Cannot be found");
            }

            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }
            return result;
        }

        public class AllGeneralatedata1
        {
            public string GeneralateName { get; set; }
            public string Address { get; set; }
            public string Telephone { get; set; }
            public string EmailId { get; set; }
            public string Fax { get; set; }
            public string website { get; set; }
            public string Country { get; set; }
        }

    }
}