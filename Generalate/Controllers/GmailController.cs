using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.Edmx;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class GmailController : Controller
    {
        GeneralDBContext db = new GeneralDBContext();
        EmailEntities edb = new EmailEntities();
        string username = ConfigurationManager.AppSettings["frommail"].ToString();
        string password = ConfigurationManager.AppSettings["password"].ToString();
        string host = ConfigurationManager.AppSettings["host"].ToString();
        public ActionResult Inbox()
        {

           
            LoadInbox();
            Loaddata();

            return View();
        }
        public ActionResult GetAll()
        {
            
            var messagesdb = edb.InboxEmails.Where(x => x.IsDeleted != true).Select(e => new { e.ID, e.Subject, e.FromAddress, e.EmailDate}).ToList();
            Loaddata();
            return Json(messagesdb, JsonRequestBehavior.AllowGet);
        }
        public void storeindatabase(List<EmailMessage> messages)
        {

            foreach (var message in messages)
            {
                InboxEmail i = new InboxEmail();
                Guid EmailId = Guid.NewGuid();
                i.ID = EmailId;
                i.EmailUid = message.Uid;
                i.FromAddress = message.EmailContent.Headers.From.Address;
                i.ToAddress = string.Join(",", message.EmailContent.Headers.To.Select(x => x.Address));
                i.CCAddress = string.Join(",", message.EmailContent.Headers.Cc.Select(x => x.Address));
                i.BCCAddress = string.Join(",", message.EmailContent.Headers.Bcc.Select(x => x.Address));
                i.Subject = message.EmailContent.Headers.Subject;
                byte[] messageBody = null;
                var body = message.EmailContent.FindFirstHtmlVersion();
                if (body != null)
                    messageBody = body.Body;
                else
                {
                    body = message.EmailContent.FindFirstPlainTextVersion();
                    if (body != null)
                        messageBody = body.Body;
                }
                string ascii = Encoding.ASCII.GetString(messageBody);

                // if the original encoding was UTF-8
                string utf = Encoding.UTF8.GetString(messageBody);

                // if the original encoding was UTF-16
                string utfs = Encoding.Unicode.GetString(messageBody);
                i.Body = messageBody;
                i.asciiBody = ascii;
                i.utfBody = utf;
                i.utfsBody = utfs;
                i.EmailDate = message.EmailContent.Headers.DateSent;
                i.MailType = 1;
                edb.InboxEmails.Add(i);
                edb.SaveChanges();
                foreach (var att in message.Attachments)
                {
                    InboxEmailAttachment at = new InboxEmailAttachment();
                    at.ID = Guid.NewGuid();
                    at.InboxEmailID = EmailId;
                    at.Filename = att.FileName;
                    at.Attachment = att.Body;
                    edb.InboxEmailAttachments.Add(at);
                    edb.SaveChanges();

                }

            }


        }
        public ActionResult GetInboxDataByMailId(string id)
        {
#pragma warning disable CS0168 // The variable 'ID' is declared but never used
            Guid ID;
#pragma warning restore CS0168 // The variable 'ID' is declared but never used
            //TODO Rajesh Comment this code
            //if (Guid.TryParse(id, out ID))
            //{
            //    List<CGetInboxByMailId> data = edb.GetInboxByMailId(ID).ToList();
            //    if (data.Count == 0)
            //    {
            //        var dataemail = from email in edb.InboxEmails
            //                        where email.ID == ID
            //                        select email;

            //        return Json(dataemail, JsonRequestBehavior.AllowGet);
            //    }
            //    else
            //    {
            //        return Json(data, JsonRequestBehavior.AllowGet);
            //    }

            //}
            return View(string.Empty, JsonRequestBehavior.AllowGet);
        }
        public ActionResult deleteInboxrecord(string id)
        {
            try
            {
                Guid ID;

                if (Guid.TryParse(id, out ID))
                {
                    InboxEmail i = edb.InboxEmails.FirstOrDefault(x => x.ID == ID);
                    i.IsDeleted = true;
                    edb.SaveChanges();
                    List<InboxEmail> messagesdb = edb.InboxEmails.Where(x => x.IsDeleted != true).ToList();
                    ViewBag.messages = messagesdb;
                    ViewBag.messagesCount = messagesdb.Count();
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
       public void Loaddata()
       {
            var messagesdb = edb.InboxEmails.Where(x => x.IsDeleted != true).Select(e => new { e.ID, e.Subject, e.FromAddress, e.EmailDate }).ToList();
            ViewBag.messages = messagesdb;
            ViewBag.messagesCount = messagesdb.Count();
       }
        public void LoadInbox()
        {
            List<string> existingUid = edb.InboxEmails.Select(x => x.EmailUid).ToList();
            List<EmailMessage> messages = Utils.ReceiveEmail(existingUid).ToList();
            storeindatabase(messages);
        }
        public JsonResult GetPersonaldetails(string term)
        {

            List<string> persons = db.tbl_PersonalDetails.Where(s => s.Name.StartsWith(term))
                .Select(x => x.EmailID).ToList();
            return Json(persons, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UploadFiles(Emaildata data)
        {


            tbl_Emaildata ed = new tbl_Emaildata();
            // int count=edb.tbl_Emaildata.Max(x=>x==null?0:x.EmailId);
            //int count = edb.tbl_Emaildata.Max(x=>x==null?0:x.EmailId);
            //int count = 0;
            //int emailId = 0;
            //if (edb.tbl_Emaildata.Count() == 0)
            //{
            //    emailId = count + 1;
            //}
            //else if (edb.tbl_Emaildata.Count() > 0)
            //{
            //    count = edb.tbl_Emaildata.Max(x => x.EmailId);
            //    emailId = count + 1;
            //}
            //int emailId=count+1;
            ed.EmailSubject = data.Subject;
            ed.EmailBody = data.Body;
            ed.ToAddress = data.PersonalDetails;

#pragma warning disable CS0219 // The variable 'Sender' is assigned but its value is never used
            string Sender = "rajesh.techprocomp@gmail.com";
#pragma warning restore CS0219 // The variable 'Sender' is assigned but its value is never used
            Guid objGuid = new Guid();
            objGuid = Guid.NewGuid();

            if (data.files.Count(file => file != null) > 0)
            {
                try
                {
                    //  int EmailId=edb.AddEmailDataMethod(data.Subject, data.Body, data.PersonalDetails, data.CCAddress, data.BCCAddress, username, objGuid.ToString(),false);
                    // System.Data.Entity.Core.Objects.ObjectParameter output = new System.Data.Entity.Core.Objects.ObjectParameter("AddEmailData", typeof(int));


                    var EmailId = edb.AddEmailData(objGuid, data.Subject, data.Body, data.PersonalDetails, data.CCAddress, data.BCCAddress, username, false);
                    //edb.AddEmailDataMethod(data.Subject, data.Body, data.PersonalDetails, data.CCAddress, data.BCCAddress, username, objGuid.ToString(), false,out id);



                    List<string> filePathsList = new List<string>();
                    foreach (HttpPostedFileBase file in data.files)
                    {
                        tbl_EmailAttachement et = new tbl_EmailAttachement();
                        if (file != null && file.ContentLength > 0)
                        {
                            string path1 = string.Format("{0}\\{1}", Server.MapPath("~/Documents"), "EmailAttachemnts");
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
                                edb.addAttachment(file.FileName, documentContent, contenttype, extension, objGuid);


                                TempData["Message"] = "Email has been sent successfully!!!";
                            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                            {
                                TempData["Message"] = String.Empty;
                            }

                        }
                    }
                    sendMail(ed.EmailSubject, ed.EmailBody, ed.ToAddress.TrimEnd(','), filePathsList, objGuid);
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }

            }
            else
            {
                try
                {

                    var identity = edb.AddEmailData(objGuid, data.Subject, data.Body, data.PersonalDetails, data.CCAddress, data.BCCAddress, username, false);

                    sendMail(ed.EmailSubject, ed.EmailBody, ed.ToAddress.TrimEnd(','), null, objGuid);
                    TempData["Message"] = "Email has been sent successfully!!!";
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    TempData["Message"] = String.Empty;
                }
            }





            return RedirectToAction("Inbox", "Gmail");
        }

        private void SaveFile(string directoryPath, string fullpath, HttpPostedFileBase file)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            file.SaveAs(fullpath);
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
        public void sendMail(string Subject, string body, string emailto, List<string> filePathList, Guid objGuid)
        {
            try
            {
                string frommail = ConfigurationManager.AppSettings["frommail"].ToString();
                string password = ConfigurationManager.AppSettings["password"].ToString();
                string host = ConfigurationManager.AppSettings["host"].ToString();
                MailMessage newmsg = new MailMessage();
                newmsg.From = new MailAddress(frommail);

                string[] multimailId = emailto.Split(',');

                if (emailto.Contains(',') == true)
                {
                    foreach (string mailto in multimailId)
                    {
                        if (!string.IsNullOrEmpty(mailto.Trim()) && mailto != String.Empty)
                            newmsg.To.Add(new MailAddress(mailto));
                    }
                }
                else
                {
                    newmsg.To.Add(emailto);
                }

                newmsg.Subject = Subject;
                newmsg.Body = body;
                newmsg.BodyEncoding = Encoding.UTF8;
                newmsg.IsBodyHtml = true;
                String MessageID = "<" + objGuid.ToString() + ">";


                //For File Attachment, more file can also be attached
                //Attachment att = new Attachment(filePathList.FirstOrDefault());
                if (filePathList != null && filePathList.Count != 0)
                {
                    try
                    {
                        foreach (string attachementpath in filePathList)
                        {
                            newmsg.Attachments.Add(new Attachment(attachementpath));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                SmtpClient smtp = new SmtpClient(host, 587);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(frommail, password);
                smtp.EnableSsl = true;


                try
                {
                    smtp.Send(newmsg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public JsonResult GetEmailWithFileCount()
        {
           //TODO Rajesh  Comment This code
            //List<CGetEmailWithFileCount> data = edb.GetEmailWithFileCountMethod().ToList();
            //return Json(data, JsonRequestBehavior.AllowGet);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        
            public ActionResult Delete(string id)
            {
                try
                {
                    Guid ID;
                    if (Guid.TryParse(id, out ID))
                        edb.DeleteByEmailId(ID);
                    return RedirectToAction("Inbox");
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                return View("Inbox");

            }
            [HttpGet]
            [ValidateInput(false)]
            public ActionResult GetDataByMailId(string id)
            {
                Guid ID;

                if (Guid.TryParse(id, out ID))
                {
                //TODO Rajesh Comment this code
                    //var data = edb.GetDataByMailIdMethod(ID).ToList();
                    //if (data.Count == 0)
                    //{
                    //    var dataemail = from email in edb.tbl_Emaildata
                    //                    where email.EmailUniqueId == ID
                    //                    select email;
                    //    return Json(dataemail, JsonRequestBehavior.AllowGet);
                    //}
                    //else
                    //{
                    //    return Json(data, JsonRequestBehavior.AllowGet);
                    //}

                }
                return View();
            }
            [HttpGet]
            [ValidateInput(false)]
            public ActionResult GetFileDataByFileIdMethod(string id)
            {
                Guid ID;
                tbl_EmailAttachement att = null;
                if (Guid.TryParse(id, out ID))
                {
                     //TODO Rajesh
                    //att = edb.GetFileDataByFileIdMethod(ID).FirstOrDefault();
                }
                string filename = att.attchedfilename;
                string contentType = att.FileMIMEtype;
                Byte[] data = (Byte[])att.FileContent;

                // Send the file to the browser
                //Response.AddHeader("Content-type", contentType);
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                //Response.Charset = "";
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.BinaryWrite(data);
                //Response.Flush();
                //Response.End();
                // return Json(data, JsonRequestBehavior.AllowGet);
                return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
            }   
    }

    }
