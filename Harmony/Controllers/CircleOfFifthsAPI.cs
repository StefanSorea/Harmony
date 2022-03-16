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
    public class CircleOfFifthsAPI : Controller
    {

        public JsonResult GetHarmonies(int numberOfChords = 4, string scale = "C", bool isMagic = false)
        {

            List<CircleOfFifthsHarmony> initialHarmonies;

            if (isMagic)
            {
                initialHarmonies = HarmonyFactory.GenerateMagicHarmonies(numberOfChords, scale);
            }
            else
            {
                initialHarmonies = HarmonyFactory.GenerateHarmonies(numberOfChords, scale);
            }

            var harmonyViewModels = new List<HarmonyViewModel>();

            foreach (CircleOfFifthsHarmony h in initialHarmonies)
            {

                if (h.NumberOfChords == numberOfChords)
                {

                    HarmonyViewModel harmonyViewModel = new HarmonyViewModel();

                    for (int i = 0; i < h.Measures; i++)
                    {
                        harmonyViewModel.Chords.Add(h.getChords()[i]);
                    }

                    harmonyViewModel.Key = scale;
                    harmonyViewModel.IsMagic = isMagic;
                    harmonyViewModel.NumberOfChords = h.Measures;
                    harmonyViewModels.Add(harmonyViewModel);

                }

            }

            return Json(harmonyViewModels);
        }



    }
}
