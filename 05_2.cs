using System;

namespace _05_2_fraction
{
    class Fraction
    {
        private int numerator;//числитель
        private int denominator;//знаменатель
        
        public Fraction() { }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("Знаменатель не может быть равен 0");
            }
            else
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
        } 

        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value != 0)
                {
                    denominator = value;
                }
                else
                {
                    throw new DivideByZeroException("Знаменатель не может быть равен 0!");
                }
            }
        }
        
        //Наибольший общий делитель (туповатый)
        public static Fraction GreatestCommonDivisor(Fraction f)
        {
            int divisor = 2;
            do
            {
                if ((f.numerator % divisor == 0) && (f.denominator % divisor == 0))
                {
                    f.numerator /= divisor;
                    f.denominator /= divisor;
                }
                else
                {
                    ++divisor;
                    continue;
                }
                
            } while (divisor <= f.numerator || divisor <= f.denominator);
            return f;
        }

        //сокращение дроби
        public static Fraction FractionReduction(Fraction f)
        {
            if (f.denominator == f.numerator)
            {
                f.denominator = f.numerator = 1;
            }
            else
            {
                return GreatestCommonDivisor(f);
            }
            return f;
        }

        public static Fraction operator + (Fraction lValue, Fraction rValue)
        {
            Fraction f = new Fraction();
            if (lValue.Denominator == rValue.Denominator)
            {
                f.Numerator = lValue.Numerator + rValue.Numerator;
                f.Denominator = lValue.Denominator;
            }
            else
            {
                f.Numerator = lValue.Numerator * rValue.Denominator + rValue.Numerator * lValue.Denominator;
                f.Denominator = lValue.Denominator * rValue.Denominator;
            }
            return FractionReduction(f);
        }

        // перегрузка дробь + дабл
        public static Fraction operator + (Fraction lValue, double rValue)
        {
            Fraction f = new Fraction();
            string s = rValue.ToString();
            string sIntPart = null; // строка для целой части дабла
            string sFractPart = null;// ----------дробной----------            

            if (rValue == 0)
            {
                return f = lValue;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')
                {                   
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        sFractPart += s[j];
                    }
                    break;
                }
                else
                {
                    sIntPart += s[i];
                }
            }
                        
            if (sFractPart != null)
            {
                f.denominator = Convert.ToInt32(Math.Pow(10.0, Convert.ToDouble(sFractPart.Length)));

                if (sIntPart != null)
                {
                    f.numerator = (Convert.ToInt32(sIntPart)) * f.denominator + Convert.ToInt32(sFractPart);
                }
                else
                {
                    f.numerator = Convert.ToInt32(sFractPart);
                }
            }
            else if (sIntPart != null)
            {
                f.numerator = f.denominator = Convert.ToInt32(sIntPart);
            }
            else
            {
                return f = lValue;
            }

            f += lValue;
            
            return GreatestCommonDivisor(f);
        }

        //унарный "-"
        public static Fraction operator - (Fraction f)
        {
            return new Fraction(f.numerator * (-1), f.denominator);           
        }

        // a - b определяем через перегруженный унарный "-"
        public static Fraction operator - (Fraction lValue, Fraction rValue)
        {
            Fraction f = new Fraction();
            f = lValue + (-rValue);
            return FractionReduction(f);
        }

        public static Fraction operator * (Fraction lValue, Fraction rValue)
        {
            return FractionReduction(new Fraction(lValue.numerator * rValue.numerator, lValue.denominator * rValue.denominator));
        }

        public static Fraction operator * (int lValue, Fraction rValue)
        {
            return FractionReduction(new Fraction(lValue * rValue.numerator, rValue.denominator));
        }

        public static Fraction operator * (Fraction lValue, int rValue)
        {
            return FractionReduction(new Fraction(lValue.numerator * rValue, lValue.denominator)); 
        }

        public static Fraction operator / (Fraction lValue, Fraction rValue)
        {
            return FractionReduction(new Fraction(lValue.numerator * rValue.denominator, lValue.denominator * rValue.numerator));
        }

        public static Boolean operator true(Fraction f)
        {
            return f.numerator < f.denominator;
        }

        public static Boolean operator false(Fraction f)
        {
            return f.numerator > f.denominator;
        }

        public static Boolean operator == (Fraction lValue, Fraction rValue)
        {
            bool result = false;

            if (ReferenceEquals(lValue, rValue))
            {
                return true;
            }
            else if ((Object)lValue != null)
            {
                result = lValue.Equals(rValue);
            }

            return result;
        }

        public static Boolean operator != (Fraction lValue, Fraction rValue)
        {
            return !(lValue == rValue);
        }

        public static Boolean operator < (Fraction lValue, Fraction rValue)
        {
            return ((Convert.ToDouble(lValue.numerator) / Convert.ToDouble(lValue.denominator)) < 
                (Convert.ToDouble(rValue.numerator)) / Convert.ToDouble(rValue.denominator));
        }

        public static Boolean operator > (Fraction lValue, Fraction rValue)
        {
            return ((Convert.ToDouble((FractionReduction(lValue).numerator)) / Convert.ToDouble((FractionReduction(lValue).denominator))) > 
                (Convert.ToDouble((FractionReduction(rValue).numerator)) / Convert.ToDouble((FractionReduction(rValue).denominator))));
        }

        public override Boolean Equals(Object rValue)
        {
            bool result = false;

            if (rValue != null)
            {
                Fraction f = rValue as Fraction;

                if (f != null)
                {
                    if (numerator == f.numerator && denominator == f.denominator)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public override Int32 GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override String ToString()
        {
            return String.Format("{0}/{1}", numerator, denominator);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fraction f = new Fraction(3, 4);
            int a = 10;

            Fraction f1 = f * a;
            Console.WriteLine(f1);

            Fraction f2 = a * f;
            Console.WriteLine(f2);

            double d = 1.5;
            Fraction f3 = f + d;

            Console.WriteLine(f3);

        }
    }
}
