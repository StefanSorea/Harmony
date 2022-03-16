using Harmony.Data;
using Harmony.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Controllers
{
    [Route("Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ApplicationDbContext applicationDb;
        private readonly UserManager<User> _userManager;

        public AuthController(ApplicationDbContext applicationDbContext, UserManager<User> userManager)
        {
            this.applicationDb = applicationDbContext;
            _userManager = userManager;
        }

        [HttpGet("PostJWT")]
        public async Task<IActionResult> PostJWT()
        {


            var currentUserId = _userManager.GetUserId(HttpContext.User);

            string tokenString = "";

            if (applicationDb.JwtModel.Where(x => x.UserId == currentUserId) == null) {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(currentUserId));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44383",
                    audience: "http://localhost:44384",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                var JwtEntry = new JwtModel();

                JwtEntry.UserId = currentUserId;
                JwtEntry.Jwt = tokenString;

                applicationDb.Add(JwtEntry);
                await applicationDb.SaveChangesAsync();
            }

            
            return Redirect("http://localhost:44384?jwt=" + tokenString);

        }






    }
}
