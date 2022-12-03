using System.Collections.Generic;
using System.Linq;
List<string> input = Utility.ImportInput.ToStringList("input.txt");

// map of values for each char
// a to z = 1 to 26
// A to Z = 27 to 52
// Not nice not to have chosen the ASCII order, this would have avoided the charmap :D

Dictionary<char, int> charMap = new Dictionary<char, int>();
for (int i = 0; i < 26; i++)
{
    charMap.Add((char)(i + 97), i + 1);
    charMap.Add((char)(i + 65), i + 27);
}
Part1(input, charMap);
Part2(input, charMap);

void Part1(List<string> input, Dictionary<char, int> charMap)
{
    List<List<char>> compartment1 = new List<List<char>>();
    List<List<char>> compartment2 = new List<List<char>>();

    // Split every line in two compartments of equal length and put them in two lists
    foreach (string line in input)
    {
        compartment1.Add(line.Substring(0, line.Length / 2).ToArray().ToList());
        compartment2.Add(line.Substring(line.Length / 2, line.Length / 2).ToArray().ToList());
    }

    // Look in each list if there is a common char and add the value of the char to the sum
    int sum = 0;
    for (int i = 0; i < compartment1.Count; i++)
    {
        foreach (char c in compartment1[i])
        {
            if (compartment2[i].Contains(c))
            {
                sum += charMap[c];
                break;
            }
        }
    }

    Console.WriteLine("Part 1: the sum of all the items present in both compartments is {0}", sum);
}

void Part2(List<string> input, Dictionary<char,int> charMap){

    int sum = 0;
    // Look for the common chars in each group of 3 lines, this is the badge
    for (int i = 0; i <= input.Count-3; i += 3)
    {
        foreach (char c in input[i])
        {
            if (input[i + 1].Contains(c) && input[i + 2].Contains(c))
            {
                sum += charMap[c];
                break;
            }
        }
    }
    Console.WriteLine("Part 2: the sum of all the group badges is {0}", sum);

}