using System;

namespace lab_2_na_zajeciach
{
    abstract class AbstractMessage
    {
        public string Content { get; init; }
        public abstract bool Send();
    }

    public interface IFly
    {
        void Fly();
    }

    public interface ISwim
    {
        void Swim();
    }

    class Duck : IFly, ISwim
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    class Hydroplane : IFly, ISwim
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    class EmailMessage : AbstractMessage
    {
        public string To { get; init; }
        public string From { get; init; }
        public string Subject { get; init; }
        public override bool Send()
        {
            Console.WriteLine($"Sending email from: {From} to {To} with content {Content}");
            return true;
        }
    }

    class SmsMessage : AbstractMessage
    {
        public string ToPhone { get; init; }
        public string FromPhone { get; init; }
        public override bool Send()
        {
            Console.WriteLine($"Sending sms from: {FromPhone} to {ToPhone} with content {Content}");
            return true;
        }
    }

    class MessengerMessage : AbstractMessage
    {
        public override bool Send()
        {
            Console.WriteLine($"Sending messenger message with content{Content}");
            return true;
        }
    }

    class User
    {
        public string Name { get; init; }
        public AbstractMessage LastMessage { get; init; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string messageType = "SMS";
            switch (messageType)
            {
                case "SMS":
                    Console.WriteLine("Sending SMS");
                    break;
                case "email":
                    Console.WriteLine("Sending SMS");
                    break;
            }
            User[] users =
            {
                new User() {Name="Karol", LastMessage = new SmsMessage(){Content="Hello", FromPhone="0949049" , ToPhone="55476756"}
                },
                new User() {Name="Karol", LastMessage = new EmailMessage(){Content="Hello", From="jdjdjd" , To="jdjdjdjdj"}
                }
            };


            int EmailCounter = 0;
            foreach (var user in users)
            {
                user.LastMessage.Send();
                if (user.LastMessage is EmailMessage)
                {
                    EmailCounter++;
                }
                if (user.LastMessage is SmsMessage)
                {
                    SmsMessage sms = (SmsMessage)user.LastMessage;
                    Console.WriteLine(sms.ToPhone);
                }
            }
            Console.WriteLine($"Wysłano wiadomości email: {EmailCounter}");

            IFly[] flyingObject =
            {
                new Duck(),
                new Hydroplane()
            };
        }
    }
    interface IAggragate
    {
        IIterator createIterator();
    }

    interface IIterator
    {
        bool HasNext();
        int GetNext();

    }

    class SimpleAggregate : IAggragate
    {
        public int a = 5;
        public int b = 9;
        public int c = 6;
        public IIterator createIterator()
        {
            return new SimpleAggregateIterator(this);
        }
    }

    class SimpleAggregateIterator : IIterator
    {
        private SimpleAggregate _aggregate;
        private int count = 0;

        public SimpleAggregateIterator(SimpleAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public int GetNext()
        {
            switch (++count)
            {
                case 1:
                    return _aggregate.a;
                case 2:
                    return _aggregate.b;
                case 3:
                    return _aggregate.c;
            }
        }

        public bool HasNext()
        {
            throw new NotImplementedException();
        }
    }
}
