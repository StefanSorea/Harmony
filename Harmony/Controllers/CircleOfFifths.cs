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
using Harmony.Data;
using System.Text.Json;

namespace Harmony.Controllers
{

    public class CircleOfFifths : Controller
    {

        private readonly ApplicationDbContext _context;

        public CircleOfFifths(ApplicationDbContext context)
        {
            _context = context;
        }

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
        public IActionResult Index(int numberOfChords = 4, string scale = "C", bool isMagic = false)
        {

            var x = User;

            List<CircleOfFifthsHarmony> initialHarmonies;

            if (isMagic)
            {
                initialHarmonies = HarmonyFactory.GenerateMagicHarmonies(numberOfChords, scale); 
            }
            else {
                initialHarmonies = HarmonyFactory.GenerateHarmonies(numberOfChords, scale);
            }
            
            var harmonyViewModels = new List<HarmonyViewModel>();

            foreach (CircleOfFifthsHarmony h in initialHarmonies) {
                
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

            return View(harmonyViewModels);
        }

        [HttpPost]
        public async Task<NoContentResult> AddToFavourites([FromBody] string jsonHarmony) {

            HarmonyModel harmonyToBeAdded = JsonSerializer.Deserialize<HarmonyModel>(jsonHarmony);

            harmonyToBeAdded.UserId = "2af8cf83-c6e2-4b26-8421-7ef43a90a62b";
            
            _context.Add(harmonyToBeAdded);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        //public async Task<NoContentResult> AddToFavourites(int numberOfChords = 0, string scale = null, bool isMagic = false, string firstChord = null, string secondChord = null, string thirdChord = null, string fourthChord = null, string fifthChord = null, string sixthChord = null, string seventhChord = null, string eigthChord = null)
        //{

        //    HarmonyModel harmonyToBeAdded = new HarmonyModel();

        //    harmonyToBeAdded.UserId = "2af8cf83-c6e2-4b26-8421-7ef43a90a62b";
        //    harmonyToBeAdded.NumberOfChords = numberOfChords;
        //    harmonyToBeAdded.Key = scale;
        //    harmonyToBeAdded.IsMagic = isMagic;
        //    harmonyToBeAdded.FirstChord = firstChord;
        //    harmonyToBeAdded.SecondChord = secondChord;
        //    harmonyToBeAdded.ThirdChord = thirdChord;
        //    harmonyToBeAdded.FourthChord = fourthChord;
        //    harmonyToBeAdded.FifthChord = fifthChord;
        //    harmonyToBeAdded.SixthChord = sixthChord;
        //    harmonyToBeAdded.SeventhChord = seventhChord;
        //    harmonyToBeAdded.EigthChord = eigthChord;

        //    _context.Add(harmonyToBeAdded);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}








    }
}
