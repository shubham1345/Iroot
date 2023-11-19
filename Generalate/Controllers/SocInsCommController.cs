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
    public class SocInsCommController : Controller
    {

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult PrintMemberReport()
        {

            return View();

        }
        public JsonResult Society()
        {



            return Json(JsonRequestBehavior.AllowGet);
        }
        public List<DetailsSummaryViewModel> GetAllSummaryData(string memberId)
        {
            List<DetailsSummaryViewModel> data = new List<DetailsSummaryViewModel>();

            var primaryDetails = dbcont.tbl_Primarydetails.FirstOrDefault(x => x.MemberId.ToString() == memberId);
            if (primaryDetails != null)
            {
                data.Add(new DetailsSummaryViewModel
                {
                    Title = primaryDetails.Knowname,
                    Date = primaryDetails.DOB,
                    Description = primaryDetails.noofsisters
                });
            }

            var familyData = dbcont.FamilyDetails.Where(x => x.MemberId == memberId).ToList();
            if (familyData != null)
            {
                foreach (var item in familyData)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Name,
                        Date = item.YearOfBirth,
                        Description = item.Address
                    });
                }
            }

            var allhealths = dbcont.tbl_Health.Where(x => x.MemberID == memberId).ToList();
            if (allhealths != null)
            {
                foreach (var item in allhealths)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Title,
                        Date = item.FromDate,
                        Description = item.Description
                    });
                }
            }

            var allpassed = dbcont.tbl_Passed.Where(x => x.MemberID == memberId).ToList();
            if (allpassed != null)
            {
                foreach (var item in allpassed)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Title,
                        Date = item.Date,
                        Description = item.Description
                    });
                }
            }

            var allScraments = dbcont.Sacraments.Where(x => x.MemberId == memberId).ToList();
            if (allScraments != null)
            {
                foreach (var item in allScraments)
                {
                    data.Add(new DetailsSummaryViewModel
                    {
                        Title = item.Title,
                        Date = item.Date,
                        Description = item.Remarks
                    });
                }
            }

            return data;
        }
    }
}
