using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Generalate.Models.ViewModels;
using System.Threading.Tasks;
using System.IO;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class SecularEducationController : Controller
    {
        // GET: SecularEducation

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Secular()
        {
            // ViewBag.tbl_PersonalDetails = new SelectList(dbcont.tbl_PersonalDetails, "Name", "MemberID");
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult SecularPrint()
        {
            return View();
        }

        //public ActionResult SecularReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("SecularPrint");
        //}


        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_SecularEducation.ToList(), JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_SecularEducation.FirstOrDefault(e => e.SecularId == Id);
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

        public JsonResult Add(tbl_SecularEducation newobj)
        {
            try
            {
                if (newobj.Certificate != null)
                {
                    string filename = newobj.Certificate;
                    newobj.Certificate = null;
                    newobj.Certificate = filename;
                }
                dbcont.tbl_SecularEducation.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_SecularEducation newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_SecularEducation.FirstOrDefault(e => e.SecularId == newobj.SecularId);
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
                var genralobj = dbcont.tbl_SecularEducation.FirstOrDefault(e => e.SecularId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_SecularEducation.Remove(genralobj);
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
                tbl_SecularEducation gen = new tbl_SecularEducation();
                gen = dbcont.tbl_SecularEducation.FirstOrDefault(e => e.SecularId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Details(int id)
        {
            var member = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.PersonalDetailsId == id);
            List<FormationViewModel> formationViewsList = new List<FormationViewModel>();
            var allFormation = dbcont.tbl_SecularEducation.Where(x => x.MemberID == member.MemberID).ToList();
            Parallel.ForEach(allFormation, (formation) =>
            {
                FormationViewModel formationViewModel = new FormationViewModel()
                {
                    Course = formation.Certificate,
                    //Title = formation.Spare1,
                    DegreeObtained = formation.DegreeName,
                    Univercity = formation.University,
                    Fromdate = formation.FromDate,
                    ToDate = formation.ToDate,
                    ClassObtained = formation.ClassObtained,
                    Id = formation.SecularId,
                    Medium = formation.Medium,
                    Address = formation.Address,
                    Remarks = formation.Remarks,
                    //file1 = formation.Spare2
                };
                formationViewsList.Add(formationViewModel);
            });

            var pertiondetails = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.PersonalDetailsId == id);
            TempData["Name"] = pertiondetails.Name;
            TempData["SirName"] = pertiondetails.SirName;
            TempData["MemberId"] = pertiondetails.MemberID;

            return View(formationViewsList);
        }

        [HttpPost]
        public JsonResult AddFormation(FormationViewModel formationViewModel)
        {
            tbl_SecularEducation tbl_SecularEducation = new tbl_SecularEducation();
            tbl_SecularEducation.Certificate = formationViewModel.Course;
            //tbl_SecularEducation.Spare1 = formationViewModel.Title;
            tbl_SecularEducation.DegreeName = formationViewModel.DegreeObtained;
            tbl_SecularEducation.University = formationViewModel.Univercity;
            tbl_SecularEducation.FromDate = formationViewModel.Fromdate;
            tbl_SecularEducation.ToDate = formationViewModel.ToDate;
            tbl_SecularEducation.ClassObtained = formationViewModel.ClassObtained;
            tbl_SecularEducation.Medium = formationViewModel.Medium;
            tbl_SecularEducation.Address = formationViewModel.Address;
            tbl_SecularEducation.Remarks = formationViewModel.Remarks;
            //tbl_SecularEducation.Spare2 = formationViewModel.file1;
            tbl_SecularEducation.MemberID = formationViewModel.MemberId;
            tbl_SecularEducation.SirName = formationViewModel.SirName;
            tbl_SecularEducation.Name = formationViewModel.Name;


            try
            {
                dbcont.tbl_SecularEducation.Add(tbl_SecularEducation);
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
                var genFormation = dbcont.tbl_SecularEducation.FirstOrDefault(e => e.SecularId == id);
                if (genFormation != null)
                {
                    dbcont.tbl_SecularEducation.Remove(genFormation);
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
                var genFormation = dbcont.tbl_SecularEducation.FirstOrDefault(e => e.SecularId == id);
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
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            var memid = "";
            var comPath = "";
            var fileName = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                memid = System.Web.HttpContext.Current.Request["Memid"];

                if (pic.ContentLength > 0)
                {
                    var _ext = Path.GetExtension(pic.FileName);
                    //fileName = Guid.NewGuid().ToString() + _ext;
                    fileName = pic.FileName+ _ext;
                    comPath = Server.MapPath("~/Images/SecularCertificate/") + fileName;
                    pic.SaveAs(comPath);
                }
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AddFormation1(tbl_SecularEducation formationViewModel)
        {
        

                tbl_SecularEducation table = new tbl_SecularEducation();

                table.MemberID = formationViewModel.MemberID;

            try
            {
                dbcont.tbl_SecularEducation.Add(table);
                dbcont.SaveChanges();
                return Json("Success");

            }
                //general.IsDeleted = false;
                //dbcont.tbl_SecularEducation.Add(formationViewModel);

                //dbcont.SaveChanges();
              
         
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }

        }
    }
}