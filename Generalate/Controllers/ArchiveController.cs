using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Generalate.Models.Edmx;
using Generalate.Helpers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class ArchiveController : Controller
    {
        GeneralDBContext db = new GeneralDBContext();
        EmailEntities edb = new EmailEntities();
        public ActionResult Index()
        {
            loadLandRecord();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UploadFiles(Documentdata data)
        {

            DocumentContent dc = new DocumentContent();

            dc.CommunityName = data.CommunityName;
            dc.Place = data.Place;
            dc.State = data.State;
            dc.City = data.City;
            dc.District = data.District;
            dc.DocumentCategory = data.DocumentCategory;
            dc.DocumentSubCategory = data.DocumentSubCategory;
            dc.Year = data.Year;
            dc.Filename = data.files[0].FileName.ToString();
            var DocumentId =((edb.Documents
                     .OrderByDescending(m => m.ID)
                     .FirstOrDefault()).ID);
            List<string> filePathsList = new List<string>();
            foreach (HttpPostedFileBase file in data.files)
            {


                if (file != null && file.ContentLength > 0)
                {
                    string path1 = string.Format("{0}\\{1}", Server.MapPath("~/Documents"), "ArchiveFiles");
                    var filename = Path.GetFileNameWithoutExtension(file.FileName);
                    var extension = Path.GetExtension(file.FileName);
                    string fileWithDate = String.Format("{0}_{1}_{2}", filename, DateTime.Now.ToString("yyyyMMddHHmmssfff"), extension);
                    var fullpath = string.Format("{0}\\{1}", path1, fileWithDate);
                    SaveFile(path1, fullpath, file);
                    filePathsList.Add(fullpath);

                    var contenttype = file.ContentType;
                    byte[] documentContent = ReadFile(fullpath);
                    try
                    {


                        Guid id = Guid.NewGuid();
                        //  dc.DocumentId =Convert.ToInt32(DocumentId);
                        dc.DocumentId = (DocumentId);
                        dc.ArchivedFile = id;
                        dc.FileContent = documentContent;
                        dc.FileExtension = extension;
                        dc.FileMIMEtype = file.ContentType;
                        dc.Year = DateTime.Now.Year.ToString();
                        dc.Filesendtime = DateTime.Now;
                        dc.Filename = filename;

                        edb.DocumentContents.Add(dc);
                        edb.SaveChanges();
                        return RedirectToAction("Index");
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        TempData["Message"] = String.Empty;
                    }

                }
            }
            loadLandRecord();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SearchDocument(DocumentContent data)
        {
         

            DocumentContent d = edb.DocumentContents.Where(
                x => x.DocumentCategory == data.DocumentCategory
                && x.DocumentSubCategory == data.DocumentSubCategory
                && x.Filename == data.Filename
                ).FirstOrDefault();

            List<DocumentContent> ddata = edb.DocumentContents.Where(
               x => x.DocumentCategory == data.DocumentCategory
               && x.DocumentSubCategory == data.DocumentSubCategory
               && x.Filename == data.Filename
               ).ToList();
            if (ddata != null && ddata.Count != 0)
            {
                ViewBag.ddata = ddata;
            }
            if (d != null)
                if (d.FileContent != null)
                {
                    byte[] byteArray = d.FileContent;
                    MemoryStream ms = new MemoryStream(byteArray);
                    ViewBag.FileContent = ms;

                    loadLandRecord();
                

                    return View("Index");
                }
            loadLandRecord();
            return View("Index");
        }
        private void SaveFile(string directoryPath, string fullpath, HttpPostedFileBase file)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            file.SaveAs(fullpath);
        }
        public ActionResult GetDataByLandId(int Id)
        {
            DocumentContent d = edb.DocumentContents.Where(x => x.ID == Id).FirstOrDefault();
            byte[] byteArray = d.FileContent;
            MemoryStream ms = new MemoryStream(byteArray);
            ViewBag.FileContent = ms;
            return PartialView("_ImageViewer", ViewBag.FileContent);
        }
        public JsonResult GetFieldValues(int Id)
        {

            //int fvalue = Convert.ToInt32(fieldvalue);
            return Json(edb.ArchiveFieldValues.Where(x => x.FieldId == Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveFieldvalue(int fieldid, string fiename, string fieldvalue)
        {
            ArchiveFieldValue av = new ArchiveFieldValue();

            av.FieldId = fieldid;
            av.Fieldname = fiename;
            av.FieldValue = fieldvalue;

            edb.ArchiveFieldValues.Add(av);
            try
            {
                edb.SaveChanges();
                loadLandRecord();
                return Json("Success", JsonRequestBehavior.AllowGet);
            }

#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Failure", JsonRequestBehavior.AllowGet);
            }

        }
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            //Close BinaryReader
            br.Close();

            //Close FileStream
            fStream.Close();

            return data;
        }

        public void loadLandRecord()
        {
            List<ArchiveField> ar = edb.ArchiveFields.ToList();
            ViewData["FieldName"] = new SelectList(edb.ArchiveFields.ToList(), "ID", "FieldName");
            ViewBag.ArchiveField = ar;
            foreach (var v in edb.ArchiveFields.ToList())
            {
                if (v.FieldName == "CommunityName")
                    ViewData[v.FieldName] = new SelectList(edb.ArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");
                if (v.FieldName == "Place")
                    ViewData[v.FieldName] = new SelectList(edb.ArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");
                if (v.FieldName == "State")
                    ViewData[v.FieldName] = new SelectList(edb.ArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");
                if (v.FieldName == "City")
                    ViewData[v.FieldName] = new SelectList(edb.ArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");
                if (v.FieldName == "District")
                    ViewData[v.FieldName] = new SelectList(edb.ArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");
                if (v.FieldName == "DocumentCategory")
                    ViewData[v.FieldName] = new SelectList(edb.ArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");
                if (v.FieldName == "DocumentSubCategory")
                    ViewData[v.FieldName] = new SelectList(edb.ArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");
                if (v.FieldName == "Year")
                    ViewData[v.FieldName] = new SelectList(edb.ArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");

            }
            loadPersonalRecord();
        }
        public void loadPersonalRecord()
        {
            List<PArchiveField> arp = edb.PArchiveFields.ToList();
            ViewData["PFieldName"] = new SelectList(edb.PArchiveFields.ToList(), "ID", "FieldName");
            foreach (var v in edb.PArchiveFields.ToList())
            {
                if (v.FieldName == "MemberID")
                    ViewData[v.FieldName] = new SelectList(db.tbl_PersonalDetails, "Name", "MemberID");
                //if (v.FieldName == "Username")
                //    ViewData[v.FieldName] = new SelectList(db.tbl_PersonalDetails, "Name", "MemberID");
                if (v.FieldName == "PDocumentCategory")
                    ViewData[v.FieldName] = new SelectList(edb.PArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");
                if (v.FieldName == "PDocumentSubCategory")
                    ViewData[v.FieldName] = new SelectList(edb.PArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");
                if (v.FieldName == "PYear")
                    ViewData[v.FieldName] = new SelectList(edb.PArchiveFieldValues.Where(x => x.FieldId == v.ID), "FieldValue", "FieldValue");

            }
            ViewBag.PArchiveField = arp;

        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PSearchDocument(PersonalDocumentContent data, string MemberIDhdns)
        {

            PersonalDocumentContent d = edb.PersonalDocumentContents.Where(
                x => x.PDocumentCategory == data.PDocumentCategory
                && x.PDocumentSubCategory == data.PDocumentSubCategory
                && x.Filename == data.Filename
                ).FirstOrDefault();

            List<PersonalDocumentContent> pddata = edb.PersonalDocumentContents.Where(
                x => x.PDocumentCategory == data.PDocumentCategory
                && x.PDocumentSubCategory == data.PDocumentSubCategory
                && x.Filename == data.Filename
                ).ToList();
          
            if (pddata != null && pddata.Count != 0)
            {
                ViewBag.pddata = pddata;
            }
            if (d != null)
                if (d.FileContent != null)
                {
                    byte[] byteArray = d.FileContent;
                    MemoryStream ms = new MemoryStream(byteArray);
                    ViewBag.FileContent = ms;
                   
                    loadLandRecord();
                    string tab2active = "tab2active";
                    ViewBag.secondtab = tab2active;
                    return View("Index");
                }
            
            loadLandRecord();
            return RedirectToAction("Index");
        }
        public JsonResult PGetFieldValues(int Id)
        {

            //int fvalue = Convert.ToInt32(fieldvalue);
            return Json(edb.PArchiveFieldValues.Where(x => x.FieldId == Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult PSaveFieldvalue(int pfieldid, string pfiename, string pfieldvalue)
        {
            PArchiveFieldValue pav = new PArchiveFieldValue();

            pav.FieldId = pfieldid;
            pav.Fieldname = pfiename;
            pav.FieldValue = pfieldvalue;

            edb.PArchiveFieldValues.Add(pav);
            try
            {
                edb.SaveChanges();
              
                return Json("Success", JsonRequestBehavior.AllowGet);
            }

#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Failure", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult PUploadFiles(PersonalData data, string MemberIDhdn)
        {
           

            PersonalDocumentContent dc = new PersonalDocumentContent();

           
            var DocumentId = (db.tbl_PersonalDetails
                .OrderByDescending(m => m.MemberID)
                .FirstOrDefault()).MemberID;

            dc.MemberID = MemberIDhdn;
            dc.Name = data.Name;
            dc.PDocumentCategory = data.PDocumentCategory;
            dc.PDocumentSubCategory = data.PDocumentSubCategory;
            dc.PYear = data.PYear;
            dc.Filename = data.files[0].FileName.ToString();

            List<string> filePathsList = new List<string>();
            foreach (HttpPostedFileBase file in data.files)
            {


                if (file != null && file.ContentLength > 0)
                {
                    string path1 = string.Format("{0}\\{1}", Server.MapPath("~/Documents"), "PersonalArchiveFiles");
                    var filename = Path.GetFileNameWithoutExtension(file.FileName);
                    var extension = Path.GetExtension(file.FileName);
                    string fileWithDate = String.Format("{0}_{1}_{2}", filename, DateTime.Now.ToString("yyyyMMddHHmmssfff"), extension);
                    var fullpath = string.Format("{0}\\{1}", path1, fileWithDate);
                    SaveFile(path1, fullpath, file);
                    filePathsList.Add(fullpath);

                    var contenttype = file.ContentType;
                    byte[] documentContent = ReadFile(fullpath);
                    try
                    {


                        Guid id = Guid.NewGuid();

                        dc.ArchivedFile = id;
                        dc.FileContent = documentContent;
                        dc.FileExtension = extension;
                        dc.FileMIMEtype = file.ContentType;
                        dc.PYear = DateTime.Now.Year.ToString();
                        dc.Filesendtime = DateTime.Now;
                        dc.Filename = filename;

                        edb.PersonalDocumentContents.Add(dc);
                        edb.SaveChanges();
                        string tab2active = "tab2active";
                        ViewBag.secondtab = tab2active;
                        TempData["secondtab"] = tab2active;
                        loadLandRecord();
                        return RedirectToAction("Index");
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        TempData["Message"] = String.Empty;
                    }

                }
            }
            loadLandRecord();
            return View("Index");
        }
        public ActionResult GetDataByPId(int Id)
        {
            PersonalDocumentContent d = edb.PersonalDocumentContents.Where(x => x.ID == Id).FirstOrDefault();
            byte[] byteArray = d.FileContent;
            MemoryStream ms = new MemoryStream(byteArray);
            ViewBag.PFileContent = ms;
            return PartialView("_ImageViewer", ViewBag.PFileContent);
        }

       // [HttpPost]
        public ActionResult ViewPDF(String id)
        {
            string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"500px\" height=\"500px\">";
            embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            embed += "</object>";
            TempData["Embed"] = string.Format(embed, VirtualPathUtility.ToAbsolute("~/Documents/10_CSS.pdf"));

            return RedirectToAction("Index");
        }
     
    }
}