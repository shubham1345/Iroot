using Generalate.Helpers;
using Generalate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generalate.Controllers
{
    [CustomAuthenticationFilter]
    public class DataController : Controller
    {
        GeneralDBContext dbcont = new GeneralDBContext();
        // GET: Data
        public ActionResult DataItem()
        {
            var allDataListItems = dbcont.DataLists.ToList();
            ViewBag.allDataListItems = allDataListItems;

            var allDataListItems2 = dbcont.Tbl_ProfessionDetails.ToList();
            ViewBag.allDataListItems2 = allDataListItems2;

            var AllContinent = dbcont.tblContinentMst.ToList();
            ViewBag.Continents = AllContinent;

            var allDataListItems3 = dbcont.Tbl_CommunityAppointmentDetails.ToList();
            ViewBag.allDataListItems3 = allDataListItems3;
        
            var allDataListItems4 = dbcont.Tbl_InstitutionAppointmentDetails.ToList();
            ViewBag.allDataListItems4 = allDataListItems4;

            var allDataListItems5 = dbcont.Tbl_DesignationDetails.ToList();
            ViewBag.allDataListItems5 = allDataListItems5;

            var allDataList = dbcont.DataListItems.ToList();
            ViewBag.allDataList = allDataList;


            var allcommunityData = dbcont.tblAddExtraCommunity.ToList();
            ViewBag.allcommunityData = allcommunityData;

            var allDocumentData = dbcont.tbl_DocumentType.ToList();
            ViewBag.allDocumentData = allDocumentData;

            var professionPlace = dbcont.Tbl_ProfessionPlace.ToList();
            ViewBag.professionPlace = professionPlace;

            var AgeList = dbcont.Tbl_AverageAge.ToList();
            ViewBag.AgeList = AgeList;

            ViewBag.formationid = dbcont.DataListItems.Where(x => x.DataListName == "StageOfFormation").Count() + 1;

            return View();
        }

        public JsonResult GetLanguageTable(JqueryDatatableParam param)
        {
            var data = dbcont.DataListItems.ToList();

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                data = data.Where(x => !string.IsNullOrEmpty(x.DataListName) && x.DataListName.ToLower().Contains(param.sSearch.ToLower())
                || !string.IsNullOrEmpty(x.Name) && x.Name.ToLower().Contains(param.sSearch.ToLower())
                || !string.IsNullOrEmpty(x.Name_French) && x.Name_French.ToLower().Contains(param.sSearch.ToLower())
                ).ToList();
            }
            var responsedata = data.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
            var totalrecords = data.Count();
            return Json(new {
                param.sEcho,
                iTotalRecords = totalrecords,
                iTotalDisplayRecords = totalrecords,
                aaData = responsedata
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DataItemSave(string name,string name_French)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            try
            {
                DataLists dataList = new DataLists()
                {
                    Name = name,
                    Name_French = name_French
                };
                dbcont.DataLists.Add(dataList);
                dbcont.SaveChanges();
                dataList.CreatedBy = Convert.ToString(Session["loginuserid"]);
                // return Content("<script language='javascript' type='text/javascript'>document.getElementById('mybuttonclick').click();location.replace('" + url + "')</script>");
                //return Content("<script language='javascript' type='text/javascript'>alert('Data Saved Successfully!');location.replace('" + url + "')</script>");
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        [HttpPost]
        public ActionResult DataItemUpdate(string name,string name_French, string Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var id = Convert.ToInt32(Id);
                var existingobj = dbcont.DataLists.FirstOrDefault(e => e.Id == id);
                var changeObj = dbcont.DataLists.FirstOrDefault(e => e.Id == id);
                changeObj.Name = name;
                changeObj.Name_French = name_French;
                changeObj.UpdateBy = Convert.ToString(Session["loginuserid"]); ;
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(changeObj);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        [HttpPost]
        public ActionResult DataItemDetailSave(DataListItems dataListItems)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                DataListItems data = new DataListItems()
                {
                    DataListName = dataListItems.DataListName,
                    Name = dataListItems.Name,
                    Name_French = dataListItems.Name_French,
                    Continent = dataListItems.Continent,
                    FormationId = dataListItems.FormationId
                };
                dataListItems.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.DataListItems.Add(data);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        [HttpPost]
        public ActionResult ProfessionDetailSave(Tbl_ProfessionDetails Tbl_ProfessionDetails)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                Tbl_ProfessionDetails data = new Tbl_ProfessionDetails()
                {
                    DataListName = Tbl_ProfessionDetails.DataListName,
                    Name = Tbl_ProfessionDetails.Name,
                    Name_French = Tbl_ProfessionDetails.Name_French,
                    Continent = Tbl_ProfessionDetails.Continent,
                    FormationId = Tbl_ProfessionDetails.FormationId,
                    CreatedBy = Convert.ToString(Session["loginuserid"])
            };
                Tbl_ProfessionDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Tbl_ProfessionDetails.Add(data);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        [HttpPost]
        public ActionResult CommunityAppointmentDetailSave(Tbl_CommunityAppointmentDetails Tbl_CommunityAppointmentDetails)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                Tbl_CommunityAppointmentDetails data = new Tbl_CommunityAppointmentDetails()
                {
                    DataListName = Tbl_CommunityAppointmentDetails.DataListName,
                    Name = Tbl_CommunityAppointmentDetails.Name,
                    Name_French = Tbl_CommunityAppointmentDetails.Name_French,
                    Continent = Tbl_CommunityAppointmentDetails.Continent,
                    FormationId = Tbl_CommunityAppointmentDetails.FormationId,
                    CreatedBy = Convert.ToString(Session["loginuserid"])
                };
                Tbl_CommunityAppointmentDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Tbl_CommunityAppointmentDetails.Add(data);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        [HttpPost]
        public ActionResult InstitutionAppointmentDetailSave(Tbl_InstitutionAppointmentDetails Tbl_InstitutionAppointmentDetails)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                Tbl_InstitutionAppointmentDetails data = new Tbl_InstitutionAppointmentDetails()
                {
                    DataListName = Tbl_InstitutionAppointmentDetails.DataListName,
                    Name = Tbl_InstitutionAppointmentDetails.Name,
                    Name_French = Tbl_InstitutionAppointmentDetails.Name_French,
                    Continent = Tbl_InstitutionAppointmentDetails.Continent,
                    FormationId = Tbl_InstitutionAppointmentDetails.FormationId,
                    CreatedBy = Convert.ToString(Session["loginuserid"])
                };
                Tbl_InstitutionAppointmentDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Tbl_InstitutionAppointmentDetails.Add(data);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        [HttpPost]
        public ActionResult DesignationDetailSave(Tbl_DesignationDetails Tbl_DesignationDetails)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                Tbl_DesignationDetails data = new Tbl_DesignationDetails()
                {
                    DataListName = Tbl_DesignationDetails.DataListName,
                    Name = Tbl_DesignationDetails.Name,
                    Name_French = Tbl_DesignationDetails.Name_French,
                    DesignationType = Tbl_DesignationDetails.DesignationType,
                    Continent = Tbl_DesignationDetails.Continent,
                    FormationId = Tbl_DesignationDetails.FormationId,
                    CreatedBy = Convert.ToString(Session["loginuserid"])
                };
                Tbl_DesignationDetails.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Tbl_DesignationDetails.Add(data);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        [HttpPost]
        public JsonResult DataItemCountryDetailSave(string DataListName, string Name, string Continent, string Name_French)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                DataListItems data = new DataListItems()
                {
                    DataListName = DataListName,
                    Name = Name,
                    Name_French = Name_French,
                    Continent = Continent,
                };
                data.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.DataListItems.Add(data);
                dbcont.SaveChanges();
                //setcookies("200");
                return Json("Data added successfully!");
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("Country created error!");
                throw;
            }
        }

        [HttpPost]
        public ActionResult CommunityDetailUpdate(string name, string Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var comm = dbcont.tblAddExtraCommunity.Where(i => i.EntryId.ToString() == Id).FirstOrDefault();
                if (comm != null) { 
                comm.Name = name;
                dbcont.SaveChanges();
                }
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        [HttpPost]
        public ActionResult DocumentTypeSave( string Name, string Continent, string Name_French)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                tbl_DocumentType data = new tbl_DocumentType()
                {
                    Name = Name,
                    Name_French = Name_French,
                };
                data.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.tbl_DocumentType.Add(data);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Json("Country created error!");
                throw;
            }
        }
        [HttpPost]
        public ActionResult DocumentTypeUpdate(string Name, string Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var comm = dbcont.tbl_DocumentType.Where(i => i.Id.ToString() == Id).FirstOrDefault();
                if (comm != null)
                {
                    comm.Name = Name;
                    dbcont.SaveChanges();
                }
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public JsonResult GetDocumentTypById(string id)
        {
            try
            {
                var data = dbcont.tbl_DocumentType.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DocumentTypeDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tbl_DocumentType.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.tbl_DocumentType.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        [HttpPost]
        public ActionResult ProfessionPlaceUpdate(string name, string frenchName, string Id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var comm = dbcont.Tbl_ProfessionPlace.Where(i => i.Id.ToString() == Id).FirstOrDefault();
                if (comm != null)
                {
                    comm.Name = name;
                    comm.Name_French = frenchName;
                    dbcont.SaveChanges();
                }
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        public JsonResult GetDataitemById(string id)
        {
            try
            {
                var data = dbcont.DataListItems.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetDataitemByIdProfession(string id)
        {
            try
            {
                var data = dbcont.Tbl_ProfessionDetails.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetDataitemByIdCommunityAppointment(string id)
        {
            try
            {
                var data = dbcont.Tbl_CommunityAppointmentDetails.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetDataitemByIdDesignation(string id)
        {
            try
            {
                var data = dbcont.Tbl_DesignationDetails.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDataitemByIdCommunity(string id)
        {
            try
            {
                var data = dbcont.tblAddExtraCommunity.FirstOrDefault(e => e.EntryId.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDataitemByIdProfPlace(string id)
        {
            try
            {
                var data = dbcont.Tbl_ProfessionPlace.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetDataitemByIdInstitutionAppointment(string id)
        {
            try
            {
                var data = dbcont.Tbl_InstitutionAppointmentDetails.FirstOrDefault(e => e.Id.ToString() == id);
                if (data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("NoRecord", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult DataListItemUpdate(DataListItems dataListItems)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.DataListItems.FirstOrDefault(e => e.Id == dataListItems.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(dataListItems);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }

        public JsonResult GetAllDocumentType()
        {
            try
            {
                var allDocumentData = dbcont.tbl_DocumentType.ToList();
                return Json(allDocumentData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetDocumentByIdName(string id)
        {
            try
            {
                var data = dbcont.Tbl_provinceDatas.Where(e => e.id.ToString() == id).Select(x => new
                {
                    x.id,
                    x.Name,
                    x.Title,
                    x.Description,
                    x.ProvinceName,
                    x.ProvinceId,
                    x.File,
                    DocNamme = dbcont.tbl_DocumentType.Where(c => c.Id.ToString() == x.Name).Select(c => c.Name).FirstOrDefault(),
                    x.Date,
                    x.Mandate
                })
                .FirstOrDefault();
                return Json(data, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult ProfessionUpdate(Tbl_ProfessionDetails Tbl_ProfessionDetails)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_ProfessionDetails.FirstOrDefault(e => e.Id == Tbl_ProfessionDetails.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_ProfessionDetails);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult CommunityAppointmentUpdate(Tbl_CommunityAppointmentDetails Tbl_CommunityAppointmentDetails)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_CommunityAppointmentDetails.FirstOrDefault(e => e.Id == Tbl_CommunityAppointmentDetails.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_CommunityAppointmentDetails);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult InstitutionAppointmentUpdate(Tbl_InstitutionAppointmentDetails Tbl_InstitutionAppointmentDetails)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_InstitutionAppointmentDetails.FirstOrDefault(e => e.Id == Tbl_InstitutionAppointmentDetails.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_InstitutionAppointmentDetails);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult DesignationDetailUpdate(Tbl_DesignationDetails Tbl_DesignationDetails)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var existingobj = dbcont.Tbl_DesignationDetails.FirstOrDefault(e => e.Id == Tbl_DesignationDetails.Id);
                if (existingobj != null)
                {
                    dbcont.Entry(existingobj).CurrentValues.SetValues(Tbl_DesignationDetails);
                    dbcont.SaveChanges();
                }
                setcookies("201");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult DatalistDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.DataListItems.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.DataListItems.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult DatalistDeleteProfession(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_ProfessionDetails.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Tbl_ProfessionDetails.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult DatalistDeleteDesignation(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_DesignationDetails.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Tbl_DesignationDetails.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult CommunityDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.tblAddExtraCommunity.FirstOrDefault(e => e.EntryId == id);
                if (data != null)
                {
                    dbcont.tblAddExtraCommunity.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult ProfessionPlaceDelete(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_ProfessionPlace.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Tbl_ProfessionPlace.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult DatalistDeleteCommunityAppointment(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_CommunityAppointmentDetails.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Tbl_CommunityAppointmentDetails.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }
        public ActionResult DatalistDeleteInstitutionAppointment(int id)
        {
            string url = this.Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_InstitutionAppointmentDetails.FirstOrDefault(e => e.Id == id);
                if (data != null)
                {
                    dbcont.Tbl_InstitutionAppointmentDetails.Remove(data);
                    dbcont.SaveChanges();
                    setcookies("202");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
            }
            catch (Exception)
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }


            

        }

        [HttpPost]
        public ActionResult AgeSave(Tbl_AverageAge tbl_AverageAge)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                dbcont.Tbl_AverageAge.Add(tbl_AverageAge);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
        }

        //[HttpPost]
        //public ActionResult AgeUpdate(int id)
        //{
        //    var url = Request.UrlReferrer.AbsoluteUri;
        //    var data = dbcont.Tbl_AverageAge.
        //}

        #region Language Settings

        public ActionResult LanguageSetting()
        {

            //var Languages = dbcont.DataListItems.Where(x => x.DataListName == "Languages").ToList();
            var AllLanguages = dbcont.Tbl_Languages.ToList();
            ViewBag.AllLanguages = AllLanguages;

            var languagesettings = dbcont.Tbl_Languagesetting.ToList();
            ViewBag.languagesettings = languagesettings;
            var status = "";
            List<Tbl_Languagesetting> Tbl_Languagesetting = new List<Tbl_Languagesetting>();
            foreach(var item in languagesettings)
            {
                if(item.Active == "1")
                {
                    status = "Active";
                }
                else
                {
                    status = "InActive";
                }
                Tbl_Languagesetting.Add(new Tbl_Languagesetting
                {
                    Language_Name = item.Language_Name,
                    Language_Id = item.Language_Id,
                    Setting_Id = item.Setting_Id,
                    Active = status

                });

            }
            var userRoleName = Session["UserRole"] as string;
            if (!string.IsNullOrEmpty(userRoleName))
            {
                var userRoleId = dbcont.Tbl_UserRole.Where(x => x.Role_Name == userRoleName).Select(x => x.Userrole_Id).FirstOrDefault();

                string CurrentPageName = "Settings";
                int Submenu_Id = dbcont.Tbl_Submenuhead.Where(x => x.Submenu_Name.ToUpper() == CurrentPageName.ToUpper()).Select(x => x.Submenu_Id).FirstOrDefault();
                var RolePermissionTage = (from m in dbcont.Tbl_TopMenuPermission.ToList()
                                          from n in dbcont.Tbl_Submenuhead.ToList()
                                          where m.ParentId == n.Submenu_Id && Convert.ToInt32(m.RoleId) == userRoleId && m.ParentId == Submenu_Id
                                          && Convert.ToUInt32(m.HasPermission) == 1
                                          select new Tbl_RolePermission
                                          {
                                              TagName = m.PageName,
                                              Url = m.PageViewName
                                          }).ToList();
                Session["RolePermissionTage"] = RolePermissionTage.ToList();
                ViewBag.CurrentPageName = "Settings";

                var topmenulist = dbcont.Tbl_TopMenuPermission.Where(x => x.RoleId == userRoleId.ToString()).ToList();
                Session["TopmenuPermission"] = topmenulist;
            }
            ViewBag.AllLangSettings = Tbl_Languagesetting;
            return View();
        }

        public ActionResult AddLanguageSetting(Tbl_Languagesetting tbl_Languagesetting)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_Languagesetting.FirstOrDefault(x => x.Language_Name == tbl_Languagesetting.Language_Name);
                if (data != null)
                {
                    dbcont.Entry(data).CurrentValues.SetValues(tbl_Languagesetting);
                    dbcont.SaveChanges();
                    setcookies("200");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");

                    //return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var languagename = dbcont.Tbl_Languages.FirstOrDefault(x => x.Lnaguage_Id == tbl_Languagesetting.Language_Id)?.Language_Name;
                    tbl_Languagesetting.Language_Name = languagename;

                    var newlanguage = languagename.Substring(0, 2);
                    tbl_Languagesetting.LanguageCode = newlanguage;

                    dbcont.Tbl_Languagesetting.Add(tbl_Languagesetting);
                    dbcont.SaveChanges();
                    setcookies("200");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");

                    //return Json("Success", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");

                //return Json("Fail", JsonRequestBehavior.AllowGet);
            }



        }

        public JsonResult GetLanguageSettingByIdI(int id)
        {
            try
            {
                var data = dbcont.Tbl_Languagesetting.FirstOrDefault(x => x.Setting_Id == id);
                if(data != null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Fail", JsonRequestBehavior.AllowGet);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                throw;
            }
        }

        public ActionResult UpdateLanguageSetting(Tbl_Languagesetting tbl_Languagesetting )
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                var data = dbcont.Tbl_Languagesetting.FirstOrDefault(x => x.Setting_Id == tbl_Languagesetting.Setting_Id);
                if(data != null)
                {
                    var activelist = dbcont.Tbl_Languagesetting.Where(x => x.Active == "1").ToList();
                    foreach(var item in activelist)
                    {
                        var existingdata = dbcont.Tbl_Languagesetting.FirstOrDefault(x => x.Setting_Id == item.Setting_Id);
                        var activedata = dbcont.Tbl_Languagesetting.FirstOrDefault(x => x.Setting_Id == item.Setting_Id);
                        activedata.Active = "0";

                        var languagename = dbcont.Tbl_Languages.FirstOrDefault(x => x.Lnaguage_Id == tbl_Languagesetting.Language_Id)?.Language_Name;
                        tbl_Languagesetting.Language_Name = languagename;
                        dbcont.Entry(existingdata).CurrentValues.SetValues(activedata);
                        dbcont.SaveChanges();
                    }

                    tbl_Languagesetting.LanguageCode = data.LanguageCode;
                    Session["CurrentLang"] = tbl_Languagesetting.LanguageCode;

                    dbcont.Entry(data).CurrentValues.SetValues(tbl_Languagesetting);
                    dbcont.SaveChanges();
                    setcookies("201");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                }
                else
                {
                    setcookies("204");
                    return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                    
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
                throw;
            }
        }


        public JsonResult GetAllLanguages()
        {
            var data = dbcont.DataListItems.Where(x => x.DataListName == "Languages").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddLanguages(Tbl_Languages tbl_Languages)
        {
            var url = Request.UrlReferrer.AbsoluteUri;
            try
            {
                tbl_Languages.CreatedBy = Convert.ToString(Session["loginuserid"]);
                dbcont.Tbl_Languages.Add(tbl_Languages);
                dbcont.SaveChanges();
                setcookies("200");
                return Content("<script language='javascript' type='text/javascript'>location.replace('" + url + "')</script>");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
           catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                setcookies("204");
                throw;
            }

        }


        #endregion

        public void setcookies(string code)
        {
            //200 success
            //201 update
            //202 delete
            //203 error
            HttpCookie cookie = new HttpCookie("iscode", code);
            //cookie.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Add(cookie);
        }
    }
}