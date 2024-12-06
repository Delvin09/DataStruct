using System.Runtime.InteropServices;

namespace DataStruct.Tests
{
    public interface IPet
    {
        string Name { get; }

        int Age { get; }

        double Weight { get; }
    }

    public interface ILivePet : IPet
    {
        void Sleep();

        void Eat();

        void Voice();
    }

    public interface IFlyable
    {
        void Fly();
    }

    public interface IVoiced
    {
        void Voice();
    }

    public interface ISomthing
    {
        void Do();
    }

    class WoodDuck : IPet, IVoiced
    {
        public string Name => "Mock Duck";

        public int Age { get; set; }

        public double Weight => 2.0;

        public void Voice()
        {
            Console.WriteLine("KraaaaKraaa");
        }
    }

    class PlasticCat : IPet
    {
        public string Name => "Plastic Cat";

        public int Age { get; set; }

        public double Weight => 1.0;
    }

    internal class Piano : IVoiced
    {
        public void Voice()
        {
            throw new NotImplementedException();
        }
    }

    abstract class Pet : ILivePet, IVoiced, ISomthing
    {
        protected int _id = 0;

        public string Name { get; }

        public int Age { get; private set; }

        public double Weight { get; private set; }

        public Pet(string name)
        {
            Name = name;
        }

        public Pet(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        public virtual void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }

        void IVoiced.Voice()
        {
            throw new NotImplementedException();
        }

        public abstract void Voice();

        void ISomthing.Do()
        {
            throw new NotImplementedException();
        }
    }

    class Duck : Pet, IFlyable
    {
        public Duck(string name) : base(name)
        {
        }

        public void Fly()
        {
            Console.WriteLine("Duck is flying!");
        }

        public override void Voice()
        {
            Console.WriteLine("KraKra");
        }
    }

    class Rabbit : Pet
    {
        public Rabbit(string name) : base(name)
        {
        }

        public override void Voice()
        {
            Console.WriteLine($"{Name}: Frrrfrr!");
        }
    }

    class Cat : Pet
    {
        private double _value = 0;

        public Cat(string name)
            : this(name, 0, 5.0)
        {
            //...
        }

        public Cat(string name, int age, double weight)
            : base(name, age, weight)
        {
            //..2
        }

        public void CatchMouse()
        {
        }

        public override void Voice()
        {
            Console.WriteLine($"{Name}: Mew!");
        }
    }

    class Collar : IDisposable
    {
        ~Collar()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(false);
        }

        private void Dispose(bool finalizer)
        {
            //....

            if (!finalizer)
            {
                GC.SuppressFinalize(this);
            }
        }
    }

    class Dog : Pet
    {
        public Collar Collar { get; }

        public Dog(string name, Collar collar)
            : this(name, collar, 7.0, 0)
        {
        }

        public Dog(string name, Collar collar, double weight, int age)
            : base(name, age, weight)
        {
            Collar = collar;
        }

        public void Guard()
        {

        }

        public override void Voice()
        {
            Console.WriteLine($"{Name}: Guf!");
        }
    }

    readonly struct Card
    {
        public readonly int value;
        public readonly int suit;

        public int SomeCoolProp { get; init; }

        public Card(int value, int suit)
        {
            this.value = value;
            this.suit = suit;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using var collar = new Collar();

            try
            {
                Cat barsik = new Cat("barsik");
                Cat murka = new Cat("murka");

                ISomthing somthing = barsik;
                somthing.Do();

                barsik.Voice();
                ILivePet livePet = barsik;
                livePet.Voice();

                IVoiced voiced = barsik;
                voiced.Voice();

                Dog bobik = new Dog("bobik", new Collar());

                Duck donald = new Duck("donald");

                WoodDuck woodDuck = new WoodDuck();
                PlasticCat plasticCat = new PlasticCat();

                // Up-cast
                FeedPets(barsik, murka, bobik, donald);

                CountPets(barsik, murka, bobik, donald, woodDuck, plasticCat);
            }
            finally
            {
                collar.Dispose();
            }
        }

        private static void CountPets(params IPet[] pets)
        {
            foreach (IPet pet in pets)
            {
                Console.WriteLine(pet.Name);
            }
        }

        static void FeedPets(params ILivePet[] pets)
        {
            foreach (var pet in pets)
            {
                pet.Eat();

                if (pet is IVoiced voiced)
                {
                    voiced.Voice();
                }

                if (pet is IFlyable flyable)
                {
                    flyable.Fly();
                }
            }
        }
    }
}
