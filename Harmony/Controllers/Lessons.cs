﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harmony.Controllers
{
    public class LessonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
