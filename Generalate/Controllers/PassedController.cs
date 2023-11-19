using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Web.Helpers;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class PassedController : Controller
    {
        // GET: Passed

        GeneralDBContext dbcont = new GeneralDBContext();

        public ActionResult Passed()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        public ActionResult PassedPrint()
        {
            return View();
        }

        //public ActionResult PassedReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("PassedPrint");
        //}

        //[HttpPost]
        //public void Passed(HttpPostedFileBase postedFile, tbl_Passed pass)
        //{
        //    byte[] bytes;
        //    using (BinaryReader br = new BinaryReader(postedFile.InputStream))
        //    {
        //        bytes = br.ReadBytes(postedFile.ContentLength);
        //    }
        //    //string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        //    //using (SqlConnection con = new SqlConnection(constr))
        //    //{
        //    //    string query = "INSERT INTO tblFiles VALUES (@Name, @ContentType, @Data)";
        //    //    using (SqlCommand cmd = new SqlCommand(query))
        //    //    {
        //    //        cmd.Connection = con;
        //    //        cmd.Parameters.AddWithValue("@Name", Path.GetFileName(postedFile.FileName));
        //    //        cmd.Parameters.AddWithValue("@ContentType", postedFile.ContentType);
        //    //        cmd.Parameters.AddWithValue("@Data", bytes);
        //    //        con.Open();
        //    //        cmd.ExecuteNonQuery();
        //    //        con.Close();
        //    //    }
        //    //}

        //    //return View(GetFiles());
        //    //return View();
        //}


        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Passed.ToList(), JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_Passed.FirstOrDefault(e => e.PassedId == Id);
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

        public JsonResult Add(tbl_Passed newobj)
        {
            try
            {
                dbcont.tbl_Passed.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_Passed newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_Passed.FirstOrDefault(e => e.PassedId == newobj.PassedId);
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
                var genralobj = dbcont.tbl_Passed.FirstOrDefault(e => e.PassedId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Passed.Remove(genralobj);
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
                tbl_Passed gen = new tbl_Passed();
                gen = dbcont.tbl_Passed.FirstOrDefault(e => e.PassedId == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            var memid = "";
            var comPath = "";
            var fileName = "";
            var folderName = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                memid = System.Web.HttpContext.Current.Request["Memid"];
                folderName = System.Web.HttpContext.Current.Request["FolderName"];

                if (pic.ContentLength > 0)
                {
                    var _ext = Path.GetExtension(pic.FileName);
                    fileName = Guid.NewGuid().ToString() + _ext;

                    comPath = Server.MapPath("~/Images/PassedImages/") + fileName;

                    pic.SaveAs(comPath);
                }
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }
    }
}