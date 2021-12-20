using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Harmony.Util;

namespace Harmony.Models
{
    public class HarmonyModel
    {
        public int Id { get; set; }
        public string? UserId { get; set; }

        public string? FirstChord { get; set; }
        public string? SecondChord { get; set; }
        public string? ThirdChord { get; set; }
        public string? FourthChord { get; set; }
        public string? FifthChord { get; set; }
        public string? SixthChord { get; set; }
        public string? SeventhChord { get; set; }

        public string? EigthChord { get; set; }
        public int? NumberOfChords { get; set; }

        public string? Key { get; set; }

        public bool? IsMagic { get; set; }

        
    }
}
