using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Data.Entity;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class CommonDataListItemsController : Controller
    {
        // GET: CommonDataListItems
        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult DataListItems()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_CommonDataListItems, JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_CommonDataListItems.FirstOrDefault(e => e.CDLITId == Id);
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

        public JsonResult Add(tbl_CommonDataListItems general)
        {
            try
            {
                dbcont.tbl_CommonDataListItems.Add(general);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_CommonDataListItems general)
        {
            try
            {
                var genralobj = dbcont.tbl_CommonDataListItems.FirstOrDefault(e => e.CDLITId == general.CDLITId);
                //genralobj.DataListName = general.DataListName;
                //genralobj.DataListItemName = general.DataListItemName;
                //genralobj.Status = general.Status;
                dbcont.Entry(genralobj).CurrentValues.SetValues(general);
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
                var genralobj = dbcont.tbl_CommonDataListItems.FirstOrDefault(e => e.CDLITId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_CommonDataListItems.Remove(genralobj);
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

        public JsonResult GetDatalistItemsByModuleName(string DlistName)
        {
            var query = (from c in dbcont.tbl_CommonDataListItems
                         where c.DataListName.Equals(DlistName)
                         orderby c.DataListName ascending
                         select new { c.DataListItemName }).Distinct();

            return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDatalistName()
        {
            var query = (from c in dbcont.tbl_CommonDataList
                         orderby c.DataListName ascending
                         select new { c.DataListName }).Distinct();

            return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}