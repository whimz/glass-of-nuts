/*
3. Написать программу, проверяющую, является ли одна строка анаграммой для другой строки 
(строка может состоять из нескольких слов и символов пунктуации). 
Пробелы и пунктуация, разница в больших и маленьких буквах должны игнорироваться. 
Обе строки вводятся с клавиатуры.

Пример анаграммы:
Аз есмь строка, живу я, мерой остр. 
За семь морей ростка я вижу рост!
*/

using System;

namespace _03_3
{
    class Anagramm
    {
        char[] alpabet = { 'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х',
            'ъ', 'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж',
            'э', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю' };
        
        
        public bool CheckAnagram(string s1, string s2)
        {
            string sTemp1 = null;
            string sTemp2 = null;

            s1 = s1.ToLower();
            s2 = s2.ToLower();

            for (int i = 0; i < alpabet.Length; i++)
            {
                for (int j = 0; j < s1.Length; j++)
                {
                    if (alpabet[i] == s1[j])
                    {
                        sTemp1 += s1[j];
                    }
                }

                for (int j = 0; j < s2.Length; j++)
                {
                    if (alpabet[i] == s2[j])
                    {
                        sTemp2 += s2[j];
                    }
                }
            }

            Console.WriteLine(sTemp1 + ' ' + sTemp2);
            if (sTemp1.Length != sTemp2.Length)
            {
                Console.WriteLine("Ваши строки ни разу не анаграммы, но вы держитесь там, хорошего вам настроения:)");
                return false;
            }                   

            
            for (int i = 0; i < sTemp1.Length; i++)
            {
                if (sTemp1[i] != sTemp2[i])
                {
                    Console.WriteLine("Ваши строки ни разу не анаграммы, но вы держитесь там, хорошего вам настроения:)");
                    return false;
                }
            }


            Console.WriteLine("Ваши строки-таки анаграммы:)");
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Anagramm a = new Anagramm();

            Console.WriteLine("Введите строку1");
            string s1 = Console.ReadLine();
            Console.WriteLine("Введите строку2");
            string s2 = Console.ReadLine();

            Console.WriteLine("s1 = " + s1 + '\n' + "s2 = " + s2);

            a.CheckAnagram(s1, s2);


        }
    }
}
