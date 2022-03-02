using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Person person = new Person() { FirstName = "A" };
            Console.WriteLine(person.FirstName);*/
            Money money = Money.Of(0, (Currency)1);
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

            private Money(decimal value, Currency currency)
            {
                _value = value;
                _currency = currency;
            }

            public static Money Of(decimal value, Currency currency)
            {
                if(value > 0)
                {
                    return new Money(value, currency);
                }
                //return value < 0 ? null : new Money(value, currency);
                else
                {
                    throw new ArgumentOutOfRangeException("Podaj wartość dodatnią");
                }
            }

            public static Money operator*(Money money, decimal value)
            {
                return Money.Of(money._value * value, money._currency);
            }
        }


    }
