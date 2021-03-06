using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var money1 = Money.Of((decimal)13.12, Currency.USD);
            var money2 = Money.Of((decimal)18.34, Currency.USD);

            Console.WriteLine(($"{money1}"));
            Console.WriteLine(($"{money2}"));

            Console.WriteLine(money1 > money2);
            Console.WriteLine(money1 < money2);

            Console.WriteLine(money1.Percent(20));
            Console.WriteLine(money2.ToCurrency((decimal)4.1, Currency.PLN));

        }
    }


    public class Person
    {
        private string _firstName;

        private Person(string firstName)
        {
            _firstName = firstName;
        }

        public static Person of(string firstName)
        {
            if (firstName.Length <= 2)
            {
                return new Person(firstName);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Imię jest zbyt krótkie");

            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value.Length >= 2)
                {
                    _firstName = value;
                }
            }
        }
    }

        public enum Currency
        {
            PLN = 1,
            USD = 2,
            EUR = 3
        }

        public class Money
        { 
 
            private readonly decimal _value;
            private readonly Currency _currency;

            public decimal Value
            {
                get { return _value; }
            }

            public Currency Currency
            {
                get { return _currency; }
            }

            private Money(decimal value, Currency currency)
            {
                _value = value;
                _currency = currency;
            }

            public override string ToString()
            {
                return $"{_value} {_currency}";
            }



            public static Money Of(decimal value, Currency currency)
            {
                if (value < 0)
                {
                    throw new Exception("Value should be biggerthan 0!");
                }

                return new Money(value, currency);
            }

            public static Money ParseValue(string stringValue, Currency currency)
            {
                decimal value = decimal.Parse(stringValue);
                return new Money(value, currency);
            }

            public static Money operator *(Money money, decimal factor)
            {
                return new Money(money.Value * factor, money.Currency);
            }

            public static Money operator +(Money a, Money b)
            {
                return new(a.Value + b.Value, a.Currency);
            }

            public static bool operator <(Money a, Money b)
            {
                return a.Value < b.Value;
            }

            public static bool operator >(Money a, Money b)
            {
                return a.Value > b.Value;
            }

            public static explicit operator float(Money money)
            {
                return (float)money.Value;
            }

        }

        public static class MoneyExtension
        {
            public static Money Percent(this Money money, decimal percent)
            {
                return Money.Of((money.Value * percent) / 100m, money.Currency) ?? throw new ArgumentException();
            }

            public static Money ToCurrency(this Money money, decimal factor, Currency currency)
            {
                 return Money.Of(money.Value * factor, currency) ?? throw new ArgumentException();
            }
        }


        public class Tank
        {
            public readonly int Capacity;
            private int _level;

            public Tank(int capacity)
            {
                Capacity = capacity;
            }

            public override string ToString()
            {
                return $"Tank: Capacity = {Capacity}, Level = {_level}";
            }

            public int Level
            {
                get
                {
                    return _level;
                }

                private set
                {
                    if (value < 0 || value > Capacity)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    _level = value;
                }
            }

            public bool consume(int amount)
            {
                if (amount < 0)
                {
                    return false;
                }
                if (_level + amount < Capacity)
                {
                    return false;
                }
                Level = _level - amount;
                return true;

            }

            public void refuel(int amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentException("Argument cant be non positive!");
                }
                if (_level + amount > Capacity)
                {
                    throw new ArgumentException("Argument is too large!");
                }
                _level += amount;
            }
            

        }
    }


