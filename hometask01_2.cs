using System;


namespace hometask01_02
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите количество ярусов:   ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите высоту яруса:   ");
            int h = int.Parse(Console.ReadLine());
         
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < n; ++i) 
            {
                for (int j = 0; j < h; ++j)
                {
                    for (int k = 0; k < 2 * (h + n); ++k)
                    {
                        if (k < h + n - j - i - 2 || k > h + n + j + i - 2)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }
                    Console.WriteLine();
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < h; ++i)
            {
                for (int k = 0; k < 2 * (h + n); ++k)
                {
                    if (k < h + n - 3 || k > h + n - 3)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("###");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
