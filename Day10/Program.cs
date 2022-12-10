List<string> input = File.ReadAllLines("input.txt").ToList();
// 6 lines times 40 pixels from Part 2
char[,] screen = new char[6, 40];
Console.WriteLine("Part 1 : the sum of the 6 signal strengths is " + Solve(input));
Console.WriteLine("Part 2 : the 8 letters are :");
// Print the matrix on the screen
    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 40; j++)
        {
            Console.Write(screen[i, j]);
        }
        Console.WriteLine();
    }
// Part 1
int Solve(List<string> input)
{
    int clockCycle = 1;
    int remainingCycles = 0;
    bool isExecuting = false;
    int X = 1;
    int index = 0;
    string command = "";
    int addValue = 0;
    int[] milestones = { 20, 60, 100, 140, 180, 220 };
    List<Tuple<int, int>> clockMilestones = new List<Tuple<int, int>>();
    // Go trough instructions
    // Clock tick is the master
    do
    {
        // Let's draw the pixels for part 2
        int screenLine = clockCycle / 40;
        int screenPixel = clockCycle % 40;
        if (isSpriteOverlapping(screenPixel, X))
        {
            screen[screenLine, screenPixel] = '#';
        }
        else
        {
            screen[screenLine, screenPixel] = '.';
        }

        // The real part 1

        if ((clockCycle - 20) % 40 == 0) // We add a milestone at 20th clock cycle and every 40th after that
        {
            clockMilestones.Add(new Tuple<int, int>(clockCycle, X * clockCycle));
        }
        if (!isExecuting) // If we are not executing a command, get the next one
        {
            command = input[index].Split(' ')[0];
        }
        if (command == "noop")
        {
            // Do nothing
            index++;
        }
        else // command is addx
        {
            if (!isExecuting)
            {
                isExecuting = true;
                remainingCycles = 2;
            }
            if (remainingCycles > 1) // First cycle, nothing happens
            {
                remainingCycles--;
            }
            else // We can execute the command and add the value to X
            {
                addValue = int.Parse(input[index].Split(' ')[1]);
                X += addValue;
                isExecuting = false;
                index++; // we can go to the next instruction
            }

        }
        clockCycle++;
    } while (index < input.Count && clockCycle < 240);

    return clockMilestones.Where(x => milestones.Contains(x.Item1)).Select(x => x.Item2).Sum();
}


// Check if the sprite is overlapping the current pixel on the current line
bool isSpriteOverlapping(int y, int spriteIndex)
{
    int spriteY = spriteIndex % 40;
    for (int i = 0; i < 3 && spriteY + i < 40; i++)
    {
        if (spriteY + i == y)
        {
            return true;
        }
    }
    return false;
}