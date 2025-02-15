namespace SingletonPattern
{
    internal class SuperHeavyClass
    {
        private static SuperHeavyClass _singleton;
        private static object _locker = new object();
        //bước 1: khai báo constructior, private để bên ngoài ko khởi tạo đc
        private SuperHeavyClass()
        {
            Thread.Sleep(500);
            Console.WriteLine("Object created with hashcode {0}", this.GetHashCode());
        }
        public static SuperHeavyClass GetInstance()
        {
            lock (_locker) // Thread safe by locker
            {
                if (_singleton == null)
                {
                    Thread.Sleep(100);
                    _singleton = new SuperHeavyClass();
                }
            }
            return _singleton;
        }
        public void ToString()
        {
            Console.WriteLine("I'm an instance of {0} with hashcode {1}", this.GetType().ToString(), this.GetHashCode());
        }
    }
}
