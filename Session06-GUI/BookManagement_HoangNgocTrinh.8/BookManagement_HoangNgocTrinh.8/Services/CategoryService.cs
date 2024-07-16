using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	//GUI -- SERVICE -- REPOSITORY -- DBCONTEXT
	public class CategoryService
	{
		private CategoryRepository _repo = new();
		public List<BookCategory> GetAllCategories()
		{
			//select tất cả các Category (5 dòng 3 cột chuẩn bị đổ lên drop down cho user lựa chọn)
			return _repo.GetAll();
			//có thể dùng Expression body
		}
	}
}
