//Дана последовательность: 1, 11, 21, 1211, 111221, 312211, 13112221, …
//Ввести число N.
//Показать N-ый по счёту элемент последовательности.


using System;

namespace ht_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] init = new int[1000];
            int[] result = new int[1000];
            int ctr = 1, res_ctr = 0;
            init[0] = 1;

            Console.WriteLine("Введите N");

            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("На " + n + " позиции находится число\n");
            
            do
            {
                for (int i = 0; i < init.Length - 1; ++i)
                {
                    if (init[i] == 0)
                        break;
                    if (init[i] == init[i + 1])
                    {
                        ctr++;
                    }
                    else if (i + 1 == init.Length - 1 || init[i] != init[i + 1])
                    {
                        result[res_ctr] = ctr;
                        result[++res_ctr] = init[i];
                        ++res_ctr;
                        ctr = 1;
                    }
                }

                result.CopyTo(init, 0);

                n--;
                ctr = 1;
                res_ctr = 0;
            } while (n > 0);

            
            for (int i = 0; i < result.Length; ++i)
            {
                if (result[i] == 0)
                    break;
                Console.Write(result[i]);
            }
            Console.WriteLine();


        }
    }
}
