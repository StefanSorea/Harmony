using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harmony.Util

{
    public class CircleOfFifthsHarmony
    {
        // Transition to List

        private List<string> chords;
        
        // Transition to Properties
        public int Measures { get; set; }
        public string Key { get; set; }
        public int NumberOfChords { get { return chords.Count();} }
        public string PreviousChord { get { return chords[chords.Count() - 1]; } }


        public CircleOfFifthsHarmony(int measures, string key)
        {
            chords = new List<string>();
            Measures = measures;
            Key = key;
        }

        public List<string> getChords()
        {
            return chords;
        }

        public void AddChord(string chord)
        {
            chords.Add(chord);
        }

        public CircleOfFifthsHarmony cloneHarmony()
        {

            CircleOfFifthsHarmony clonedHarmony = new CircleOfFifthsHarmony(this.Measures, this.Key);

            foreach (string harmonyChord in this.chords) {
                clonedHarmony.AddChord(harmonyChord);
            }

            return clonedHarmony;

        }

    }

}
