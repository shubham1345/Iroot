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
    public class CommonDataListController : Controller
    {
        // GET: CommonDataList
        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult DataLists()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_CommonDataList, JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_CommonDataList.FirstOrDefault(e => e.CDLId == Id);
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

        public JsonResult Add(tbl_CommonDataList general)
        {
            try
            {
                dbcont.tbl_CommonDataList.Add(general);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_CommonDataList general)
        {
            try
            {
                var genralobj = dbcont.tbl_CommonDataList.FirstOrDefault(e => e.CDLId == general.CDLId);
                genralobj.DataListName = general.DataListName;
                genralobj.Status = general.Status;

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
                var genralobj = dbcont.tbl_CommonDataList.FirstOrDefault(e => e.CDLId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_CommonDataList.Remove(genralobj);
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

    }
}