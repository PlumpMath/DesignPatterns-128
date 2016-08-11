namespace Builder
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'Product' class
    /// </summary>
    public class Vehicle
    {
        private readonly string vehicleType;
        private readonly Dictionary<string, string> parts = new Dictionary<string, string>();

        public Vehicle(string vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get { return this.parts[key]; }
            set { this.parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", this.vehicleType);
            Console.WriteLine(" Frame  : {0}", this.parts["frame"]);
            Console.WriteLine(" Engine : {0}", this.parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", this.parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", this.parts["doors"]);
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder' class
    /// </summary>
    internal class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            this.Vehicle = new Vehicle("Car");
        }

        public override void BuildFrame()
        {
            this.Vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            this.Vehicle["engine"] = "2500 cc";
        }

        public override void BuildWheels()
        {
            this.Vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            this.Vehicle["doors"] = "4";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder' class
    /// </summary>
    internal class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            this.Vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildFrame()
        {
            this.Vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            this.Vehicle["engine"] = "500 cc";
        }

        public override void BuildWheels()
        {
            this.Vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            this.Vehicle["doors"] = "0";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder' class
    /// </summary>
    internal class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            this.Vehicle = new Vehicle("Scooter");
        }

        public override void BuildFrame()
        {
            this.Vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            this.Vehicle["engine"] = "50 cc";
        }

        public override void BuildWheels()
        {
            this.Vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            this.Vehicle["doors"] = "0";
        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    internal class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    public class TankBuilder : VehicleBuilder
    {
        public override void BuildFrame()
        {
            throw new NotImplementedException();
        }

        public override void BuildEngine()
        {
            throw new NotImplementedException();
        }

        public override void BuildWheels()
        {
            throw new NotImplementedException();
        }

        public override void BuildDoors()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    public abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; set; }

        public abstract void BuildFrame();

        public abstract void BuildEngine();

        public abstract void BuildWheels();

        public abstract void BuildDoors();
    }

    internal class Program
    {
        internal static void Main()
        {
            VehicleBuilder builder;
            var shop = new Shop();

            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new TankBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
        }
    }
}
