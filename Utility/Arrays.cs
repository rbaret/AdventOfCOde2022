namespace Utility;

public class Arrays
{
    // function to rotate a bidimensional array by 90 degrees right
    public static int[,] RotateArrayRight(int[,] array)
    {
        int[,] newArray = new int[array.GetLength(1), array.GetLength(0)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[j, array.GetLength(0) - i - 1] = array[i, j];
            }
        }
        return newArray;
    }

    // function to rotate a bidimensional array by 90 degrees left
    public static int[,] RotateArrayLeft(int[,] array)
    {
        int[,] newArray = new int[array.GetLength(1), array.GetLength(0)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[array.GetLength(1) - j - 1, i] = array[i, j];
            }
        }
        return newArray;
    }

    // function to rotate a bidimensional array by 180 degrees
    public static int[,] RotateArray180(int[,] array)
    {
        int[,] newArray = new int[array.GetLength(0), array.GetLength(1)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[array.GetLength(0) - i - 1, array.GetLength(1) - j - 1] = array[i, j];
            }
        }
        return newArray;
    }

    // function to rotate a bidimensional array of chars by 90 degrees right
    public static char[,] RotateArrayRight(char[,] array)
    {
        char[,] newArray = new char[array.GetLength(1), array.GetLength(0)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[j, array.GetLength(0) - i - 1] = array[i, j];
            }
        }
        return newArray;
    }

    // function to rotate a bidimensional array of chars by 90 degrees left
    public static char[,] RotateArrayLeft(char[,] array)
    {
        char[,] newArray = new char[array.GetLength(1), array.GetLength(0)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[array.GetLength(1) - j - 1, i] = array[i, j];
            }
        }
        return newArray;
    }

    // function to rotate a bidimensional array of chars by 180 degrees
    public static char[,] RotateArray180(char[,] array)
    {
        char[,] newArray = new char[array.GetLength(0), array.GetLength(1)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[array.GetLength(0) - i - 1, array.GetLength(1) - j - 1] = array[i, j];
            }
        }
        return newArray;
    }

    // function to do a vertical symmetry on an int array
    public static int[,] VerticalSymmetry(int[,] array)
    {
        int[,] newArray = new int[array.GetLength(0), array.GetLength(1)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[i, array.GetLength(1) - j - 1] = array[i, j];
            }
        }
        return newArray;
    }

    // function to do a vertical symmetry on a char array
    public static char[,] VerticalSymmetry(char[,] array)
    {
        char[,] newArray = new char[array.GetLength(0), array.GetLength(1)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[i, array.GetLength(1) - j - 1] = array[i, j];
            }
        }
        return newArray;
    }

    // function to do a horizontal symmetry on an int array
    public static int[,] HorizontalSymmetry(int[,] array)
    {
        int[,] newArray = new int[array.GetLength(0), array.GetLength(1)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[array.GetLength(0) - i - 1, j] = array[i, j];
            }
        }
        return newArray;
    }

    // function to do a horizontal symmetry on a char array
    public static char[,] HorizontalSymmetry(char[,] array)
    {
        char[,] newArray = new char[array.GetLength(0), array.GetLength(1)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                newArray[array.GetLength(0) - i - 1, j] = array[i, j];
            }
        }
        return newArray;
    }

    // function to return the coordinates of the first occurence of a char in a bidimensional array
    public static Tuple<int,int> Array2DIndexOf(char[][] array, char c)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] == c)
                {
                    return new Tuple<int, int>(i, j);
                }
            }
        }
        return null;
    }

    // function to return all coordinates of a char occurence in a bidimensional array
    public static List<Tuple<int, int>> Array2DGetAllIndicesOf(char[][] array, char c)
    {
        List<Tuple<int, int>> result = new List<Tuple<int, int>>();
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] == c)
                {
                    result.Add(new Tuple<int, int>(i, j));
                }
            }
        }
        return result;
    }

    public static List<int[]> Return4Neighbors(char[][] array, int x, int y)
    {
        List<int[]> result = new List<int[]>();
        result.Add(new int[]{x - 1, y});
        result.Add(new int[]{x + 1, y});
        result.Add(new int[]{x, y - 1});
        result.Add(new int[]{x, y + 1});
        return result;
    }
}
