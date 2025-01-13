// See https://aka.ms/new-console-template for more information

using System.Data;
using Microsoft.VisualBasic.FileIO;

class Program
{
    static void Main()
    {
        var queueTools1 = new PrintQueueTools();
        QueueData queueData = queueTools1.ParseInput("/Users/calebvandermaas/Developer/Advent-of-Code-2024/Day5/input.txt");
        List<List<int>> correctLines = queueTools1.FindCorrectUpdates(queueData);
        int answer = queueTools1.SumCorrectLists(correctLines);
        Console.WriteLine(answer);
        // Console.WriteLine(correctLines.Count);
        // foreach (int num in correctLines)
        // {
        //     Console.WriteLine(num);
        // }
    }
}

class QueueData
{
   public List<(int,int)> Rules { get; set; }
   public List<List<int>> Updates { get; set; }
}

class PrintQueueTools
{
    public QueueData ParseInput(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        List<(int Before, int After)> Rules = new List<(int Before, int　After)>();
        List<List<int>> Updates = new List<List<int>>();
        foreach (string line in lines)
        {
            if (line.Contains('|'))
            {
                int splitInd = line.IndexOf('|');
                int before = Convert.ToInt32(line.Substring(0, splitInd));
                int after = Convert.ToInt32(line.Substring(splitInd + 1, line.Length - splitInd - 1));
                (int Before, int After) tuple = (before, after);
                Rules.Add(tuple);
            }
            
            if (line.Contains(','))
            {
                List<int> temp = line.Split(',').Select(int.Parse).ToList();
                Updates.Add(temp);
            }
        }

        return new QueueData()
        {
            Rules = Rules,
            Updates = Updates
        };
    }

    public List<List<int>> FindCorrectUpdates(QueueData data)
    {
        List<List<int>> goodLists = [];
        foreach (List<int> update in data.Updates)
        {
            foreach ((int, int) rule  in data.Rules)
            {
                if (update.Contains(rule.Item1) && update.Contains(rule.Item2))
                {
                    int beginIndex = update.IndexOf(rule.Item1);
                    int endIndex = update.IndexOf(rule.Item2);
                    if (beginIndex > endIndex)
                    {
                        break;
                    }
                    else
                    {
                        //continue
                    }
                }

                if (rule == data.Rules.Last())
                {
                    goodLists.Add(update);
                }
            }
        }
        return goodLists;
        
    }

    public int SumCorrectLists(List<List<int>> goodLists)
    {
        List<int> sumList = [];
        foreach (List<int> list in goodLists)
        {
            sumList.Add(list[list.Count / 2]);
        }

        foreach (int item in sumList)
        {
            Console.WriteLine(item);
        }
        return sumList.Sum();;
    }
}