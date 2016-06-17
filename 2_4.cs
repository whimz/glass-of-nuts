//Заполнить двумерный массив размерностью M x N по спирали.
//Число 1 ставится в центр массива,
//а затем массив заполняется по спирали против часовой стрелки значениями по возрастанию.

using System;


namespace ht_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива N. (N = 2k+1)");
            int size = Convert.ToInt32(Console.ReadLine());
            int y = size / 2;
            int x = size / 2;
            int d = -1;
            int ctr = 1;
            int[,] ar = new int[size, size];
            ar[x, y] = ctr;
            for (int i = 0; i < size;)
            {
                for (int j = i; j >= 0; --j)
                {
                    x += d;
                    if (x < 0)
                        break;
                    ar[x, y] = ++ctr;
                }

                for (int j = i; j >= 0; --j)
                {
                    if (x < 0)
                        break;
                    y += d;
                    ar[x, y] = ++ctr;
                }
                
                ++i;
                d *= -1;
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0, 4}", ar[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
