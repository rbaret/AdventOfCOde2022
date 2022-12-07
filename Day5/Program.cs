using System.Text;
using System.Threading;
/**
Graph of initial stacks disposition
bottom to top
        [G]         [D]     [Q]    
[P]     [T]         [L] [M] [Z]    
[Z] [Z] [C]         [Z] [G] [W]    
[M] [B] [F]         [P] [C] [H] [N]
[T] [S] [R]     [H] [W] [R] [L] [W]
[R] [T] [Q] [Z] [R] [S] [Z] [F] [P]
[C] [N] [H] [R] [N] [H] [D] [J] [Q]
[N] [D] [M] [G] [Z] [F] [W] [S] [S]
 1   2   3   4   5   6   7   8   9 
**/

// Initial state of stacks. yes it was faster to hardcode it given the size
// Transpose columns above into rows
char[][] initialStacks = new char[9][];
initialStacks[0] = new char[] { 'N', 'C', 'R', 'T', 'M', 'Z', 'P' };
initialStacks[1] = new char[] { 'D', 'N', 'T', 'S', 'B', 'Z' };
initialStacks[2] = new char[] { 'M', 'H', 'Q', 'R', 'F', 'C', 'T', 'G' };
initialStacks[3] = new char[] { 'G', 'R', 'Z' };
initialStacks[4] = new char[] { 'Z', 'N', 'R', 'H' };
initialStacks[5] = new char[] { 'F', 'H', 'S', 'W', 'P', 'Z', 'L', 'D' };
initialStacks[6] = new char[] { 'W', 'D', 'Z', 'R', 'C', 'G', 'M' };
initialStacks[7] = new char[] { 'S', 'J', 'F', 'L', 'H', 'W', 'Z', 'Q' };
initialStacks[8] = new char[] { 'S', 'Q', 'P', 'W', 'N' };



// 9 lists to hold the values of the 9 stacks
List<List<char>> stacks = new List<List<char>>();
for (int i = 0; i < 9; i++)
{
    stacks.Add(new List<char>());
    stacks[i] = initialStacks[i].ToList();
}

// DIsplay initial state
foreach (List<char> stack in stacks)
{
    foreach (char crate in stack)
    {
        Console.Write("[{0}]", crate);
    }
    Console.Write("\r\n");
}
Console.ReadKey();
Console.Clear();
string path = "input_parsed.txt";
Part1(stacks, path);
Console.ReadKey();
Console.Clear();
Part2(stacks, path);
// Part 1
static void Part1(List<List<char>> stacksList, string path)
{
    Console.WriteLine("Press any key to start");
    Console.ReadKey();
    List<List<char>> stacks = stacksList.Select(x => x.ToList()).ToList();
    foreach (string line in File.ReadLines(@path))
    {
        int[] move = line.Split(',').Select(int.Parse).ToArray();
        for (int crates = 1; crates <= move[0]; crates++)
        {
            Console.WriteLine("Move {0} crates from stack {1} to stack {2}", move[0], move[1], move[2]);
            // // Fancy visualization of the stacks after each move
            // foreach (List<char> stack in stacks)
            // {
            //     Console.Write("Stack {0} : ", stacks.IndexOf(stack) + 1);
            //     foreach (char crate in stack)
            //     {
            //         Console.Write("[{0}]", crate);
            //     }
            //     Console.Write("\r\n");
            // }
            // Thread.Sleep(20);
            Console.Clear();
            stacks[move[2] - 1].Add(stacks[move[1] - 1].Last());
            stacks[move[1] - 1].RemoveAt(stacks[move[1] - 1].Count - 1);
        }
    }

    StringBuilder sb = new StringBuilder();
    Console.WriteLine("Part 1 final disposition of stacks");
    foreach (List<char> stack in stacks)
    {
        Console.Write("Stack {0} : ", stacks.IndexOf(stack) + 1);
        foreach (char crate in stack)
        {
            Console.Write("[{0}]", crate);
        }
        sb.Append(stack.Last());
        Console.Write("\r\n");
    }
    Console.WriteLine("List of crates on top of each pile : {0}", sb.ToString());

}
// Part 2
static void Part2(List<List<char>> stacksList, string path)
{
    List<List<char>> stacks = stacksList.Select(x => x.ToList()).ToList();

    Console.WriteLine("Initial state of stacks");
    foreach (List<char> stack in stacks)
    {
        foreach (char crate in stack)
        {
            Console.Write("[{0}]", crate);
        }
        Console.Write("\r\n");
    }
    Console.WriteLine("Press any key to start");
    Console.ReadKey();
    foreach (string line in File.ReadLines(@path))
    {
        int[] move = line.Split(',').Select(int.Parse).ToArray();
        // Fancy visualization of the stacks after each move
        // foreach (List<char> stack in stacks)
        // {
        //     Console.Write("Stack {0} : ", stacks.IndexOf(stack) + 1);
        //     foreach (char crate in stack)
        //     {
        //         Console.Write("[{0}]", crate);
        //     }
        //     Console.Write("\r\n");
        // }
        // Thread.Sleep(10);

        Console.Clear();
        char[] cratesToMove = stacks[move[1] - 1].GetRange(stacks[move[1] - 1].Count - move[0], move[0]).ToArray();
        stacks[move[2] - 1].AddRange(cratesToMove);
        stacks[move[1] - 1].RemoveRange(stacks[move[1] - 1].Count - move[0], move[0]);
    }

    StringBuilder sb = new StringBuilder();
    Console.WriteLine("Part 2 final disposition of stacks");
    foreach (List<char> stack in stacks)
    {
        Console.Write("Stack {0} : ", stacks.IndexOf(stack) + 1);
        foreach (char crate in stack)
        {
            Console.Write("[{0}]", crate);
        }
        sb.Append(stack.Last());
        Console.Write("\r\n");
    }
    Console.WriteLine("List of crates on top of each pile : {0}", sb.ToString());
}