﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_Elvis.Controllers
{
    /// <summary>
    /// Created by: shreelvi
    /// Date created: 05/09/2019
    /// Controls the Content Writing menu in home page
    /// </summary>
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SuperWiFi()
        {
            return View();
        }

        public IActionResult VCS()
        {
            return View();
        }
    }
}