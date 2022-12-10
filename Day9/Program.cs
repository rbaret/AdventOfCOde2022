List<string> input = File.ReadAllLines("input.txt").ToList();
List<Tuple<int, int>> knots = new List<Tuple<int, int>>();
for (int i = 0; i < 10; i++)
{
    knots.Add(new Tuple<int, int>(0, 0)); // Simulate a 10 knots rope
}
Console.WriteLine("Part 1: The tail has visited at least {0} positions", Part1(input));
Console.WriteLine("Part 2: The tail has visited at least {0} positions", Part2(input, knots));

// Part 1
// Trace the path of the tail and count the number of unique positions it visits

int Part1(List<string> input)
{
    List<string> visited = new List<string>();
    int x = 0;
    int y = 0;
    Tuple<int, int> headPosition = new Tuple<int, int>(0, 0);
    Tuple<int, int> tailPosition = new Tuple<int, int>(0, 0);
    visited.Add(x + "," + y);
    char direction;
    foreach (string line in input)
    {
        string[] moveDescription = line.Split(' ');
        direction = moveDescription[0].ToCharArray()[0];
        int distance = int.Parse(moveDescription[1]);
        for (int i = 0; i < distance; i++)
        {
            switch (direction)
            {
                case 'U':
                    y++;
                    break;
                case 'D':
                    y--;
                    break;
                case 'R':
                    x++;
                    break;
                case 'L':
                    x--;
                    break;
            }
            headPosition = new Tuple<int, int>(x, y);
            if (measureGridDistance(headPosition, tailPosition) > 1)
            {
                switch (direction)
                {
                    case 'U':
                        tailPosition = new Tuple<int, int>(headPosition.Item1, headPosition.Item2 - 1);
                        break;
                    case 'D':
                        tailPosition = new Tuple<int, int>(headPosition.Item1, headPosition.Item2 + 1);
                        break;
                    case 'R':
                        tailPosition = new Tuple<int, int>(headPosition.Item1 - 1, headPosition.Item2);
                        break;
                    case 'L':
                        tailPosition = new Tuple<int, int>(headPosition.Item1 + 1, headPosition.Item2);
                        break;
                }
            }

            if (!visited.Contains(tailPosition.Item1 + "," + tailPosition.Item2))
                visited.Add(tailPosition.Item1 + "," + tailPosition.Item2);
        }
    }
    return visited.Count;
}

int measureGridDistance(Tuple<int, int> head, Tuple<int, int> tail)
{
    if (Math.Abs(head.Item1 - tail.Item1) >= Math.Abs(head.Item2 - tail.Item2))
        return Math.Abs(head.Item1 - tail.Item1);
    else
        return Math.Abs(head.Item2 - tail.Item2);
}

int Part2(List<string> input, List<Tuple<int, int>> knots)
{
    List<string> visited = new List<string>();
    int x = 0;
    int y = 0;
    Tuple<int, int> headPosition = knots.First();
    Tuple<int, int> tailPosition = knots.Last();
    visited.Add(x + "," + y);
    char direction;
    foreach (string line in input)
    {
        string[] moveDescription = line.Split(' ');
        direction = moveDescription[0].ToCharArray()[0];
        int distance = int.Parse(moveDescription[1]);
        for (int i = 0; i < distance; i++)
        {
            List<Tuple<int, int>> newCoords = new List<Tuple<int, int>>();
            switch (direction)
            {
                case 'U':
                    y++;
                    break;
                case 'D':
                    y--;
                    break;
                case 'R':
                    x++;
                    break;
                case 'L':
                    x--;
                    break;
            }
            headPosition = new Tuple<int, int>(x, y);
            newCoords.Add(headPosition);
            int index = 1; // Keep track of the knot weŕe analyzing
            foreach (Tuple<int, int> knot in knots)
            {
                if (index > 0)
                { // Skip the head knot
                    if (measureGridDistance(newCoords[index - 1], knot) > 1)
                    {
                        // Move the knot depending on the direction of the previous node

                        // TBD
                    }
                    else
                    {
                        newCoords.Add(knot);
                    }
                }
                index++;
            }
            knots = newCoords;
            tailPosition = knots.Last();
            if (!visited.Contains(tailPosition.Item1 + "," + tailPosition.Item2))
                visited.Add(tailPosition.Item1 + "," + tailPosition.Item2);
        }
    }
    return visited.Count;
}