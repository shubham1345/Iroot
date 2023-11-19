using ClosedXML.Excel;
using Generalate.Models;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    public class ExcelWorkController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: ExcelWork
        public string UploadMemberExcelFile()
        {
#pragma warning disable CS0219 // The variable 'status' is assigned but its value is never used
            int status = 1;
#pragma warning restore CS0219 // The variable 'status' is assigned but its value is never used
            string ErrorList = "";
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
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
                                //WorkSheet.FirstRow().Delete();//if you want to remove ist row
                                var colNameRow = WorkSheet.FirstRow();
                                var provinceInfo = dbcont.tbl_Province.ToList();
                                var AllCountry = dbcont.DataListItems.Where(x => x.DataListName == "Country").OrderBy(x => x.Name).ToList();
                                var Allcontinent = dbcont.DataListItems.Where(x => x.DataListName == "Country").ToList();
                                var LanguageList = dbcont.DataListItems.Where(x => x.DataListName == "Language").OrderBy(x => x.Name).ToList();
                                int RowNumber = 0;
                                foreach (var row in WorkSheet.RowsUsed())
                                {
                                    //do something here
                                    RowNumber++;
                                    if (RowNumber != 1)
                                    {
                                        row.Cell(1).Value.ToString();//Get ist cell. 1 represent column number
                                        int ValidRow = 1;

                                        tbl_Primarydetails tbl_PrimaryDetail = new tbl_Primarydetails();
                                        string Name = "";
                                        string MotherTongue = "0";
                                        string SirName = "";
                                        long? PersonalDetailsId = null;
                                        string FileNo = "";
                                        string[] LangSpocken = null;
                                        string noofbrother = "";
                                        string noofsisters = "";
                                        tbl_PrimaryDetail.MemberId = "AutoGen";
                                        if (row.Cell(2).Value.ToString() != "" && row.Cell(2).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.ProvinceName = row.Cell(2).Value.ToString().Replace("\t", "");
                                            var isExistsProv = dbcont.tbl_Province.Where(x => x.ProvinceName == tbl_PrimaryDetail.ProvinceName).ToList();
                                            if (isExistsProv.Count == 0)
                                            {
                                                ValidRow = 0;
                                                ErrorList += "Invalid " + colNameRow.Cell(2).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br />";
                                            }
                                            else
                                            {
                                                tbl_PrimaryDetail.ProvinceName = Convert.ToString(isExistsProv[0].Id);
                                            }
                                        }
                                        else
                                        {
                                            ErrorList += "Invalid " + colNameRow.Cell(2).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br />";
                                            ValidRow = 0;
                                        }
                                        if (row.Cell(3).Value.ToString() != "" && row.Cell(3).Value.ToString() != null)
                                        {
                                            Name = row.Cell(3).Value.ToString().Replace("\t", "");
                                        }
                                        else
                                        {
                                            ErrorList += "Invalid " + colNameRow.Cell(3).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br />";
                                            ValidRow = 0;
                                        }
                                        SirName = row.Cell(4).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.Baptismialname = row.Cell(5).Value.ToString().Replace("\t", "");
                                        //if (row.Cell(5).Value.ToString() != "" && row.Cell(5).Value.ToString() != null)
                                        //{
                                        //    tbl_PrimaryDetail.Baptismialname = row.Cell(5).Value.ToString().Replace("\t", "");
                                        //}
                                        //else
                                        //{
                                        //    ErrorList += "Invalid " + colNameRow.Cell(5).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                        //    ValidRow = 0;
                                        //}
                                        if (row.Cell(6).Value.ToString() != "" && row.Cell(6).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.Congregation = row.Cell(6).Value.ToString().Replace("\t", "");
                                        }
                                        //else
                                        //{
                                        //    ErrorList += "Invalid " + colNameRow.Cell(6).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                        //    ValidRow = 0;
                                        //}


                                        if (row.Cell(7).Value.ToString() != "" && row.Cell(7).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.country = row.Cell(7).Value.ToString().Replace("\t", "");
                                            var isValidCountry = AllCountry.Where(x => x.Name == tbl_PrimaryDetail.country).ToList();
                                            if (isValidCountry.Count == 0)
                                            {
                                                ErrorList += "Invalid " + colNameRow.Cell(7).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                                ValidRow = 0;
                                            }
                                            else
                                            {
                                                tbl_PrimaryDetail.Continent = Allcontinent.FirstOrDefault(x => x.DataListName == "Country" && (x.Name == tbl_PrimaryDetail.country || x.Name_French == tbl_PrimaryDetail.country)).Continent;
                                            }
                                        }
                                        else
                                        {
                                            tbl_PrimaryDetail.country = row.Cell(7).Value.ToString().Replace("\t", "");
                                            //ErrorList += "Invalid " + colNameRow.Cell(7).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                            //ValidRow = 0;
                                        }
                                        tbl_PrimaryDetail.placeofbirth = row.Cell(8).Value.ToString().Replace("\t", "");
                                        //if (row.Cell(8).Value.ToString() != "" && row.Cell(8).Value.ToString() != null)
                                        //{
                                        //    tbl_PrimaryDetail.placeofbirth = row.Cell(8).Value.ToString().Replace("\t", "");
                                        //}
                                        //else
                                        //{
                                        //    ErrorList += "Invalid " + colNameRow.Cell(8).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                        //    ValidRow = 0;
                                        //}
                                        if (row.Cell(9).Value.ToString() != "" && row.Cell(9).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.Nationality = row.Cell(9).Value.ToString().Replace("\t", "");
                                        }
                                        else
                                        {
                                            ErrorList += "Invalid " + colNameRow.Cell(9).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                            ValidRow = 0;
                                        }
                                        if (row.Cell(10).Value.ToString() != "" && row.Cell(10).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.LangSpocken = row.Cell(10).Value.ToString().Replace("\t", "");
                                            LangSpocken = tbl_PrimaryDetail.LangSpocken.Split(',');
                                            if (LangSpocken != null)
                                            {
                                                for (int k = 0; k < LangSpocken.Length; k++)
                                                {
                                                    var lgsp = LanguageList.Where(x => x.Name == (LangSpocken[i]) || x.Name_French == (LangSpocken[i])).ToList();
                                                    if (lgsp.Count == 0)
                                                    {
                                                        ErrorList += "Invalid " + colNameRow.Cell(10).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                                        ValidRow = 0;
                                                    }
                                                }
                                            }
                                        }
                                        if (row.Cell(11).Value.ToString() != "" && row.Cell(11).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.DOB = row.Cell(11).Value.ToString().Replace("\t", "").Replace(" 00:00:00", "");

                                            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

                                            //Verify whether date entered in dd/MM/yyyy format.
                                            bool isValid = regex.IsMatch(tbl_PrimaryDetail.DOB.Trim());

                                            //Verify whether entered date is Valid date.
                                            DateTime dt;
                                            isValid = DateTime.TryParseExact(tbl_PrimaryDetail.DOB, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
                                            if (!isValid)
                                            {
                                                ErrorList += "Invalid " + colNameRow.Cell(2).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                                ValidRow = 0;
                                            }
                                        }
                                        MotherTongue = row.Cell(12).Value.ToString().Replace("\t", "");
                                        if (row.Cell(12).Value.ToString() != "" && row.Cell(12).Value.ToString() != null)
                                        {
                                            var rfdg = LanguageList.Where(x => x.Name == MotherTongue || x.Name_French == MotherTongue).ToList();
                                            if (rfdg.Count == 0)
                                            {
                                                ErrorList += "Invalid " + colNameRow.Cell(12).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                                ValidRow = 0;
                                            }

                                        }
                                        if (row.Cell(13).Value.ToString() != "" && row.Cell(13).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.DOBInTheCertificate = row.Cell(13).Value.ToString().Replace("\t", "").Replace(" 00:00:00", "");

                                            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

                                            //Verify whether date entered in dd/MM/yyyy format.
                                            bool isValid = regex.IsMatch(tbl_PrimaryDetail.DOBInTheCertificate.Trim());

                                            //Verify whether entered date is Valid date.
                                            DateTime dt;
                                            isValid = DateTime.TryParseExact(tbl_PrimaryDetail.DOBInTheCertificate, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
                                            if (!isValid)
                                            {
                                                ErrorList += "Invalid " + colNameRow.Cell(13).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                                ValidRow = 0;
                                            }
                                        }
                                        tbl_PrimaryDetail.placeinfamily = row.Cell(14).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.Knowname = row.Cell(15).Value.ToString().Replace("\t", "");
                                        FileNo = row.Cell(16).Value.ToString().Replace("\t", "");
                                        if (row.Cell(17).Value.ToString() != "" && row.Cell(17).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.emailid = row.Cell(17).Value.ToString().Replace("\t", "").Replace(" 00:00:00", "");

                                            bool isValid = Regex.IsMatch(tbl_PrimaryDetail.emailid, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                                            if (!isValid)
                                            {
                                                ErrorList += "Invalid " + colNameRow.Cell(17).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                                ValidRow = 0;
                                            }
                                        }
                                        if (row.Cell(18).Value.ToString() != "" && row.Cell(18).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.Bloodgroup = row.Cell(18).Value.ToString().Replace("\t", "");
                                            string[] BloodGroups = { "A+", "B+", "AB+", "O+", "A-", "B-", "AB-", "O-" };
                                            bool isValid = BloodGroups.Contains(tbl_PrimaryDetail.Bloodgroup);
                                            if (!isValid)
                                            {
                                                ErrorList += "Invalid " + colNameRow.Cell(18).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                                ValidRow = 0;
                                            }
                                        }
                                        tbl_PrimaryDetail.mobilenumber = row.Cell(19).Value.ToString().Replace("\t", "");
                                        noofbrother = row.Cell(20).Value.ToString().Replace("\t", "");
                                        noofsisters = row.Cell(21).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.homeparish = row.Cell(22).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.homediocese = row.Cell(23).Value.ToString().Replace("\t", "");
                                        if (row.Cell(24).Value.ToString() != "" && row.Cell(24).Value.ToString() != null)
                                        {
                                            tbl_PrimaryDetail.Will = row.Cell(24).Value.ToString().Replace("\t", "");
                                            string[] will = { "yes", "NO" };
                                            bool isValid = will.Contains(tbl_PrimaryDetail.Will);
                                            if (!isValid)
                                            {
                                                ErrorList += "Invalid " + colNameRow.Cell(24).Value.ToString() + " in S.No. " + (RowNumber - 1) + " <br/>";
                                                ValidRow = 0;
                                            }
                                        }
                                        tbl_PrimaryDetail.Telephone = row.Cell(25).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.NameInTheCertificate = row.Cell(26).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.state = row.Cell(27).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.district = row.Cell(28).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.city = row.Cell(29).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.pin = row.Cell(30).Value.ToString().Replace("\t", "");
                                        tbl_PrimaryDetail.Address = row.Cell(31).Value.ToString().Replace("\t", "");
                                        if (ValidRow == 1)
                                        {
                                            int tempcall = AddPrimaryDetails(tbl_PrimaryDetail, Name, MotherTongue, SirName, PersonalDetailsId, FileNo, LangSpocken, noofbrother, noofsisters);
                                        }

                                    }
                                }

                                //status = 1;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "0";
                }
            }
            return ErrorList;
        }

        public int AddPrimaryDetails(tbl_Primarydetails tbl_Primarydetails, string Name, string MotherTongue, string SirName, long? PersonalDetailsId, string FileNo, string[] LangSpocken, string noofbrother, string noofsisters)
        {
            tbl_PersonalDetails tbl_PersonalDetails = new tbl_PersonalDetails();
            if (tbl_Primarydetails.MemberId == "AutoGen")
            {
                var provinceInfo = dbcont.tbl_Province.FirstOrDefault(x => x.Id.ToString() == tbl_Primarydetails.ProvinceName);
                tbl_PersonalDetails.MemberUnicId = Convert.ToString(Guid.NewGuid());
                var myId = dbcont.tbl_PersonalDetails.Where(x => x.ProvinceName == tbl_Primarydetails.ProvinceName).Any() ? dbcont.tbl_PersonalDetails.ToList().LastOrDefault(x => x.ProvinceName == tbl_Primarydetails.ProvinceName).MemberID : "01";
                if (myId != "01")
                {
                    myId = myId.Split('/')[1];
                    long z = Convert.ToInt64(myId) + 1;
                    myId = (z < 10) ? provinceInfo.Place + "/0" + z.ToString() : provinceInfo.Place + "/" + z.ToString();
                }
                else
                {
                    myId = provinceInfo.Place + "/" + myId.ToString();
                }
                tbl_PersonalDetails.MemberID = myId;
                tbl_PersonalDetails.ProvinceCode = provinceInfo.Place;
                tbl_PersonalDetails.ProvinceName = Convert.ToString(provinceInfo.Id);
                tbl_PersonalDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                tbl_PersonalDetails.Name = Name;
                tbl_PersonalDetails.SirName = SirName;
                tbl_PersonalDetails.MotherTongue = MotherTongue;
                tbl_PersonalDetails.NoOfBrother = noofbrother;
                tbl_PersonalDetails.NoOfSister = noofsisters;
                tbl_PersonalDetails.FileNo = FileNo;
                dbcont.tbl_PersonalDetails.Add(tbl_PersonalDetails);
                dbcont.SaveChanges();
                tbl_Primarydetails.MemberId = myId;

            }

             

            var memeberDetails = dbcont.tbl_Primarydetails.FirstOrDefault(x => x.MemberId == tbl_Primarydetails.MemberId);

            if (memeberDetails == null)
            {
                try
                {
                    var fileName = string.Empty;
                    if (tbl_Primarydetails != null)
                    {

                        // var memeberdata1 = dbcont.DataListItems.FirstOrDefault(x => x.Name == tbl_Primarydetails.Continent);

                        tbl_Primarydetails.LangSpocken = LangSpocken == null ? "" : String.Join(",", LangSpocken);
                        tbl_Primarydetails.mothertounge = MotherTongue;
                        tbl_Primarydetails.noofsisters = noofsisters;
                        tbl_Primarydetails.noofbrother = noofbrother;
                        tbl_Primarydetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        dbcont.tbl_Primarydetails.Add(tbl_Primarydetails);
                        dbcont.SaveChanges();

                        //
                        var objPersonalDet = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.MemberID == tbl_Primarydetails.MemberId);
                        if (objPersonalDet != null && fileName != string.Empty)
                        {
                            objPersonalDet.Spare1 = fileName;
                            dbcont.SaveChanges();
                        }
                        //
                        //setcookies("200");
                        return 1;
                    }
                    else
                    {

                        //setcookies("204");
                        return 0;
                    }
                }


                catch (Exception)
                {
                    //setcookies("204");
                    return 0;
                    throw;
                }

            }
            else
            {
                return 1;
            }
        }
    }
}