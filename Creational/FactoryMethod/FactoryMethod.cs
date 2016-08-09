namespace FactoryMethod.GsmConglomerate
{
    using System;

    public class EyePhone : Gsm
    {
        public EyePhone()
        {
            this.Name = "EyePhone";
        }

        public override void Start()
        {
            Console.WriteLine("Booting up...eyePhone");
            Console.WriteLine("Welcome to your eyePhone");
        }
    }

    public class SamunGalaxy : Gsm
    {
        public SamunGalaxy()
        {
            this.Name = "Samun Galaxy";
        }

        public override void Start()
        {
            Console.WriteLine("Starting up the Galaxy...");
            Console.WriteLine("Thrusters on full!");
        }
    }

    public class PearComputers : Manufacturer
    {
        public override Gsm ManufactureGsm()
        {
            var phone = new EyePhone
            {
                BatteryLife = 1000,
                Height = 200,
                Weight = 100,
                Width = 50
            };

            return phone;
        }
    }

    public class SamunComputers : Manufacturer
    {
        public override Gsm ManufactureGsm()
        {
            var phone = new SamunGalaxy
            {
                BatteryLife = 999,
                Height = 199,
                Weight = 99,
                Width = 49
            };

            return phone;
        }
    }

    public abstract class Gsm
    {
        public int BatteryLife { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string Name { get; set; }

        public abstract void Start();
    }

    public abstract class Manufacturer
    {
        public abstract Gsm ManufactureGsm();
    }

    public interface IStartable
    {
        void Start();
    }

    public class Program
    {
        public static void Main()
        {
            var pearComp = new PearComputers();
            var samunComp = new SamunComputers();

            Gsm firstPhone = pearComp.ManufactureGsm();
            Gsm secondPhone = samunComp.ManufactureGsm();

            PrintGsmInfo(firstPhone);
            firstPhone.Start();

            Console.WriteLine();

            PrintGsmInfo(secondPhone);
            secondPhone.Start();
        }

        public static void PrintGsmInfo(Gsm gsm)
        {
            Console.WriteLine("Phone name: {0}", gsm.Name);
            Console.WriteLine("Height: {0}", gsm.Height);
            Console.WriteLine("Width: {0}", gsm.Width);
            Console.WriteLine("Weight: {0}", gsm.Weight);
            Console.WriteLine("Battery life: {0}", gsm.BatteryLife);
        }
    }
}
