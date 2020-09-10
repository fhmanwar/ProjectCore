using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.GetString("lvl") == "Admin")
                {
                    return View();
                }
                return Redirect("/profile");
            }
            return RedirectToAction("Login", "Auth");
        }

        [Route("profile")]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
