using Harmony.Util;
using Harmony.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harmony.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFavoritesAPI : Controller
    {

        public JsonResult GetHarmonies(int numberOfChords = 4, string scale = "C", bool isMagic = false)
        {

            return null;
        }

    }
}
