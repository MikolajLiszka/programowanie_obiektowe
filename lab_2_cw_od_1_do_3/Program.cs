using System;

namespace lab_2_cwiczenie_1
{
    public abstract class Vehicle
    {
        public double Weight { get; init; }
        public int MaxSpeed { get; init; }
        protected int _mileage;
        public int Mileage
        {
            get { return _mileage; }
        }
        public abstract decimal Drive(int distance);
        public override string ToString()
        {
            return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
        }
    }

    public class Scooter : Vehicle
    {
        public bool isDriver { get; set; }
        public override decimal Drive(int distance)
        {
            if (isDriver)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
        public override string ToString()
        {
            return $"Scooter{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}"; ;
        }

    }

    public class ElectricScooter: Scooter
    {
        public int BatteriesLevel { get; init; }
        public int MaxRange { get; init; }

        public void ChargeBatteries()
        {
            if (BatteriesLevel < 100)
            {
                for (int i = BatteriesLevel; i <= 101; i++)
                {
                    Console.WriteLine("Bateria Naładowana");
                }
            }
            else
            {
                Console.WriteLine("Bateria w pełni naładowana");
            }
        }
        public override decimal Drive(int distance)
        {
            if (BatteriesLevel > 0)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
    }

    public class KickScooter : Scooter
    {
        public override decimal Drive(int distance)
        {
            if (isDriver)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles =
            {
                new Scooter(){Weight = 15, MaxSpeed = 35, isDriver = true},
                new ElectricScooter(){Weight = 88, MaxSpeed = 80, isDriver = true, BatteriesLevel = 88},
                new ElectricScooter(){Weight = 88, MaxSpeed = 80, isDriver = true, BatteriesLevel = 88},
                new ElectricScooter(){Weight = 88, MaxSpeed = 80, isDriver = true, BatteriesLevel = 88},
                new ElectricScooter(){Weight = 88, MaxSpeed = 80, isDriver = true, BatteriesLevel = 88},
                new ElectricScooter(){Weight = 88, MaxSpeed = 80, isDriver = true, BatteriesLevel = 88},
                new ElectricScooter(){Weight = 88, MaxSpeed = 80, isDriver = true, BatteriesLevel = 33},
                new ElectricScooter(){Weight = 88, MaxSpeed = 80, isDriver = true, BatteriesLevel = 88},
                new ElectricScooter(){Weight = 88, MaxSpeed = 80, isDriver = true, BatteriesLevel = 88},
                new ElectricScooter(){Weight = 88, MaxSpeed = 80, isDriver = true, BatteriesLevel = 0},
                new KickScooter(){Weight = 88, MaxSpeed = 80, isDriver = true}
            };

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine("Time for distance: " + vehicle.Drive(100));
            }

            int scooterCounter = 0;
            int electricScooterCounter = 0;
            int kickScooterCounter = 0;

            foreach (var vehicle in vehicles)
            {
                if (vehicle is Scooter)
                {
                    scooterCounter++;
                    Scooter scooter = (Scooter)vehicle;
                    Console.WriteLine("Czy skuter ma kierowcę: " + scooter.isDriver);
                }
                if (vehicle is ElectricScooter)
                {
                    electricScooterCounter++;
                }
                if (vehicle is Scooter)
                {
                    kickScooterCounter++;
                }
            }
            Console.WriteLine($"Liczba skuterów: {scooterCounter}, liczba samochodów: {electricScooterCounter}");
        }
    }
}
