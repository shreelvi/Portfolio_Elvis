﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_Elvis.Controllers
{
    /// <summary>
    /// Created by: shreelvi
    /// Date created: 05/10/2019
    /// Controls the System and Database Design menu in home page
    /// </summary>
    public class SystemDesignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SysProject1()
        {
            return View();
        }

        //To display executive summary of project1
        public IActionResult SysProject1_Summary()
        {
            return View();
        }

        //To display introduction of project1 in seperate page
        public IActionResult SysProject1_Intro()
        {
            return View();
        }
    }
}