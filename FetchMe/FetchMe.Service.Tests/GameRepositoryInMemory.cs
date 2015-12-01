using System.Collections.Generic;
using System.Linq;
using FetchMe.Data;
using FetchMe.Data.Interface;

namespace FetchMe.Service.Tests
{
	public class GameRepositoryInMemory : IGameRepository
	{
		public List<Game> Games { get; } = new List<Game>();

		public void AddGame(Game game)
		{
			Games.Add(game);
		}

		public IEnumerable<Game> GetGames(string fromTeam)
		{
			return from g in Games
				   where g.Team1 == fromTeam || g.Team2 == fromTeam
				   select g;
		}

		public IEnumerable<Game> GetGames(string fromFirstTeam, string againstSecondTeam)
		{
			return from g in Games
				   where
					   (g.Team1 == fromFirstTeam || g.Team1 == againstSecondTeam) &&
					   (g.Team2 == fromFirstTeam || g.Team2 == againstSecondTeam)
				   select g;
		}
	}
}