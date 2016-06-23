/*1. Дана строка символов. Необходимо проверить, является ли эта строка палиндромом. */

using System;


namespace _03_1
{
    class Palindrome
    {

        public bool CheckPal(string str)
        {          
            string strTemp = null;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    strTemp += str[i];
                }
            }

            strTemp = strTemp.ToLower();
                     
            int ctr = strTemp.Length - 1;

            for (int i = 0; i < strTemp.Length / 2; ++i, ctr--)
            {
                if (strTemp[i] != strTemp[ctr])
                {
                    Console.WriteLine("Ваша строка ни разу не палиндром, но вы держитесь там, хорошего вам настроения:)");
                    return false;
                }
            }
            Console.WriteLine("Ваша строка-таки палиндром.");
            return true;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            
            Palindrome p = new Palindrome();
            Console.WriteLine("Введите строку");
            p.CheckPal(Console.ReadLine());           
            

        }
    }
}
