using System;

namespace lab_7
{
    delegate double op(double a, double b);
    class Program
    {
        static double AddFunction(double a1, double a2)
        {
            return a1 + a2;
        }

        static double MulFunction(double a1, double a2)
        {
            return a1 * a2;
        }
        static void Main(string[] args)
        {
            Func<double, double, double> Div = delegate (double a, double b)
            {
                return a / b;
            };

            Func<int, string> Format = delegate (int number)
            {
                return string.Format("{0:x}", number);
            };

            Func<string, bool> filter1 = delegate (string s)
            {
                return s.Length == 6;
            };

            Predicate<string> filter2 = delegate (string s)
            {
                return s.Length == 6;
            };

            Action<string> Print = delegate (string s)
            {
                Console.WriteLine(s.ToUpper());
            };

            op Add = AddFunction;
            op Mul = MulFunction;
            Console.WriteLine(Add.Invoke(4, 5.6));
            Console.WriteLine(Mul.Invoke(7, 8.8));
            Console.WriteLine(Format.Invoke(11));
            Console.WriteLine("Hello World!");

            Action<string> PrintLambda = (s) => Console.WriteLine(s);

            Predicate<string> FilterLambda = (a) => a.Length == 6;

            Func<double, double, double> DivLambda = (a, b) =>
             {
                 if (b != 0)
                 {
                     return a / b;
                 }
                 else
                 {
                     throw new Exception("b is zero");
                 }
             };
        }
    }
}
