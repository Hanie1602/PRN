namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ILogger logger = new SqlLogger();
            // Vấn đề là khi muoonschuyeenr từ SqlLog sang TxtLod thì phải tìm all những đoạn code có sử dụng constructor khởi tạo ILogger và thay đổi
            //=> sai sót, tốn công, ảnh hưởng đến nhiều người
            //=> Giải pháp dùng 1 class để kiểm soát việc tạo ra Logger object 
            ILogger logger = LoggerFactory.CreateLogger();
            logger.Log("StartProgram");
            logger.Log("End Progran");

        }
    }
    class LoggerFactory
    {

        public static ILogger CreateLogger()
        {
            //read mode in config file
            // Muốn khởi taopj mode nào thì chỉ cần edit lại mode ở file config là đc
            int mode = 1; // mode đọc data từ app Appsettings
            if (mode == 1)
            {
                return new SqlLogger();
            }
            return new TxtLogger();
        }
    }

    internal interface ILogger
    {
        void Log(string message);
    }
    class SqlLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("SqlLog: " + message);
        }
    }
    class TxtLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("TxtLog: " + message);
        }
    }
}
