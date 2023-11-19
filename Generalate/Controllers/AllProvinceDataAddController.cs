using Generalate.Helpers;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class AllProvinceDataAddController : Controller
    {
        private GeneralDBContext db = new GeneralDBContext();
        private GeneralDBContext dbcont = new GeneralDBContext();

        // GET: AllProvinceDataAdd
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllProvinceDataAdd()
        {
            var AllProvince = dbcont.tbl_Province.ToList();
            ViewBag.AllProvince = AllProvince;

            return View();
        }

        public ActionResult AddProvinceData(AllProvinceRecord AllProvinceRecord)
        {
            dbcont.AllProvinceRecord.Add(AllProvinceRecord);
            dbcont.SaveChanges();
            string url = this.Request.UrlReferrer.AbsolutePath;
            return Content("<script language='javascript' type='text/javascript'>alert('Data Save Successfully!');location.replace('" + url + "')</script>");

        }

        public ActionResult AllProvinceDataView( string id)
        {
            Tbl_RenewalVows AllMemberdata = dbcont.Tbl_RenewalVows.FirstOrDefault(x => x.MemberId.ToString() == id);
            ViewBag.AllMemberdata = dbcont.Tbl_RenewalVows.Where(x => x.MemberId == AllMemberdata.MemberId).ToList();
            return View();

        }
    }
}