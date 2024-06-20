using Repositories;
using Repositories.Entities;

namespace BookManager
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Thêm cuốn sách xem sao, gọi Cabinet DbContext
			BookManagementDbContext context = new();
			context.Books.Add(new Book() { BookId = 999, BookName = "Conan", Author = "Japan", Description = "Sách trinh thám....", Price = 5.0, Quantity = 100, BookCategoryId = 1, PublicationDate = DateTime.Now});

			context.SaveChanges();

			List<Book> arr = new BookManagementDbContext().Books.ToList();
            //Đã Select * from rồi
            //in 17 cuốn sách, loop

            Console.WriteLine("The list of books in table");
			foreach (Book x in arr)
                Console.WriteLine($"{x.BookId} | {x.BookName} | {x.Author} | {x.BookCategoryId}");
        }
	}
}
