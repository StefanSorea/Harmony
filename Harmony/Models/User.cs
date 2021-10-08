using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harmony.Models
{
    public class User : IdentityUser
    {
        public string ProfilePictureLocation { get; set; } 
        public string UserDisplayName { get; set; }
        public ICollection<HarmonyModel> MyHarmonies { get; set; }

    }
}
