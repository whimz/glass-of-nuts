/*
2. Написать программу, подсчитывающую количество слов, гласных и согласных букв в строке, 
введёной пользователем. Дополнительно выводить количество знаков пунктуации, цифр и др. символов. 
Пример вывода программы:

Всего символов – 38, из них:
Слов – 6
Гласных - 12
Согласных - 24
Знаков пунктуации - 2
Цифр – 0
Др. символов – 0
*/
 
 
using System;

namespace _03_2
{
    class StringCalc
    {
        char[] vowels0 = { 'а', 'е', 'и', 'й', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        char[] consonant1 = { 'б', 'в', 'г', 'д', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
        char[] puncs2 = { '.', ',', '?', ';', ':', '!', '"', '\'', '-' };
        char[] digits3 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] others4 = { ' ', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=', '/', '\\', '|', 'ъ', 'ь' };
        uint[] stat = { 0, 0, 0, 0, 0, 0};

        uint Routine(string s, char[] Check)
        {
            uint ctr = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < Check.Length; j++)
                {
                    if (s[i] == Check[j])
                    {
                        ctr++;
                    }
                }
            }
            return ctr;
        }

                  
        void Processing(string s)
        {
            for (int i = 0; i < stat.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        stat[i] = Routine(s, vowels0);
                        break;
                    case 1:
                        stat[i] = Routine(s, consonant1);
                        break;
                    case 2:
                        stat[i] = Routine(s, puncs2);
                        break;
                    case 3:
                        stat[i] = Routine(s, digits3);
                        break;                    
                    case 4:
                        stat[i] = Routine(s, others4);
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < s.Length; i++)//подсчет кол-ва слов
            {
                if (s[i] == ' ' || i == s.Length - 1)
                {
                    stat[5]++;
                }
            }

        }

        public void PrintCalc(string s)
        {
            Processing(s);

            Console.WriteLine("Всего символов = " + s.Length);

            for (int i = 0; i < stat.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("Гласные = " + stat[i]);
                        break;
                    case 1:
                        Console.WriteLine("СоГласные = " + stat[i]);
                        break;                   
                    case 2:
                        Console.WriteLine("Пунктуация = " + stat[i]);
                        break;
                    case 3:
                        Console.WriteLine("Цифры = " + stat[i]);
                        break;
                    case 4:
                        Console.WriteLine("Другие знаки = " + stat[i]);
                        break;
                    case 5:
                        Console.WriteLine("Всего слов = " + stat[i]);
                        break;
                    default:
                        break;
                }
            }
        }

    }
    class Program
    {
        static void Main()
        {
                        
            StringCalc sc = new StringCalc();
            Console.WriteLine("Введите строку");
            sc.PrintCalc(Console.ReadLine());
            
        }

       
    }
}
