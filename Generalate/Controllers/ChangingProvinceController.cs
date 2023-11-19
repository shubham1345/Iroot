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
    public class ChangingProvinceController : Controller
    {

        private GeneralDBContext db = new GeneralDBContext();
        private GeneralDBContext dbcont = new GeneralDBContext();
        // GET: ChangingProvince
        public ActionResult ChangingProvinceList(string myId)
        {

            string currentloginuserid = Convert.ToString(Session["loginuserid"]);
            string currentUser = Convert.ToString(Session["username"]);
            var data = db.tbl_Province.FirstOrDefault(x => x.MyId == myId);
            if (data != null && !string.IsNullOrEmpty(data.MyId))
            {
                ViewBag.Provincename = data.ProvinceName;
                ViewBag.MyId = data.MyId;
                ViewBag.Id = data.Id;

                var brotherbyProv = dbcont.tbl_PersonalDetails.Where(x => x.ProvinceName == data.Id.ToString()).ToList();
                if (brotherbyProv != null)
                {
                    if (Session["username"].ToString() == "admin")
                    {

                        var brotherbyProv1 = brotherbyProv
                        .Where(x => x.IsTransfer != "yes" && x.Archivecheck != "yes" && x.Diedcheck != "Active" && x.Sapcheck != "Active").ToList()
                        .Select(x => new tbl_PersonalDetails { MemberID = x.MemberID, Name = x.Name, SirName = x.SirName })
                        .ToList();
                        ViewBag.brotherbyProv = brotherbyProv1;

                    }
                    else
                    {
                        var brotherbyProv1 = brotherbyProv
                        .Where(x => x.ProvinceName == data.Id.ToString() && x.CreatedBy == currentloginuserid && x.IsTransfer != "yes" && x.Archivecheck != "yes" && x.Diedcheck != "Active" && x.Sapcheck != "Active").ToList()
                        .Select(x => new tbl_PersonalDetails { MemberID = x.MemberID, Name = x.Name, SirName = x.SirName })
                        .ToList();

                        ViewBag.brotherbyProv = brotherbyProv1;
                    }

                    ViewBag.currentPro = data.ProvinceName;
                    ViewBag.currentProMyId = data.MyId;
                }

                //Transferdata
                if (Session["username"].ToString() == "admin")
                {
                    //  var prodata = dbcont.tbl_Province.FirstOrDefault(x => x.MyId == myId);
                    var AllData1 = dbcont.Tbl_Transfer.Where(x => x.OldProvinceId == myId).ToList();
                    ViewBag.AllData = AllData1;
                }
                else
                {
                    var AllData1 = dbcont.Tbl_Transfer.Where(x => x.CreatedBy == currentloginuserid).ToList();
                    ViewBag.AllData = AllData1;
                }
            }
            return View();
        }
    }
}