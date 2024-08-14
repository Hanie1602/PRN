using GermanyEuro2024_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_DAL.Repositories
{
	public class UefaaccountRepository
	{
		private GermanyEuro2024DbContext _context;

		public Uefaaccount GetOne(string email, string password)
		{
			_context = new GermanyEuro2024DbContext();

			return _context.Uefaaccounts.FirstOrDefault(u => u.AccountEmail == email && u.AccountPassword == password);
		}
	}
}
