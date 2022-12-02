using System;
using System.Linq;
using System.Net;
using Utility;



string input = Utility.ImportInput.ToString("input.txt");
List<string> games = input.Replace(" ", "").Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();

Part1(games);
Part2(games);


// Rock paper scissors rules list
// Winning gives 6
// Tie gives 3
// Losing gives 0
void Part1(List<string> games)
{
    /* Classic rules
    A = X = Rock
    B = Y = Paper
    C = Z = Scissors
    A = X = 1
    B = Y = 2
    C = Z = 3
    List of possible scores
    AX = 1+3 = 4
    AY = 2+6 = 8
    AZ = 3+0 = 3
    BX = 1+0 = 1
    BY = 2+3 = 5
    BZ = 3+6 = 9
    CX = 1+6 = 7
    CY = 2+0 = 2
    CZ = 3+3 = 6 */
    // Map of possible scores
    Dictionary<string, int> scores = new Dictionary<string, int>();
    scores.Add("AX", 4);
    scores.Add("AY", 8);
    scores.Add("AZ", 3);
    scores.Add("BX", 1);
    scores.Add("BY", 5);
    scores.Add("BZ", 9);
    scores.Add("CX", 7);
    scores.Add("CY", 2);
    scores.Add("CZ", 6);

    int total = 0;
    foreach (string line in games)
    {
        total += scores[line];
    }
    Console.WriteLine("Part 1: The total score is {0}", total);
}

void Part2(List<string> games)
{
    /*  New rules where 2nd char determines outcome
    A Rock
    B Paper
    C Scissors
    A = 1
    B = 2
    C = 3
    X means round lost
    Y means draw
    Z means round won
    List of possible scores
    AX = 0+3 = 3
    AY = 3+1 = 4
    AZ = 6+2 = 8
    BX = 0+1 = 1
    BY = 3+2 = 5
    BZ = 6+3 = 9
    CX = 0+2 = 2
    CY = 3+3 = 6
    CZ = 6+1 = 7
    Map of possible scores */
    Dictionary<string, int> scores = new Dictionary<string, int>();
    scores.Add("AX", 3);
    scores.Add("AY", 4);
    scores.Add("AZ", 8);
    scores.Add("BX", 1);
    scores.Add("BY", 5);
    scores.Add("BZ", 9);
    scores.Add("CX", 2);
    scores.Add("CY", 6);
    scores.Add("CZ", 7);

    int total = 0;
    foreach (string line in games)
    {
        total += scores[line];
    }
    Console.WriteLine("Part 2: The total score is {0}", total);
}