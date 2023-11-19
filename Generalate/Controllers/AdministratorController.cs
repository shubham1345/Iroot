using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class AdministratorController : Controller
    {
        // GET: EntryLife

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult EntryLife()
        {
            // ViewBag.tbl_PersonalDetails = new SelectList(dbcont.tbl_PersonalDetails, "Name", "MemberID");
            var getids = dbcont.tbl_PersonalDetails.Where(x => x.IsDeleted == false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult EntryLifePrint()
        {
            return View();
        }

        //public ActionResult EntryLifeReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("EntryLifePrint");
        //}

        public ActionResult EntryLife1()
        {
            return View();
        }

        public ActionResult EntryLifePrint1()
        {
            return View();
        }

        //public ActionResult EntryLifeReport1()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("EntryLifePrint1");
        //}


        public JsonResult GetAll()
        {
            try
            {
                //TODO Rajesh
                return Json(dbcont.tbl_EntryLife.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetById(int Id)
        {
            try
            {
                var gid = dbcont.tbl_EntryLife.FirstOrDefault(e => e.EntryLifeId == Id);
                if (gid != null)
                {
                    return Json(gid, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult Add(tbl_EntryLife newobj)
        {
            try
            {
                dbcont.tbl_EntryLife.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_EntryLife newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_EntryLife.FirstOrDefault(e => e.EntryLifeId == newobj.EntryLifeId);
                dbcont.Entry(existingobj).CurrentValues.SetValues(newobj);
                dbcont.SaveChanges();
                return Json("Sucess");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult Delete(int Id)
        {
            try
            {
                var genralobj = dbcont.tbl_EntryLife.FirstOrDefault(e => e.EntryLifeId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_EntryLife.Remove(genralobj);
                    dbcont.SaveChanges();
                    return Json("Success");
                }

                else
                {
                    return Json("Record Not Found");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult GetAllEL()
        {
            try
            {
                return Json(dbcont.tbl_EntryLife1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetByIdEL(int Id1)
        {
            try
            {
                var gidel1 = dbcont.tbl_EntryLife1.FirstOrDefault(e => e.EntryLifeId == Id1);
                if (gidel1 != null)
                {
                    return Json(gidel1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult AddEL1(tbl_EntryLife1 newobj1)
        {
            try
            {
                dbcont.tbl_EntryLife1.Add(newobj1);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult UpdateEL1(tbl_EntryLife1 newobj1)
        {
            try
            {
                var existingobj = dbcont.tbl_EntryLife1.FirstOrDefault(e => e.EntryLifeId == newobj1.EntryLifeId);
                dbcont.Entry(existingobj).CurrentValues.SetValues(newobj1);
                dbcont.SaveChanges();
                return Json("Sucess");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult DeleteEL1(int Id1)
        {
            try
            {
                var genralobj1 = dbcont.tbl_EntryLife1.FirstOrDefault(e => e.EntryLifeId == Id1);
                if (genralobj1 != null)
                {
                    dbcont.tbl_EntryLife1.Remove(genralobj1);
                    dbcont.SaveChanges();
                    return Json("Success");
                }
                else
                {
                    return Json("Record Not Found");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult ViewProfile(int id)
        {
            try
            {
                tbl_EntryLife gen = new tbl_EntryLife();
                gen = dbcont.tbl_EntryLife.FirstOrDefault(e => e.EntryLifeId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Details(int persionId, string dataListName = null)
        {
            var pertiondetails = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.PersonalDetailsId == persionId);

            var url = Request.Url.AbsoluteUri;
            TempData["EntryDetail"] = url;

            List<tbl_PersonalDetails> allRecords = dbcont.tbl_PersonalDetails
                            .Where(x => x.IsDeleted == false)
                            .ToList();
            ViewBag.AllMembers = allRecords;
            List<Tbl_Complains> allComplains = dbcont.Tbl_Complains.Where(x => x.MemberId == pertiondetails.MemberID).ToList();
            ViewBag.allComplains = allComplains;
            //var member = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.PersonalDetailsId == id);
            List<FormationViewModel> formationViewsList = new List<FormationViewModel>();
            var allFormation = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == pertiondetails.MemberID).ToList();
            foreach (var formation in allFormation)
            {
                string formationName = dbcont.Tbl_FormationTypes.FirstOrDefault(x => x.Id.ToString() == formation.StageOfFormation).FortmationType;
                FormationViewModel formationViewModel = new FormationViewModel()
                {
                    FromDate = formation.FromDate,
                    ToDate = formation.ToDate,
                    StageOfFormation = formationName,
                    Title = formation.Title,
                    Description = formation.Description,
                    Id = formation.Id,
                    file = formation.FileName
                };
                formationViewsList.Add(formationViewModel);
            }

            TempData["Name"] = pertiondetails.Name;
            TempData["SirName"] = pertiondetails.SirName;
            TempData["MemberId"] = pertiondetails.MemberID;
            var allFormationTypes = dbcont.Tbl_FormationTypes.ToList();
            ViewBag.FormationTypes = allFormationTypes;
            //Academy Details
            ViewBag.allAcedemy = dbcont.tbl_Academy.Where(x => x.MemberId == pertiondetails.MemberID).ToList();
            //Appoinment
            var allTypes = dbcont.DataLists.ToList();
            ViewBag.AppointmentType = allTypes;
            //Designation
            var allDesignation = dbcont.DataListItems.ToList();
            ViewBag.DesignationType = allDesignation;
            //Institution
            var allInstitution = dbcont.Tbl_ParisInstitutionDetails.ToList();
            ViewBag.InstitutionType = allInstitution;
            //Parish
            var allParish = dbcont.Tbl_Paris.ToList();
            ViewBag.ParishType = allParish;
            //Community
            var allCommunity = dbcont.tbl_CommunitiesSocialCentresDoc.ToList();
            ViewBag.CommunityType = allCommunity;
            //Appoinment work
            var DataListItems = dbcont.DataListItems
                       .Where(x => x.Name == pertiondetails.Name).ToList();
            ViewBag.DataListItems = DataListItems;

            var allApoinments = dbcont.Appointments.Where(x => x.MemberId == pertiondetails.MemberID).ToList();
            ViewBag.allApoinments = allApoinments;
            // All Summary
            var allSummary = GetALlSummary(pertiondetails.MemberID);
            ViewBag.allSummary = allSummary;
            return View(formationViewsList);
        }

        [HttpPost]
        public JsonResult AddFormation(FormationViewModel formationViewModel)
        {
            tbl_EntryLife tbl_EntryLife = new tbl_EntryLife();
            tbl_EntryLife.Spare3 = formationViewModel.Description;
            tbl_EntryLife.ColName = formationViewModel.Formator;
            tbl_EntryLife.EntryDate = formationViewModel.Date_Year;
            tbl_EntryLife.Place = formationViewModel.Place;
            tbl_EntryLife.Director = formationViewModel.Superior;
            tbl_EntryLife.OngoingFormation = formationViewModel.StageOfFormation;
            tbl_EntryLife.Minister = formationViewModel.Minister;
            tbl_EntryLife.Spare2 = formationViewModel.file;
            tbl_EntryLife.MemberID = formationViewModel.MemberId;
            tbl_EntryLife.SirName = formationViewModel.SirName;


            try
            {
                dbcont.tbl_EntryLife.Add(tbl_EntryLife);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult DeleteFormationById(int id)
        {
            try
            {
                var genFormation = dbcont.Tbl_formationsDetails.FirstOrDefault(e => e.Id == id);
                if (genFormation != null)
                {
                    dbcont.Tbl_formationsDetails.Remove(genFormation);
                    dbcont.SaveChanges();
                    return Json("Success", JsonRequestBehavior.AllowGet);
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

        public JsonResult GetFormationById(int id)
        {
            try
            {
                var genFormation = dbcont.Tbl_formationsDetails.FirstOrDefault(e => e.Id == id);
                if (genFormation != null)
                {
                    return Json(genFormation, JsonRequestBehavior.AllowGet);
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


        public ActionResult Paris()
        {
            return View();
        }

        public ActionResult AddFormationDetail(Tbl_formationsDetails tbl_FormationsDetails, HttpPostedFileBase FileName)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            if (FileName != null)
            {
                if (FileName.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(FileName.FileName);
                    var path = Path.Combine(Server.MapPath("~/Image/Formation"), fileName);
                    FileName.SaveAs(path);
                    tbl_FormationsDetails.FileName = fileName;
                }
            }
            if (tbl_FormationsDetails.StageOfFormation == "0")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Please Select Stage Of Formation!');location.replace('" + url + "')</script>");

            }
            dbcont.Tbl_formationsDetails.Add(tbl_FormationsDetails);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Data Save Successfully!');location.replace('" + url + "')</script>");

        }


        public ActionResult UpdateFormationDetail(Tbl_formationsDetails tbl_FormationsDetails)
        {
            try
            {
                var existingobj = dbcont.Tbl_formationsDetails.FirstOrDefault(e => e.Id == tbl_FormationsDetails.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_FormationsDetails);
                    dbcont.SaveChanges();
                }
                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Record Update Successfully!');location.replace('" + url + "')</script>");

            }
            catch (Exception)
            {

                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Some Error Occure!');location.replace('" + url + "')</script>");

            }

        }


        //tbl_Academy Work
        [HttpPost]

        public ActionResult AddAcademyDetail(tbl_Academy tbl_Academy, HttpPostedFileBase file)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Image/Academy"), fileName);
                    file.SaveAs(path);
                    tbl_Academy.doc = fileName;
                }
            }

            dbcont.tbl_Academy.Add(tbl_Academy);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Data Save Successfully!');location.replace('" + url + "')</script>");

        }


        public JsonResult GetAcademyById(int id)
        {
            try
            {
                var genAcademy = dbcont.tbl_Academy.FirstOrDefault();
                if (genAcademy != null)
                {
                    return Json(genAcademy, JsonRequestBehavior.AllowGet);
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

        public ActionResult UpdateAcademyDetail(tbl_Academy tbl_Academy)
        {
            try
            {
                var existingobj = dbcont.tbl_Academy.FirstOrDefault(e => e.Id == tbl_Academy.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(tbl_Academy);
                    dbcont.SaveChanges();
                }
                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Record Update Successfully!');location.replace('" + url + "')</script>");

            }
            catch (Exception)
            {

                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Some Error Occure!');location.replace('" + url + "')</script>");

            }

        }





        #region Appoinment work
        public JsonResult GetDataListItemsByDataListName(string dataListName)
        {
            var dataListItems = dbcont.DataListItems
                .Where(x => x.DataListName.ToLower() == dataListName.ToLower())
                .ToList();
            return Json(dataListItems, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveAppoinment(Appointments appointments)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            //if (file != null)
            //{
            //    if (file.ContentLength > 0)
            //    {
            //        var fileName = Path.GetFileName(file.FileName);
            //        var path = Path.Combine(Server.MapPath("~/Image/Academy"), fileName);
            //        file.SaveAs(path);
            //        tbl_Academy.doc = fileName;
            //    }
            //}

            dbcont.Appointments.Add(appointments);
            dbcont.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Data Save Successfully!');location.replace('" + url + "')</script>");

        }
        public JsonResult GetAppoinmentById(string id)
        {
            try
            {
                var data = dbcont.Appointments.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AppoinmentUpdate(Appointments appointments)
        {
            try
            {
                var existingobj = dbcont.Appointments.FirstOrDefault(e => e.Id == appointments.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(appointments);
                    dbcont.SaveChanges();
                }
                string url = this.Request.UrlReferrer.AbsolutePath;
                return Content("<script language='javascript' type='text/javascript'>alert('Record Update Successfully!');location.replace('" + url + "')</script>");

            }
            catch (Exception)
            {

                string url = this.Request.UrlReferrer.AbsolutePath;
                return Content("<script language='javascript' type='text/javascript'>alert('Some Error Occure!');location.replace('" + url + "')</script>");

            }

        }

        public ActionResult AppoinmentDelete(int id)
        {
            try
            {
                var data = dbcont.Appointments.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Appointments.Remove(data);
                    dbcont.SaveChanges();
                    string url = this.Request.UrlReferrer.AbsoluteUri;
                    return Content("<script language='javascript' type='text/javascript'>alert('Record delete successfully');location.replace('" + url + "')</script>");

                }
                else
                {
                    string url = this.Request.UrlReferrer.AbsolutePath;
                    return Content("<script language='javascript' type='text/javascript'>alert('Record delete successfully');location.replace('" + url + "')</script>");

                }
            }
            catch (Exception)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region  SUMMARY lIST
        public List<DetailsSummaryViewModel> GetALlSummary(string memberId)
        {
            List<DetailsSummaryViewModel> allSummary = new List<DetailsSummaryViewModel>();

            var allTbl_Complains = dbcont.Tbl_Complains.Where(x => x.MemberId == memberId);
            var allTbl_formationsDetails = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == memberId);
            var alltbl_Academy = dbcont.tbl_Academy.Where(x => x.MemberId == memberId);
            var allAppointments = dbcont.Appointments.Where(x => x.MemberId == memberId);
            foreach (var item in allTbl_Complains)
            {
                allSummary.Add(new DetailsSummaryViewModel
                {
                    Title = item.Title,
                    Date = item.Date,
                    Description = item.Discription
                });
            }
            foreach (var item in allTbl_formationsDetails)
            {
                allSummary.Add(new DetailsSummaryViewModel
                {
                    Title = item.Title,
                    Date = item.ToDate,
                    Description = item.Description
                });
            }
            foreach (var item in alltbl_Academy)
            {
                allSummary.Add(new DetailsSummaryViewModel
                {
                    Title = item.title,
                    Date = item.fromdate,
                    Description = "No Description"
                });
            }
            foreach (var item in allAppointments)
            {
                allSummary.Add(new DetailsSummaryViewModel
                {
                    Title = item.Title,
                    Date = item.Date,
                    Description = item.Description
                });
            }
            return allSummary.ToList();
        }
        #endregion
        //Complains
        [HttpPost]
        public JsonResult AddComplain(Tbl_Complains Tbl_Complains)

        {
            tbl_EntryLife tbl_EntryLife = new tbl_EntryLife();
            tbl_EntryLife.Spare3 = Tbl_Complains.Date;
            tbl_EntryLife.EntryDate = Tbl_Complains.Title;
            tbl_EntryLife.Place = Tbl_Complains.NatureofTheComplaint;
            tbl_EntryLife.Director = Tbl_Complains.ComplaintReceived;
            tbl_EntryLife.OngoingFormation = Tbl_Complains.Decision;
            tbl_EntryLife.Minister = Tbl_Complains.InvolvedIn;

            tbl_EntryLife.MemberID = Tbl_Complains.MemberId;



            try
            {
                dbcont.tbl_EntryLife.Add(tbl_EntryLife);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult DeleteCompainById(int id)
        {
            try
            {
                var genCompain = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id == id);
                if (genCompain != null)
                {
                    dbcont.Tbl_Complains.Remove(genCompain);
                    dbcont.SaveChanges();
                    return Json("Success", JsonRequestBehavior.AllowGet);
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

        public JsonResult GetCompainById(int id)
        {
            try
            {
                var genComplain = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id == id);
                if (genComplain != null)
                {
                    return Json(genComplain, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateCompain(Tbl_Complains Tbl_Complains)
        {
            try
            {
                var existingobj = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id == Tbl_Complains.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_Complains);
                    dbcont.SaveChanges();
                }
                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Record Update Successfully!');location.replace('" + url + "')</script>");

            }
            catch (Exception)
            {

                string url = this.Request.UrlReferrer.AbsoluteUri;
                return Content("<script language='javascript' type='text/javascript'>alert('Some Error Occure!');location.replace('" + url + "')</script>");

            }

        }

        //public JsonResult Delete(int Id)
        //{
        //    try
        //    {
        //        var genralobj = dbcont.Tbl_Complains.FirstOrDefault(e => e.Id == Id);
        //        if (genralobj != null)
        //        {
        //            dbcont.Tbl_Complains.Remove(genralobj);
        //            dbcont.SaveChanges();
        //            return Json("Success");
        //        }
        //        else
        //        {
        //            return Json("Record Not Found");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public ActionResult ViewComplain(int id)
        {
            Tbl_Complains tbl_Complains = dbcont.Tbl_Complains.FirstOrDefault(x => x.Id == id);
            return View(tbl_Complains);
        }
    }


}