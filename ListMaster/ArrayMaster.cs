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
            int numberRectangle = 0;
            int M = array.GetLength(0);
            int N = array.GetLength(1);
            int i = 0;
            int j = 0;
            int number = 1;

            while (number <= M * N)
            {
                array[i, j] = number;

                if (i == numberRectangle && j < N - numberRectangle - 1) j++;
                else if (j == N - numberRectangle - 1 && i < M - numberRectangle - 1) i++;
                else if (i == M - numberRectangle - 1 && j > numberRectangle) j--;
                else i--;

                if (i == numberRectangle + 1 && j == numberRectangle && numberRectangle != N - numberRectangle - 1)
                // Переходим к следующему прямоугольнику если достигли в текущем второй строки, первого столбца и мы не чертим последний столбец 
                {
                    numberRectangle++;
                }
                number++;
            }
        }
    }
}

