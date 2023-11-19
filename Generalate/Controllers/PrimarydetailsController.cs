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
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class PrimarydetailsController : Controller
    {
        // GET: EntryLife

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Primarydetails()
        {
            // ViewBag.tbl_PersonalDetails = new SelectList(dbcont.tbl_PersonalDetails, "Name", "MemberID");
            var getids = dbcont.tbl_PersonalDetails.Where(x => x.IsDeleted == false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult PrimarydetailsPrint()
        {
            return View();
        }

        //public ActionResult PrimarydetailsReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("PrimarydetailsPrint");
        //}

        public ActionResult Primarydetails1()
        {
            return View();
        }

       

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
                var gid = dbcont.tbl_Primarydetails.FirstOrDefault(e => e.Primaryid == Id);
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

        public JsonResult Add(tbl_Primarydetails newobj)
        {
            try
            {
                dbcont.tbl_Primarydetails.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_Primarydetails newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_Primarydetails.FirstOrDefault(e => e.Primaryid == newobj.Primaryid);
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
                var genralobj = dbcont.tbl_Primarydetails.FirstOrDefault(e => e.Primaryid == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Primarydetails.Remove(genralobj);
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
                return Json(dbcont.tbl_Primarydetails, JsonRequestBehavior.AllowGet);
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
                var gidel1 = dbcont.tbl_Primarydetails.FirstOrDefault(e => e.Primaryid == Id1);
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


       


        public ActionResult ViewProfile(int id)
        {
            try
            {
                tbl_Primarydetails gen = new tbl_Primarydetails();
                gen = dbcont.tbl_Primarydetails.FirstOrDefault(e => e.Primaryid == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult MemberInfoById(int id)
        {
            var member = dbcont.tbl_Primarydetails.FirstOrDefault(x => x.Primaryid == id);
            List<AddMember> formationViewsList = new List<AddMember>();
            var allFormation = dbcont.tbl_Primarydetails.Where(x => x.MemberId == member.MemberId).ToList();
            Parallel.ForEach(allFormation, (formation) =>
            {
                AddMember AddMember = new AddMember()
                {
                    Knowname = formation.Knowname,
                    Baptismialname = formation.Baptismialname,
                    //DOB = formation.DOB,
                    //DOB1 = formation.DOB1,
                    //Feastday = formation.Feastday,
                    //Bloodgroup = formation.Bloodgroup,
                    //emailid = formation.emailid,
                    Id = formation.Primaryid
                    //mobilenumber = formation.mobilenumber,
                    //whatsappnumber = formation.whatsappnumber,
                    //facebookid = formation.facebookid,
                    //twitterid = formation.twitterid,
                    //blog = formation.blog,
                    //house = formation.house,
                    //city = formation.city,
                    //district = formation.district,
                    //state = formation.state,
                    //pin = formation.pin,
                    //adhar = formation.adhar,
                    //pan = formation.pan,
                    //passport = formation.passport,
                    //nameonadhar = formation.nameonadhar,
                    //nameonpan = formation.nameonpan
                };
                formationViewsList.Add(AddMember);
            });

            var pertiondetails = dbcont.tbl_PersonalDetails.FirstOrDefault(x => x.PersonalDetailsId == id);
            TempData["Name"] = pertiondetails.Name;
            TempData["SirName"] = pertiondetails.SirName;
            TempData["MemberId"] = pertiondetails.MemberID;

            return View(formationViewsList);
        }

        [HttpPost]
        public JsonResult AddFormation(AddMember AddMember)
        {
            tbl_Primarydetails tbl_Primarydetails = new tbl_Primarydetails();
            tbl_Primarydetails.Knowname = AddMember.Knowname;
            tbl_Primarydetails.Baptismialname = AddMember.Baptismialname;
            //tbl_Primarydetails.EntryDate = AddMember.Date_Year;
            //tbl_Primarydetails.Place = AddMember.Place;
            //tbl_Primarydetails.Director = AddMember.Superior;
            //tbl_Primarydetails.OngoingFormation = AddMember.StageofFormation;
            //tbl_Primarydetails.Minister = AddMember.Minister;
            //tbl_Primarydetails.Spare2 = AddMember.file;
            //tbl_Primarydetails.MemberID = AddMember.MemberId;
            //tbl_Primarydetails.SirName = AddMember.SirName;


            try
            {
                dbcont.tbl_Primarydetails.Add(tbl_Primarydetails);
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
                var genFormation = dbcont.tbl_EntryLife.FirstOrDefault(e => e.EntryLifeId == id);
                if (genFormation != null)
                {
                    dbcont.tbl_EntryLife.Remove(genFormation);
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
                var genFormation = dbcont.tbl_Primarydetails.FirstOrDefault(e => e.Primaryid == id);
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
    }
}