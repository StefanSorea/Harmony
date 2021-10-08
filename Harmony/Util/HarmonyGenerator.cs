using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Harmony.Util;

namespace Harmony.Util
{
    public class HarmonyGenerator
    {
        static Dictionary<int, string> MajorKeys = new Dictionary<int, string>();
        static Dictionary<int, string> MinorKeys = new Dictionary<int, string>();

        static HarmonyGenerator()
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

        }


        public static List<Harmony> GenerateHarmonies(int measures, string scale)
        {

            List<Harmony> generatedHarmonies = new List<Harmony>();
            string[] chordsInMyScale = new string[6];

            bool isMajor = true;

            if (scale.Contains("m"))
            {
                isMajor = false;
            }

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


            if (isMajor)
            {
                int scaleKey = MajorKeys.FirstOrDefault(x => x.Value == scale).Key;
                chordsInMyScale[0] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[1] = MinorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[2] = MinorKeys[scaleKey];

                goUpHalfStep(ref scaleKey);
                chordsInMyScale[3] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[4] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[5] = MinorKeys[scaleKey];

            }
            else
            {
                int scaleKey = MinorKeys.FirstOrDefault(x => x.Value == scale).Key;
                chordsInMyScale[0] = MinorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[1] = MinorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[2] = MinorKeys[scaleKey];

                goUpHalfStep(ref scaleKey);
                chordsInMyScale[3] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[4] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[5] = MinorKeys[scaleKey];
            }

            void AddAnotherChord()
            {
                List<Harmony> newListOfHarmonies = new List<Harmony>();

                foreach (Harmony currentHarmony in generatedHarmonies)
                {
                    foreach (string currentChord in chordsInMyScale)
                    {
                        if (currentHarmony.PreviousChord != currentChord)
                        {
                            Harmony newHarmony = currentHarmony.cloneHarmony();
                            newHarmony.AddChord(currentChord);
                            newListOfHarmonies.Add(newHarmony);
                        }
                    }
                }

                generatedHarmonies = generatedHarmonies.Concat(newListOfHarmonies).ToList();
            }

            Harmony[] tempHarmonies = new Harmony[6];

            for (int j = 0; j < chordsInMyScale.Length; j++)
            {
                Harmony initialHarmony = new Harmony(measures,scale);
                initialHarmony.AddChord(chordsInMyScale[j]);
                tempHarmonies[j] = initialHarmony;
            }

            foreach (Harmony h in tempHarmonies)
            {
                foreach (string usableChord in chordsInMyScale)
                {
                    if (h.PreviousChord != usableChord)
                    {
                        Harmony newHarmony = h.cloneHarmony();
                        newHarmony.AddChord(usableChord);
                        generatedHarmonies.Add(newHarmony);

                    }
                }
            }


            for (int x = 0; x < measures - 2; x++)
            {
                AddAnotherChord();
            }


            return generatedHarmonies;
        }

        public static List<Harmony> GenerateMagicHarmonies(int measures, string scale)
        {

            List<Harmony> generatedHarmonies = new List<Harmony>();
            string[] chordsInMyScale = new string[6];

            bool isMajor = true;

            if (scale.Contains("m"))
            {
                isMajor = false;
            }

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


            if (isMajor)
            {
                int scaleKey = MajorKeys.FirstOrDefault(x => x.Value == scale).Key;
                chordsInMyScale[0] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[1] = MinorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[2] = MinorKeys[scaleKey];

                goUpHalfStep(ref scaleKey);
                chordsInMyScale[3] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[4] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[5] = MinorKeys[scaleKey];

            }
            else
            {
                int scaleKey = MinorKeys.FirstOrDefault(x => x.Value == scale).Key;
                chordsInMyScale[0] = MinorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[1] = MinorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[2] = MinorKeys[scaleKey];

                goUpHalfStep(ref scaleKey);
                chordsInMyScale[3] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[4] = MajorKeys[scaleKey];

                goUpOneStep(ref scaleKey);
                chordsInMyScale[5] = MinorKeys[scaleKey];
            }


            foreach (string chord in chordsInMyScale)
            {
                Harmony firstChordHarmony = new Harmony(measures, scale);
                firstChordHarmony.AddChord(chord);
                generatedHarmonies.Add(firstChordHarmony);
            }

            void AddToHarmony()
            {
                List<Harmony> tempList = new List<Harmony>();

                foreach (Harmony currentHarmony in generatedHarmonies)
                {
                    if (currentHarmony.PreviousChord == chordsInMyScale[0])
                    {
                        for (int a = 1; a < chordsInMyScale.Length; a++)
                        {
                            Harmony newHarmony = currentHarmony.cloneHarmony();
                            newHarmony.AddChord(chordsInMyScale[a]);
                            tempList.Add(newHarmony);
                        }
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[1])
                    {
                        Harmony newHarmony = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[5]);
                        tempList.Add(newHarmony);
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[2])
                    {
                        Harmony newHarmony = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[5]);
                        tempList.Add(newHarmony);
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[3])
                    {
                        Harmony newHarmony = currentHarmony.cloneHarmony();
                        Harmony newHarmony2 = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[0]);
                        newHarmony2.AddChord(chordsInMyScale[4]);
                        tempList.Add(newHarmony);
                        tempList.Add(newHarmony2);
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[4])
                    {
                        Harmony newHarmony = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[0]);
                        tempList.Add(newHarmony);
                    }
                    else if (currentHarmony.PreviousChord == chordsInMyScale[5])
                    {
                        Harmony newHarmony = currentHarmony.cloneHarmony();
                        newHarmony.AddChord(chordsInMyScale[1]);
                        tempList.Add(newHarmony);
                    }
                }

                generatedHarmonies = generatedHarmonies.Concat(tempList).ToList();

            }


            for (int x = 0; x < measures - 1; x++)
            {
                AddToHarmony();
            }


            return generatedHarmonies;
        }


    }
}
