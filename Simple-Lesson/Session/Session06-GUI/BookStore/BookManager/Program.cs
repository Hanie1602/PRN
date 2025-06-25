using Repositories;
using Repositories.Entities;

namespace BookManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //thêm cuốn sách xem sao
            BookManagementDbContext context = new BookManagementDbContext();
            context.Books.Add(new Book() { BookId = 999, BookName = "Connan", Author = "Japan...", Description = "Trinh thám...", Price = 5.0, Quantity = 100, BookCategoryId = 1, PublicationDate = DateTime.Now});
            context.SaveChanges();

            List<Book> arr = new BookManagementDbContext().Books.ToList();
            //đã select * from
            //in 17 cuốn sách, loop
            Console.WriteLine("The list of books in table");
            foreach (var item in arr)
            {
                Console.WriteLine($"{item.BookId} | {item.BookName} | {item.Author} | {item.BookCategoryId}");
            }
        }
    }
}
