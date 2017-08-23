using pnVerification.Models;
using pnVerify.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
namespace pnVerify.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Login Page";
            return View();
            
        }

        public ActionResult Verify(string username, string password)
        {
            VerifyUser v = new VerifyUser();
            if (v.ValidateUser(username, password) == 1)
            {
                ViewBag.Title = "Verification Page";
                return View("Verify");
            }
            else
                return View("Index");
        }

    }
}

*/