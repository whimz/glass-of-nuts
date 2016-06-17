//Заполнить массив размерностью M x N следующим образом:
//1    2   3   4   5   6
//7    8   9   10  11  12
//13   14  15  16  17  18
//19   20  21  22  23  24
//25   26  27  28  29  30


using System;

namespace ht_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input M:   ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input N:   ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] ar = new int[m, n];

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ar[i, j] = n * i + j + 1;

                    Console.Write("{0, 4}", ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
