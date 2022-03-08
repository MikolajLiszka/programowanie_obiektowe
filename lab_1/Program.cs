using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Person person = new Person() { FirstName = "A" };
            Console.WriteLine(person.FirstName);*/
            Money money = Money.Of("13,95", (Currency)1);
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
        private readonly string _valueStr;
        private readonly Currency _currency;

        public decimal Value
        {
            get { return _value; }
        }

        public string ValueStr
        {
            get { return _valueStr;  }
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

        private Money(string valueStr, Currency currency)
        {
            _valueStr = valueStr;
            _currency = currency;
        }

        public static Money Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }

        public static Money Of(string valueStr, Currency currency)
        {
            return valueStr == "13,95" ? null : new Money(valueStr, currency);
        }

        public static Money operator*(Money money, decimal factor)
        {
            return new Money(money.Value * factor, money.Currency);
        }
    }


}
