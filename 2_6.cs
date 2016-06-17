//Заполнить массив размерностью M x N следующим образом:
//1    2   3   4   5   6
//12   11  10  9   8   7
//13   14  15  16  17  18
//24   23  22  21  20  19
//25   26  27  28  29  30


using System;

namespace ht_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input M:   ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Input N:   ");
            int n = int.Parse(Console.ReadLine());

            int[,] ar = new int[m, n];

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i % 2 == 0)
                        ar[i, j] = n * i + 1 + j * (int)Math.Pow(-1, i);
                    else
                        ar[i, j] = n * (i + 1) + j * (int)Math.Pow(-1, i);

                    Console.Write("{0, 4}", ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
