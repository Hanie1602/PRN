namespace SingletonPattern
{
	internal class SuperHeavyClass
	{
		//Static là mức độ dùng chung của 
		private static SuperHeavyClass _singleton;
		private static object _locker = new object();

		private SuperHeavyClass()
		{
			Thread.Sleep(500); //Tốn 0.5s
			Console.WriteLine("Object created with hashcode {0}", this.GetHashCode());
		}

		public static SuperHeavyClass GetInstance()
		{
			lock(_locker)
			{
				if(_singleton == null)
				{
					Thread.Sleep(100);
					_singleton = new SuperHeavyClass();
				}
			}
			return _singleton;
		}

		public void ToString()
		{
			Console.WriteLine("I'm an instance of {0} with hashcode", this.GetType().ToString(), this.GetHashCode());
		}
	}
}
