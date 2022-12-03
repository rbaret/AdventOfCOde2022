using System;
using System.IO;
using System.Collections.Generic;
namespace Utility
{
    public static class ImportInput
    {
        // Read input file and put each line in a list of int by parsing each line
        public static List<int> ToIntList(string @path){
            List<int> myList = new List<int>();
            foreach(string line in File.ReadLines(@path)){
                myList.Add(int.Parse(line));
            }
            return myList;
        }
        public static List<string> ToStringList(string @path){
            List<string> myList = new List<string>();
            foreach(string line in File.ReadAllLines(@path)){
                myList.Add(line);
            }
            return myList;
        }

        // Read input file and put each line in a jagged array of char by parsing each line
        public static char[][] ToCharJaggedArray(string @path){
            List<char[]> myList = new List<char[]>();
            foreach(string line in File.ReadAllLines(@path)){
                myList.Add(line.ToCharArray());
            }
            return myList.ToArray();
        }


        // Read input file and put each line in an array of string
        public static string[] ToStringArray(string @path){
            return File.ReadAllLines(@path);
        }

        // Read input file and put each line in an array of int by parsing each line for int
        public static int[] ToIntArray(string @path){
            string[] input = File.ReadAllLines(@path);
            int[] myArray = new int[input.Length];
            for(int i = 0; i < input.Length; i++){
                myArray[i] = int.Parse(input[i]);
            }
            return myArray;
        }

        public static char[][] ToCharArray(string @path){
            string[] fileContent = File.ReadAllLines(@path);
            char[][] myArray = new char[fileContent.Length][];
            int lineIndex = 0;
            foreach(string line in fileContent){
                myArray[lineIndex] = line.ToCharArray();
                lineIndex++;
            }
            return myArray;
        }

        public static int[,] ToIntMatrix(string @path){
            string[] fileContent = File.ReadAllLines(@path);
            int[,] myArray = new int [fileContent.Length,fileContent[0].Length];
            int lineIndex = 0;
            foreach(string line in fileContent){
                int i=0;
                foreach(char c in line)
                {
                    myArray[lineIndex,i] = c-48; // Converts 
                    i++;
                }
                lineIndex++;
            }
            return myArray;
        }

        // Read input file as a single string
        public static string ToString(string @path){
            return File.ReadAllText(@path);
        }
    }
}