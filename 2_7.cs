//Заполнить трёхмерный массив N x N x N нулями. В получившийся куб вписать шар, состоящий из единиц.
//После чего, разрезать куб на N слоёв,  и показать каждый слой в виде двумерного массива N x N на экране консоли.


using System;

namespace ht_2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину измерения куба N : ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,,] ar = new int[n, n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (Math.Sqrt(Math.Pow(i - n / 2, 2) + Math.Pow(j - n / 2, 2) + Math.Pow(k - n / 2, 2)) <=  n / 2)
                        {
                            ar[i, j, k] = 1;
                        }                 
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write(ar[i, j, k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }


        }
    }
}
