using System;

namespace ZadanieDomowe1
{
    class Program
    {
        static void Main(string[] args)
        {
            var length1 = Length.Of(10, Units.cm);
            var length2 = Length.Of((decimal)25.12, Units.cm);

            Console.WriteLine(($"{length1}"));
            Console.WriteLine(($"{length2}"));

            var scoreOfMultiplication = length1 * 2;
            Console.WriteLine(scoreOfMultiplication);

            var sum = length1 + length2;
            Console.WriteLine(sum);

            var scoreOfDivision = length2 / 2;
            Console.WriteLine(scoreOfDivision);
        }
    }

    public enum Units
    { 
        cm = 1,
        m = 2,
        km = 3
    }

    public class Length
    {
        private readonly decimal _value;
        private readonly Units _units;

        public decimal Value
        {
            get { return _value; }
        }

        public Units Units
        { 
            get { return _units; }
        }

        private Length(decimal value, Units units)
        {
            _value = value;
            _units = units;
        }

        public override string ToString()
        {
            return $"{_value} {_units}";
        }

        public static Length Of(decimal value, Units units)
        {
            if(value < 0)
            {
                throw new Exception("Value cannot be lower than 0.");
            }
            else
            {
                return new Length(value, units);
            }
        }

        public static Length operator *(Length length, decimal factor)
        {
            return new Length(length.Value * factor, length.Units);
        }

        public static Length operator +(Length a, Length b)
        {
            return new(a.Value + b.Value, a.Units);
        }

        public static Length operator /(Length length, decimal factor)
        {
            return new Length(length.Value / factor, length.Units);
        }
    }


}
