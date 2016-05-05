using System;

class Digits
{
    private string s;

    private string[][] digits;//одномерный массив одномерных массивов для прорисовки цифр
    //индексы digits[i] (0 <= i <= 9) соответствуют цифрам
    //таким образом, каждая цифра digits[i] представляет собой массив строк "рисующих" цифру
    public Digits(string st)
    {
        s = st;

        //длина массива для каждой цифры = 7 (высота цифры в символах)
        digits = new string[10][];
        for (int i = 0; i < digits.Length; ++i)
        {
            digits[i] = new string[7];
        }

        digits[0][0] = " 000 ";
        digits[0][1] = "0   0";
        digits[0][2] = "0   0";
        digits[0][3] = "0   0";
        digits[0][4] = "0   0";
        digits[0][5] = "0   0";
        digits[0][6] = " 000 ";

        digits[1][0] = "  1  ";
        digits[1][1] = " 11  ";
        digits[1][2] = "  1  ";
        digits[1][3] = "  1  ";
        digits[1][4] = "  1  ";
        digits[1][5] = "  1  ";
        digits[1][6] = "11111";

        digits[2][0] = " 222 ";
        digits[2][1] = "2   2";
        digits[2][2] = "2   2";
        digits[2][3] = "   2 ";
        digits[2][4] = " 2   ";
        digits[2][5] = "2    ";
        digits[2][6] = "22222";

        digits[3][0] = " 333 ";
        digits[3][1] = "3   3";
        digits[3][2] = "    3";
        digits[3][3] = "  33 ";
        digits[3][4] = "    3";
        digits[3][5] = "3   3";
        digits[3][6] = " 333 ";

        digits[4][0] = "   4 ";
        digits[4][1] = "  44 ";
        digits[4][2] = " 4 4 ";
        digits[4][3] = "4  4 ";
        digits[4][4] = "44444";
        digits[4][5] = "   4 ";
        digits[4][6] = "   4 ";

        digits[5][0] = "55555";
        digits[5][1] = "5    ";
        digits[5][2] = "5    ";
        digits[5][3] = "5555 ";
        digits[5][4] = "    5";
        digits[5][5] = "    5";
        digits[5][6] = "5555 ";

        digits[6][0] = " 666 ";
        digits[6][1] = "6   6";
        digits[6][2] = "6    ";
        digits[6][3] = "6666 ";
        digits[6][4] = "6   6";
        digits[6][5] = "6   6";
        digits[6][6] = " 666 ";

        digits[7][0] = "77777";
        digits[7][1] = "    7";
        digits[7][2] = "   7 ";
        digits[7][3] = "  7  ";
        digits[7][4] = " 7   ";
        digits[7][5] = "7    ";
        digits[7][6] = "7    ";

        digits[8][0] = " 888 ";
        digits[8][1] = "8   8";
        digits[8][2] = "8   8";
        digits[8][3] = " 888 ";
        digits[8][4] = "8   8";
        digits[8][5] = "8   8";
        digits[8][6] = " 888 ";

        digits[9][0] = " 999 ";
        digits[9][1] = "9   9";
        digits[9][2] = "9   9";
        digits[9][3] = " 9999";
        digits[9][4] = "    9";
        digits[9][5] = "9   9";
        digits[9][6] = " 999 ";

    }

    public void PrintNumber()
    {
        if (s == null || s == "")
        {
            Console.WriteLine("Строка пуста.");
        }
        else
        {   
            //все цифры, которые ввел юзер, прорисовываем построчно
            for (int j = 0; j < digits[j].Length; ++j)   
            {
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] >= 48 && s[i] <= 57) //если символ - цифра
                    {
                        // (int)Char.GetNumericValue(s[i]) говорит какую цифру нужно выбрать из массива digits[i] для отрисовки
                        Console.Write(digits[(int)Char.GetNumericValue(s[i])][j] + " ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine();
            }
        }
    }

}

namespace hometask1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число:  ");
            Digits st = new Digits(Console.ReadLine());
            st.PrintNumber();
        }
    }
}
