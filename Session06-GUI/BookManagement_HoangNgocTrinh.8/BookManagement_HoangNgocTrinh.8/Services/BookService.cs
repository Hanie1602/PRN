using Repositories;
using Repositories.Models;

namespace Services
{
	public class BookService
	{
		//GUI <--> Service           <-->     Repo               <-> DbContext <-> Table
		//         Crud trong Ram             Crub Table thực sự
		//         Hàm               >=       Hàm
		//         Thuật toán xử lý dât
		//        JOIN, SUM, AVG...
		// CLASS này cx là 1 dạng cabinet<Book> trong Ram
		//cần triệu gọi tới Repo để giúp xuống Db , giao tiếp vs GUI để hiển thị data trên GUI
		//CRUD CÁC BOOK TRONG RAM

		private BookRepository _repo = new BookRepository(); //new luôn
		//thường các method bên Service đặt tên cho dễ hiểu
		//                  bên Repo đặt gần vs CRUD
		public List<Book> GetAllBooks()
		{
			return _repo.GetBooks();
		}

		//CRUD BOOK, TÊN  HÀM ĐẶT GẦN VS USER HƠN, VÌ NÓ GIAO TIẾP VS GUI
		public void CreateBook(Book x)
		{
			_repo.Create(x);
		}

		public void UpdateBook(Book x)
		{
			_repo.Update(x);
		}

		public void DeleteBook(Book x)
		{
			_repo.Delete(x);
		}

		//Hàm Search trả về nhiều Book
		public List<Book> SearchBooksByNameAndDesc(string name, string desc)
		{
			name = name.ToLower();
			desc = desc.ToLower();
			//ta cũng phải đổi name, desc của cuốn sách trong RAM thành thường để ssearch, dể where
			//return _repo.GetBooks().Where("chuỗi where like").ToList();
			//return _repo.GetBooks().Where(x => x.BookName == name && x.Description == desc).ToList();
			return _repo.GetBooks().Where(x => x.BookName.ToLower().Contains(name) && x.Description.ToLower().Contains(desc)).ToList();

		}
	}
}
