using System;
using System.Collections.Generic;
using System.Linq;
using ListMaster;

namespace ConsoleArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArrayMaster am = new();
            Console.WriteLine("Enter number of test:\n" +
                  "61 - Multyplication arrays\n" +
                  "62 - Delete row and column with min number\n" +
                  "63 - Serpinsky triangle\n" +
                  "64 - Pascal triangle\n" +
                  "65 - Spiral fill array\n");
            try
            {
                int testNumber = Convert.ToInt32(Console.ReadLine());
                switch (testNumber)
                {
                    case 61:       // Решение задания 61 - найти произведение двух матриц

                        var firstArray = am.CreateTwoDimentionalArray(3, 4);
                        am.FillTwoDimentionalArray(firstArray, 0, 3);
                        am.PrintTwoDimentionalArray(firstArray);
                        Console.WriteLine();
                        var secondArray = am.CreateTwoDimentionalArray(4, 5);
                        am.FillTwoDimentionalArray(secondArray, 0, 9);
                        am.PrintTwoDimentionalArray(secondArray);
                        var resultArray = am.MultiplicationArrays(firstArray, secondArray);
                        am.PrintTwoDimentionalArray(resultArray);
                        break;

                    case 62:
                        // 62. В двумерном массиве целых чисел. Удалить строку и столбец,
                        // на пересечении которых расположен наименьший элемент.

                        var workArray = am.CreateTwoDimentionalArray(6, 7);
                        am.FillTwoDimentionalArray(workArray, 0, 10);
                        am.PrintTwoDimentionalArray(workArray);
                        (int minRowIndex, int minColumnIndex) = am.FindIndexOfMinimumNumber(workArray);
                        Console.WriteLine($"{minRowIndex}, {minColumnIndex}");
                        var resultArray2 = am.DeleteRowAndColumnInArray(workArray);
                        am.PrintTwoDimentionalArray(resultArray2);
                        break;

                    case 63:
                        // 63. Печать треугольника Серпинского

                        int row = 120;           //Количество строк в треугольнике
                        int[,] triangle = new int[row, row];
                        am.FillTriangle(triangle);
                        am.Magic(triangle);
                        break;

                    case 64:
                        // 64. Показать треугольник Паскаля - Сделать вывод в виде равнобедренного треугольника

                        int row2 = 20;           //Количество строк в треугольнике
                        int[,] triangle2 = new int[row2, row2];
                        am.FillTriangle(triangle2);
                        am.PrintGoodTriangle(triangle2);
                        break;

                    case 65:
                        // 65.Спирально заполнить двумерный массив:

                        var workArray2 = am.CreateTwoDimentionalArray(6, 7);
                        am.SpiralFillArray(workArray2);
                        am.PrintTwoDimentionalArray(workArray2);


                        break;

                    default:
                        Console.WriteLine("Input error");
                        Environment.Exit(1);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input error");
                Environment.Exit(1);
            }
        }
    }
}
