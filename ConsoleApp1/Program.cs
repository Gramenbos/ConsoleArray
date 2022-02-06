using System;
using System.Collections.Generic;
using System.Linq;
using ListMaster;

namespace ConsoleArray3
{
    public class Program3
    {
        public static void Main3(string[] args)
        {
            ArrayMaster am = new();
            // 64. Показать треугольник Паскаля - Сделать вывод в виде равнобедренного треугольника

            int row = 30;           //Количество строк в треугольнике
            int[,] triangle = new int[row, row];
            Console.ReadLine();
            am.FillTriangle(triangle);
            am.PrintGoodTriangle(triangle);   //Отображение треугольника Паскаля
            //am.Magic(triangle);                 //Печать треугольника Серпинского
        }
    }
}