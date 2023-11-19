using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Generalate.Models;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Text;
using System.Web.UI.WebControls;
using Generalate.Models.MailViewModel;
using Generalate.Models.Edmx;
using Generalate.Helpers;
using Generalate.Controllers;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class EmailController : Controller
    {
        GeneralDBContext db = new GeneralDBContext();
        GeneralDBContext dbcont = new GeneralDBContext();

        EmailEntities edb = new EmailEntities();
        string username = ConfigurationManager.AppSettings["frommail"].ToString();
        string password = ConfigurationManager.AppSettings["password"].ToString();
        string host = ConfigurationManager.AppSettings["host"].ToString();

        [HttpGet]
        public ActionResult SignInEmail()
        {

            List<string> existingUid = edb.InboxEmails.Select(x => x.EmailUid).ToList();
            List<EmailMessage> messages = Utils.ReceiveEmail(existingUid).ToList();

            ViewBag.messages = messages;


            return View(messages);
        }
        //[HttpGet]
        //public ActionResult SignInEmail1()
        //{

        //    List<string> existingUid = edb.InboxEmails.Select(x => x.EmailUid).ToList();
        //    List<EmailMessage> messages = Utils.ReceiveEmail(existingUid).ToList();

        //    ViewBag.messages = messages;


        //    return Json(messages, JsonRequestBehavior.AllowGet);
        //}

        // GET: Email
        [HttpGet]
        public ActionResult SendEmail()
        {


            return View();
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult EmailData()
        {
            //TODO Rajesh
            var data = edb.GetEmailWithFileCount().ToList();
            //List<CGetEmailWithFileCount> data = edb.GetEmailWithFileCount().ToList();
            //List<CGetEmailWithFileCount> data = null;
            return Json(data, JsonRequestBehavior.AllowGet);
            // return View(data);
        }
        [HttpGet]
        public JsonResult GetEmailWithFileCount()
        {
            //TODO Rajesh
            //List<CGetEmailWithFileCount> data = edb.GetEmailWithFileCountMethod().ToList();
            List<CGetEmailWithFileCount> data = null;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //GetDataByMailId
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult GetDataByMailId(string id)
        {
            Guid ID;

            //TODO Rajesh  Comment This code and check
            if (Guid.TryParse(id, out ID))
            {
                var data = edb.GetDataByMailId(ID).ToList();
                if (data.Count == 0)
                {
                    var dataemail = from email in edb.tbl_Emaildata
                                    where email.EmailUniqueId == ID
                                    select email;
                    return Json(dataemail, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }

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
                //TODO 
                var Data = edb.GetFileDataByFileId(ID).FirstOrDefault();
                att.attchedfilename = Data.attchedfilename;
                att.EmailUniqueId = Data.EmailUniqueId;
                att.FileContent = Data.FileContent;
                att.FileExtension = Data.FileExtension;
                att.FileMIMEtype = Data.FileMIMEtype;
                att.Filesendtime = Data.Filesendtime;
                att.FileUniqueId = Data.FileUniqueId;
                att.tbl_Emaildata = null;
            }
            string filename = att.attchedfilename;
            string contentType = att.FileMIMEtype;
            Byte[] data = (Byte[])att.FileContent;

            //Send the file to the browser
            Response.AddHeader("Content-type", contentType);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(data);
            Response.Flush();
            Response.End();
            // return Json(data, JsonRequestBehavior.AllowGet);
            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UploadFiles(Emaildata data)
        {


            tbl_Emaildata ed = new tbl_Emaildata();
            //int count = edb.tbl_Emaildata.Max(x => x == null ? 0 : x.EmailId);
            int count = edb.tbl_Emaildata.Where(x => x.ToAddress == data.PersonalDetails).Count();
            if (count < 0)
            {
                count = 0;
            }
            int emailId = 0;
            if (edb.tbl_Emaildata.Count() == 0)
            {
                emailId = count + 1;
            }
            else if (edb.tbl_Emaildata.Count() > 0)
            {
                count = edb.tbl_Emaildata.Count();
                emailId = count + 1;
            }
            emailId = count + 1;
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





            return RedirectToAction("Inbox", "Inbox");
        }

        private void SaveFile(string directoryPath, string fullpath, HttpPostedFileBase file)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            file.SaveAs(fullpath);
        }

        public JsonResult GetPersonaldetails(string term)
        {

            List<string> persons = db.tbl_PersonalDetails.Where(s => s.Name.StartsWith(term))
                .Select(x => x.EmailID).ToList();
            return Json(persons, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetPersonaldetails()
        {

            List<string> persons = db.tbl_PersonalDetails.Select(x => x.EmailID).ToList();
            return Json(persons, JsonRequestBehavior.AllowGet);
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


        public tbl_Emaildata GetFile(string FileName, byte[] FileContent, string FileMIMEtype, string FileExtension)
        {

            return new tbl_Emaildata();
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

        public ActionResult delete(string id)
        {
            try
            {
                Guid ID;
                if (Guid.TryParse(id, out ID))
                    edb.DeleteByEmailId(ID);
                return RedirectToAction("Inbox", "Inbox");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            return View("Inbox", "Inbox");

        }



        #region Calender

        public ActionResult CalenderView()
        {
            return View();
        }

        public JsonResult GetMonthlyEvent()
        {
            string currentUserid = Convert.ToString(Session["loginuserid"]);
            string currentuser = Convert.ToString(Session["username"]);

            var tblappointment = dbcont.AppointmentData.ToList();
            var appointmentdata = new List<CalenderEvents>();
            var tempvow = GetConfingSetting("DyKey1");
            var finalvow = GetConfingSetting("DyKey2");

            var currentdate = DateTime.Now.ToString();


            if (Session["username"].ToString() == "admin")
            {
                //var data = dbcont.tbl_Primarydetails.Where(x => x.DOB != "" && x.DOB != null).ToList();

                var fromdate = currentdate.Split('/');
                var todate = currentdate.Split('/');
                var data = dbcont.tbl_PersonalDetails.Where(x => x.IsTransfer == null).ToList();

                //if (province != "0")
                //{
                //    data = data.Where(x => x.ProvinceName == province).ToList();
                //}
                //else
                //{
                //    data = data.ToList();
                //}
                var primarydata = new List<GetAllPrileView>();
              var primarylist = dbcont.tbl_Primarydetails;
                foreach (var item in data)
                {
                    {
                        var dob = primarylist.FirstOrDefault(x => x.MemberId == item.MemberID);
                        var Firstvow = dbcont.Tbl_formationsDetails.FirstOrDefault(x => x.MemberId == item.MemberID && x.StageOfFormation == tempvow && x.Status == "0" && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null);
                        var FinalVow = dbcont.Tbl_formationsDetails.FirstOrDefault(x => x.MemberId == item.MemberID && x.StageOfFormation == finalvow && x.Status == "1" && x.Diedcheck == null && x.Sapcheck == null && x.Archivecheck == null);
                        if (dob.DOB != null && Firstvow != null && FinalVow != null)
                        {
                            var dataofbirth = dob.DOB.Split('/');
                            if (Convert.ToInt32(dataofbirth[1].TrimStart('0')) == Convert.ToInt32(fromdate[1].TrimStart('0')))
                            {
                                primarydata.Add(new GetAllPrileView()
                                {
                                    Name = item.Name,
                                    Sirname = item.SirName,
                                    DOB = dob.DOB,
                                    Age = MemberController.GetAge1(dob.DOB).ToString()
                                });
                            }
                        }

                    }


                }

                foreach(var obj in tblappointment)
                {
                     if(obj.Date != null)
                    {
                        DateTime adate = Convert.ToDateTime(obj.Date);
                        var date1 = adate.ToString("s");
                        appointmentdata.Add(new CalenderEvents
                        {
                            title = obj.DataListItemName,
                            start = date1,
                            display = "block",
                            textColor = "white",
                            backgroundColor = "#44c3ef"
                        });
                    }
                }


                return Json(appointmentdata, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

            #endregion

        }
        public string GetConfingSetting(string Configkey)
        {
            var tempvow = new tblConfigSetting();
            var ConfigSettings = dbcont.tblConfigSetting.Where(x => x.strPurpose == "MemberReportStatistic").ToList();
            tempvow = ConfigSettings.FirstOrDefault(x => x.strConfigKey == Configkey);
            var finalvow = ConfigSettings.FirstOrDefault(x => x.strConfigKey == "DyKey2");

            return tempvow.strConfigValue;
        }
       
    }

    public class CalenderEvents
    {
        public string title { get; set; }

        public string description { get; set; }

        public string start { get; set; }

        public string end { get; set; }

        public string backgroundColor { get; set; }
        public string display { get; set; }
        public string textColor { get; set; }



    }

}

//     public int EmailId { get; set; }
//        public string EmailSubject { get; set; }
//        public string EmailBody { get; set; }
//        public string EmailTo { get; set; }
//        public string Sender { get; set; }
//        public System.DateTime Emailsenddate { get; set; }
//        public bool IsDeleted { get; set; }
    
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<tbl_EmailAttachement> tbl_EmailAttachement { get; set; }

//}

//foreach (var message in messages)
//                {
//                    var messageUid = message.Uid;
//                    var messageFrom = message.EmailContent.Headers.From.Address;
//                    var messageTo = string.Join(",", message.EmailContent.Headers.To.Select(x => x.Address));
//                    var messageCc = string.Join(",", message.EmailContent.Headers.Cc.Select(x => x.Address));
//                    var messageBcc = string.Join(",", message.EmailContent.Headers.Bcc.Select(x => x.Address));
//                    var messageSubject = message.EmailContent.Headers.Subject;
//                    byte[] messageBody = null;
//                    var body = message.EmailContent.FindFirstHtmlVersion();
//                    if (body != null)
//                        messageBody = body.Body;
//                    else
//                    {
//                        body = message.EmailContent.FindFirstPlainTextVersion();
//                        if (body != null)
//                            messageBody = body.Body;
//                    }
//                    var messageDate = message.EmailContent.Headers.DateSent;

//                    var id = new AddEmailTableAdapter().GetData(emailDetail.ID, messageUid, messageFrom, messageTo, messageCc, messageBcc, messageSubject, messageBody, messageDate, 1);
//                    var eid = (int)id.First().EmailID;
//                    message.Attachments.ForEach(x => new QueriesTableAdapter().AddEmailAttachment(eid, x.FileName, x.Body));
//                }
//            }