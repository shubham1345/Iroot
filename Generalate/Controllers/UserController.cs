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
    public class UserController : Controller
    {
        GeneralDBContext db = new GeneralDBContext();

        // GET: User
       
      
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(tbl_UserModuleLogin userlogin)
        {


            if (ModelState.IsValid)
            {
                var user = (from userlist in db.tbl_UserModuleLogin
                            where userlist.Username == userlogin.Username && userlist.UserPassword == userlogin.UserPassword
                            select new
                            {
                                userlist.Username,
                                userlist.UserPassword
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().Username;
                    Session["UserID"] = user.FirstOrDefault().UserPassword;
                    return Redirect("~/User_EmergencyContact/Homeuser");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }

            return View(userlogin);
        }


    }
}