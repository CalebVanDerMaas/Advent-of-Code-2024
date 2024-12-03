// string filePath = "/Users/calebvandermaas/Developer/Advent-of-Code-2024/Day2/input.txt";
// string[] lines = File.ReadAllLines(filePath);
// int numSafe = 0;
// foreach (string line in lines)
// {
//     int charIndx = 0;
//     int startIndx = 0;
//     bool isAscending = false;
//     bool moreThanTwoItems = false;
//     List<int> tempList = new List<int>();
//     foreach (char c in line)
//     {
//         if (line.Length == 1)
//         {
//             break;
//         }
//         if (c == ' ')
//         {
//             int previousNumber = Convert.ToInt32(line.Substring(startIndx, charIndx - startIndx));
//             if (tempList.Count == 0)
//             {
//                 tempList.Add(previousNumber);
//             } else if (tempList.Count == 1)
//             {
//                 tempList.Add(previousNumber);
//                 if (tempList[0] == tempList[1])
//                 {
//                     break;
//                 }
//                 if (tempList[0] < tempList[1] && tempList[1] <= tempList[0] + 3)
//                 {
//                     isAscending = true;
//                 } else if (tempList[0] > tempList[1] && tempList[1] >= tempList[0] - 3)
//                 {
//                     isAscending = false;
//                 }
//                 else
//                 {
//                     break;
//                 }
//
//                 moreThanTwoItems = true;
//             }
//             else
//             {
//                 tempList[0] = tempList[1];
//                 tempList[1] = previousNumber;
//                 if (tempList[0] == tempList[1])
//                 {
//                     break;
//                 }
//                 if (isAscending)
//                 {
//                     if (tempList[0] > tempList[1])
//                     {
//                         break;
//                     } 
//                     if (tempList[1] > tempList[0] + 3)
//                     {
//                         break;
//                     }
//                 } 
//                 if (!isAscending)
//                 {
//                     if (tempList[0] < tempList[1])
//                     {
//                         break;
//                     }
//                     if (tempList[1] < tempList[0] - 3)
//                     {
//                         break;
//                     }
//                 } 
//             }
//             startIndx = charIndx + 1;
//         } else if (charIndx == line.Length -1 && !moreThanTwoItems)
//         {
//             int lastNumber = Convert.ToInt32(line.Substring(startIndx, charIndx - startIndx + 1));
//             tempList.Add(lastNumber);
//             if (tempList[0] == tempList[1])
//             {
//                 break;
//             }
//             if (tempList[0] < tempList[1] && tempList[1] <= tempList[0] + 3)
//             {
//                 numSafe += 1;
//             } else if (tempList[0] > tempList[1] && tempList[1] >= tempList[0] - 3)
//             {
//                 numSafe += 1;
//             }
//             else
//             {
//                 break;
//             }
//         }
//         else if (charIndx == line.Length - 1)
//         {
//             numSafe += 1;
//         }
//         charIndx += 1;
//     }
// }
//
// Console.WriteLine(numSafe);