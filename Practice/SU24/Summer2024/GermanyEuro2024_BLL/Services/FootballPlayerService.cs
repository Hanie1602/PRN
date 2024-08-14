using GermanyEuro2024_DAL.Entities;
using GermanyEuro2024_DAL.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_BLL.Services
{
	public class FootballPlayerService
	{
		private FootballPlayerRepository _repository = new();

		public List<FootballPlayer> GetAllFootballPlayer()
		{
			return _repository.GetFootballPlayer();
		}

		public List<FootballPlayer> SearchByAchivement(string achivement)
		{
			achivement = achivement.ToLower();
			return _repository.GetFootballPlayer().Where(u => u.Achievements.ToLower().Contains(achivement)).ToList();
		}

		public List<FootballPlayer> SearchByPlayerNam(string name)
		{
			name = name.ToLower();
			return _repository.GetFootballPlayer().Where(u => u.PlayerName.ToLower().Contains(name)).ToList();
		}
	}
}
