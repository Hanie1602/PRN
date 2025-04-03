using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class UserAccountService
	{
		//GUI --> Service --> Repo --> DbContext --> Table
		private UserAccountRepository _repo = new();

		//CRUD UserAccount như bình thường, còn thêm hàm tính xem login sai mấy lần...
		//Bài này mình chỉ tập trung vào login hoy
		public UserAccount Authenticate(string email, string password)
		{
			return _repo.GetOne(email, password);
		}
	}
}
