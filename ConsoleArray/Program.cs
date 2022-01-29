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
            // Решение задания 61 - найти произведение двух матриц
            var firstArray = am.CreateTwoDimentionalArray(3, 4);
            am.FillTwoDimentionalArray(firstArray, 0, 3);
            am.PrintTwoDimentionalArray(firstArray);
            Console.WriteLine();
            var secondArray = am.CreateTwoDimentionalArray(4, 5);
            am.FillTwoDimentionalArray(secondArray, 0, 9);
            am.PrintTwoDimentionalArray(secondArray);
            var resultArray = am.MultiplicationArrays(firstArray, secondArray);
            am.PrintTwoDimentionalArray(resultArray);
        }
    }
}
