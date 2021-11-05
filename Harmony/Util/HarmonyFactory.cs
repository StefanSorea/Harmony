using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony.Util;

namespace Harmony.Util

{
    public class HarmonyFactory
    {      
        private static readonly Dictionary<int, string> MajorKeys = new Dictionary<int, string>();
        private static readonly Dictionary<int, string> MinorKeys = new Dictionary<int, string>();
        private static readonly List<int[]> MagicChords = new List<int[]>();
        static HarmonyFactory()
        {

            MajorKeys.Add(0, "C");
            MajorKeys.Add(1, "C#");
            MajorKeys.Add(2, "D");
            MajorKeys.Add(3, "D#");
            MajorKeys.Add(4, "E");
            MajorKeys.Add(5, "F");
            MajorKeys.Add(6, "F#");
            MajorKeys.Add(7, "G");
            MajorKeys.Add(8, "G#");
            MajorKeys.Add(9, "A");
            MajorKeys.Add(10, "A#");
            MajorKeys.Add(11, "B");

            MinorKeys.Add(0, "Cm");
            MinorKeys.Add(1, "C#m");
            MinorKeys.Add(2, "Dm");
            MinorKeys.Add(3, "D#m");
            MinorKeys.Add(4, "Em");
            MinorKeys.Add(5, "Fm");
            MinorKeys.Add(6, "F#m");
            MinorKeys.Add(7, "Gm");
            MinorKeys.Add(8, "G#m");
            MinorKeys.Add(9, "Am");
            MinorKeys.Add(10, "A#m");
            MinorKeys.Add(11, "Bm");

            MagicChords.Add(new int[] { 0, 4, 5, 3 });
            MagicChords.Add(new int[] { 0, 3, 4 });
            MagicChords.Add(new int[] { 0, 5, 4, 5 });
            MagicChords.Add(new int[] { 0, 3, 5, 4 });
            MagicChords.Add(new int[] { 1, 4, 0 });
            MagicChords.Add(new int[] { 0, 5, 3, 4 });
            MagicChords.Add(new int[] { 0, 4, 5, 2 });
            MagicChords.Add(new int[] { 3, 0, 3, 4 });

        }

        private static string[] generateCircleOfFifthChords(string specifiedScale) {

            string[] chordsOfSpecifiedScale; ;

            bool isMajor = true;

            if (specifiedScale.Contains("m"))
            {
                isMajor = false;
                chordsOfSpecifiedScale = new string[7];
            }
            else
            {
                chordsOfSpecifiedScale = new string[6];
            }

            if (isMajor)
            {
                int scaleKey = MajorKeys.FirstOrDefault(x => x.Value == specifiedScale).Key;
                chordsOfSpecifiedScale[0] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsOfSpecifiedScale[1] = MinorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsOfSpecifiedScale[2] = MinorKeys[scaleKey];

                goUpHalfStep(ref scaleKey);
                chordsOfSpecifiedScale[3] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsOfSpecifiedScale[4] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsOfSpecifiedScale[5] = MinorKeys[scaleKey];

            }
            else
            {
                int scaleKey = MinorKeys.FirstOrDefault(x => x.Value == specifiedScale).Key;
                chordsOfSpecifiedScale[0] = MinorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsOfSpecifiedScale[1] = MajorKeys[scaleKey];

                goUpHalfStep(ref scaleKey);
                chordsOfSpecifiedScale[2] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsOfSpecifiedScale[3] = MinorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsOfSpecifiedScale[4] = MinorKeys[scaleKey];

                goUpHalfStep(ref scaleKey);
                chordsOfSpecifiedScale[5] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsOfSpecifiedScale[6] = MajorKeys[scaleKey];


            }

            return chordsOfSpecifiedScale;

            // Helper methods

            void goUpHalfStep(ref int someKey)
            {
                someKey++;
                if (someKey == 12)
                {
                    someKey = 0;
                }
            }

            void goUpOneStep(ref int someKey)
            {
                someKey = someKey + 2;
                if (someKey >= 12)
                {
                    someKey = someKey - 12;
                }
            }
        }

        // DEPRECATED - Will be useful in the future DO NOT DELETE

        //public static List<CircleOfFifthsHarmony> GenerateHarmonies(int measures, string scale)
        //{

        //    List<CircleOfFifthsHarmony> generatedHarmonies = new List<CircleOfFifthsHarmony>();

        //    string[] chordsInMyScale = generateCircleOfFifthChords(scale);

        //    CircleOfFifthsHarmony initialHarmony = new CircleOfFifthsHarmony(measures, scale);
        //    initialHarmony.AddChord(chordsInMyScale[0]);
        //    generatedHarmonies.Add(initialHarmony);


        //    for (int x = 0; x < measures - 1; x++)
        //    {
        //        AddToHarmony();
        //    }

        //    return generatedHarmonies;

        //    // Local functions

        //    void AddToHarmony()
        //    {
        //        List<CircleOfFifthsHarmony> newListOfHarmonies = new List<CircleOfFifthsHarmony>();

        //        foreach (CircleOfFifthsHarmony currentHarmony in generatedHarmonies)
        //        {
        //            foreach (string currentChord in chordsInMyScale)
        //            {
        //                if (currentHarmony.PreviousChord != currentChord)
        //                {
        //                    CircleOfFifthsHarmony newHarmony = currentHarmony.cloneHarmony();
        //                    newHarmony.AddChord(currentChord);
        //                    newListOfHarmonies.Add(newHarmony);
        //                }
        //            }
        //        }

        //        generatedHarmonies = newListOfHarmonies;
        //    }

        //}

        public static List<CircleOfFifthsHarmony> GenerateHarmonies(int measures, string scale)
        {

            List<CircleOfFifthsHarmony> generatedHarmonies = new List<CircleOfFifthsHarmony>();

            string[] chordsInMyScale = generateCircleOfFifthChords(scale);


            foreach (string chord in chordsInMyScale)
            {
                CircleOfFifthsHarmony firstChordHarmony = new CircleOfFifthsHarmony(measures, scale);
                firstChordHarmony.AddChord(chord);
                generatedHarmonies.Add(firstChordHarmony);
            }

            for (int x = 0; x < measures - 1; x++)
            {
                AddToHarmony();
            }


            return generatedHarmonies;

            // Local functions

            void AddToHarmony()
            {
                List<CircleOfFifthsHarmony> tempList = new List<CircleOfFifthsHarmony>();

                foreach (CircleOfFifthsHarmony currentHarmony in generatedHarmonies)
                {
                    if (currentHarmony.PreviousChord == chordsInMyScale[0])
                    {
                        for (int a = 1; a < chordsInMyScale.Length; a++)
                        {
                            CircleOfFifthsHarmony newHarmony = currentHarmony.cloneHarmony();
                            newHarmony.AddChord(chordsInMyScale[a]);
                            tempList.Add(newHarmony);
                        }
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[1])
                    {
                        CircleOfFifthsHarmony newHarmony = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[4]);
                        tempList.Add(newHarmony);
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[2])
                    {
                        CircleOfFifthsHarmony newHarmony = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[5]);
                        tempList.Add(newHarmony);
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[3])
                    {
                        CircleOfFifthsHarmony newHarmony = currentHarmony.cloneHarmony();
                        CircleOfFifthsHarmony newHarmony2 = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[0]);
                        newHarmony2.AddChord(chordsInMyScale[4]);
                        tempList.Add(newHarmony);
                        tempList.Add(newHarmony2);
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[4])
                    {
                        CircleOfFifthsHarmony newHarmony = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[0]);
                        tempList.Add(newHarmony);
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[5])
                    {
                        CircleOfFifthsHarmony newHarmony = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[1]);
                        tempList.Add(newHarmony);
                    }
                }

                generatedHarmonies = tempList;

            }
        }


        public static List<CircleOfFifthsHarmony> GenerateMagicHarmonies(int measures, string scale)
        {
          
            List<CircleOfFifthsHarmony> generatedHarmonies = new List<CircleOfFifthsHarmony>();

            string[] chordsInMyScale = generateCircleOfFifthChords(scale);       
            
            foreach (var chordProgression in MagicChords) {
                CircleOfFifthsHarmony newCircleOfFifthsHarmony = new CircleOfFifthsHarmony(measures, scale);

                int chordProgressionCounter = 0;
                for (int i = 0; i < measures; i++) {
                    newCircleOfFifthsHarmony.AddChord(chordsInMyScale[chordProgression[chordProgressionCounter]]);
                    chordProgressionCounter++;
                    if (chordProgressionCounter == chordProgression.Length) {
                        chordProgressionCounter = 0;
                    }
                }

                generatedHarmonies.Add(newCircleOfFifthsHarmony);
            }
            
            return generatedHarmonies;
        
        }



    }

}
