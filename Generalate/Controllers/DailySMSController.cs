using Generalate.Helpers;
using Generalate.Models;
using Generalate.Models.Edmx;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class DailySMSController : Controller
    {
        // GET: DailySMS

        //GeneralDBContext dbcont = new GeneralDBContext();
        EmailEntities dbcont = new EmailEntities();
        public ActionResult DailySMS()
        {
            return View();
        }

        public JsonResult SMS()
        {
            string smsurl = "http://sms.sbjinfo.com/submitsms.jsp?user=redchc&key=89be15d1adXX&mobile=7795596525&message=JesusChrist&senderid=INFOSM&accusage=1";
            WebRequest request = WebRequest.Create(smsurl);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return Json(responseFromServer, JsonRequestBehavior.AllowGet);
        }




        public JsonResult CheckSMSBalance()
        {
            WebRequest request = WebRequest.Create("http://sms.sbjinfo.com/getbalance.jsp?user=redchc&key=89be15d1adXX&accusage=1");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return Json(responseFromServer, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DailySMSPrint()
        {
            return View();
        }

        //public ActionResult DailySMSReport()
        //{
        //    return new Rotativa.MVC.ActionAsPdf("DailySMSPrint");
        //}


        public JsonResult GetAll()
        {
            try
            {
                var data = dbcont.tbl_DailySms.ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
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
                var gid = dbcont.tbl_DailySms.FirstOrDefault(e => e.SmsId == Id);
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

        public JsonResult Add(tbl_DailySms newobj)
        {
            try
            {
                dbcont.tbl_DailySms.Add(newobj);
                dbcont.SaveChanges();
                return Json("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult Update(tbl_DailySms newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_DailySms.FirstOrDefault(e => e.SmsId == newobj.SmsId);
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
                var genralobj = dbcont.tbl_DailySms.FirstOrDefault(e => e.SmsId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_DailySms.Remove(genralobj);
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

        public ActionResult SMSContent()
        {
            return View();
        }

        public JsonResult CGetAll()
        {
            try
            {
                return Json(dbcont.tbl_SMSContent, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult CGetById(int Id)
        {
            try
            {
                var gid = dbcont.tbl_SMSContent.FirstOrDefault(e => e.ContentId == Id);
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

        public JsonResult CAdd(tbl_SMSContent newobj)
        {
            try
            {
              //  newobj.ContentId = 1;
                //dbcont.tbl_SMSContent.Add(newobj);
                //dbcont.SaveChanges();
                dbcont.addSMSContent(newobj.Feast,newobj.Content,newobj.Status,newobj.Spare);
                return Json("Success");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return Json("Failed");
            }
        }

        public JsonResult CUpdate(tbl_SMSContent newobj)
        {
            try
            {
                var existingobj = dbcont.tbl_SMSContent.FirstOrDefault(e => e.ContentId == newobj.ContentId);
                dbcont.Entry(existingobj).CurrentValues.SetValues(newobj);
                dbcont.SaveChanges();
                return Json("Sucess");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult CDelete(int Id)
        {
            try
            {
                var genralobj = dbcont.tbl_SMSContent.FirstOrDefault(e => e.ContentId == Id);
                if (genralobj != null)
                {
                    dbcont.tbl_SMSContent.Remove(genralobj);
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