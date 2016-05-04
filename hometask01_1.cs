using System;

class Stairs
{
    private int stairsNumber;

    public Stairs()
    {
        stairsNumber = 0;
    }

    public void SetStairs(int n)
    {
        stairsNumber = n;
    }

    public void DrawStairs() 
    {
        if (stairsNumber <= 0)
        {
            Console.WriteLine("Число ступенек не может быть <= 0 \n");
        }
        else
        {
            int i = 1;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("***");
                for (int j = 0; j < i; ++j)
                    Console.Write("  ");
                Console.WriteLine("*");
                for (int j = 0; j < i; ++j)
                    Console.Write("  ");

            } while (stairsNumber - i++ >= 0);

            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}

namespace hometask01
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;

            Stairs stairs = new Stairs();


            Console.Clear();
            Console.Write("Введите число ступенек: ");
            s = Console.ReadLine();
            stairs.SetStairs(int.Parse(s));
            stairs.DrawStairs();
        }
    }
}
