using ClosedXML.Excel;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    public class UtilitiesController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: Utilities
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Utilities()
        {
            return View();
        }
        public string UploadMemberExcelFile(string province, string utilities)
        {
#pragma warning disable CS0219 // The variable 'status' is assigned but its value is never used
            int status = 0;
#pragma warning restore CS0219 // The variable 'status' is assigned but its value is never used
            string ErrorList = "";

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
                                    return "0";
                                }
                                IXLWorksheet WorkSheet = null;
                                try
                                {
                                    WorkSheet = Workbook.Worksheet("sheet1");
                                }
                                catch
                                {
                                    return "0";
                                }
                                WorkSheet.FirstRow().Delete();

                                if (utilities == "Primary")
                                {
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();
                                        tbl_Primarydetails tbl_Primarydetails = new tbl_Primarydetails();
                                        tbl_Primarydetails.Baptismialname = row.Cell(2).Value.ToString();
                                        tbl_Primarydetails.country = row.Cell(3).Value.ToString();
                                        tbl_Primarydetails.Continent = row.Cell(4).Value.ToString();
                                        tbl_Primarydetails.DOB = row.Cell(5).Value.ToString();
                                        tbl_Primarydetails.placeinfamily = row.Cell(6).Value.ToString();
                                        tbl_Primarydetails.Bloodgroup = row.Cell(7).Value.ToString();
                                        tbl_Primarydetails.Nationality = row.Cell(8).Value.ToString();
                                        tbl_Primarydetails.noofbrother = row.Cell(9).Value.ToString();
                                        tbl_Primarydetails.homeparish = row.Cell(10).Value.ToString();
                                        tbl_Primarydetails.Will = row.Cell(11).Value.ToString();
                                        tbl_Primarydetails.Congregation = row.Cell(12).Value.ToString();
                                        tbl_Primarydetails.placeofbirth = row.Cell(13).Value.ToString();
                                        tbl_Primarydetails.LangSpocken = row.Cell(14).Value.ToString();
                                        tbl_Primarydetails.Feastday = row.Cell(15).Value.ToString();
                                        tbl_Primarydetails.Ordination = row.Cell(16).Value.ToString();
                                        tbl_Primarydetails.emailid = row.Cell(17).Value.ToString();
                                        tbl_Primarydetails.mobilenumber = row.Cell(18).Value.ToString();
                                        tbl_Primarydetails.noofsisters = row.Cell(19).Value.ToString();
                                        tbl_Primarydetails.homediocese = row.Cell(20).Value.ToString();
                                        tbl_Primarydetails.pin = row.Cell(21).Value.ToString();
                                        tbl_Primarydetails.city = row.Cell(22).Value.ToString();
                                        tbl_Primarydetails.district = row.Cell(23).Value.ToString();
                                        tbl_Primarydetails.state = row.Cell(24).Value.ToString();
                                        tbl_Primarydetails.adhar = row.Cell(25).Value.ToString();
                                        tbl_Primarydetails.nameonadhar = row.Cell(26).Value.ToString();
                                        tbl_Primarydetails.passport = row.Cell(27).Value.ToString();
                                        tbl_Primarydetails.nameonpassport = row.Cell(28).Value.ToString();
                                        tbl_Primarydetails.MemberId = row.Cell(29).Value.ToString();
                                        tbl_Primarydetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                        var dataget = dbcont.tbl_PersonalDetails.ToList().LastOrDefault(x => x.MemberID == tbl_Primarydetails.MemberId);
                                        if (dataget != null)
                                        {
                                            tbl_Primarydetails.Knowname = dataget.Name;
                                            tbl_Primarydetails.SurName = dataget.SirName;
                                        }
                                        tbl_Primarydetails.ProvinceName = province;
                                        dbcont.tbl_Primarydetails.Add(tbl_Primarydetails);
                                        dbcont.SaveChanges();
                                    }
                                }
                                if (utilities == "Family")
                                {
                                    var tblpersoneldata = dbcont.tbl_PersonalDetails.ToList();
                                    var tblfamilydata = dbcont.Tbl_formationsDetails.ToList();



                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();
                                        var fileno = row.Cell(2).Value.ToString();
                                        var name = row.Cell(1).Value.ToString();
                                        var mobile = row.Cell(3).Value.ToString();
                                        var address = row.Cell(4).Value.ToString();


                                        var personeldata = tblpersoneldata.FirstOrDefault(x => x.FileNo == fileno);

                                        if (personeldata != null)
                                        {
                                            var familydata = tblfamilydata.FirstOrDefault(x => x.MemberId == personeldata.MemberID);

                                            if (familydata == null)
                                            {
                                                FamilyDetails FamilyDetails = new FamilyDetails();
                                                FamilyDetails.MemberId = personeldata.MemberID;
                                                FamilyDetails.Name = name;
                                                FamilyDetails.Mobile = mobile;
                                                FamilyDetails.Address = address;
                                                FamilyDetails.ProvinceName = personeldata.ProvinceName;
                                                FamilyDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                                FamilyDetails.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");

                                                dbcont.FamilyDetails.Add(FamilyDetails);
                                                dbcont.SaveChanges();

                                            }
                                        }
                                    }
                                }
                                if (utilities == "Sacrament")
                                {
                                    var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
                                    var tblsacrements = dbcont.Sacraments.ToList();


                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();

                                        var fileno = row.Cell(2).Value.ToString();
                                        var name = row.Cell(1).Value.ToString();
                                        var sacre = row.Cell(3).Value.ToString();
                                        var parishname = row.Cell(4).Value.ToString();

                                        var personeldata = tblpersoneldetails.FirstOrDefault(x => x.FileNo == fileno);
                                        if (personeldata != null)
                                        {
                                            var sacrementdata = tblsacrements.FirstOrDefault(x => x.MemberId == personeldata.MemberID);
                                            if (sacrementdata == null)
                                            {
                                                Sacraments Sacraments = new Sacraments();
                                                Sacraments.MemberId = personeldata.MemberID;
                                                Sacraments.Name = name;
                                                Sacraments.Sacrament = sacre;
                                                Sacraments.Remarks = parishname;

                                                dbcont.Sacraments.Add(Sacraments);
                                                dbcont.SaveChanges();

                                            }
                                        }


                                    }
                                }
                                if (utilities == "Health")
                                {
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();
                                        tbl_Health tbl_Health = new tbl_Health();
                                        tbl_Health.FromDate = row.Cell(2).Value.ToString();
                                        tbl_Health.ToDate = row.Cell(3).Value.ToString();
                                        tbl_Health.Complaint = row.Cell(4).Value.ToString();
                                        tbl_Health.Doctor = row.Cell(5).Value.ToString();
                                        tbl_Health.Diagnosis = row.Cell(6).Value.ToString();
                                        tbl_Health.Hospital = row.Cell(7).Value.ToString();
                                        tbl_Health.MemberID = row.Cell(8).Value.ToString();
                                        tbl_Health.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                        var Getdata = dbcont.tbl_PersonalDetails.ToList().LastOrDefault(x => x.MemberID == tbl_Health.MemberID);
                                        if (Getdata != null)
                                        {
                                            tbl_Health.Name = Getdata.Name;
                                        }
                                        tbl_Health.ProvinceName = province;
                                        dbcont.tbl_Health.Add(tbl_Health);
                                        dbcont.SaveChanges();
                                    }
                                }
                                if (utilities == "Formation")
                                {

                                    int RowNumber = 0;
                                    var colNameRow = WorkSheet.FirstRow();


                                    var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
                                    var tblProfessionDetails = dbcont.Tbl_ProfessionDetails.ToList();
                                    var tblformationdeails = dbcont.Tbl_formationsDetails.ToList();



                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
#pragma warning disable CS0219 // The variable 'ValidRow' is assigned but its value is never used
                                        int ValidRow = 1;
#pragma warning restore CS0219 // The variable 'ValidRow' is assigned but its value is never used

                                        RowNumber++;
                                        if (true)// (RowNumber != 1)
                                        {
                                            var vowsdate = "";
                                            var fromdate = "";
                                            row.Cell(1).Value.ToString();

                                            var fileno = row.Cell(1).Value.ToString();
                                            var date = row.Cell(3).Value.ToString();

                                            if (date.Contains('-'))
                                                date.Replace('-', '/');
                                            var remarks = row.Cell(4).Value.ToString();
                                            var status1 = row.Cell(6).Value.ToString();
                                            var stageofformation = row.Cell(7).Value.ToString();
                                            if (date == null)
                                            {
                                                ValidRow = 0;
                                                ErrorList += "Invalid" + colNameRow.Cell(3).Value.ToString() + "In rowno" + (RowNumber - 1) + "<br />";
                                            }

                                            var personeldata = tblpersoneldetails.FirstOrDefault(x => x.FileNo == fileno);
                                            stageofformation = tblProfessionDetails.FirstOrDefault(x => x.Name == stageofformation) == null ? stageofformation : tblProfessionDetails.FirstOrDefault(x => x.Name == stageofformation).Id.ToString();
                                            if (personeldata != null)
                                            {
                                                var formationdata = tblformationdeails.FirstOrDefault(x => x.MemberId == personeldata.MemberID && x.StageOfFormation == stageofformation);
                                                if (formationdata == null)
                                                {
                                                    if (stageofformation == "5" || stageofformation == "6")
                                                    {
                                                        vowsdate = date;
                                                    }
                                                    else
                                                    {
                                                        fromdate = date;
                                                    }
                                                    Tbl_formationsDetails Tbl_formationsDetails = new Tbl_formationsDetails();
                                                    Tbl_formationsDetails.MemberId = personeldata.MemberID;
                                                    Tbl_formationsDetails.StageOfFormation = stageofformation;
                                                    Tbl_formationsDetails.Name = personeldata.Name;
                                                    Tbl_formationsDetails.FromDate = fromdate;
                                                    Tbl_formationsDetails.VowsDate = vowsdate;
                                                    Tbl_formationsDetails.Status = status1;
                                                    Tbl_formationsDetails.Description = remarks;
                                                    Tbl_formationsDetails.ProvinceName = personeldata.ProvinceName;
                                                    dbcont.Tbl_formationsDetails.Add(Tbl_formationsDetails);
                                                    dbcont.SaveChanges();



                                                    //CultureInfo provider = CultureInfo.InvariantCulture;
                                                    //// It throws Argument null exception  
                                                    //DateTime VowsDt = DateTime.ParseExact(Tbl_formationsDetails.VowsDate, "yyyy/MM/dddd", provider);


                                                    Tbl_formationsStatusYear Tbl_formationsStatusYear = new Tbl_formationsStatusYear();
                                                    Tbl_formationsStatusYear.formationsDetailsId = Tbl_formationsDetails.Id;
                                                    Tbl_formationsStatusYear.MemberId = Tbl_formationsDetails.MemberId;
                                                    Tbl_formationsStatusYear.Status = status1;
                                                    //Tbl_formationsStatusYear.StatusDate = row.Cell(5).Value.ToString();
                                                    Tbl_formationsStatusYear.StatusYear = row.Cell(5).Value.ToString().Split(' ')[0];
                                                    //Tbl_formationsStatusYear.StatusYear = row.Cell(5).Value.ToString().Split(' ')[0].Split('/')[2];
                                                    Tbl_formationsStatusYear.CreatedDate = DateTime.Now.ToShortDateString();
                                                    dbcont.Tbl_formationsStatusYear.Add(Tbl_formationsStatusYear);
                                                    dbcont.SaveChanges();

                                                }
                                                else
                                                {
                                                    //CultureInfo provider = CultureInfo.InvariantCulture;
                                                    //DateTime VowsDt = DateTime.ParseExact(formationdata.VowsDate, "yyyy/MM/dddd", provider);


                                                    Tbl_formationsStatusYear Tbl_formationsStatusYear = new Tbl_formationsStatusYear();
                                                    Tbl_formationsStatusYear.formationsDetailsId = formationdata.Id;
                                                    Tbl_formationsStatusYear.MemberId = formationdata.MemberId;
                                                    Tbl_formationsStatusYear.Status = status1;
                                                    //Tbl_formationsStatusYear.StatusDate = row.Cell(5).Value.ToString();
                                                    Tbl_formationsStatusYear.StatusYear = row.Cell(5).Value.ToString().Split(' ')[0];
                                                    //Tbl_formationsStatusYear.StatusYear = row.Cell(5).Value.ToString().Split(' ')[0].Split('/')[2];
                                                    Tbl_formationsStatusYear.CreatedDate = DateTime.Now.ToShortDateString();
                                                    dbcont.Tbl_formationsStatusYear.Add(Tbl_formationsStatusYear);
                                                    dbcont.SaveChanges();
                                                }
                                            }
                                            else
                                            {
                                                ValidRow = 0;
                                                ErrorList += "Invalid" + colNameRow.Cell(2).Value.ToString() + "In rowno" + (RowNumber - 1) + "<br />";

                                            }

                                        }
                                    }
                                }



                                if (utilities == "Academics")
                                {
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();//Get ist cell. 1 represent column number
                                        tbl_Academy tbl_Academy = new tbl_Academy();
                                        tbl_Academy.fromdate = row.Cell(2).Value.ToString();
                                        tbl_Academy.todate = row.Cell(3).Value.ToString();
                                        tbl_Academy.course = row.Cell(4).Value.ToString();
                                        tbl_Academy.degree = row.Cell(5).Value.ToString();
                                        tbl_Academy.university = row.Cell(6).Value.ToString();
                                        tbl_Academy.remark = row.Cell(7).Value.ToString();
                                        tbl_Academy.adress = row.Cell(8).Value.ToString();
                                        tbl_Academy.Description = row.Cell(9).Value.ToString();
                                        tbl_Academy.MemberId = row.Cell(10).Value.ToString();
                                        tbl_Academy.ProvinceName = province;
                                        tbl_Academy.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                        dbcont.tbl_Academy.Add(tbl_Academy);
                                        dbcont.SaveChanges();
                                    }
                                }
                                if (utilities == "Appointment")
                                {
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();
                                        Appointments Appointments = new Appointments();
                                        Appointments.FromDate = row.Cell(2).Value.ToString();
                                        Appointments.ToDate = row.Cell(3).Value.ToString();
                                        Appointments.DesignationType = row.Cell(4).Value.ToString();
                                        Appointments.CommunityType = row.Cell(5).Value.ToString();
                                        Appointments.Description = row.Cell(6).Value.ToString();
                                        Appointments.MemberId = row.Cell(7).Value.ToString();
                                        Appointments.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                        var Getdata = dbcont.tbl_PersonalDetails.ToList().LastOrDefault(x => x.MemberID == Appointments.MemberId);
                                        if (Getdata != null)
                                        {
                                            Appointments.Name = Getdata.Name;
                                        }
                                        Appointments.ProvinceName = province;
                                        dbcont.Appointments.Add(Appointments);
                                        dbcont.SaveChanges();
                                    }
                                }
                                if (utilities == "Remarks")
                                {
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();//Get ist cell. 1 represent column number
                                        Tbl_Complains Tbl_Complains = new Tbl_Complains();
                                        Tbl_Complains.MyDate = row.Cell(2).Value.ToString();
                                        Tbl_Complains.Title = row.Cell(3).Value.ToString();
                                        Tbl_Complains.NatureofTheComplaint = row.Cell(4).Value.ToString();
                                        Tbl_Complains.ComplaintReceived = row.Cell(5).Value.ToString();
                                        Tbl_Complains.Discription = row.Cell(6).Value.ToString();
                                        Tbl_Complains.Decision = row.Cell(7).Value.ToString();
                                        Tbl_Complains.InvolvedIn = row.Cell(8).Value.ToString();
                                        Tbl_Complains.MemberId = row.Cell(9).Value.ToString();
                                        Tbl_Complains.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                        var Getdata = dbcont.tbl_PersonalDetails.ToList().LastOrDefault(x => x.MemberID == Tbl_Complains.MemberId);
                                        if (Getdata != null)
                                        {
                                            Tbl_Complains.MemberName = Getdata.Name;
                                        }
                                        Tbl_Complains.ProvinceName = province;
                                        dbcont.Tbl_Complains.Add(Tbl_Complains);
                                        dbcont.SaveChanges();
                                    }
                                }
                                if (utilities == "Retirement")
                                {
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();
                                        tbl_Retirement tbl_Retirement = new tbl_Retirement();
                                        tbl_Retirement.DOR = row.Cell(2).Value.ToString();
                                        tbl_Retirement.Age = row.Cell(3).Value.ToString();
                                        tbl_Retirement.Reason = row.Cell(4).Value.ToString();
                                        tbl_Retirement.Remarks = row.Cell(5).Value.ToString();
                                        tbl_Retirement.MemberID = row.Cell(6).Value.ToString();
                                        tbl_Retirement.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                        var Getdata = dbcont.tbl_PersonalDetails.ToList().LastOrDefault(x => x.MemberID == tbl_Retirement.MemberID);
                                        if (Getdata != null)
                                        {
                                            tbl_Retirement.Name = Getdata.Name;
                                            tbl_Retirement.SirName = Getdata.SirName;
                                            tbl_Retirement.Community = Getdata.CurrentCommunity;
                                        }
                                        tbl_Retirement.ProvinceName = province;
                                        dbcont.tbl_Retirement.Add(tbl_Retirement);
                                        dbcont.SaveChanges();
                                    }
                                }
                                if (utilities == "Insurance")
                                {
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();//Get ist cell. 1 represent column number
                                        tbl_Insurance tbl_Insurance = new tbl_Insurance();
                                        tbl_Insurance.Title = row.Cell(2).Value.ToString();
                                        tbl_Insurance.Date = row.Cell(3).Value.ToString();
                                        tbl_Insurance.Premium = row.Cell(4).Value.ToString();
                                        tbl_Insurance.Ammount = row.Cell(5).Value.ToString();
                                        tbl_Insurance.Description = row.Cell(6).Value.ToString();
                                        tbl_Insurance.MemberId = row.Cell(7).Value.ToString();
                                        tbl_Insurance.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                        var Getdata = dbcont.tbl_PersonalDetails.ToList().LastOrDefault(x => x.MemberID == tbl_Insurance.MemberId);
                                        if (Getdata != null)
                                        {
                                            tbl_Insurance.Name = Getdata.Name;
                                        }
                                        tbl_Insurance.ProvinceName = province;
                                        dbcont.tbl_Insurance.Add(tbl_Insurance);
                                        dbcont.SaveChanges();
                                    }
                                }
                                if (utilities == "Separation")
                                {
                                    int RowNumber = 0;
                                    var colNameRow = WorkSheet.FirstRow();



                                    var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
                                    //var appointments = dbcont.Appointments.ToList();
                                    var formationdetails = dbcont.Tbl_formationsDetails.ToList();
                                    //var retirement = dbcont.tbl_Retirement.ToList();
                                    //var renewal = dbcont.Tbl_RenewalVows.ToList();
                                    var tblsepration = dbcont.tbl_SeperationFromTheCongregation.ToList();
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {

#pragma warning disable CS0219 // The variable 'ValidRow' is assigned but its value is never used
                                        int ValidRow = 1;
#pragma warning restore CS0219 // The variable 'ValidRow' is assigned but its value is never used
                                        RowNumber++;

                                        row.Cell(1).Value.ToString();//Get ist cell. 1 represent column number
                                        var FileNo = row.Cell(1).Value.ToString();
                                        var name = row.Cell(3).Value.ToString();
                                        var title = row.Cell(4).Value.ToString();
                                        var seprationdate = row.Cell(5).Value.ToString();
                                        var descriptio = row.Cell(6).Value.ToString();
                                        if (seprationdate.Contains('-'))
                                            seprationdate.Replace('-', '/');
                                        //var addeddate = DateTime.ParseExact(seprationdate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                                        //var addedyear = addeddate.Year.ToString();
                                        tbl_SeperationFromTheCongregation Sepration = new tbl_SeperationFromTheCongregation();

                                        var personeldata = tblpersoneldetails.FirstOrDefault(x => x.FileNo == FileNo);
                                        if (personeldata != null)
                                        {
                                            var sepratindata = tblsepration.FirstOrDefault(x => x.MemberID == personeldata.MemberID);
                                            if (sepratindata == null)
                                            {
                                                Sepration.MemberID = personeldata.MemberID;
                                                Sepration.ProvinceName = personeldata.ProvinceName;
                                                Sepration.Name = personeldata.Name;
                                                Sepration.Title = title;
                                                Sepration.SeperationDate = seprationdate;
                                                Sepration.Describtion = descriptio;
                                                Sepration.Sapcheck = "Active";
                                                //Sepration.Added_Year = seprationdate;
                                                Sepration.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                                //Sepration.ProvinceName = province;

                                                var Getdata = tblpersoneldetails.LastOrDefault(x => x.MemberID == Sepration.MemberID);
                                                if (Getdata != null)
                                                {
                                                    Sepration.Name = Getdata.Name;
                                                    Sepration.StageOFFormation = Getdata.CurrentStatus;
                                                }
                                                dbcont.tbl_SeperationFromTheCongregation.Add(Sepration);
                                                dbcont.SaveChanges();

                                                var dataUpdate = tblpersoneldetails.LastOrDefault(x => x.MemberID == Sepration.MemberID);
                                                if (dataUpdate != null)
                                                {
                                                    dataUpdate.Sapcheck = Sepration.Sapcheck;
                                                    dbcont.SaveChanges();
                                                }
                                                //Formation
                                                var dataUpdateFor = formationdetails.Where(x => x.MemberId == Sepration.MemberID).ToList();
                                                if (dataUpdateFor != null)
                                                {
                                                    foreach (var item in dataUpdateFor)
                                                    {
                                                        item.Sapcheck = Sepration.Sapcheck;
                                                        dbcont.SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    ValidRow = 0;
                                                    ErrorList += "Invalid No data in formationtable" + FileNo + "In rowno" + (RowNumber - 1) + "<br />";

                                                }
                                                //var dataUpdateretire = retirement.LastOrDefault(x => x.MemberID == Sepration.MemberID);
                                                //if (dataUpdateretire != null)
                                                //{
                                                //    dataUpdateretire.SapCheck = Sepration.Sapcheck;
                                                //    dbcont.SaveChanges();
                                                //}
                                                //var dataUpdaterenewal = renewal.LastOrDefault(x => x.MemberId == Sepration.MemberID);
                                                //if (dataUpdaterenewal != null)
                                                //{
                                                //    dataUpdaterenewal.SapCheck = Sepration.Sapcheck;
                                                //    dbcont.SaveChanges();
                                                //}

                                            }
                                        }
                                        else
                                        {
                                            ValidRow = 0;
                                            ErrorList += "Invalid No data in personeltable" + FileNo + "In rowno" + (RowNumber - 1) + "<br />";
                                        }

                                        //Sepration.Title = row.Cell(2).Value.ToString();
                                        //Sepration.SeperationDate = row.Cell(3).Value.ToString();
                                        //Sepration.Describtion = row.Cell(4).Value.ToString();
                                        //Sepration.MemberID = row.Cell(5).Value.ToString();

                                        //Sepration.Sapcheck = "Active";
                                        //Sepration.CreatedBy = Convert.ToString(Session["loginuserid"]);

                                    }
                                }
                                if (utilities == "Eternal")
                                {
                                    var tblpassed = dbcont.tbl_Passed.ToList();
                                    var tblpersoneldetails = dbcont.tbl_PersonalDetails.ToList();
                                    var appointments = dbcont.Appointments.ToList();
                                    var formationdetails = dbcont.Tbl_formationsDetails.ToList();
                                    //var retirement = dbcont.tbl_Retirement.ToList();
                                    //var renewal = dbcont.Tbl_RenewalVows.ToList();
                                    int RowNumber = 0;
                                    var colNameRow = WorkSheet.FirstRow();
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
#pragma warning disable CS0219 // The variable 'ValidRow' is assigned but its value is never used
                                        int ValidRow = 1;
#pragma warning restore CS0219 // The variable 'ValidRow' is assigned but its value is never used
                                        RowNumber++;
                                        row.Cell(1).Value.ToString();//Get ist cell. 1 represent column number
                                        var Fileno = row.Cell(1).Value.ToString();
                                        //var name = row.Cell(3).Value.ToString();
                                        //var lastname = row.Cell(2).Value.ToString();
                                        //var Firstname = name + lastname;
                                        var dob = row.Cell(4).Value.ToString();
                                        var placelastrited = row.Cell(5).Value.ToString();
                                        var description = row.Cell(6).Value.ToString();
                                        tbl_Passed tbl_Passed = new tbl_Passed();

                                        var personeldata = tblpersoneldetails.FirstOrDefault(x => x.FileNo == Fileno);
                                        if (personeldata != null)
                                        {
                                            var passeddata = tblpassed.FirstOrDefault(x => x.MemberID == personeldata.MemberID);
                                            if (passeddata == null)
                                            {
                                                tbl_Passed.MemberID = personeldata.MemberID;
                                                tbl_Passed.Name = personeldata.Name;
                                                tbl_Passed.SirName = personeldata.SirName;
                                                tbl_Passed.Date = dob;
                                                tbl_Passed.LastPlaceRites = placelastrited;
                                                tbl_Passed.Description = description;
                                                tbl_Passed.Diedcheck = "Active";
                                                tbl_Passed.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                                tbl_Passed.ProvinceName = personeldata.ProvinceName;
                                                tbl_Passed.CurrentStatusFor = personeldata.CurrentStatus;
                                                dbcont.tbl_Passed.Add(tbl_Passed);
                                                dbcont.SaveChanges();

                                                //var Getdata = tblpersoneldetails.LastOrDefault(x => x.MemberID == tbl_Passed.MemberID);
                                                //if (Getdata != null)
                                                //{
                                                //    tbl_Passed.Name = Getdata.Name;
                                                //    tbl_Passed.SirName = Getdata.SirName;
                                                //    tbl_Passed.CurrentStatusFor = Getdata.CurrentStatus;
                                                //}
                                                var Appointment = appointments.LastOrDefault(x => x.MemberId == tbl_Passed.MemberID);
                                                if (Appointment != null)
                                                {
                                                    tbl_Passed.LastCommunity = Appointment.CommunityType;
                                                    tbl_Passed.InstitutionPlace = Appointment.InstitutionType;
                                                }

                                                var dataUpdate = tblpersoneldetails.LastOrDefault(x => x.MemberID == tbl_Passed.MemberID);
                                                if (dataUpdate != null)
                                                {
                                                    dataUpdate.Diedcheck = tbl_Passed.Diedcheck;
                                                    dbcont.SaveChanges();
                                                }
                                                var dataUpdateFor = formationdetails.Where(x => x.MemberId == tbl_Passed.MemberID).ToList();
                                                if (dataUpdateFor != null)
                                                {
                                                    foreach (var item in dataUpdateFor)
                                                    {
                                                        item.Diedcheck = tbl_Passed.Diedcheck;
                                                        dbcont.SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    ValidRow = 0;
                                                    ErrorList += "Invalid No data in formationtable" + Fileno + "In rowno" + (RowNumber - 1) + "<br />";

                                                }


                                            }
                                        }
                                        else
                                        {
                                            ValidRow = 0;
                                            ErrorList += "Invalid No data in personeltable" + Fileno + "In rowno" + (RowNumber - 1) + "<br />";
                                        }


                                    }
                                }
                                if (utilities == "Archive")
                                {
                                    foreach (var row in WorkSheet.RowsUsed())
                                    {
                                        row.Cell(1).Value.ToString();
                                        tbl_Archive tbl_Archive = new tbl_Archive();
                                        tbl_Archive.MemberId = row.Cell(2).Value.ToString();
                                        tbl_Archive.FileNo = row.Cell(3).Value.ToString();
                                        tbl_Archive.ArchiveNo = row.Cell(4).Value.ToString();
                                        tbl_Archive.Archivecheck = "yes";
                                        tbl_Archive.CreatedBy = Convert.ToString(Session["loginuserid"]);
                                        var Getdata = dbcont.tbl_PersonalDetails.ToList().LastOrDefault(x => x.MemberID == tbl_Archive.MemberId);
                                        if (Getdata != null)
                                        {
                                            tbl_Archive.Name = Getdata.Name;
                                            tbl_Archive.Surname = Getdata.SirName;
                                        }
                                        tbl_Archive.ProvinceName = province;
                                        dbcont.tbl_Archive.Add(tbl_Archive);
                                        dbcont.SaveChanges();

                                        var dataUpdate = dbcont.tbl_PersonalDetails.ToList().LastOrDefault(x => x.MemberID == tbl_Archive.MemberId);
                                        if (dataUpdate != null)
                                        {
                                            dataUpdate.Archivecheck = tbl_Archive.Archivecheck;
                                            dbcont.SaveChanges();
                                        }
                                        //Formation
                                        var dataUpdateFor = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == tbl_Archive.MemberId).ToList();
                                        if (dataUpdateFor != null)
                                        {
                                            foreach (var item in dataUpdateFor)
                                            {
                                                item.Archivecheck = tbl_Archive.Archivecheck;
                                                dbcont.SaveChanges();
                                            }
                                        }
                                        var dataUpdateretire = dbcont.tbl_Retirement.ToList().LastOrDefault(x => x.MemberID == tbl_Archive.MemberId);
                                        if (dataUpdateretire != null)
                                        {
                                            dataUpdateretire.Archivecheck = tbl_Archive.Archivecheck;
                                            dbcont.SaveChanges();
                                        }
                                        var dataUpdaterenewal = dbcont.Tbl_RenewalVows.ToList().LastOrDefault(x => x.MemberId == tbl_Archive.MemberId);
                                        if (dataUpdaterenewal != null)
                                        {
                                            dataUpdaterenewal.Archivecheck = tbl_Archive.Archivecheck;
                                            dbcont.SaveChanges();
                                        }
                                    }
                                }
                            }
                            status = 1;
                        }
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    return "0";
                }
            }
            return ErrorList;
        }
    }
}