using Generalate.Helpers;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class User_JublieController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: User_Jublie
        public ActionResult Jublie()
        {
            return View();
        }
        public ActionResult JublieView(string Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.tbl_Jubilee = GetJublie(Id);
            return View(mymodel);
        }
        public IEnumerable<tbl_Jubilee> GetJublie(string Id)
        {
            return dbcont.tbl_Jubilee.Where(e => e.MemberID == Id);
            // return dbcont.tbl_EntryLife;
        }
        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Jubilee, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public JsonResult ThisMonthGetAllJubly()
        {
            try
            {
                var allRecords = dbcont.tbl_Jubilee.Where(x=>x.GoldenJubilee != null).ToList();

                string Month = "";
                var todayDate = DateTime.Now.Month;
                if (todayDate < 10)
                {
                    Month = "0" + todayDate.ToString();
                }
                else
                {
                    Month = todayDate.ToString();

                }
                if (allRecords.Count > 0)
                {
                    var allRecordBirthday = allRecords.Where(x => Regex.Split(x.GoldenJubilee, @"\D+")[1] == Month)
                                                          .Select(x => new { x.Name, x.SirName, x.GoldenJubilee })
                                                          .ToList();
                    return Json(allRecordBirthday, JsonRequestBehavior.AllowGet);

                }
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}