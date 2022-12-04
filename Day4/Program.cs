using System.Net;
using Utility;
List<string> input = Utility.ImportInput.ToStringList("input.txt");

// Condensed version. Initial version in comments below.
int completeOverlap, partialoverlap, m1start, m1end, m2start, m2end;
completeOverlap = partialoverlap = m1start = m1end = m2start = m2end = 0;

foreach (string line in input)
{
    m1start = int.Parse(line.Split(',')[0].Split('-')[0]);
    m1end = int.Parse(line.Split(',')[0].Split('-')[1]);
    m2start = int.Parse(line.Split(',')[1].Split('-')[0]);
    m2end = int.Parse(line.Split(',')[1].Split('-')[1]);
    if ((m1start >= m2start && m1end <= m2end) || (m1start <= m2start && m1end >= m2end))
        completeOverlap++;
    if ((m1start >= m2start && m1start <= m2end) || (m1end >= m2start && m1end <= m2end) || (m2start >= m1start && m2start <= m1end) || (m2end >= m1start && m2end <= m1end))
        partialoverlap++;
}
Console.WriteLine("Part 1: {0} assignment pairs have a complete overlap", completeOverlap);
Console.WriteLine("Part 2: {0} assignment pairs have an overlap", partialoverlap);


// Initial version
/* // Create two lists of members, each member having a start and end of the range
List<Tuple<int, int>> member1 = new List<Tuple<int, int>>();
List<Tuple<int, int>> member2 = new List<Tuple<int, int>>();

// Assign ranges to each member of the pair
foreach (string line in input)
{
    member1.Add(new Tuple<int, int>(int.Parse(line.Split(',')[0].Split('-')[0]), int.Parse(line.Split(',')[0].Split('-')[1])));
    member2.Add(new Tuple<int, int>(int.Parse(line.Split(',')[1].Split('-')[0]), int.Parse(line.Split(',')[1].Split('-')[1])));
}


// Part 1
// Check for range complete overlap for each pair
int overlap = 0;
int currentAssignment = 0; // 

foreach (Tuple<int, int> member in member1)
{
    int index = currentAssignment;
    if ((member.Item1 >= member2[index].Item1 && member.Item2 <= member2[index].Item2) || (member.Item1 <= member2[index].Item1 && member.Item2 >= member2[index].Item2))
    {
        overlap++;
    }
    currentAssignment++;
}
Console.WriteLine("Part 1: {0} assignment pairs have a complete overlap", overlap);


// Part 2
// Check for ranges which overlap at all
overlap = 0;
currentAssignment = 0;
foreach (Tuple<int, int> member in member1)
{
    int index = currentAssignment;
    if ((member.Item1 >= member2[index].Item1 && member.Item1<= member2[index].Item2) || (member.Item2 >= member2[index].Item1 && member.Item2 <= member2[index].Item2) || (member2[index].Item1 >= member.Item1 && member2[index].Item1 <= member.Item2) || (member2[index].Item2 >= member.Item1 && member2[index].Item2 <= member.Item2))
    {
        overlap++;
    }
    currentAssignment++;
}
Console.WriteLine("Part 2: {0} assignment pairs have an overlap", overlap);
 */