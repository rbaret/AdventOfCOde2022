namespace Day10
{
    public class monkeyItems
    {
        public int id;
        public List<int> items;
        public string operation;
        public int opValue;
        public int divisibleBy;
        public int ifTrue;
        public int ifFalse;

        public monkeyItems(int id, List<int> items, string operation, int opValue, int divisibleBy, int ifTrue, int ifFalse)
        {
            this.id = id;
            this.items = items;
            this.operation = operation;
            this.opValue = opValue;
            this.divisibleBy = divisibleBy;
            this.ifTrue = ifTrue;
            this.ifFalse = ifFalse;
        }


    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<monkeyItems> monkeyList = new List<monkeyItems>();
            // Manually initialize the list of monkeys, faster than coding a parser :D
            monkeyList.Add(new monkeyItems(0, new List<int> { 59, 65, 86, 56, 74, 57, 56 }, "times", 17, 3, 3, 6));
            monkeyList.Add(new monkeyItems(1, new List<int> { 63, 83, 50, 63, 56 }, "plus", 2, 13, 3, 0));
            monkeyList.Add(new monkeyItems(2, new List<int> { 93, 79, 74, 55 }, "plus", 1, 2, 0, 1));
            monkeyList.Add(new monkeyItems(3, new List<int> { 86, 61, 67, 88, 94, 69, 56, 91 }, "plus", 7, 11, 6, 7));
            monkeyList.Add(new monkeyItems(4, new List<int> { 76, 50, 51 }, "square", 0, 19, 2, 5));
            monkeyList.Add(new monkeyItems(5, new List<int> { 77, 76 }, "plus", 8, 17, 2, 1));
            monkeyList.Add(new monkeyItems(6, new List<int> { 74 }, "times", 2, 5, 4, 7));
            monkeyList.Add(new monkeyItems(7, new List<int> { 86, 85, 52, 86, 91, 95 }, "plus", 6, 7, 4, 5));

            // Let GH Copilot write a parser for the input file and store the result in a list of monkeyItems   
            List<monkeyItems> monkeyList2 = parseInput("input.txt");
            Console.WriteLine("Part 1 : the monkey business is : {0}", Part1(monkeyList2));
            Console.WriteLine("Part 2 : the monkey business is : {0}", Part2(monkeyList2));
        }
        public static List<monkeyItems> parseInput(string path)
        {
            List<monkeyItems> monkeyList = new List<monkeyItems>();
            string[] lines = File.ReadAllLines(path);
            int id = 0;
            List<int> items = new List<int>();
            string operation = "";
            int opValue = 0;
            int divisibleBy = 0;
            int ifTrue = 0;
            int ifFalse = 0;
            foreach(string line in lines)
            {
                if (line.Contains("Monkey"))
                {
                    id = int.Parse(line.Split(' ')[1].Replace(":", ""));
                }
                else if (line.Contains("Starting items"))
                {
                    items = line.Split(':')[1].Split(',').Select(x => int.Parse(x)).ToList();
                }
                else if (line.Contains("Operation")) // ignore everything before the equal sign
                {
                    string[] operationSplit = line.Split('=')[1].Split(' ');
                    if (operationSplit[3] == "old")
                    {
                        opValue = 0;
                        operation = "square";
                    }
                    else
                    {
                        operation = operationSplit[2];
                        opValue = int.Parse(operationSplit[3]);
                    }
                    
                }
                else if (line.Contains("Test"))
                {
                    divisibleBy = int.Parse(line.Split(':')[1].Split(' ')[3]);
                }
                else if (line.Contains("If true"))
                {
                    ifTrue = int.Parse(line.Split(':')[1].Split(' ')[4]);
                }
                else if (line.Contains("If false"))
                {
                    ifFalse = int.Parse(line.Split(':')[1].Split(' ')[4]);
                    monkeyList.Add(new monkeyItems(id, items, operation, opValue, divisibleBy, ifTrue, ifFalse));
                }
            }
            return monkeyList;


        }

        public static double Part1(List<monkeyItems> monkeyList)
        {
            List<int> inspectedItems = new List<int>(){0,0,0,0,0,0,0,0};
            
            for (int i = 0; i < 20; i++)
            {
                int index = 0;
                foreach (monkeyItems monkey in monkeyList)
                {
                    int worryLevelAfterInspection = 0;
                    foreach (int item in monkey.items)
                    {
                        switch (monkey.operation)
                        {
                            case "+":
                                worryLevelAfterInspection = item + monkey.opValue;
                                break;
                            case "*":
                                worryLevelAfterInspection = item * monkey.opValue;
                                break;
                            case "square":
                                worryLevelAfterInspection = item * item;
                                break;
                        }
                        int newWorryLevel = worryLevelAfterInspection/3;
                        if (newWorryLevel % monkey.divisibleBy == 0)
                        {
                            monkeyList[monkey.ifTrue].items.Add(newWorryLevel);
                        }
                        else
                        {
                            monkeyList[monkey.ifFalse].items.Add(newWorryLevel);
                        }
                        inspectedItems[index]++;
                    }
                    monkeyList[index].items.Clear();
                    index++;
                }
            }
            return inspectedItems.OrderByDescending(x=>x).Take(2).Aggregate(1, (x, y) => x * y);;
        }

        public static long Part2(List<monkeyItems> monkeyList)
        {
            List<long> inspectedItems = new List<long>(){0,0,0,0,0,0,0,0};
            int supermodulo = monkeyList.Select(x => x.divisibleBy).Aggregate(1, (x, y) => x * y);
            for (int i = 0; i < 10000; i++)
            {
                int index = 0;
                foreach (monkeyItems monkey in monkeyList)
                {
                    int worryLevelAfterInspection = 0;
                    foreach (int item in monkey.items)
                    {
                        switch (monkey.operation)
                        {
                            case "+":
                                worryLevelAfterInspection = item + monkey.opValue;
                                break;
                            case "*":
                                worryLevelAfterInspection = item * monkey.opValue;
                                break;
                            case "square":
                                worryLevelAfterInspection = item * item;
                                break;
                        }
                        if (worryLevelAfterInspection % monkey.divisibleBy == 0)
                        {
                            monkeyList[monkey.ifTrue].items.Add(worryLevelAfterInspection%supermodulo);
                        }
                        else
                        {
                            monkeyList[monkey.ifFalse].items.Add(worryLevelAfterInspection%supermodulo);
                        }
                        inspectedItems[index]++;
                    }
                    monkeyList[index].items.Clear();
                    index++;
                }
            }
            List<long> returnList = inspectedItems.OrderByDescending(x=>x).Take(2).ToList();
            return (long)returnList[0] * (long)returnList[1];
        }
    }
}
