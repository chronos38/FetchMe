using System.Collections.Generic;
using System.Data.SQLite;
using FetchMe.Data.Interface;
using FetchMe.Dto;

namespace FetchMe.Data.FootballDb
{
	public class TeamRepository : ITeamRepository
	{
		private SQLiteConnection Connection { get; }

		public TeamRepository(SQLiteConnection connection)
		{
			Connection = connection;
		}

		public int AddTeam(TeamDto team)
		{
			throw new System.NotImplementedException();
		}

		public TeamDto GetTeam(int id)
		{
			throw new System.NotImplementedException();
		}

		public TeamDto GetTeam(string name)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<TeamDto> GetTeams(string country)
		{
			throw new System.NotImplementedException();
		}
	}
}