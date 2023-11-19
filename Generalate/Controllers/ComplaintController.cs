using Generalate.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using System.Web.UI.WebControls;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class ComplaintController : Controller
    {
        // GET: Complaint

        GeneralDBContext dbcont = new GeneralDBContext();
        tbl_Complaint tbl = new tbl_Complaint();
        
        public ActionResult Complaints()
        {
            var getids = dbcont.tbl_PersonalDetails.Where(x=>x.IsDeleted==false).ToList();
            SelectList list = new SelectList(getids, "Name", "SirName");
            ViewBag.tbl_PersonalDetails = list;
            return View();
        }

        

        //[HttpPost]
        //public ActionResult Complaints(FormCollection fc, HttpPostedFileBase file)
        //{
        //    tbl.MemberID = fc["tbl_PersonalDetails option:selected"].ToString();
        //    tbl.Name = fc["Name"].ToString(); 
        //    tbl.Decesion = fc["Decesion"].ToString(); 
        //    tbl.ComplaintFrom = fc["ComplaintFrom"].ToString(); 
        //    tbl.ComplaintDATE = fc["ComplaintDATE"].ToString(); 
        //    tbl.ComplaintNATURE = fc["ComplaintNATURE"].ToString();

        //    tbl.Spare1 = fc["Spare1"].ToString();
        //    //if (tbl.Spare1.Length > 30)
        //    //    tbl.Spare1.Substring(0, 30);
        //    //tbl.Document = FileUpload(tbl.MemberID, file);

        //    dbcont.tbl_Complaint.Add(tbl);
        //    dbcont.SaveChanges();
        //   // file.SaveAs(tbl.Document);

        //    return View();
        //}
//

      //  public FileContentResult File()
       // {
            //var fullPathToFile = @"C:\Harish\Ramya\Bishop\Generalate\Documents\debugcore._CMSF1.txt";
        //    var mimeType = "application/text";
            //var mimeType = "application/pdf";
            //var mimeType = "application / vnd.openxmlformats - officedocument.wordprocessingml.document";
         //   var fileContents = System.IO.File.ReadAllBytes(@"C:\Harish\Ramya\Bishop\Generalate\Documents\sample.docx");

            //return new FileContentResult(fileContents, MimeTypes.Pdf);
        //    return new FileContentResult(fileContents, mimeType);
      //  }
//
        //public string  FileUpload(string MembrID, HttpPostedFileBase file)
        //{
        //    var fileName = Path.GetFileName(file.FileName);
        //    var ext = Path.GetExtension(file.FileName);

        //    //string name = Path.GetFileNameWithoutExtension(fileName);
        //    //string myfile = name + "_" + MembrID + ext;

        //    string myfile = MembrID + ext;

        //    var path = Path.Combine(Server.MapPath("~/Documents"), myfile);
        //    //file.SaveAs(path);
            
        //    //PDF Coversion code
        //    //Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
        //    //var wordDocument = appWord.Documents.Open(path);
        //    //wordDocument.ExportAsFixedFormat(path, WdExportFormat.wdExportFormatPDF);

        //    return path;
        //}

        public ActionResult ComplaintsPrint()
        {
            return View();
        }

        //public ActionResult ComplaintsReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("ComplaintsPrint");
        //}

        public JsonResult GetAll()
        {
            try
            {
                return Json(dbcont.tbl_Complaint.ToList(), JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_Complaint.FirstOrDefault(e => e.ComplaintID == Id);
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

        public JsonResult Add(tbl_Complaint newobj)
        {
           try
            {
                dbcont.tbl_Complaint.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }


        //[HttpPost]
        //public void Complaints(HttpPostedFileBase postedFile, tbl_Complaint complaint)
        //{
        //    bytes = null;

        //    using (BinaryReader br = new BinaryReader(postedFile.InputStream))
        //    {
        //        bytes = br.ReadBytes(postedFile.ContentLength);
        //    }

        //    //return bytes;
        //}

       public JsonResult Update(tbl_Complaint newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_Complaint.FirstOrDefault(e => e.ComplaintID == newobj.ComplaintID);
                dbcont.Entry(existingobj).CurrentValues.SetValues(newobj);
                dbcont.SaveChanges();
                return Json("Sucess");
            }
            catch (Exception ex)
            {

               
                throw ex;
            }
        }
    
        public JsonResult Delete(int Id)
        {
            try
            {
                var genralobj = dbcont.tbl_Complaint.FirstOrDefault(e => e.ComplaintID == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_Complaint.Remove(genralobj);
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
                tbl_Complaint gen = new tbl_Complaint();
                gen = dbcont.tbl_Complaint.FirstOrDefault(e => e.ComplaintID == id);
                return View(gen);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadDocFiles()
        {
            var memid = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                memid = System.Web.HttpContext.Current.Request["Memid"];

                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    //_imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~/Images/Complaints/") + memid + _ext;
                    memid = memid + _ext;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                    // MemoryStream ms = new MemoryStream();
                    //  WebImage img = new WebImage(_comPath);

                    //if (img.Width > 200)
                    //    img.Resize(200, 200);
                    //  img.Save(_comPath);
                    // end resize
                }
            }
            return Json(memid, JsonRequestBehavior.AllowGet);
        }

        public FileResult Download()
        {
            string path = Server.MapPath("~/Documents/");
            string FileName = Path.GetFileName("CMF.jpg");

            String fullPath = Path.Combine(path, FileName);
            return File(fullPath, "Documents/jpg", "CMF.jpg");
        }

    }
}