using Repositories.Models;

namespace Repositories
{
	public class BookRepository
	{
		//class này sẽ triệu gọi DbContext để giúp CRUD trên đúng table Book mà thôi, ko ôm đồm nhiều table khác
		//Nó chính là Cabinet<Book> như đã học, chứa àm AddBook(), UpdateBook(), GetBooks()
		//Và sẽ insert trực tiếp xuống table thay vì chỉ trong RAM
		//Mô hình thực thi
		//GUI/WPF -> Service --> Repo --------------> DbContext -> Table
		//[1]		  [2]		 [3]
		//			  RAM		 TABLE THỰC SỰ
		//			  Cabinet	 Cabinet				Cabinet
		//3-LAYER ARCHITECTURE

		private BookManagementDbContext _context;	//ko new
		//Mỗi lần dùng cho CRUD Book table thì mới new!!!!!

		//Các hàm CRUD Book here!!!!
		public List<Book> GetBooks()
		{
			_context = new BookManagementDbContext();
			return _context.Books.ToList();	//trả về DbSet 1 dạng List, nên cần convert thành List truyền thống
		}
	}
}
