using System;
using Utility;
using System.Text;
string path="input.txt";
string input = ImportInput.ToString(@path);

// Part 1
int position = 0;
bool found = false;
do
{
    
    StringBuilder sb = new StringBuilder();
    for(int i=position;i<=position+3 && i<input.Length;i++){
        sb.Append(input[i]);
    }
    string check = sb.ToString();
    Console.WriteLine("Current string and position : {0} {1}",check,position);
    if(check.Distinct().Count() == 4){
        Console.WriteLine("Part 1: Marker found at position {0}, the marker value is {1}",position+4,check);
        found = true;
        break;
    }
    else {
        position++;
    }
}while(position < input.Length-3 && !found);

//Console.ReadKey();
// Part 2

position = 0;
found = false;
do
{
    
    StringBuilder sb = new StringBuilder();
    for(int i=position;i<position+14 && i<input.Length;i++){
        sb.Append(input[i]);
    }
    string check = sb.ToString();
    Console.WriteLine("Current string and position : {0} {1}",check,position);
    int distinctChars = check.Distinct().Count();
    if(distinctChars == 14){
        Console.WriteLine("Part 2: Message marker found at position {0} after {1} chars have been processed, the marker value is {2}",position,position+14,check);
        found = true;
        break;
    }
    else {
        position++;
    }
}while(position < input.Length-14 && !found);