using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode2022
{
    public class Day1
    {
        [Fact]
        public void CalenderDay1()
        {
            List<int> elfSupplies = new List<int>();
            int calories = 0;
            foreach (string line in File.ReadLines("data\\input1.txt"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elfSupplies.Add(calories);
                    calories = 0;
                    continue;
                }

                calories = calories + int.Parse(line);
            }
            elfSupplies.Add(calories);
            calories = 0;

            elfSupplies = elfSupplies.OrderByDescending(i => i).ToList();

            var answer = elfSupplies[0];
            var answer2 = elfSupplies[0] + elfSupplies[1] + elfSupplies[2];
        }
    }
}
