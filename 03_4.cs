/*
4. Напишите программу, которая выведет на экран все перестановки символов в исходной строке. 
Избежать повторений при перестановках.  
Примерами перестановки строки "AAB" могут быть "AAB", "ABA" и "BAA". 
*/

using System;

namespace _03_4
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] ch;
            Console.WriteLine("Введите строку");
            ch = (Console.ReadLine()).ToCharArray();

            int position = ch.Length - 1;
            char chTmp;            
            string[] sArray = new string[ch.Length * (ch.Length - 1)];//кол-во символов на кол-во смещений одного символа по массиву
            int ctr = 0;
            
            do
            {
                
                for (int i = ch.Length - 1; i > 0; --i)
                {
                    chTmp = ch[i];
                    ch[i] = ch[i - 1];
                    ch[i - 1] = chTmp;

                    for (int j = 0; j < ch.Length; j++)
                    {
                        sArray[ctr] += ch[j];
                    }

                    ++ctr;
                }

                
            } while (--position >= 0);

            Array.Sort(sArray);

            Console.WriteLine("Возможные комбинации из символов строки без повторения");

            Console.WriteLine(sArray[0]);

            for (int j = 1; j < sArray.Length; j++)
            {
                if (sArray[j] != sArray[j - 1])
                {
                    Console.WriteLine(sArray[j]);
                }
            }
            
        }
    }
}
