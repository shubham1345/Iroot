using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class TransferDataController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: TransferData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TransferData(string myId)
        {
            string currentUser = Convert.ToString(Session["username"]);
            var pertionalInfo = dbcont.tbl_Province.FirstOrDefault(x => x.MyId.ToString() == myId);
            if (pertionalInfo != null)
            {
                ViewBag.ProvinceId = pertionalInfo.MyId;
            }

            if (Session["username"].ToString() == "admin")
            {
                var membersDetail = dbcont.tbl_PersonalDetails.Where(x => x.IsDeleted == false).ToList();
                ViewBag.AllMemberName = membersDetail;
            }
            else
            {
                var membersDetail = dbcont.tbl_PersonalDetails.Where(x => x.ProvinceName == currentUser && x.IsDeleted == false).ToList();
                ViewBag.AllMemberName = membersDetail;
            }

            if (Session["username"].ToString() == "admin")
            {
                var AllProvince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active").ToList();
                ViewBag.AllProvince = AllProvince;
            }
            else
            {
                var AllProvince = dbcont.tbl_Province.Where(x => x.ActiveCkeck == "Active" && x.Place == currentUser).ToList();
                ViewBag.AllProvince = AllProvince;
            }

            if (Session["username"].ToString() == "admin")
            {
                var AllData = dbcont.Tbl_Transfer.ToList();
                ViewBag.AllData = AllData;
            }
            else
            {
                var AllData = dbcont.Tbl_Transfer.Where(x => x.NewProvinceName == currentUser).ToList();
                ViewBag.AllData = AllData;
            }
            return View();
        }

        public ActionResult TransferSave(Tbl_Transfer Transfer)
        {
            Transfer.CreatedBy = Convert.ToString(Session["loginuserid"]);
            dbcont.Tbl_Transfer.Add(Transfer);
            dbcont.SaveChanges();
            string[] names = Transfer.BrotherName.Split(' ');
            string name = names[0];
            var dataforUpdate = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.Name.Contains(name) && x.ProvinceName == Transfer.OldProvinceName);
            if (dataforUpdate != null)
            {
                dataforUpdate.ProvinceName = Transfer.NewProvinceName;
                dataforUpdate.MemberID = Transfer.OldMemberId;
                dbcont.SaveChanges();
            }
            string url = this.Request.UrlReferrer.AbsolutePath;
            return Content("<script language='javascript' type='text/javascript'>alert('Data Saved Successfully!');location.replace('" + url + "')</script>");
        }

        public JsonResult GetTransById(int id)
        {
            try
            {
                var data = dbcont.Tbl_Transfer.FirstOrDefault(e => e.Id == id);
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

        public ActionResult TransferUpdate(Tbl_Transfer Tbl_Transfer)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                var existingobj = dbcont.Tbl_Transfer.FirstOrDefault(e => e.Id == Tbl_Transfer.Id);
                if (existingobj != null)
                {
                    Tbl_Transfer.CreatedBy = existingobj.CreatedBy;
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_Transfer);
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

        public ActionResult TransferDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_Transfer.FirstOrDefault(e => e.Id == id);
                var personalDetailsFileNo = dbcont.tbl_PersonalDetails.FirstOrDefault(e => e.MemberID == data.OldMemberId).FileNo;
                var personalDetailList = dbcont.tbl_PersonalDetails.Where(e => e.FileNo == personalDetailsFileNo && e.IsTransfer != "yes").ToList();

                List<Tbl_formationsDetails> formationsDetailslist = new List<Tbl_formationsDetails>();
                List<Appointments> ListOfAppointments = new List<Appointments>();
                List<tbl_Primarydetails> primarydetailsList = new List<tbl_Primarydetails>();
                List<tbl_Archive> archiveList = new List<tbl_Archive>();
                List<tbl_Academy> academiesList = new List<tbl_Academy>();
                List<FamilyDetails> familyDetailsList = new List<FamilyDetails>();
                List<Sacraments> sacramentsList = new List<Sacraments>();

                foreach(var item in personalDetailList)
                {
                    formationsDetailslist.AddRange(dbcont.Tbl_formationsDetails.Where(x => x.MemberId == item.MemberID).ToList());
                    ListOfAppointments.AddRange(dbcont.Appointments.Where(x => x.MemberId == item.MemberID).ToList());
                    primarydetailsList.AddRange(dbcont.tbl_Primarydetails.Where(x => x.MemberId == item.MemberID).ToList());
                    archiveList.AddRange(dbcont.tbl_Archive.Where(x => x.MemberId == item.MemberID).ToList());
                    academiesList.AddRange(dbcont.tbl_Academy.Where(x => x.MemberId == item.MemberID).ToList());
                    familyDetailsList.AddRange(dbcont.FamilyDetails.Where(x => x.MemberId == item.MemberID).ToList());
                    sacramentsList.AddRange(dbcont.Sacraments.Where(x => x.MemberId == item.MemberID).ToList());
                }
                if(formationsDetailslist != null)
                {
                    dbcont.Tbl_formationsDetails.RemoveRange(formationsDetailslist);                    
                }
                if(ListOfAppointments != null)
                {
                    dbcont.Appointments.RemoveRange(ListOfAppointments);
                }
                if(primarydetailsList != null)
                {
                    dbcont.tbl_Primarydetails.RemoveRange(primarydetailsList);
                }
                if (archiveList != null)
                {
                    dbcont.tbl_Archive.RemoveRange(archiveList);
                }
                if (academiesList != null)
                {
                    dbcont.tbl_Academy.RemoveRange(academiesList);
                }
                if (familyDetailsList != null)
                {
                    dbcont.FamilyDetails.RemoveRange(familyDetailsList);
                }
                if (sacramentsList != null)
                {
                    dbcont.Sacraments.RemoveRange(sacramentsList);
                }

                if (personalDetailList != null)
                {
                    dbcont.tbl_PersonalDetails.RemoveRange(personalDetailList);

                    tbl_PersonalDetails personalDetails = new tbl_PersonalDetails();
                    personalDetails = dbcont.tbl_PersonalDetails.FirstOrDefault(e => e.FileNo == personalDetailsFileNo && e.IsTransfer == "yes");
                    if (personalDetails != null)
                    {
                        personalDetails.IsTransfer = "";
                        dbcont.Entry(personalDetails).State = System.Data.Entity.EntityState.Modified;
                    }
                    dbcont.SaveChanges();
                }
                if (data != null)
                {
                    dbcont.Tbl_Transfer.Remove(data);
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
        public ActionResult SaveTransferData(TransferViewModel Transfer)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                if (Transfer != null)
                {
                    var allPersonalDetails = dbcont.tbl_PersonalDetails.ToList();
                    var allPrimaryDetails = dbcont.tbl_Primarydetails.ToList();
                    var allfamilydetails = dbcont.FamilyDetails.ToList();
                    var allformationdetails = dbcont.Tbl_formationsDetails.ToList();
                    var allprovince = dbcont.tbl_Province.ToList();
                    var allsacrements = dbcont.Sacraments.ToList();
                    var allacademy = dbcont.tbl_Academy.ToList();
                    var allarchieve = dbcont.tbl_Archive.ToList();
                    var tblappointments = dbcont.Appointments.ToList();

                    foreach (var BrothersMemberID in Transfer.BrothersMemberID)
                    {
                        Tbl_Transfer tbl_Transfer = new Tbl_Transfer();

                        var PersonalDetails = allPersonalDetails.FirstOrDefault(x => x.MemberID == BrothersMemberID);

                        tbl_Transfer.CreatedBy = Convert.ToString(Session["loginuserid"]);
                        tbl_Transfer.OldMemberId = BrothersMemberID;
                        tbl_Transfer.BrotherName = PersonalDetails.Name + " " + PersonalDetails.SirName;
                        tbl_Transfer.OldProvinceId = Transfer.OldProvinceId;
                        tbl_Transfer.OldProvinceName = Transfer.OldProvinceName;

                        tbl_Transfer.NewProvinceId = Transfer.NewProvinceId;
                        tbl_Transfer.NewProvinceName = Transfer.NewProvinceName;
                        tbl_Transfer.CreatedDate = DateTime.Now.ToString();
                        tbl_Transfer.InsertBy = Session["username"].ToString();
                        tbl_Transfer.MemberUnicId = PersonalDetails.MemberUnicId;
                        var provinve = allprovince.FirstOrDefault(x => x.MyId == Transfer.NewProvinceId);

                        //Generate new memberid
                        int allStdCountInProv = allPersonalDetails.Where(x => x.ProvinceName == provinve.Id.ToString()).Count();
                        string newmemberId = provinve.Place + "/" + (allStdCountInProv + 1);
                        tbl_Transfer.NewMemberId = newmemberId;

                        dbcont.Tbl_Transfer.Add(tbl_Transfer);
                        dbcont.SaveChanges();
                        //end
                        var persionalDetails = allPersonalDetails.FirstOrDefault(x => x.MemberID == BrothersMemberID);
                        if (persionalDetails != null)
                        {
                            persionalDetails.IsTransfer = "yes";
                            dbcont.SaveChanges();

                            persionalDetails.MemberID = newmemberId;
                            persionalDetails.ProvinceName = provinve.Id.ToString();
                            persionalDetails.ProvinceCode = provinve.Place;
                            persionalDetails.IsTransfer = "";

                            //new add member 
                            dbcont.tbl_PersonalDetails.Add(persionalDetails);
                            dbcont.SaveChanges();
                        }

                        //primary Details
                        var PrimaryDetails = allPrimaryDetails.FirstOrDefault(x => x.MemberId == BrothersMemberID);
                        if(PrimaryDetails != null)
                        {
                            PrimaryDetails.MemberId = newmemberId;
                            PrimaryDetails.ProvinceName = provinve.Id.ToString();

                            dbcont.tbl_Primarydetails.Add(PrimaryDetails);
                            dbcont.SaveChanges();
                        }

                        //Family details 
                        var Familydetails = allfamilydetails.Where(x => x.MemberId == BrothersMemberID).ToList();
                        if(Familydetails != null)
                        {
                            foreach(var item in Familydetails)
                            {
                                var Family_Details = Familydetails.FirstOrDefault(x => x.MemberId == item.MemberId);

                                Family_Details.MemberId = tbl_Transfer.NewMemberId;
                                Family_Details.ProvinceName = provinve.Id.ToString();
                                Family_Details.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");

                                dbcont.FamilyDetails.Add(Family_Details);
                                dbcont.SaveChanges();
                            }
                        }

                        //Formation Details
                        var Formationdetails = allformationdetails.Where(x => x.MemberId == BrothersMemberID).ToList();
                        if(Formationdetails != null)
                        {
                            foreach(var item in Formationdetails)
                            {
                                var Formation_Details = Formationdetails.FirstOrDefault(x => x.MemberId == item.MemberId);

                                Formation_Details.MemberId = tbl_Transfer.NewMemberId;
                                Formation_Details.ProvinceName = provinve.Id.ToString();
                                Formation_Details.CreatedDate = DateTime.Now.ToString();

                                dbcont.Tbl_formationsDetails.Add(Formation_Details);
                                dbcont.SaveChanges();
                            }
                        }

                        //sacrements
                        var Sacrementsdata = allsacrements.Where(x => x.MemberId == BrothersMemberID).ToList();
                        if(Sacrementsdata != null)
                        {
                            foreach(var item in Sacrementsdata)
                            {
                                var Sacrements_Data = Sacrementsdata.FirstOrDefault(x => x.MemberId == item.MemberId);

                                Sacrements_Data.MemberId = tbl_Transfer.NewMemberId;
                                Sacrements_Data.ProvinceName = provinve.Id.ToString();
                                Sacrements_Data.CreatedDate = DateTime.Now.ToString();

                                dbcont.Sacraments.Add(Sacrements_Data);
                                dbcont.SaveChanges();
                            }
                        }

                        //Academy
                        var Academydata = allacademy.Where(x => x.MemberId == BrothersMemberID).ToList();
                        if(Academydata != null)
                        {
                            foreach(var item in Academydata)
                            {
                                var Academy_Data = Academydata.FirstOrDefault(x => x.MemberId == item.MemberId);

                                Academy_Data.MemberId = tbl_Transfer.NewMemberId;
                                Academy_Data.ProvinceName = provinve.Id.ToString();
                                Academy_Data.CreatedDate = DateTime.Now.ToString();

                                dbcont.tbl_Academy.Add(Academy_Data);
                                dbcont.SaveChanges();
                            }
                        }

                        //Archieve
                        var Archievedata = allarchieve.Where(x => x.MemberId == BrothersMemberID).ToList();
                        if(Archievedata != null)
                        {
                            foreach(var item in Archievedata)
                            {
                                var Archieve_data = Archievedata.FirstOrDefault(x => x.MemberId == item.MemberId);

                                Archieve_data.MemberId = tbl_Transfer.NewMemberId;
                                Archieve_data.ProvinceName = provinve.Id.ToString();
                                Archieve_data.CreatedDate = DateTime.Now.ToString();

                                dbcont.tbl_Archive.Add(Archieve_data);
                                dbcont.SaveChanges();
                            }
                        }

                        //Appointments
                        var Appointmentdata = tblappointments.Where(x => x.MemberId == BrothersMemberID).ToList();
                        if(Appointmentdata.Count > 0)
                        {
                            
                            foreach (var item in Appointmentdata)
                            {
                                var data = Appointmentdata.FirstOrDefault(x => x.MemberId == item.MemberId);
                                data.MemberId = tbl_Transfer.NewMemberId;
                                data.ProvinceName = provinve.Id.ToString();
                                data.CreatedDate = DateTime.Now.ToString();

                                dbcont.SaveChanges();
                            }
                        }


                        string[] names = tbl_Transfer.BrotherName.Split(' ');
                        string name = names[0];
                        var UpdateforGenfile = dbcont.GeneralateFileNo.Where(x => x.Name.Contains(name)).ToList();
                        if (UpdateforGenfile != null)
                        {
                            foreach (var item in UpdateforGenfile)
                            {
                                item.MemberId = tbl_Transfer.NewMemberId;
                                item.ProvinceName = tbl_Transfer.NewProvinceName;
                                dbcont.SaveChanges();
                            }
                        }
                    }
                }
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
        public void setcookies(string code)
        {
            HttpCookie cookie = new HttpCookie("iscode", code);
            Response.Cookies.Add(cookie);
        }
    }
}