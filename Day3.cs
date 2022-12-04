using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdventOfCode2022
{
    public class Day3
    {
        [Fact]
        public void CalenderDay3()
        {
            int total = 0;
            foreach (string line in File.ReadLines("data\\input3.txt"))
            {
                int split = line.Length / 2;
                string sack1 = line.Substring(0, split);
                string sack2 = line.Substring(split, split);

                char dup = '?';
                foreach (var letter in sack1)
                {
                    if (sack2.Contains(letter))
                    {
                        dup = letter;
                        break;
                    }
                }

                if(dup == '?')
                    throw new Exception("CalenderDay3: Dat data is fugly!!!");

                 total = total + GetPriority(dup);
            }
        }

        private int GetPriority(char letter)
        {
            string alphebet = "abcdefghijklmnopqrstuvwxyz";
            int priority = alphebet.IndexOf(letter, StringComparison.InvariantCultureIgnoreCase) + 1;

            if (char.IsUpper(letter))
                priority = priority + 26;

            return priority;
        }

        [Fact]
        public void CalenderDay3Part2()
        {
            int total = 0;
            List<string> groupMembers = new List<string>();
            foreach (string line in File.ReadLines("data\\input3.txt"))
            {
                groupMembers.Add(line);
                if (groupMembers.Count < 3)
                {
                    continue;
                }

                char badge = '?';
                foreach (var letter in groupMembers[0])
                {
                    if (groupMembers[1].Contains(letter) && groupMembers[2].Contains(letter))
                    {
                        badge = letter;
                        break;
                    }
                }

                if (badge == '?')
                    throw new Exception("CalenderDay3: Dat data is fugly!!!");

                groupMembers = new List<string>();
                total = total + GetPriority(badge);
            }
        }


    }
}
