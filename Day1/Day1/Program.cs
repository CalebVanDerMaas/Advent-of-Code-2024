// See https://aka.ms/new-console-template for more information

string filePath = "/Users/calebvandermaas/Developer/Advent-of-Code-2024/Day1/Day1/input.txt";
string[] lines = File.ReadAllLines(filePath);
int linesCount = lines.Length;
List<int> list1 = new List<int>(linesCount);
List<int> list2 = new List<int>(linesCount);
int index = 0;
foreach (string line in lines)
{
    for (int i = 0; i < line.Length; i++)
    {
        if (line[i] == ' ')
        {
            index = i;
            break;
        }
    }

    //Convert Substring to Int & Add to List
    list1.Add(Convert.ToInt32((line.Substring(0, index))));
    list2.Add(Convert.ToInt32((line.Substring(index + 3, (line.Length - (index + 3))))));
}

list1.Sort();
list2.Sort();

int sum = 0;
for (int i = 0; i < list1.Count; i++)
{
    if (list1[i] >= list2[i])
    {
        sum += list1[i] - list2[i];
    }
    else
    {
        sum += list2[i] - list1[i];
    }
}

Console.WriteLine(sum);

// foreach (int num in list2)
// {
//     Console.WriteLine(num);
// }

// Console.WriteLine("List 1 Length: " + list1.Count);
// Console.WriteLine("List 2 Length: " + list2.Count);
//