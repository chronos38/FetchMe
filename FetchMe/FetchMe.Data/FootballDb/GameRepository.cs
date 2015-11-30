using System.Collections.Generic;
using System.Data.SQLite;
using FetchMe.Data.Interface;
using FetchMe.Dto;

namespace FetchMe.Data.FootballDb
{
	public class GameRepository : IGameRepository
	{
		private SQLiteConnection Connection { get; }

		public GameRepository(SQLiteConnection connection)
		{
			Connection = connection;
		}

		public int AddGame(GameDto game)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<GameDto> GetGames(TeamDto fromTeam)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<GameDto> GetGames(TeamDto fromFirstTeam, TeamDto againstSecondTeam)
		{
			throw new System.NotImplementedException();
		}
	}
}