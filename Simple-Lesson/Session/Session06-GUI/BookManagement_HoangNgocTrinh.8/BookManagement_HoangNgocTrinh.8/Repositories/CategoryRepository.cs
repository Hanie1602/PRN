using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class CategoryRepository
	{
		//là Cabinet chỉ chơi vs Category table
		//chắc chắn nó cần gọi DbContext.BookCategories
		//kĩ thuật mà mỗi class lo riêng 1  nhóm công việc ko ôm đồm sang chỗ khác
		//ví dụ class này chỉ tập trung vào table category
		//kĩ thuật này gọi là SINGLE REPOSITORY
		//ĐƠN TRÁCH NHIỆM TRONG THIẾT KẾ CLASS
		//TỪ ĐẦU TIÊN TRONG TỪ HUYỀN THOẠI   SOLID-giaolang Dependencies Youtue

		private BookManagementDbContext _context; //ko new, lúc nào dùng ms new
		public List<BookCategory> GetAll()
		{
			_context = new BookManagementDbContext();
			return _context.BookCategories.ToList();
		}



	}
}
