using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP_Management_System.DTOs;
using TRP_Management_System.EF;

namespace TRP_Management_System.Controllers
{
    public class LoginController : Controller
    {
        TRPEntities db = new TRPEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO log)
        {
            //
            var user = (from u in db.Users
                        where u.Uname.Equals(log.Uname)
                        && u.Password.Equals(log.Password)
                        select u).SingleOrDefault();
            if (user != null)
            {
                Session["user"] = user; //boxing
                return RedirectToAction("List", "Channel");
            }
            TempData["Msg"] = "User not found";
            return View();
        }
    }
}