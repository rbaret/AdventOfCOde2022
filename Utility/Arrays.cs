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
}
