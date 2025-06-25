using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories
{
	public class BookRepository
	{
		//class này sẽ triệu gọi DbContext để giúp CRUD trên dúng table Book mà thôi, ko ôm đồm nhiều table khác
		//Nó chính là Cabinet<Book> như đã học, chứa các hàm AddBook(), UpdateBook(), GetBooks()...
		//và sẽ insert trực tiếp xuống db thay vì trong Ram
		//Mô hình thực thi
		//GUI/WPF -> Service -> Repo           -> DbContext -> TABLE
		//  1           2        3
		//            RAM       TABLE THỰC SỰ
		//            Cabinet   Cabinet           Cabinet  
		//3-LAYER ARCHITECTURE 

		private BookManagementDbContext _context; //ko new
		//mỗi lần dùng cho CRUD Book ms new!! Vì liên quan đến đồng bộ data

		//các hàm CRUD Book here
		public List<Book> GetBooks()
		{
			_context = new BookManagementDbContext();
			//return _context.Books.ToList(); 
			//trả về DbSet 1 dạng của List, nên cần convert thành List truyền thống
			//Lazy ko thèm join vs table category

			return _context.Books.Include("BookCategory").ToList();
				//gửi vào tên biến object móc sang object bên kia
				//chính là móc sang table Category
		}
		//hàm tạo ms cuốn sách trong Repo
		//tên hàm đặt trheo sql: INSERT, UPDATE, DELETE, SELECT
		public void Create(Book x)
		{
			_context = new();
			_context.Books.Add(x);
			_context.SaveChanges();
		}

		public void Update(Book x)
		{
			_context = new();
			_context.Books.Update(x);
			_context.SaveChanges();
		}

		public void Delete(Book x)
		{
			_context = new();
			_context.Books.Remove(x);
			_context.SaveChanges();
		}
	}
}
