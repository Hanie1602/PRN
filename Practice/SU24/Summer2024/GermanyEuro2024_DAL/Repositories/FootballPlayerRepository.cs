using GermanyEuro2024_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024_DAL.Repositories
{
	public class FootballPlayerRepository
	{
		private GermanyEuro2024DbContext _context;

		public List<FootballPlayer> GetFootballPlayer()
		{
			_context = new GermanyEuro2024DbContext();

			return _context.FootballPlayers.Include("FootballTeam").ToList();
		}
	}
}
