List<string> input = File.ReadAllLines("input.txt").ToList();
Console.WriteLine("Part 1: The tail has visited at least {0} positions", followTailKnot(input, 2)); 
Console.WriteLine("Part 2: The tail has visited at least {0} positions", followTailKnot(input, 10));


int followTailKnot(List<string> input, int knotsNumber)
{
    List<string> visited = new List<string>();
    List<Tuple<int, int>> knots = new List<Tuple<int, int>>();
    for (int i = 0; i < knotsNumber; i++)
    {
        knots.Add(new Tuple<int, int>(0, 0)); // Simulate a 10 knots rope
    }
    visited.Add(0 + "," + 0);
    char direction;
    foreach (string line in input)
    {
        string[] moveDescription = line.Split(' ');
        direction = moveDescription[0].ToCharArray()[0];
        int distance = int.Parse(moveDescription[1]);
        for (int i = 0; i < distance; i++)
        {
            List<Tuple<int, int>> newCoords = new List<Tuple<int, int>>();
            // Set new head coordinates
            switch (direction)
            {
                case 'U':
                    newCoords.Add(new Tuple<int, int>(knots[0].Item1 + 1, knots[0].Item2));
                    break;
                case 'D':
                    newCoords.Add(new Tuple<int, int>(knots[0].Item1 - 1, knots[0].Item2));
                    break;
                case 'R':
                    newCoords.Add(new Tuple<int, int>(knots[0].Item1, knots[0].Item2 + 1));
                    break;
                case 'L':
                    newCoords.Add(new Tuple<int, int>(knots[0].Item1, knots[0].Item2 - 1));
                    break;
            }
            knots.RemoveAt(0); // Remove head from previous list as it's now in a new list
            int index = 0; // Keep track of the knot weŕe analyzing
            foreach (Tuple<int, int> knot in knots)
            {
                // Measure distance between current knot and preceding knot
                // we compare current index from old knots with same index of new knots list because head has been removed
                // and all knots have been shifted by 1
                if (measureGridDistance(newCoords[index], knot) > 1)
                {
                    newCoords.Add(moveKnot(knot, newCoords[index]));
                }
                else
                {
                    newCoords.Add(knot);
                }
                index++;
            }
            knots = newCoords;
            if (!visited.Contains(knots.Last().Item1 + "," + knots.Last().Item2))
                visited.Add(knots.Last().Item1 + "," + knots.Last().Item2);
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

Tuple<int, int> moveKnot(Tuple<int, int> knot, Tuple<int, int> previousKnot)
{
    int lineDiff = Math.Abs(previousKnot.Item1 - knot.Item1);
    int columnDiff = Math.Abs(previousKnot.Item2 - knot.Item2);
    int newX = knot.Item1;
    int newY = knot.Item2;
    // Here we go for the hell's algorithm
    if (lineDiff == 1 && columnDiff > 1) // knot 1 line below/above the previous knot and at least 2 cols behind/after
    {
        newX = previousKnot.Item1; // reach same line
        if (knot.Item2 > previousKnot.Item2) // check if previous knot is on the left or the right
            newY = knot.Item2 - 1; // If the previous knot is at the left of the current one, move left
        else
            newY = knot.Item2 + 1; // else move right
    }
    else if (columnDiff == 1 && lineDiff > 1) // knot 1 column left/right from the previous one
    {
        newY = previousKnot.Item2; // move to the same column
        if (knot.Item1 > previousKnot.Item1)// check if previous knot is above or below
            newX = knot.Item1 - 1; // If the previous kot is below, move down
        else
            newX = knot.Item1 + 1; // else move up
    }
    else if (lineDiff > 1 && columnDiff > 1) // This situation happens when the previous node was 1,1 away and is moved diagonally leasing to 2,2 distance or more
    {
        // Same checks and moves as above
        if (knot.Item1 > previousKnot.Item1)
            newX = knot.Item1 - 1;
        else
            newX = knot.Item1 + 1;
        if (knot.Item2 > previousKnot.Item2)
            newY = knot.Item2 - 1;
        else
            newY = knot.Item2 + 1;
    }
    else if (lineDiff == 0) // We stay on the same line, only move left or right
    {
        if (knot.Item2 > previousKnot.Item2)
            newY = knot.Item2 - 1;
        else
            newY = knot.Item2 + 1;
    }
    else if (columnDiff == 0) // Same if we stay on the same column
    {
        if (knot.Item1 > previousKnot.Item1)
            newX = knot.Item1 - 1;
        else
            newX = knot.Item1 + 1;
    }
    knot = new Tuple<int, int>(newX, newY);
    return knot;
}