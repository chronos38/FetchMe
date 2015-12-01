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
				   where g.Team1.Team == fromTeam || g.Team2.Team == fromTeam
				   select g;
		}

		public IEnumerable<Game> GetGames(string fromFirstTeam, string againstSecondTeam)
		{
			return from g in Games
				   where
					   (g.Team1.Team == fromFirstTeam || g.Team1.Team == againstSecondTeam) &&
					   (g.Team2.Team == fromFirstTeam || g.Team2.Team == againstSecondTeam)
				   select g;
		}
	}
}