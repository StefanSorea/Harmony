using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harmony.Util
{
    public class Harmony
    {

        private string[] chords;
        string key = "";
        private int measures = 0;


        public int Measures { get { return measures; } set { this.measures = value; } }
        public string Key { get { return key; } set { this.key = value; } }

        private int numberOfChords = 0;
        public int NumberOfChords { get { return numberOfChords; } set { this.numberOfChords = value; } }

        public Harmony(int measures, string key)
        {
            chords = new string[measures];
            Measures = measures;
            Key = key;
        }

        public string[] getChords()
        {
            return chords;
        }

        public string getKey()
        {
            return chords[0];
        }


        private string previousChord = "";

        private int nextSlotToOccupy;

        public string PreviousChord
        {
            get { return previousChord; }
        }
        public void AddChord(string chord)
        {
            chords[nextSlotToOccupy] = chord;
            previousChord = chords[nextSlotToOccupy];
            NumberOfChords++;
            nextSlotToOccupy++;
        }

        public Harmony cloneHarmony()
        {

            Harmony clonedHarmony = new Harmony(this.measures, this.key);

            for (int i = 0; i < measures; i++)
            {
                clonedHarmony.chords[i] = this.chords[i];
            }

            clonedHarmony.nextSlotToOccupy = this.nextSlotToOccupy;
            clonedHarmony.previousChord = this.previousChord;
            clonedHarmony.NumberOfChords = numberOfChords;

            return clonedHarmony;

        }

    }

}
