using System.Diagnostics.CodeAnalysis;

namespace Day12
{
    class Program
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int cost { get; set; }
            public Point? previous { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
                cost = int.MaxValue;
            }


            public Point(int x, int y, int cost, Point previous)
            {
                X = x;
                Y = y;
                this.cost = cost;
                this.previous = previous;
            }

            public Point(Tuple<int, int> coords)
            {
                X = coords.Item1;
                Y = coords.Item2;
                cost = int.MaxValue;
            }

            public override bool Equals([NotNullWhen(true)] object? obj)
            {
                if (obj is Point point)
                {
                    return point.X == X && point.Y == Y;
                }
                return false;
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }
        public static void Main(string[] args)
        {
            // Load input
            char[][] elevationMap = File.ReadAllLines("input.txt").Select(x => x.ToCharArray()).ToArray();
            Point startCoords = new Point(Utility.Arrays.Array2DIndexOf(elevationMap, 'S'));
            Point endCoords = new Point(Utility.Arrays.Array2DIndexOf(elevationMap, 'E'));
            Console.WriteLine("Part 1 : The shortest path to the exit is {0} steps long", Part1(elevationMap, startCoords, endCoords).Last().cost);
            Console.WriteLine("Part 2 : The shortest path to the exit is {0} steps long", Part2(elevationMap, startCoords, endCoords).Min(x => x.Last().cost));
        }

        public static List<Point> Part1(char[][] elevationMap, Point startCoords, Point endCoords)
        {
            Dictionary<Point, List<Point>> validNeighbors = new Dictionary<Point, List<Point>>();
            elevationMap[startCoords.X][startCoords.Y] = 'a'; // Assign an elevation of "a" to the start point
            elevationMap[endCoords.X][endCoords.Y] = 'z';
            validNeighbors = getValidNeighbors(elevationMap);
            List<Point> path = getPath(elevationMap, startCoords, endCoords, validNeighbors);
            return path;
        }
        public static List<List<Point>> Part2(char[][] elevationMap, Point startCoords, Point endCoords)
        {
            Dictionary<Point, List<Point>> validNeighbors = new Dictionary<Point, List<Point>>();
            elevationMap[startCoords.X][startCoords.Y] = 'a'; // Assign an elevation of "a" to the start point
            elevationMap[endCoords.X][endCoords.Y] = 'z';
            validNeighbors = getValidNeighbors(elevationMap);
            List<List<Point>> paths = new List<List<Point>>();
            List<Tuple<int, int>> aCoords = Utility.Arrays.Array2DGetAllIndicesOf(elevationMap, 'a');
            foreach (Tuple<int, int> aCoord in aCoords)
            {
                Point start = new Point(aCoord);
                if (validNeighbors[start].Where(x => elevationMap[x.X][x.Y] == 'b').Count() > 0)
                    paths.Add(getPath(elevationMap, start, endCoords, validNeighbors));
            }
            return paths;
        }
        public static void initMaps(char[][] elevationMap, ref List<Point> unvisited)
        {
            for (int x = 0; x < elevationMap.Length; x++)
            {
                for (int y = 0; y < elevationMap[0].Length; y++)
                {
                    unvisited.Add(new Point(x, y));
                }
            }
            return;
        }

        public static Dictionary<Point, List<Point>> getValidNeighbors(char[][] elevationMap)
        {
            Dictionary<Point, List<Point>> validNeighbors = new Dictionary<Point, List<Point>>();
            // Get valid neighbors
            for (int i = 0; i < elevationMap.Length; i++)
            {
                for (int j = 0; j < elevationMap[0].Length; j++)
                {
                    char elevation = elevationMap[i][j];
                    List<Point> neighbors = new List<Point>();
                    if (i > 0 && (elevationMap[i - 1][j] - elevation <= 1))
                        neighbors.Add(new Point(i - 1, j));
                    if (i < elevationMap.Length - 1 && (elevationMap[i + 1][j] - elevation <= 1))
                        neighbors.Add(new Point(i + 1, j));
                    if (j > 0 && (elevationMap[i][j - 1] - elevation <= 1))
                        neighbors.Add(new Point(i, j - 1));
                    if (j < elevationMap[0].Length - 1 && (elevationMap[i][j + 1] - elevation <= 1))
                        neighbors.Add(new Point(i, j + 1));

                    validNeighbors.Add(new Point(i, j), neighbors);
                }
            }
            return validNeighbors;
        }

        // Dijsktra's algorithm to find shortest path from start to end
        public static List<Point> getPath(char[][] elevationMap, Point startCoords, Point endCoords, Dictionary<Point, List<Point>> validNeighbors)
        {
            List<Point> visited = new List<Point>();
            List<Point> unvisited = new List<Point>();

            initMaps(elevationMap, ref unvisited);
            unvisited.Where(x => x.Equals(startCoords)).First().cost = 0;
            while (unvisited.Count > 0 && !visited.Contains(endCoords))
            {
                Point current = unvisited.OrderBy(x => x.cost).First();
                visited.Add(current);
                unvisited.Remove(current);
                foreach (Point neighbor in validNeighbors[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        int newCost = current.cost + 1;
                        if (newCost < neighbor.cost && newCost >= 0)
                        {
                            unvisited.Where(x => x.Equals(neighbor)).First().cost = newCost;
                            unvisited.Where(x => x.Equals(neighbor)).First().previous = current;

                        }

                    }
                }
            }
            List<Point> path = new List<Point>();
            Point currentPoint = visited.Where(x => x.X.Equals(endCoords.X) && x.Y.Equals(endCoords.Y)).First();
            //Console.WriteLine(visited[currentPoint]);
            while (currentPoint != null)
            {
                path.Add(currentPoint);
                currentPoint = currentPoint.previous;
            }
            path.Reverse();
            return path;

        }

    }
}