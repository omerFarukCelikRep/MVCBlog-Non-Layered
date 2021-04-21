using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("ID"))
            {
                return RedirectToAction("Index", "Member");
            }

            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
