using System.Text;

string[] input = File.ReadAllLines("input.txt");
string currentPath = "";
var foldersSize = new Dictionary<string, int>();
var foldersChildren = new Dictionary<string, List<string>>();
foldersSize.Add("/", 0);
foldersChildren.Add("/", new List<string>());

foreach (string line in input)
{
    StringBuilder sb = new StringBuilder();
    string[] lineContent = line.Split(' ');
    if (lineContent[0] == "$")
    { //we are executing a command
        if (lineContent[1] == "cd") // We are changing directory
        {
            if (lineContent[2] == "..") // We are going up one directory
            {
                int lastSlash = currentPath.LastIndexOf("/"); // Find the last slash in the path
                currentPath = currentPath.Substring(0, lastSlash); // Remove the last folder from the path
                continue;
            }
            else // We are going down one directory
            {
                sb.Append(currentPath); // Add the current path
                if (lineContent[2] != "/" && currentPath != "/") sb.Append("/"); // Add slash between parent folder and child folder, avoid double slash
                sb.Append(lineContent[2]);
                currentPath = sb.ToString(); // Set the new path
                continue; // Skip to the next line
            }

        }
        else if (lineContent[1] == "ls") // We are listing the directory
        {
            continue; // We can skip to the next line, which is the directory listing
        }
    }
    else
    {
        string[] folderContent = line.Split(' ');
        if (folderContent[0] == "dir")
        {
            sb.Append(currentPath);
            if (currentPath != "/") sb.Append("/"); // Separate folder from parent folder, avoid doule slash
            sb.Append(folderContent[1]);
            string subfolder = sb.ToString();
            foldersChildren[currentPath].Add(subfolder); // Add the subfolder to the list of children of the current folder
            if (!foldersSize.ContainsKey(subfolder))
            {
                foldersSize.Add(subfolder, 0);
                foldersChildren.Add(subfolder, new List<string>());
            }
        }
        else
        {
            foldersSize[currentPath] += int.Parse(folderContent[0]);
        }
    }
}
foldersSize.OrderBy(x => x.Key);
foreach (KeyValuePair<string, int> folder in foldersSize)
{
    Console.WriteLine("{0} : {1}", folder.Key, folder.Value);
}

int calculateFoldersSize(string currentFolder)
{
    int currentFoldersize = foldersSize[currentFolder];
    List<string> children = foldersChildren[currentFolder];

    foreach (string child in children)
    {
        currentFoldersize += calculateFoldersSize(child);
    }
    foldersSize[currentFolder] = currentFoldersize;
    return foldersSize[currentFolder];
}

int totalFolderSize = calculateFoldersSize("/");

int size100k = foldersSize.Where(x => x.Value <= 100000).Sum(x => x.Value);
Console.WriteLine("Part 1 : the total size of folders with a size of at most 100k is {0}", size100k);

// Part 2
int freeSpace = 70000000 - totalFolderSize;
Console.WriteLine("Part 2 : the amount of free space is {0}", freeSpace);
int neededSpace = 30000000 - freeSpace;
string folderToDelete = foldersSize.Where(x => x.Value >= neededSpace).OrderByDescending(x => x.Value).Last().Key;

Console.WriteLine("Part 2 : the folder to delete is {0} and is total size is {1}", folderToDelete, foldersSize[folderToDelete]);