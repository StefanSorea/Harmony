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
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Harmony.Controllers
{

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }

    public class CircleOfFifths : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CircleOfFifths(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //GET USER ID
       
        [Authorize]
        //GET/?
        public IActionResult Index(int numberOfChords = 4, string scale = "C", bool isMagic = false)
        {


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

        //[HttpPost]
        //public async Task<NoContentResult> AddToFavourites([FromBody] string jsonHarmony) {

        //    HarmonyModel harmonyToBeAdded = JsonSerializer.Deserialize<HarmonyModel>(jsonHarmony);

        //    harmonyToBeAdded.UserId = "2af8cf83-c6e2-4b26-8421-7ef43a90a62b";

        //    _context.Add(harmonyToBeAdded);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}


        public async Task<NoContentResult> AddToFavourites(int numberOfChords = 0, string scale = null, bool isMagic = false, string firstChord = null, string secondChord = null, string thirdChord = null, string fourthChord = null, string fifthChord = null, string sixthChord = null, string seventhChord = null, string eigthChord = null)
        {
            // 2af8cf83-c6e2-4b26-8421-7ef43a90a62b
            HarmonyModel harmonyToBeAdded = new HarmonyModel();

            harmonyToBeAdded.UserId = _userManager.GetUserId(HttpContext.User);
            harmonyToBeAdded.NumberOfChords = numberOfChords;
            harmonyToBeAdded.Key = scale;
            harmonyToBeAdded.IsMagic = isMagic;
            harmonyToBeAdded.FirstChord = firstChord;
            harmonyToBeAdded.SecondChord = secondChord;
            harmonyToBeAdded.ThirdChord = thirdChord;
            harmonyToBeAdded.FourthChord = fourthChord;
            harmonyToBeAdded.FifthChord = fifthChord;
            harmonyToBeAdded.SixthChord = sixthChord;
            harmonyToBeAdded.SeventhChord = seventhChord;
            harmonyToBeAdded.EigthChord = eigthChord;

            _context.Add(harmonyToBeAdded);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
