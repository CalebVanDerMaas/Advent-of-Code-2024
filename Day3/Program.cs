// See https://aka.ms/new-console-template for more information

string filePath = "/Users/calebvandermaas/Developer/Advent-of-Code-2024/Day3/input.txt";
string[] lines = File.ReadAllLines(filePath);
// string line = lines[0];
int runningTotal = 0;

foreach (string line in lines){
    for (int charIndex = 0; charIndex < line.Length; charIndex++)
    {
        char c = line[charIndex];
        int num1 = 0;
        int num2 = 0;
        if (c == 'm' && charIndex != line.Length )
        {
            //check for key1 "mul("
            string check = line.Substring(charIndex, 4);
            if (check == "mul(")
            {
                //proceed with second check "#-###,"
                int secondIndex = charIndex + 4;
                for (int i = secondIndex; i <= charIndex + 7; i++)
                {
                    //if not a number or comma, then break
                    if (!Char.IsNumber(line[i]) && line[i] != ',')
                    {
                        charIndex = i;
                        break;
                    }

                    //if a comma and at least one number, then grab num1
                    if (line[i] == ',' && i >= charIndex + 5)
                    {
                        num1 = Convert.ToInt32(line.Substring(charIndex + 4, i - (charIndex + 4)));
                        secondIndex = i;
                        break;
                    }
                }

                if (num1 != 0)
                {
                    //proceed with second check num2
                    int thirdIndex = secondIndex + 1;
                    for (int x = thirdIndex; x <= thirdIndex + 3; x++)
                    {
                        if (!Char.IsNumber(line[x]) && line[x] != ')')
                        {
                            charIndex = x;
                            break;
                        }

                        if (line[x] == ')' && x >= thirdIndex + 1)
                        {
                            num2 = Convert.ToInt32(line.Substring(thirdIndex, x - thirdIndex));
                            // charIndex = x + 1;
                        }
                        
                        if (num2 != 0)
                        {
                            int sum = num1 * num2;
                            runningTotal += sum;
                            break;
                        }
                    }
                }
            }
        }
       
    }
}

Console.WriteLine(runningTotal);

