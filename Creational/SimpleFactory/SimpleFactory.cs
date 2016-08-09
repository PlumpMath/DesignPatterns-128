namespace SimpleFactory.CoffeeShop
{
    using System;

    public enum CoffeeType
    {
        Regular,
        Double,
        Cappuccino,
        Macchiato
    }

    public class Program
    {
        public static void Main()
        {
            var macchiato = CoffeeFactory.GetCoffee(CoffeeType.Macchiato);
            var regularCoffee = CoffeeFactory.GetCoffee(CoffeeType.Regular);

            Console.WriteLine("Macchiato - Milk content: {0} ml, Coffee content: {1} ml", macchiato.MilkContent, macchiato.CoffeeContent);
            Console.WriteLine("Regular coffee - Milk content: {0} ml, Coffee content: {1} ml", regularCoffee.MilkContent, regularCoffee.CoffeeContent);
        }
    }

    public static class CoffeeFactory
    {
        public static Coffee GetCoffee(CoffeeType coffeeType)
        {
            switch (coffeeType)
            {
                case CoffeeType.Regular:
                    return new Coffee(0, 150);
                case CoffeeType.Double:
                    return new Coffee(0, 200);
                case CoffeeType.Cappuccino:
                    return new Coffee(100, 100);
                case CoffeeType.Macchiato:
                    return new Coffee(200, 100);
                default:
                    throw new ArgumentException();
            }
        }
    }

    public class Coffee
    {
        public int MilkContent { get; set; }

        public int CoffeeContent { get; set; }

        public Coffee(int milk, int coffee)
        {
            this.MilkContent = milk;
            this.CoffeeContent = coffee;
        }
    }
}
