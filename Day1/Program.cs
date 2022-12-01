using System;
using Utility;

class Program {
    public static void Main(string[] args){
        Console.WriteLine("Day 1");
        string[] input = Utility.ImportInput.ToStringArray("input.txt");
        List<Tuple<int, int>> elves = new List<Tuple<int, int>>();
        elves=ListElves(input);
        Part1(elves);
        Part2(elves);
        void Part1(List<Tuple<int, int>> elves)
        {
            int elfnumber = elves.OrderBy(x => x.Item2).Last().Item1;
            int calories = elves.OrderBy(x => x.Item2).Last().Item2;
            Console.WriteLine("Part 1: The elf with the most calories is elf number {0} with {1} calories", elfnumber, calories);
        }

        void Part2(List<Tuple<int, int>> elves)
        {
            int top3 = elves.OrderByDescending(x => x.Item2).Take(3).Sum(x => x.Item2);
            Console.WriteLine("Part 2: The top 3 elves have a combined total of {0} calories", top3);
        }

        List<Tuple<int,int>> ListElves(string[] input)
        {
            List<Tuple<int, int>> elves = new List<Tuple<int, int>>();
            Tuple<int, int> elf = new Tuple<int, int>(0, 0);
            int i=0;
            int sum =0;
            foreach (string line in input)
            {
                if(line != ""){
                    sum += int.Parse(line);
                }
                else
                {
                    elves.Add(new Tuple<int, int>(i, sum));
                    i++;
                    sum = 0;
                }
            }
            return elves;
        }
    }
}