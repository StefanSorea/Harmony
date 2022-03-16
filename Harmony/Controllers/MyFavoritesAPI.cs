using Harmony.Data;
using Harmony.Models;
using Harmony.Util;
using Harmony.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private readonly ApplicationDbContext applicationDb;
        private readonly UserManager<User> _userManager;

        public MyFavoritesAPI(ApplicationDbContext applicationDbContext, UserManager<User> userManager) {
            this.applicationDb = applicationDbContext;
            _userManager = userManager;
        }

        [HttpGet]
    
        public async Task<ActionResult<List<HarmonyModel>>> GetHarmonies()
        {
            string myUserId = _userManager.GetUserId(HttpContext.User);
            HttpContext check = HttpContext;
            myUserId = "2af8cf83-c6e2-4b26-8421-7ef43a90a62b";
            return await applicationDb.HarmonyModel.AsQueryable().Where(x => x.UserId == myUserId).ToListAsync();

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int Id) {
            var querriedHarmony = await applicationDb.HarmonyModel.FirstOrDefaultAsync(x => x.Id == Id);

            if (querriedHarmony == null) {
                return NotFound();
            }

            applicationDb.Remove(querriedHarmony);
            await applicationDb.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("filter")]

        public async Task<ActionResult<List<HarmonyModel>>> Filter( [FromQuery] HarmonyModel harmony) {

            //string myUserId = _userManager.GetUserId(HttpContext.User);

            string myUserId = "2af8cf83-c6e2-4b26-8421-7ef43a90a62b";
            var harmoniesQueryable = applicationDb.HarmonyModel.AsQueryable().Where(x => x.UserId == myUserId);

            if (harmony.NumberOfChords != null) {
                harmoniesQueryable = harmoniesQueryable.Where(x => x.NumberOfChords == harmony.NumberOfChords);
            }

            if (harmony.Key != null) {
                harmoniesQueryable = harmoniesQueryable.Where(x => x.Key == harmony.Key);
            }

            if (harmony.IsMagic != null)
            {
                harmoniesQueryable = harmoniesQueryable.Where(x => x.IsMagic == harmony.IsMagic);
            }

            return await harmoniesQueryable.ToListAsync();
        }
         
    }

 }


