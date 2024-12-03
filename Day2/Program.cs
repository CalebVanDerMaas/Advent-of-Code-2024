string filePath = "/Users/calebvandermaas/Developer/Advent-of-Code-2024/Day2/input.txt";
string[] lines = File.ReadAllLines(filePath);
int numSafe = 0;
foreach (string line in lines)
{
    if (line.Length == 1)
    {
        break;
    }
    int charIndx = 0;
    int startIndx = 0;
    bool isAscending = false;
    int numCount = 0;
    List<int> tempList = new List<int>();
    foreach (char c in line)
    {
        
        if (c == ' ')
        {
            int previousNumber = Convert.ToInt32(line.Substring(startIndx, charIndx - startIndx));
            if (numCount == 0)
            {
                tempList.Add(previousNumber);
                numCount += 1;
            } else if (numCount == 1)
            {
                tempList.Add(previousNumber);
                numCount += 1;
                if (tempList[0] == tempList[1])
                {
                    break;
                }
                if (tempList[0] < tempList[1] && tempList[1] <= tempList[0] + 3)
                {
                    isAscending = true;
                } else if (tempList[0] > tempList[1] && tempList[1] >= tempList[0] - 3)
                {
                    isAscending = false;
                }
                else
                {
                    break;
                }
            }
            else
            {
                tempList[0] = tempList[1];
                tempList[1] = previousNumber;
                if (tempList[0] == tempList[1])
                {
                    break;
                }
                if (isAscending)
                {
                    if (tempList[0] > tempList[1])
                    {
                        break;
                    } 
                    if (tempList[1] > tempList[0] + 3)
                    {
                        break;
                    }
                } 
                if (!isAscending)
                {
                    if (tempList[0] < tempList[1])
                    {
                        break;
                    }
                    if (tempList[1] < tempList[0] - 3)
                    {
                        break;
                    }
                } 
            }
            startIndx = charIndx + 1;
        } else if (charIndx == line.Length - 1)
        {
            if (numCount == 0)
            {
                break;
            }
            else if (numCount == 1)
            {
                tempList.Add(Convert.ToInt32(line.Substring(startIndx, charIndx - startIndx + 1)));
                if (tempList[0] < tempList[1] - 3 || tempList[0] > tempList[1] + 3)
                {
                    break;
                }
                else
                {
                    numSafe += 1;
                }
            }
            else if (numCount >= 2)
            {
                int lastNumber = Convert.ToInt32(line.Substring(startIndx, charIndx - startIndx + 1));
                tempList[0] = tempList[1];
                tempList[1] = lastNumber;

                if (tempList[0] == tempList[1])
                {
                    break;
                }

                if (isAscending && tempList[1] > tempList[0] && tempList[1] <= tempList[0] + 3)
                {
                    numSafe++;
                }

                if (!isAscending && tempList[1] < tempList[0] && tempList[1] >= tempList[0] - 3)
                {
                    numSafe++;
                }
                else
                {
                    break;
                }
            }
        }

        charIndx += 1;
    }
}

Console.WriteLine(numSafe);