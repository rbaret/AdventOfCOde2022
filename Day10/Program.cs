List<string> input = File.ReadAllLines("input.txt").ToList();



// Part 1
int Part1(List<string> input){
    // Go trough instructions
    string[] instructions = input.First().Split(' ');
    string command = instructions[0];
    string value = "";
}