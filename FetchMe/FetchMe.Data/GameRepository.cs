using System;
using System.Collections.Generic;
using System.Linq;
using FetchMe.Data.Interface;
using FetchMe.Dto;

namespace FetchMe.Data
{
	public class GameRepository : IGameRepository
	{
		private FetchMeContext Model { get; }

		public GameRepository(FetchMeContext model)
		{
			Model = model;
		}

		public void AddGame(Game game)
		{
			Model.Games.Add(game);
			Model.SaveChanges();
		}

		public IEnumerable<Game> GetGames(string fromTeam)
		{
			return from g in Model.Games
				where g.Team1.Team == fromTeam || g.Team2.Team == fromTeam
				select g;
		}

		public IEnumerable<Game> GetGames(string fromFirstTeam, string againstSecondTeam)
		{
			return from g in Model.Games
				where
					(g.Team1.Team == fromFirstTeam || g.Team1.Team == againstSecondTeam) &&
					(g.Team2.Team == fromFirstTeam || g.Team2.Team == againstSecondTeam)
				select g;
		}
	}
}