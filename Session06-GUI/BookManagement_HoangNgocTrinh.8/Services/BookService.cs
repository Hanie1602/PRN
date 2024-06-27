using Repositories;
using Repositories.Models;

namespace Services
{
	public class BookService
	{
		//GUI <----> Service <------------------> Repo <----------> DbContext <----> Table
		//			 CRUD RAM			   CRUD Table thực sự
		//			    HÀM			>=			  HÀM
		// THUẬT TOÁN XỬ LÝ INFO:
		// JOIN, SUM, AVG,....
		//Class này cũng lại là 1 dạng Cabinet<Book> trong RAM
		//cần triệu gọi tới Repo giúp đi xuống Db
		//nó đồng thời giao tiếp với GUI để đồng bộ data trên GUI
		//CRUD trong RAM các cuốn sách
		private BookRepository _repo = new();	//new luôn

		//thường method ở bên Service đặt tên dễ hiểu
		//thường method bên Repo đặt gần với CRUD table
		public List<Book> GetAllBooks()
		{
			return _repo.GetBooks();
		}
	}
}
