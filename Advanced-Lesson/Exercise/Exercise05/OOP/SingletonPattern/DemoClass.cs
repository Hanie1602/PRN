namespace SingletonPattern
{
    public class DemoClass
    {
        public static void Run()
        {
            List<SuperHeavyClass> list = new List<SuperHeavyClass>();
            for (int i = 0; i < 10; i++)
            {
                SuperHeavyClass su = SuperHeavyClass.GetInstance();
                list.Add(su);

            }
            foreach (SuperHeavyClass su in list)
            {
                su.ToString();
            }
        }
    }
}
