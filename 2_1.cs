//***********************************************
//  Создать массив строк на 4000 элементов.
//  Заполнить его римскими числами от 1 до 3999,
//  показать на экране все элементы.
//***********************************************


using System;

namespace ht_2_1
{
    class Roman
    {
        public int size;
        public string[] s;

        public Roman()
        {
            size = 4000;
            s = new string[size];
        }

        public string Convert(int digit, int position)
        {
            string s = null;
            string[] tmp = new string[4];

            if (position == 1000)
            {
                for (int ctr = 0; ctr < digit; ++ctr)
                {
                    s += "M";
                }
                return s;
            }
            else if (position == 100)
            {
                tmp[0] = "CD";
                tmp[1] = "D";
                tmp[2] = "C";
                tmp[3] = "CM";
            }
            else if (position == 10)
            {
                tmp[0] = "XL";
                tmp[1] = "L";
                tmp[2] = "X";
                tmp[3] = "XC";
            }
            else
            {
                tmp[0] = "IV";
                tmp[1] = "V";
                tmp[2] = "I";
                tmp[3] = "IX";
            }


            for (int ctr = 0; ctr < digit; ++ctr)
            {
                if (digit == 4)
                {
                    s += tmp[0];
                    break;
                }
                else if (digit == 5)
                {
                    s += tmp[1];
                    break;
                }
                else if (digit > 5 && digit < 9)
                {
                    s += tmp[1];
                    for (int i = 0; i < digit - 5; ++i)
                        s += tmp[2];
                    break;
                }
                else if (digit == 9)
                {
                    s += tmp[3];
                    break;
                }
                else
                {
                    s += tmp[2];
                }
            }

            return s;
        }

        public void CreateNumber()
        {
            int n = 0;
            int position = 0;
            int digit = 0;
                      

            for (int i = 1; i < size; ++i)
            {
                n = i;
                position = 1000;
                do
                {
                    digit = n / position;

                    if (digit > 0)
                    {
                        s[i] += Convert(digit, position);
                    }
                    n -= digit * position;
                    position /= 10;

                } while (position > 0);
            }
        }

        public void ToConsole()
        {
            for (int i = 1; i < s.Length; i++)
            {
                Console.WriteLine(i + " = " + s[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.BufferWidth, 4000);

            Roman r = new Roman();
            r.CreateNumber();
            r.ToConsole();

        }
    }
}


