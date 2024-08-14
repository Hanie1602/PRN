using GermanyEuro2024_DAL.Entities;
using GermanyEuro2024_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_BLL.Services
{
	public class UefaaccountService
	{
		private UefaaccountRepository _repository = new();

		public Uefaaccount Authenticate (string username, string password)
		{
			return _repository.GetOne(username, password);
		}
	}
}
