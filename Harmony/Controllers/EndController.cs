using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harmony.Controllers
{
    public class EndController : Controller
    {
        public IActionResult End()
        {
            return View();
        }
    }
}
