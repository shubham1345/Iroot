using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    //[CustomAuthenticationFilter]
    public class HomeUserController : Controller
    {
        GeneralDBContext db = new GeneralDBContext();
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: HomeUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HomeUser()
        {
            string currentUser = Convert.ToString(Session["username"]);
        
            //AllMembersCount
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllMembersCount = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false).Count();
            }
            else
            {
                ViewBag.AllMembersCount = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.ProvinceName == currentUser).Count();
            }

            //AllHealthCount
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllHealthCount = db.tbl_Health.Count();
            }
            else
            {
                ViewBag.AllHealthCount = db.tbl_Health.Where(x => x.ProvinceName == currentUser).Count();
            }
           
            //AllSapration
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllSapration = db.tbl_SeperationFromTheCongregation.Count();
            }
            else
            {
                ViewBag.AllSapration = db.tbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == currentUser).Count();
            }

            //AllDeathRecordCount
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllDeathRecordCount = db.tbl_Passed.Count();
            }
            else
            {
               ViewBag.AllDeathRecordCount = db.tbl_Passed.Where(x => x.ProvinceName == currentUser).Count();
            }
          
            //ViewBag.AllAcademy
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllAcademy = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false).Count();
            }
            else
            {
                ViewBag.AllAcademy = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.ProvinceName == currentUser).Count();
            }
            //ViewBag.AllComplain 
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllComplain = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false).Count();
            }
            else
            {
                ViewBag.AllComplain = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.ProvinceName == currentUser).Count();
            }

            //ViewBag.AllAppointment 
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllAppointment = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false).Count();
            }
            else
            {
                ViewBag.AllAppointment = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.ProvinceName == currentUser).Count();
            }

            //ViewBag.AllCandidate
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllCandidate = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Candidacy").Count();
            }
            else
            {
                ViewBag.AllCandidate = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Candidacy" && x.ProvinceName == currentUser).Count();
            }

            //ViewBag.AllOrdined 
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllOrdined = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Ordination").Count();
            }
            else
            {
                ViewBag.AllOrdined = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Ordination" && x.ProvinceName == currentUser).Count();
            }

            //ViewBag.All1stProfession
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.All1stProfession = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "1stProfession").Count();
            }
            else
            {
                ViewBag.All1stProfession = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "1stProfession" && x.ProvinceName == currentUser).Count();
            }

            //ViewBag.AllNovitiate
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.AllNovitiate = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Novitiate1stY" && x.StageOfFormation == "Novitiate2ndY").Count();
            }
            else
            {
                ViewBag.AllNovitiate = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Novitiate1stY" && x.StageOfFormation == "Novitiate2ndY" && x.ProvinceName == currentUser).Count();
            }

            //Governance         
            ViewBag.AllGoverner = db.Tbl_Governer.Where(x => x.ProvinceName == "ADC").Count();
            ViewBag.AllGoverner1 = db.Tbl_Governer.Where(x => x.ProvinceName == "BRA").Count();
            ViewBag.AllGoverner2 = db.Tbl_Governer.Where(x => x.ProvinceName == "CAN").Count();
            ViewBag.AllGoverner3 = db.Tbl_Governer.Where(x => x.ProvinceName == "ESP").Count();
            ViewBag.AllGoverner4 = db.Tbl_Governer.Where(x => x.ProvinceName == "FRA").Count();
            ViewBag.AllGoverner5 = db.Tbl_Governer.Where(x => x.ProvinceName == "INB").Count();
            ViewBag.AllGoverner6 = db.Tbl_Governer.Where(x => x.ProvinceName == "IND").Count();
            ViewBag.AllGoverner7 = db.Tbl_Governer.Where(x => x.ProvinceName == "INE").Count();
            ViewBag.AllGoverner8 = db.Tbl_Governer.Where(x => x.ProvinceName == "INH").Count();
            ViewBag.AllGoverner9 = db.Tbl_Governer.Where(x => x.ProvinceName == "INP").Count();
            ViewBag.AllGoverner10 = db.Tbl_Governer.Where(x => x.ProvinceName == "INR").Count();
            ViewBag.AllGoverner11 = db.Tbl_Governer.Where(x => x.ProvinceName == "INT").Count();
            ViewBag.AllGoverner12 = db.Tbl_Governer.Where(x => x.ProvinceName == "INY").Count();
            ViewBag.AllGoverner13 = db.Tbl_Governer.Where(x => x.ProvinceName == "KIN").Count();
            ViewBag.AllGoverner14 = db.Tbl_Governer.Where(x => x.ProvinceName == "MAL").Count();
            ViewBag.AllGoverner15 = db.Tbl_Governer.Where(x => x.ProvinceName == "PEA").Count();
            ViewBag.AllGoverner16 = db.Tbl_Governer.Where(x => x.ProvinceName == "SEN").Count();
            ViewBag.AllGoverner17 = db.Tbl_Governer.Where(x => x.ProvinceName == "THA").Count();
            ViewBag.AllGoverner18 = db.Tbl_Governer.Count();


            //PrePrimary          
            ViewBag.AllPrePri = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "ADC").Count();
            ViewBag.AllPrePri1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "BRA").Count();
            ViewBag.AllPrePri2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "CAN").Count();
            ViewBag.AllPrePri3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "ESP").Count();
            ViewBag.AllPrePri4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "FRA").Count();
            ViewBag.AllPrePri5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "INB").Count();
            ViewBag.AllPrePri6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "IND").Count();
            ViewBag.AllPrePri7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "INE").Count();
            ViewBag.AllPrePri8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "INH").Count();
            ViewBag.AllPrePri9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "INP").Count();
            ViewBag.AllPrePri10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "INR").Count();
            ViewBag.AllPrePri11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "INT").Count();
            ViewBag.AllPrePri12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "INY").Count();
            ViewBag.AllPrePri13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "KIN").Count();
            ViewBag.AllPrePri14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "MAL").Count();
            ViewBag.AllPrePri15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "PEA").Count();
            ViewBag.AllPrePri16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "SEN").Count();
            ViewBag.AllPrePri17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery" && x.ProvinceName == "THA").Count();
            ViewBag.AllPrePri18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Pre-Primary/ Nursery").Count();

            //Primary
            ViewBag.AllPri = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "ADC").Count();
            ViewBag.AllPri1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "BRA").Count();
            ViewBag.AllPri2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "CAN").Count();
            ViewBag.AllPri3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "ESP").Count();
            ViewBag.AllPri4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "FRA").Count();
            ViewBag.AllPri5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "INB").Count();
            ViewBag.AllPri6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "IND").Count();
            ViewBag.AllPri7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "INE").Count();
            ViewBag.AllPri8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "INH").Count();
            ViewBag.AllPri9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "INP").Count();
            ViewBag.AllPri10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "INR").Count();
            ViewBag.AllPri11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "INT").Count();
            ViewBag.AllPri12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "INY").Count();
            ViewBag.AllPri13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "KIN").Count();
            ViewBag.AllPri14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "MAL").Count();
            ViewBag.AllPri15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "PEA").Count();
            ViewBag.AllPri16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "SEN").Count();
            ViewBag.AllPri17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary" && x.ProvinceName == "THA").Count();
            ViewBag.AllPri18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Primary").Count();

            //Middle School
            ViewBag.AllMidShl = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "ADC").Count();
            ViewBag.AllMidShl1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "BRA").Count();
            ViewBag.AllMidShl2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "CAN").Count();
            ViewBag.AllMidShl3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "ESP").Count();
            ViewBag.AllMidShl4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "FRA").Count();
            ViewBag.AllMidShl5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "INB").Count();
            ViewBag.AllMidShl6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "IND").Count();
            ViewBag.AllMidShl7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "INE").Count();
            ViewBag.AllMidShl8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "INH").Count();
            ViewBag.AllMidShl9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "INP").Count();
            ViewBag.AllMidShl10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "INR").Count();
            ViewBag.AllMidShl11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "INT").Count();
            ViewBag.AllMidShl12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "INY").Count();
            ViewBag.AllMidShl13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "KIN").Count();
            ViewBag.AllMidShl14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "MAL").Count();
            ViewBag.AllMidShl15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "PEA").Count();
            ViewBag.AllMidShl16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "SEN").Count();
            ViewBag.AllMidShl17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School" && x.ProvinceName == "THA").Count();
            ViewBag.AllMidShl18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Middle School").Count();

            //HighSchool
            ViewBag.AllHighShl = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "ADC").Count();
            ViewBag.AllHighShl1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "BRA").Count();
            ViewBag.AllHighShl2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "CAN").Count();
            ViewBag.AllHighShl3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "ESP").Count();
            ViewBag.AllHighShl4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "FRA").Count();
            ViewBag.AllHighShl5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "INB").Count();
            ViewBag.AllHighShl6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "IND").Count();
            ViewBag.AllHighShl7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "INE").Count();
            ViewBag.AllHighShl8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "INH").Count();
            ViewBag.AllHighShl9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "INP").Count();
            ViewBag.AllHighShl10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "INR").Count();
            ViewBag.AllHighShl11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "INT").Count();
            ViewBag.AllHighShl12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "INY").Count();
            ViewBag.AllHighShl13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "KIN").Count();
            ViewBag.AllHighShl14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "MAL").Count();
            ViewBag.AllHighShl15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "PEA").Count();
            ViewBag.AllHighShl16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "SEN").Count();
            ViewBag.AllHighShl17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School" && x.ProvinceName == "THA").Count();
            ViewBag.AllHighShl18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "High School").Count();

            //Hr.Sec,PU Collage
            ViewBag.AllSecPU = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "ADC").Count();
            ViewBag.AllSecPU1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "BRA").Count();
            ViewBag.AllSecPU2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "CAN").Count();
            ViewBag.AllSecPU3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "ESP").Count();
            ViewBag.AllSecPU4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "FRA").Count();
            ViewBag.AllSecPU5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "INB").Count();
            ViewBag.AllSecPU6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "IND").Count();
            ViewBag.AllSecPU7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "INE").Count();
            ViewBag.AllSecPU8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "INH").Count();
            ViewBag.AllSecPU9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "INP").Count();
            ViewBag.AllSecPU10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "INR").Count();
            ViewBag.AllSecPU11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "INT").Count();
            ViewBag.AllSecPU12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "INY").Count();
            ViewBag.AllSecPU13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "KIN").Count();
            ViewBag.AllSecPU14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "MAL").Count();
            ViewBag.AllSecPU15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "PEA").Count();
            ViewBag.AllSecPU16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "SEN").Count();
            ViewBag.AllSecPU17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College" && x.ProvinceName == "THA").Count();
            ViewBag.AllSecPU18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Hr. Sec./ PU College").Count();

            //CBSE School
            ViewBag.AllCBSC = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "ADC").Count();
            ViewBag.AllCBSC1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "BRA").Count();
            ViewBag.AllCBSC2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "CAN").Count();
            ViewBag.AllCBSC3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "ESP").Count();
            ViewBag.AllCBSC4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "FRA").Count();
            ViewBag.AllCBSC5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "INB").Count();
            ViewBag.AllCBSC6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "IND").Count();
            ViewBag.AllCBSC7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "INE").Count();
            ViewBag.AllCBSC8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "INH").Count();
            ViewBag.AllCBSC9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "INP").Count();
            ViewBag.AllCBSC10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "INR").Count();
            ViewBag.AllCBSC11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "INT").Count();
            ViewBag.AllCBSC12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "INY").Count();
            ViewBag.AllCBSC13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "KIN").Count();
            ViewBag.AllCBSC14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "MAL").Count();
            ViewBag.AllCBSC15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "PEA").Count();
            ViewBag.AllCBSC16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "SEN").Count();
            ViewBag.AllCBSC17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School" && x.ProvinceName == "THA").Count();
            ViewBag.AllCBSC18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "CBSE School").Count();

            //College
            ViewBag.AllCollege = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "ADC").Count();
            ViewBag.AllCollege1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "BRA").Count();
            ViewBag.AllCollege2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "CAN").Count();
            ViewBag.AllCollege3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "ESP").Count();
            ViewBag.AllCollege4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "FRA").Count();
            ViewBag.AllCollege5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "INB").Count();
            ViewBag.AllCollege6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "IND").Count();
            ViewBag.AllCollege7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "INE").Count();
            ViewBag.AllCollege8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "INH").Count();
            ViewBag.AllCollege9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "INP").Count();
            ViewBag.AllCollege10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "INR").Count();
            ViewBag.AllCollege11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "INT").Count();
            ViewBag.AllCollege12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "INY").Count();
            ViewBag.AllCollege13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "KIN").Count();
            ViewBag.AllCollege14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "MAL").Count();
            ViewBag.AllCollege15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "PEA").Count();
            ViewBag.AllCollege16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "SEN").Count();
            ViewBag.AllCollege17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College" && x.ProvinceName == "THA").Count();
            ViewBag.AllCollege18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "College").Count();

            //Training College B.Ed. , M.Ed. & D.Ed.
            ViewBag.AllCollegeBMD = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "ADC").Count();
            ViewBag.AllCollegeBMD1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "BRA").Count();
            ViewBag.AllCollegeBMD2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "CAN").Count();
            ViewBag.AllCollegeBMD3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "ESP").Count();
            ViewBag.AllCollegeBMD4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "FRA").Count();
            ViewBag.AllCollegeBMD5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "INB").Count();
            ViewBag.AllCollegeBMD6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "IND").Count();
            ViewBag.AllCollegeBMD7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "INE").Count();
            ViewBag.AllCollegeBMD8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "INH").Count();
            ViewBag.AllCollegeBMD9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "INP").Count();
            ViewBag.AllCollegeBMD10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "INR").Count();
            ViewBag.AllCollegeBMD11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "INT").Count();
            ViewBag.AllCollegeBMD12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "INY").Count();
            ViewBag.AllCollegeBMD13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "KIN").Count();
            ViewBag.AllCollegeBMD14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "MAL").Count();
            ViewBag.AllCollegeBMD15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "PEA").Count();
            ViewBag.AllCollegeBMD16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "SEN").Count();
            ViewBag.AllCollegeBMD17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed." && x.ProvinceName == "THA").Count();
            ViewBag.AllCollegeBMD18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Training College B.Ed. , M.Ed. & D.Ed.").Count();

            //Community College
            ViewBag.AllComClg = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "ADC").Count();
            ViewBag.AllComClg1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "BRA").Count();
            ViewBag.AllComClg2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "CAN").Count();
            ViewBag.AllComClg3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "ESP").Count();
            ViewBag.AllComClg4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "FRA").Count();
            ViewBag.AllComClg5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "INB").Count();
            ViewBag.AllComClg6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "IND").Count();
            ViewBag.AllComClg7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "INE").Count();
            ViewBag.AllComClg8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "INH").Count();
            ViewBag.AllComClg9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "INP").Count();
            ViewBag.AllComClg10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "INR").Count();
            ViewBag.AllComClg11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "INT").Count();
            ViewBag.AllComClg12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "INY").Count();
            ViewBag.AllComClg13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "KIN").Count();
            ViewBag.AllComClg14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "MAL").Count();
            ViewBag.AllComClg15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "PEA").Count();
            ViewBag.AllComClg16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "SEN").Count();
            ViewBag.AllComClg17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College" && x.ProvinceName == "THA").Count();
            ViewBag.AllComClg18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Community College").Count();

            //Distance Education
            ViewBag.AllDisEdu = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "ADC").Count();
            ViewBag.AllDisEdu1 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "BRA").Count();
            ViewBag.AllDisEdu2 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "CAN").Count();
            ViewBag.AllDisEdu3 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "ESP").Count();
            ViewBag.AllDisEdu4 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "FRA").Count();
            ViewBag.AllDisEdu5 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "INB").Count();
            ViewBag.AllDisEdu6 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "IND").Count();
            ViewBag.AllDisEdu7 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "INE").Count();
            ViewBag.AllDisEdu8 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "INH").Count();
            ViewBag.AllDisEdu9 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "INP").Count();
            ViewBag.AllDisEdu10 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "INR").Count();
            ViewBag.AllDisEdu11 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "INT").Count();
            ViewBag.AllDisEdu12 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "INY").Count();
            ViewBag.AllDisEdu13 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "KIN").Count();
            ViewBag.AllDisEdu14 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "MAL").Count();
            ViewBag.AllDisEdu15 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "PEA").Count();
            ViewBag.AllDisEdu16 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "SEN").Count();
            ViewBag.AllDisEdu17 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education" && x.ProvinceName == "THA").Count();
            ViewBag.AllDisEdu18 = db.Tbl_ParisInstitutionDetails.Where(x => x.InstitutionType == "Distance Education").Count();


            return View();
        }
        public JsonResult GetAllPrileViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false).ToList();
                var viewAllPrimaryDetails = db.tbl_Primarydetails.ToList();
                var data = new List<GetAllPrileView>();
                foreach (var item in allPersionalDetails)
                {
                    var name = item.Name + " " + item.SirName;
                    var dataPrimary = viewAllPrimaryDetails.FirstOrDefault(x => x.MemberId == item.MemberID);
                    data.Add(new GetAllPrileView()
                    {
                        Name = name,
                        MemberId = dataPrimary == null ? null : dataPrimary.MemberId
                    });
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.ProvinceName == currentUser).ToList();
                var viewAllPrimaryDetails = db.tbl_Primarydetails.Where(x => x.ProvinceName == currentUser).ToList();
                var data = new List<GetAllPrileView>();
                foreach (var item in allPersionalDetails)
                {
                    var name = item.Name + " " + item.SirName;
                    var dataPrimary = viewAllPrimaryDetails.FirstOrDefault(x => x.MemberId == item.MemberID);
                    data.Add(new GetAllPrileView()
                    {
                        Name = name,
                        MemberId = dataPrimary == null ? null : dataPrimary.MemberId
                    });
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
    
        }

        public class GetAllPrileView
        {
            public string Name { get; set; }
            public string MemberId { get; set; }
        }
        public JsonResult GetAllEternalViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var data = db.tbl_Passed.Select(x => new { x.Name, x.MemberID, }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.tbl_Passed.Where(x => x.ProvinceName == currentUser).Select(x => new { x.Name, x.MemberID, }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            //string currentUser = Convert.ToString(Session["username"]);
            //if (Session["username"].ToString() == "adminuser")
            //{
            //    var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false).ToList();
            //    var viewAllComlainDetails = db.tbl_Passed.ToList();
            //    var data = new List<GetAllPrileView>();
            //    foreach (var item in allPersionalDetails)
            //    {
            //        var name = item.Name + " " + item.SirName;
            //        var datacomplain = viewAllComlainDetails.FirstOrDefault(x => x.MemberID == item.MemberID);
            //        data.Add(new GetAllPrileView()
            //        {
            //            Name = name,
            //            MemberId = datacomplain == null ? null : datacomplain.MemberID
            //        });
            //    }

            //    return Json(data, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.ProvinceName == currentUser).ToList();
            //    var viewAllComlainDetails = db.tbl_Passed.Where(x => x.ProvinceName == currentUser).ToList();
            //    var data = new List<GetAllPrileView>();
            //    foreach (var item in allPersionalDetails)
            //    {
            //        var name = item.Name + " " + item.SirName;
            //        var datacomplain = viewAllComlainDetails.FirstOrDefault(x => x.MemberID == item.MemberID);
            //        data.Add(new GetAllPrileView()
            //        {
            //            Name = name,
            //            MemberId = datacomplain == null ? null : datacomplain.MemberID
            //        });
            //    }

            //    return Json(data, JsonRequestBehavior.AllowGet);
            //}
        }
        public JsonResult GetAllSaprationViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allRecords = db.tbl_SeperationFromTheCongregation
                             .Select(x => new { x.Name, x.MemberID })
                             .ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = db.tbl_SeperationFromTheCongregation.Where(x => x.ProvinceName == currentUser)
                            .Select(x => new { x.Name, x.MemberID })
                            .ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllHealthViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allRecords = db.tbl_Health
                            .Select(x => new { x.Name, x.MemberID })
                            .ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = db.tbl_Health.Where(x => x.ProvinceName == currentUser)
                            .Select(x => new { x.Name, x.MemberID })
                            .ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCandidacy()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Candidacy").Select(x => new { x.Name, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.ProvinceName == currentUser && x.StageOfFormation == "Candidacy").Select(x => new { x.Name, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllSacramentViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allRecords = db.Sacraments
                       .Select(x => new { x.Name, x.MemberId })
                       .ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = db.Sacraments.Where(x => x.ProvinceName == currentUser)
                      .Select(x => new { x.Name, x.MemberId })
                      .ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
          
        }
        public JsonResult GetAllAppointViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false).ToList();
                var viewAllComlainDetails = db.Appointments.ToList();
                var data = new List<GetAllPrileView>();
                foreach (var item in allPersionalDetails)
                {
                    var name = item.Name + " " + item.SirName;
                    var datacomplain = viewAllComlainDetails.FirstOrDefault(x => x.MemberId == item.MemberID);
                    data.Add(new GetAllPrileView()
                    {
                        Name = name,
                        MemberId = datacomplain == null ? null : datacomplain.MemberId
                    });
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.ProvinceName == currentUser).ToList();
                var viewAllComlainDetails = db.Appointments.Where(x => x.ProvinceName == currentUser).ToList();
                var data = new List<GetAllPrileView>();
                foreach (var item in allPersionalDetails)
                {
                    var name = item.Name + " " + item.SirName;
                    var datacomplain = viewAllComlainDetails.FirstOrDefault(x => x.MemberId == item.MemberID);
                    data.Add(new GetAllPrileView()
                    {
                        Name = name,
                        MemberId = datacomplain == null ? null : datacomplain.MemberId
                    });
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllAcademicViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                //var data = db.tbl_Academy.Select(x => new { x.Name, x.MemberId, }).ToList();
                var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false).ToList();
                var viewAllComlainDetails = db.tbl_Academy.ToList();
                var data = new List<GetAllPrileView>();
                foreach (var item in allPersionalDetails)
                {
                    var name = item.Name + " " + item.SirName;
                    var datacomplain = viewAllComlainDetails.FirstOrDefault(x => x.MemberId == item.MemberID);
                    data.Add(new GetAllPrileView()
                    {
                        Name = name,
                        MemberId = datacomplain == null ? null : datacomplain.MemberId
                    });
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.ProvinceName == currentUser).ToList();
                var viewAllComlainDetails = db.tbl_Academy.Where(x => x.ProvinceName == currentUser).ToList();
                var data = new List<GetAllPrileView>();
                foreach (var item in allPersionalDetails)
                {
                    var name = item.Name + " " + item.SirName;
                    var datacomplain = viewAllComlainDetails.FirstOrDefault(x => x.MemberId == item.MemberID);
                    data.Add(new GetAllPrileView()
                    {
                        Name = name,
                        MemberId = datacomplain == null ? null : datacomplain.MemberId
                    });
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllFormationViewData()
        {

            //var data = db.Tbl_formationsDetails.Select(x => new {x.Name, x.MemberId, }).ToList();
            var allPersionalDetails = db.tbl_PersonalDetails.ToList();
            var viewAllComlainDetails = db.Tbl_formationsDetails.ToList();
            var data = new List<GetAllPrileView>();
            foreach (var item in allPersionalDetails)
            {
                var name = item.Name + " " + item.SirName;
                var datacomplain = viewAllComlainDetails.FirstOrDefault(x => x.MemberId == item.MemberID);
                data.Add(new GetAllPrileView()
                {
                    Name = name,
                    MemberId = datacomplain == null ? null : datacomplain.MemberId
                });
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllComplainViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false).ToList();
                var viewAllComlainDetails = db.Tbl_Complains.ToList();
                var data = new List<GetAllPrileView>();
                foreach (var item in allPersionalDetails)
                {
                    var name = item.Name + " " + item.SirName;
                    var datacomplain = viewAllComlainDetails.FirstOrDefault(x => x.MemberId == item.MemberID);
                    data.Add(new GetAllPrileView()
                    {
                        Name = name,
                        MemberId = datacomplain == null ? null : datacomplain.MemberId
                    });
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allPersionalDetails = db.tbl_PersonalDetails.Where(x => x.IsDeleted == false && x.ProvinceName == currentUser).ToList();
                var viewAllComlainDetails = db.Tbl_Complains.Where(x => x.ProvinceName == currentUser).ToList();
              
                var data = new List<GetAllPrileView>();
                foreach (var item in allPersionalDetails)
                {
                    var name = item.Name + " " + item.SirName;
                    var datacomplain = viewAllComlainDetails.FirstOrDefault(x => x.MemberId == item.MemberID);
                    data.Add(new GetAllPrileView()
                    {
                        Name = name,
                        MemberId = datacomplain == null ? null : datacomplain.MemberId
                    });
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetFirstProfesssion()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "1stProfession").Select(x => new { x.Name, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.ProvinceName == currentUser && x.StageOfFormation == "1stProfession").Select(x => new { x.Name, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetPerNovitiate()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Novitiate1stY" && x.StageOfFormation == "Novitiate2ndY").Select(x => new { x.Name, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.ProvinceName == currentUser && x.StageOfFormation == "Novitiate1stY" && x.StageOfFormation == "Novitiate2ndY").Select(x => new { x.Name, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetPerProfession()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "PerpetualProfession").Select(x => new { x.Name, x.FromDate, x.ToDate, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.ProvinceName == currentUser && x.StageOfFormation == "PerpetualProfession").Select(x => new { x.Name, x.FromDate, x.ToDate, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetOrdination()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Ordination").Select(x => new { x.Name, x.FromDate, x.ToDate, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.ProvinceName == currentUser && x.StageOfFormation == "Ordination").Select(x => new { x.Name, x.FromDate, x.ToDate, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetOrdination1()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.StageOfFormation == "Ordination").Select(x => new { x.Name, x.FromDate, x.ToDate, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allRecords = db.Tbl_formationsDetails.Where(x => x.ProvinceName == currentUser && x.StageOfFormation == "Ordination").Select(x => new { x.Name, x.FromDate, x.ToDate, x.MemberId }).ToList();
                return Json(allRecords, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeathRecord(string id)
        {
            tbl_Passed data = dbcont.tbl_Passed.FirstOrDefault(x => x.MemberID.ToString() == id);
            ViewBag.allData = dbcont.tbl_Passed.Where(x => x.MemberID == data.MemberID).ToList();
            return View(data);
        }
        public ActionResult MemberDetails(string id)
        {
            tbl_Primarydetails data = dbcont.tbl_Primarydetails.FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.allData = dbcont.tbl_Primarydetails.Where(x => x.MemberId == data.MemberId).ToList();
            return View(data);
        }
        public ActionResult FormationDetails(string id)
        {
            Tbl_formationsDetails data = dbcont.Tbl_formationsDetails.FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.allformationData = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == data.MemberId).ToList();
            return View(data);
        }
        public ActionResult FirstProfessionDetails(string id)
        {
            Tbl_formationsDetails data = dbcont.Tbl_formationsDetails.Where(x => x.StageOfFormation == "1stProfession").FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.allfirstprofessionData = dbcont.Tbl_formationsDetails.Where(x => x.StageOfFormation == "1stProfession" && x.MemberId == data.MemberId).ToList();
            return View(data);
        }
        public ActionResult PerProfessionDetails(string id)
        {
            Tbl_formationsDetails data = dbcont.Tbl_formationsDetails.FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.allPerProfessionData = dbcont.Tbl_formationsDetails.Where(x => x.MemberId == data.MemberId).ToList();
            return View(data);
        }
        public ActionResult SaprationDetails(string id)
        {
            tbl_SeperationFromTheCongregation data = dbcont.tbl_SeperationFromTheCongregation.FirstOrDefault(x => x.MemberID.ToString() == id);
            ViewBag.allData = dbcont.tbl_SeperationFromTheCongregation.Where(x => x.MemberID == data.MemberID).ToList();
            ViewBag.MemberId = id;
            return View(data);
        }
        public ActionResult HealthDetails(string id)
        {
            tbl_Health data = dbcont.tbl_Health.FirstOrDefault(x => x.MemberID.ToString() == id);
            ViewBag.allHealthData = dbcont.tbl_Health.Where(x => x.MemberID == data.MemberID).ToList();
            return View(data);
        }
        public ActionResult FamilyDetails(string id)
        {
            FamilyDetails data = dbcont.FamilyDetails.FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.allFamilyData = dbcont.FamilyDetails.Where(x => x.MemberId == data.MemberId).ToList();
            return View(data);
        }
        public ActionResult SacramentDetails(string id)
        {
            Sacraments data = dbcont.Sacraments.FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.allSacramentData = dbcont.Sacraments.Where(x => x.MemberId == data.MemberId).ToList();
            return View(data);
        }
        public ActionResult AppointmentDetails(string id)
        {
            Appointments data = dbcont.Appointments.FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.allAppointmentData = dbcont.Appointments.Where(x => x.MemberId == data.MemberId).ToList();
            return View(data);
        }
        public ActionResult AcademicDetails(string id)
        {
            tbl_Academy data = dbcont.tbl_Academy.FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.allAcademicData = dbcont.tbl_Academy.Where(x => x.MemberId == data.MemberId).ToList();
            return View(data);
        }
        public ActionResult ComplaintDetails(string id)
        {
            Tbl_Complains data = dbcont.Tbl_Complains.FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.allComlainsData = dbcont.Tbl_Complains.Where(x => x.MemberId == data.MemberId).ToList();
            return View(data);
        }
        public JsonResult GetAllBirthViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var month = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var allbirthdata = dbcont.tbl_Primarydetails
                                  .Where(x => x.DOB != null).ToList();

                foreach (var item in allbirthdata)
                {
                    var data = item.DOB.Split('/');
                    if (data[1].TrimStart('0') == month.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            Name = item.Knowname,
                            DOB = item.DOB
                        });
                    }
                }
                return Json(alldata.Where(x => x.Knowname != "").ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var month = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var allbirthdata = dbcont.tbl_Primarydetails
                                  .Where(x => x.ProvinceName == currentUser && x.DOB != null).ToList();

                foreach (var item in allbirthdata)
                {
                    var data = item.DOB.Split('/');
                    if (data[1].TrimStart('0') == month.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            Name = item.Knowname,
                            DOB = item.DOB
                        });
                    }
                }
                return Json(alldata.Where(x => x.Knowname != "").ToList(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllFeastViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var currentmonth = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var allfeastday = dbcont.tbl_Primarydetails.Where(x => x.Feastday != null).ToList();
                foreach (var item in allfeastday)
                {
                    var data = item.Feastday.Split('/');
                    if (data[1].TrimStart('0') == currentmonth.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            Name = item.Knowname,
                            Feastday = item.Feastday
                        });

                    }

                }
                return Json(alldata.Where(x => x.Knowname != "").ToList(), JsonRequestBehavior.AllowGet);

            }
            else
            {
                var currentmonth = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var allfeastday = dbcont.tbl_Primarydetails
                                  .Where(x => x.ProvinceName == currentUser && x.Feastday != null)
                                  .ToList();
                foreach (var item in allfeastday)
                {
                    var data = item.Feastday.Split('/');
                    if (data[1].TrimStart('0') == currentmonth.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            Name = item.Knowname,
                            Feastday = item.Feastday
                        });
                    }
                }
                return Json(alldata.Where(x => x.Knowname != "").ToList(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllEternalDayViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var currentmonth = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var alleternal = dbcont.tbl_Passed.Where(x => x.Date != null).ToList();
                foreach (var item in alleternal)
                {
                    var data = item.Date.Split('/');
                    if (data[1].TrimStart('0') == currentmonth.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            Name = item.Name,
                            Date = item.Date
                        });

                    }
                }
                return Json(alldata.Where(x => x.Name != "").ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var currentmonth = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var alleternal = dbcont.tbl_Passed.Where(x => x.ProvinceName == currentUser && x.Date != null).ToList();
                foreach (var item in alleternal)
                {
                    var data = item.Date.Split('/');
                    if (data[1].TrimStart('0') == currentmonth.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            Name = item.Name,
                            Date = item.Date
                        });

                    }
                }
                return Json(alldata.Where(x => x.Name != "").ToList(), JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult GetAllJubileeViewData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "admin")
            {
                var jubliiiData = new List<JubliiiData>();
                var data = dbcont.tbl_Primarydetails.Where(x => x.Ordination != "" && x.Ordination != null)
                                  .ToList();
                foreach (var item in data)
                {
                    if (jubliiiData != null)
                    {
                        jubliiiData.Add(new JubliiiData
                        {
                            Name = item.Knowname,
                            SurName = item.Baptismialname,
                            Date = item.Ordination,
                            JubliiType = GetJubliiType(item.Ordination.Trim())
                        });
                    }
                }

                return Json(jubliiiData.Where(x => x.JubliiType != null).ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var jubliiiData = new List<JubliiiData>();
                var data = dbcont.tbl_Primarydetails.Where(x => x.ProvinceName == currentUser && x.Ordination != "" && x.Ordination != null)
                                  .ToList();
                foreach (var item in data)
                {
                    if (jubliiiData != null)
                    {
                        jubliiiData.Add(new JubliiiData
                        {
                            Name = item.Knowname,
                            SurName = item.Baptismialname,
                            Date = item.Ordination,
                            JubliiType = GetJubliiType(item.Ordination.Trim())
                        });

                    }
                }
                return Json(jubliiiData.Where(x => x.JubliiType != null).ToList(), JsonRequestBehavior.AllowGet);
            }
        }
        [NonAction]
        public string GetJubliiType(string date)
        {
            DateTime currentdate = DateTime.ParseExact(System.DateTime.Now.Date.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int Age = new DateTime((currentdate - dt).Ticks).Year - 1;

            if (Age == 25)
            {
                return "Silver Jubilee";
            }
            else if (Age == 50)
            {
                return "Golden Jubilee";
            }
            else if (Age == 75)
            {
                return "Platinum Jubilee";
            }
            else
            {
                return null;
            }

        }
        public JsonResult AppoData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var month = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var allappodata = dbcont.AppointmentData
                                  .Where(x =>x.Date != null).ToList();

                foreach (var item in allappodata)
                {
                    var data = item.Date.Split('/');
                    if (data[1].TrimStart('0') == month.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            DataListItemName = item.DataListItemName,
                            Description = item.Description,
                            Date = item.Date
                        });
                    }
                }
                return Json(alldata.Where(x => x.DataListItemName != "").ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var month = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var allappodata = dbcont.AppointmentData
                                  .Where(x => x.ProvinceName == currentUser && x.Date != null).ToList();
                                
                foreach (var item in allappodata)
                {
                    var data = item.Date.Split('/');
                    if (data[1].TrimStart('0') == month.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            DataListItemName = item.DataListItemName,
                            Description = item.Description,
                            Date = item.Date
                        });
                    }
                }
                return Json(alldata.Where(x => x.DataListItemName != "").ToList(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult RemindData()
        {
            string currentUser = Convert.ToString(Session["username"]);
            if (Session["username"].ToString() == "adminuser")
            {
                var month = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var allreminddata = dbcont.DataListItems2
                                  .Where(x => x.ToDate != null).ToList();

                foreach (var item in allreminddata)
                {
                    var data = item.ToDate.Split('/');
                    if (data[1].TrimStart('0') == month.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            DataListItemName = item.DataListItemName,
                            Description = item.Description,
                            Date = item.ToDate
                        });
                    }
                }
                return Json(alldata.Where(x => x.DataListItemName != "").ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var month = System.DateTime.Now;
                List<birthdayData> alldata = new List<birthdayData>();
                var allreminddata = dbcont.DataListItems2
                                  .Where(x => x.ProvinceName == currentUser && x.ToDate != null).ToList();

                foreach (var item in allreminddata)
                {
                    var data = item.ToDate.Split('/');
                    if (data[1].TrimStart('0') == month.Month.ToString())
                    {
                        alldata.Add(new birthdayData
                        {
                            DataListItemName = item.DataListItemName,
                            Description = item.Description,
                            Date = item.ToDate
                        });
                    }
                }
                return Json(alldata.Where(x => x.DataListItemName != "").ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}