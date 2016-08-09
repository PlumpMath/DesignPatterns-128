using System.Collections.Generic;

namespace AbstractFactory.PizzaPlaces
{
    using System;

    public class AlfreddosPlace : PizzaFactory
    {
        private const string name = "Alfreddo's Pizza Palace";

        public string Name
        {
            get
            {
                return name;
            }
        }

        public override CheesePizza MakeCheesePizza()
        {
            var ingridients = new List<string>();
            ingridients.Add("tomatoes");
            ingridients.Add("white cheese");
            ingridients.Add("yellow cheese");
            ingridients.Add("blue cheese");
            ingridients.Add("extra smelly cheese");

            var pizza = new CheesePizza(ingridients, this.Name);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingridients = new List<string>();
            ingridients.Add("tomatoes");
            ingridients.Add("ham");
            ingridients.Add("bacon");

            var pizza = new Calzone(ingridients, this.Name);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingridients = new List<string>();
            ingridients.Add("tomatoes");
            ingridients.Add("pepperoni");
            ingridients.Add("salami");

            var pizza = new PepperoniPizza(ingridients, this.Name);
            return pizza;
        }
    }

    public class PizzaExtraordinaire : PizzaFactory
    {
        private const string name = "Pizza Extraordinaire";

        public string Name
        {
            get
            {
                return name;
            }
        }

        public override CheesePizza MakeCheesePizza()
        {
            var ingridients = new List<string>();
            ingridients.Add("rotten tomatoes");
            ingridients.Add("grey cheese");
            ingridients.Add("green cheese");

            var pizza = new CheesePizza(ingridients, this.Name);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingridients = new List<string>();
            ingridients.Add("rotten tomatoes");
            ingridients.Add("greasy ham");

            var pizza = new Calzone(ingridients, this.Name);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingridients = new List<string>();
            ingridients.Add("old salami");
            ingridients.Add("green tomatoes");

            var pizza = new PepperoniPizza(ingridients, this.Name);
            return pizza;
        }
    }

    public class Calzone : Pizza
    {
        private string madeBy;

        public Calzone(IEnumerable<string> ingridients, string madeBy)
            : base(ingridients)
        {
            this.madeBy = madeBy;
        }

        public override string Name
        {
            get
            {
                return string.Format("Calzone made by {0}", madeBy);
            }
        }
    }

    public class CheesePizza : Pizza
    {
        private readonly string madeBy;

        public CheesePizza(IEnumerable<string> ingridients, string madeBy)
            : base(ingridients)
        {
            this.madeBy = madeBy;
        }

        public override string Name
        {
            get
            {
                return string.Format("Cheese pizza, made by {0}", this.madeBy);
            }
        }
    }

    public class PepperoniPizza : Pizza
    {
        private string madeBy;

        public PepperoniPizza(IEnumerable<string> ingridients, string madeBy)
            : base(ingridients)
        {
            this.madeBy = madeBy;
        }

        public override string Name
        {
            get
            {
                return string.Format("Pepporni Pizza made by {0}", this.madeBy);
            }
        }
    }

    public class OnlineDeliveryCompany
    {
        private PizzaFactory factory;

        public OnlineDeliveryCompany(PizzaFactory pizzaFactory)
        {
            factory = pizzaFactory;
        }

        public CheesePizza DeliverCheesePizza()
        {
            return factory.MakeCheesePizza();
        }

        public Calzone DeliverCalzone()
        {
            return factory.MakeCalzone();
        }

        public PepperoniPizza DeliverPepperoniPizza()
        {
            return factory.MakePepperoniPizza();
        }
    }

    public abstract class PizzaFactory
    {
        public abstract CheesePizza MakeCheesePizza();

        public abstract Calzone MakeCalzone();

        public abstract PepperoniPizza MakePepperoniPizza();
    }

    public abstract class Pizza
    {
        private IReadOnlyCollection<string> ingridients;

        public Pizza(IEnumerable<string> ingridients)
        {
            this.ingridients = new List<string>(ingridients);
        }

        public IEnumerable<string> Ingridients
        {
            get
            {
                return this.ingridients;
            }
        }

        public abstract string Name { get; }
    }

    public class Program
    {
        public static void Main()
        {
            var pizzaPlace = new PizzaExtraordinaire();
            var yamYam = new OnlineDeliveryCompany(pizzaPlace);

            var cheesePizza = yamYam.DeliverCheesePizza();

            Console.WriteLine(cheesePizza.Name);
            Console.WriteLine("Ingridients: ");
            foreach (var ingridient in cheesePizza.Ingridients)
            {
                Console.WriteLine(ingridient);
            }
        }
    }
}
