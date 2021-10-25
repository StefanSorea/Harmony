using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Harmony.Util;

namespace Harmony.ViewModels
{
    public class HarmonyViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<string> Chords { get; set; }

        public int NumberOfChords { get; set; }

        public string Key{ get; set; }

        public bool IsMagic { get; set; }

        public HarmonyViewModel() {
            Chords = new List<string>();
        }
        
    }
}
