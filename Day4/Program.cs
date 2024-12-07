// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "/Users/calebvandermaas/Developer/Advent-of-Code-2024/Day4/input.txt";
        string[] lines = File.ReadAllLines(filePath);

        int numXMAS = 0;

        MatrixOperator matrixOperator = new MatrixOperator();
        char[,] matrix = matrixOperator.InitMatrix(lines);

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                char value = matrix[row, col];
                if (value == 'X')
                {
                    numXMAS += matrixOperator.XMASLocator(matrix, row, col);
                }
            }
        }

        Console.WriteLine(numXMAS);
    }
}

public class MatrixOperator
{
    public char[,] InitMatrix(string[] lines)
    {
        int lineLength = lines[0].Length;
        int numRows = lines.Length;
        char[,] matrix = new char[numRows, lineLength];
        //init matrix
        for (int r=0; r < numRows; r++)
        {
            string line = lines[r];
            for (int l=0; l < lineLength; l++)
            {
                char c = line[l];
                matrix[r, l] = c; 
            }
        }
        return matrix;
    }

    public int XMASLocator(char[,] matrix, int row, int column)
    {
        int numLocations = 0;
        //search up
        if (row >= 3 && matrix[row-1, column] == 'M' && matrix[row-2, column] == 'A' && matrix[row-3, column] == 'S')
        {
            numLocations++;
        }
        //search up-right
        if (row >= 3 && column <= matrix.GetLength(1) - 4 && matrix[row - 1, column + 1] == 'M' && matrix[row - 2, column + 2] == 'A' &&
            matrix[row - 3, column + 3] == 'S')
        {
            numLocations++;
        }
        //search right 
        if (column <= matrix.GetLength(1) - 4 && matrix[row, column + 1] == 'M' && matrix[row, column + 2] == 'A' &&
            matrix[row, column + 3] == 'S')
        {
            numLocations++;
        }
        //search right-down
        if (column <= matrix.GetLength(1) - 4 && row <= matrix.GetLength(0) - 4 && matrix[row + 1, column + 1] == 'M' && matrix[row + 2, column + 2] == 'A' && matrix[row + 3, column + 3] == 'S')
        {
            numLocations++;
        }
        //search down
        if (row <= matrix.GetLength(0) - 4 && matrix[row + 1, column] == 'M' && matrix[row + 2, column] == 'A' &&
            matrix[row + 3, column] == 'S')
        {
            numLocations++;
        }
        //search down-left
        if (row <= matrix.GetLength(0) - 4 && column >= 3 && matrix[row + 1, column - 1] == 'M' &&
            matrix[row + 2, column - 2] == 'A' &&
            matrix[row + 3, column - 3] == 'S')
        {
            numLocations++;
        }
        //search left
        if (column >= 3 && matrix[row, column - 1] == 'M' &&
            matrix[row, column - 2] == 'A' &&
            matrix[row, column - 3] == 'S')
        {
            numLocations++;
        }
        //search up-left
        if (column >= 3 && row >= 3 && matrix[row - 1, column - 1] == 'M' &&
            matrix[row - 2, column - 2] == 'A' &&
            matrix[row - 3, column - 3] == 'S')
        {
            numLocations++;
        }

        return numLocations;
    }
    
}

