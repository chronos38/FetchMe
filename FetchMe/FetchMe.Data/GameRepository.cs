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
			var existsAlready = Model.Games.Any(
				g => g.Date == game.Date && g.Score1 == game.Score1 && g.Score2 == game.Score2 && g.Team1 == game.Team1 &&
				     g.Team2 == game.Team2);

			if (!existsAlready)
			{
				Model.Games.Add(game);
				Model.SaveChanges();
			}
		}

		public IEnumerable<Game> GetGames(string fromTeam)
		{
			return from g in Model.Games
				where g.Team1 == fromTeam || g.Team2 == fromTeam
				select g;
		}

		public IEnumerable<Game> GetGames(string fromFirstTeam, string againstSecondTeam)
		{
			return from g in Model.Games
				where
					(g.Team1 == fromFirstTeam || g.Team1 == againstSecondTeam) &&
					(g.Team2 == fromFirstTeam || g.Team2 == againstSecondTeam)
				select g;
		}
	}
}