namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestaurantFactory restaurant = new ComTamRestaurantFactory();

            Food food = restaurant.CreateFood();
            Sauce sauce = restaurant.CreateSauce();

            food.Show();
            sauce.Use();
            Console.ReadLine();
        }
    }
    
    abstract class RestaurantFactory {
        public abstract Food CreateFood();
        public abstract Sauce CreateSauce();
    }
    class PhoRestaurantFactory : RestaurantFactory
    {
        public override Food CreateFood()
        {
            return new Pho();
        }

        public override Sauce CreateSauce()
        {
            return new TuongDen();
        }
    }
    class ComTamRestaurantFactory : RestaurantFactory
    {
        public override Food CreateFood()
        {
            return new ComTam();
        }

        public override Sauce CreateSauce()
        {
            return new NuocMam();
        }
    }

    abstract class Food
    {
        public abstract void Show();

    }
    class Pho : Food
    {
        public override void Show()
        {
            Console.WriteLine("Pho bo");
        }
    }
    class ComTam : Food
    {
        public override void Show()
        {
            Console.WriteLine("Com tam");
        }
    }
    abstract class Sauce
    {
        public abstract void Use();
    }
    class NuocMam : Sauce
    {
        public override void Use()
        {
            Console.WriteLine("Nuoc mam");
        }
    }
    class TuongDen : Sauce
    {
        public override void Use()
        {
            Console.WriteLine("Tuong den");
        }
    }
}
