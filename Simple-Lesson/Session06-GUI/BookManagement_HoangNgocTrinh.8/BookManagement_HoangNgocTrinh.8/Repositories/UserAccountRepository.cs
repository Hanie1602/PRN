using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class UserAccountRepository
	{
		//Thằng này chứa các hàm CRUD trực tiếp table UserAccount trong cơ sở dữ liu65
		//dĩ nhiên Repo thì cần DbContext
		private BookManagementDbContext _context;	//Ko new ở đây, hàm nào xài hàm đó mới new

		//Tại thời điểm này PE, ko có nhu cầu select * User
		//chỉ có nhu cầu select 1 dòng Account where pass = pass đưa vào, email = email đưa vào
		//Trả về tối đa 1 UserAccount(id, email, pass, fullname, role)
		public UserAccount GetOne(string email, string pass)
		{
			//_context = new BookManagementDbContext();
			_context = new();
			//return _context.UserAccounts.FirstOrDefault("where???");
			return _context.UserAccounts.FirstOrDefault(u => u.Email == email && u.Password == pass);
		} //phân biệt hoa thường đó nhen, A khác a
	}
}
