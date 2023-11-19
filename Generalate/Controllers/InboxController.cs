using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.Edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class InboxController : Controller
    {
        GeneralDBContext db = new GeneralDBContext();
        EmailEntities edb;

        public InboxController()
        {
            edb = new EmailEntities();
        }
        public ActionResult Inbox()
        {
             

            var dd = edb.InboxEmails.Count();
            List<string> existingUid = edb.InboxEmails.Select(x => x.EmailUid).ToList();
            List<EmailMessage> messages;
            messages = Utils.ReceiveEmail(existingUid).ToList();
            storeindatabase(messages);
            List<InboxEmail> messagesdb = edb.InboxEmails.Where(x=>x.IsDeleted!=true).ToList();
            ViewBag.messages = messagesdb.Count()==0? null: messagesdb;
            ViewBag.messagesCount = messagesdb.Count();


            return View();
        }
        [HttpGet]
        public JsonResult GetPersonaldetails(string term)
        {

            List<string> persons = db.tbl_PersonalDetails.Where(s => s.Name.StartsWith(term))
                .Select(x => x.EmailID).ToList();
            return Json(persons, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetInboxDataByMailId(string id)
        {
            Guid ID;

            if (Guid.TryParse(id, out ID))
            {
                //TODO Rajesh Comment this code
                //List <CGetInboxByMailId> data= edb.GetInboxByMailId(ID).ToList();
                //if (data.Count == 0)
                //{
                //    var dataemail = from email in edb.InboxEmails
                //                    where email.ID == ID
                //                    select email;
                    
                //    return Json(dataemail, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return Json(data, JsonRequestBehavior.AllowGet);
                //}

            }
            return View(string.Empty,JsonRequestBehavior.AllowGet);
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
                //att = edb.GetFileDataByFileId(ID).FirstOrDefault();
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
        public ActionResult delete(string id)
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
                }

                return View("Inbox");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            return View("Inbox");

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
        public void storeindatabase(List<EmailMessage> messages)
        {
            
            foreach(var message in messages)
            {
                InboxEmail i = new InboxEmail();
                Guid EmailId = Guid.NewGuid();
                i.ID = EmailId;
                i.EmailUid = message.Uid;
                i.FromAddress = message.EmailContent.Headers.From.Address;
                i.ToAddress = string.Join(",", message.EmailContent.Headers.To.Select(x => x.Address));
                i.CCAddress = string.Join(",", message.EmailContent.Headers.Cc.Select(x => x.Address));
                i.BCCAddress = string.Join(",", message.EmailContent.Headers.Bcc.Select(x => x.Address));
                i.Subject= message.EmailContent.Headers.Subject;
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
              i.EmailDate= message.EmailContent.Headers.DateSent;
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

    }
}
  