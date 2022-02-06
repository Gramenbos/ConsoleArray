using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListMaster
{
    public class ArrayMaster
    {
        public int[,] CreateTwoDimentionalArray(int rows, int colums)
        {
            int[,] array = new int[rows, colums];
            return array;
        }
        public void FillTwoDimentionalArray(int[,] array, int minNumber, int maxNumber)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(minNumber, maxNumber + 1);
                }
            }
        }
        public void PrintTwoDimentionalArray(int[,] array)
        {
            Console.Write("\t");
            for (int j = 0; j < array.GetLength(1); j++) Console.Write($"{j}\t");
            Console.WriteLine();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write($"{i}\t");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public int[,] MultiplicationArrays(int[,] firstArray, int[,] secondArray)
        {
            int firstArrayRows = firstArray.GetLength(0);
            int firstArrayColumns = firstArray.GetLength(1);
            int secondArrayRows = secondArray.GetLength(0);
            int secondArrayColumns = secondArray.GetLength(1);
            if (firstArrayColumns != secondArrayRows) return new int[0, 0];

            int[,] resultArray = new int[firstArrayRows, secondArrayColumns];

            for (int i = 0; i < resultArray.GetLength(0); i++)
            {
                for (int j = 0; j < resultArray.GetLength(1); j++)
                {
                    for (int k = 0; k < firstArray.GetLength(1); k++)
                    {
                        resultArray[i, j] += firstArray[i, k] * secondArray[k, j];
                    }
                }
            }
            return resultArray;
        }

        public (int, int) FindIndexOfMinimumNumber(int[,] array)
        {
            int minimumNumber = array[0, 0];
            int minRowIndex = 0;
            int minColumnIndex = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < minimumNumber)
                    {
                        minimumNumber = array[i, j];
                        minRowIndex = i;
                        minColumnIndex = j;
                    }
                }
            }
            return (minRowIndex, minColumnIndex);
        }
        public int[,] DeleteRowAndColumnInArray(int[,] array)
        {
            int[,] resultArray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
            (int rowIndex, int columnIndex) = FindIndexOfMinimumNumber(array);
            int ki = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (i == rowIndex) continue;
                int kj = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == columnIndex) continue;
                    resultArray[ki, kj] = array[i, j];
                    kj++;
                }
                ki++;
            }
            return resultArray;
        }
        public void FillTriangle(int[,] triangle)
        {
            int row = triangle.GetLength(0);
            for (int i = 0; i < row; i++)
            {
                triangle[i, 0] = 1;
                triangle[i, i] = 1;
            }

            for (int i = 2; i < row; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    triangle[i, j] =
                        triangle[i - 1, j - 1] + triangle[i - 1, j];
                }
            }
        }

        const int cellWidth = 3;
        public void PrintTriangle(int[,] triangle)
        {
            int row = triangle.GetLength(0);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (triangle[i, j] != 0)
                        Console.Write($"{triangle[i, j],cellWidth}");
                }
                Console.WriteLine();
            }
        }
        public void PrintGoodTriangle(int[,] triangle)
        {
            int row = triangle.GetLength(0);
            int col = cellWidth * row;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.SetCursorPosition(col, i + 1);
                    if (triangle[i, j] != 0) Console.Write($"{triangle[i, j],cellWidth}");
                    col += cellWidth * 2;
                }

                col = cellWidth * row - cellWidth * (i + 1);

                Console.WriteLine();
            }
        }
        public void Magic(int[,] triangle)
        {
            int row = triangle.GetLength(0);
            int col = row;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.SetCursorPosition(col, i + 1);
                    if (triangle[i, j] % 2 != 0) Console.WriteLine("*");
                    col += 2;
                }
                col = row - (i + 1);
                Console.WriteLine();
            }
        }
        public void SpiralFillArray(int[,] array)
        {
            int counter = 1;
            int currentRowIndex = 0;
            int startRow = 0;
            int endRow = array.GetLength(1);
            int currentColumnIndex = array.GetLength(1) - 1;
            int endColumn = array.GetLength(0);
            int direction = 1;

            //while (counter < array.GetLength(0) * array.GetLength(1))
            //{
            FillRow(array, currentRowIndex, startRow, endRow, direction);
            startRow++;
            FillColumn(array, currentColumnIndex, startRow, endColumn, direction);
            direction *= -1;
            currentRowIndex += array.GetLength(0) - 1;
            FillRow(array, currentRowIndex, endRow - 1, startRow - 2, direction);
            currentColumnIndex += array.GetLength(1) - 1;
            FillColumn(array, currentColumnIndex, endColumn, startRow - 2, direction);
            // }

            void FillRow(int[,] array, int index, int start, int end, int direction)
            {
                if (direction > 0)
                {
                    for (int i = start; i < end; i += direction)
                    {
                        array[index, i] = counter++;
                    }
                }
                else
                {
                    for (int i = start; i > end; i += direction)
                    {
                        array[index, i] = counter++;
                    }
                }
            }
            void FillColumn(int[,] array, int index, int start, int end, int direction)
            {
                if (direction > 0)
                {
                    for (int j = start; j < end; j += direction)
                    {
                        array[j, index] = counter++;
                    }
                }
                else
                {
                    for (int j = start; j > end; j += direction)
                    {
                        array[j, index] = counter++;
                    }
                }
            }

        }
    }
}

