using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_Elvis.Controllers
{
    // Controls web development section in home page
    // Web development section includes projects web app projects that I have worked in past
    public class WebDevController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}