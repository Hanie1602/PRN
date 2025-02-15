using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Nguyên tắc của DI: khi sử dụng, chỉ dùng interface mà ko khởi tạo class cụ thể nằm trong region
            // Tạo DI Container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<ILoggerService, ConsoleLoggerService>()
                .AddSingleton<IOrderService, OrderService>()
                .BuildServiceProvider();

            // Lấy dịch vụ OrderService từ container
            var orderService = serviceProvider.GetService<IOrderService>();

            // Đặt hàng
            orderService.PlaceOrder("Laptop");
            orderService.PlaceOrder("Headphone");
            Console.ReadLine();
        }
    }
    #region Interface
    public interface IProductService
    {
        List<string> GetProducts();
    }

    public interface IOrderService
    {
        void PlaceOrder(string product);
    }

    public interface ILoggerService
    {
        void Log(string message);
    }
    #endregion

    #region Implement Interface
    public class ProductService : IProductService
    {
        private List<string> _products = new List<string> { "Laptop", "Smartphone", "Tablet" };

        public List<string> GetProducts()
        {
            return _products;
        }
    }

    public class ConsoleLoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
    public class SqlLoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message} to SQL DB");
        }
    }

    public class OrderService : IOrderService
    {
        private readonly IProductService _productService;
        private readonly ILoggerService _logger;

        public OrderService(IProductService productService, ILoggerService logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public void PlaceOrder(string product)
        {
            var products = _productService.GetProducts();
            if (products.Contains(product))
            {
                _logger.Log($"Order placed for {product}");
            }
            else
            {
                _logger.Log($"Product {product} is not available.");
            }
        }
    }
    #endregion


}
