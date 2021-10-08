using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Harmony.Util;
using Harmony.ViewModels;
using Microsoft.AspNetCore.Identity;
using Harmony.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Harmony.Controllers
{

    public class CircleOfFifths : Controller
    {

        public class AccountController : Controller
        {

            private readonly UserManager<User> _userManager;

            public AccountController(UserManager<User> userManager)
            {
                _userManager = userManager;
            }

            [HttpGet]
            public async Task<string> GetCurrentUserId()
            {
                User usr = await GetCurrentUserAsync();
                return usr?.Id;
            }

            private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        }

        [Authorize]
        //GET/?
        public IActionResult Index(int numberOfChords = 4, string scale = "C", bool isMagic = true)
        {

            var x = User;

            List<Util.Harmony> initialHarmonies;

            if (isMagic)
            {
                initialHarmonies = HarmonyGenerator.GenerateMagicHarmonies(numberOfChords, scale);
            }
            else {
                initialHarmonies = HarmonyGenerator.GenerateHarmonies(numberOfChords, scale);
            }
            
            var harmonyViewModels = new List<HarmonyViewModel>();

            foreach (Util.Harmony h in initialHarmonies) {
                
                if(h.NumberOfChords == numberOfChords) {

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

            ViewData.Model = harmonyViewModels;
            return View();
        }







    }
}
