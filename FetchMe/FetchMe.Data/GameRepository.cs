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

		public IEnumerable<Game> GetGames(Team fromTeam)
		{
			return from g in Model.Games
				where g.Team1.Team.Name == fromTeam.Name || g.Team2.Team.Name == fromTeam.Name
				select g;
		}

		public IEnumerable<Game> GetGames(Team fromFirstTeam, Team againstSecondTeam)
		{
			return from g in Model.Games
				where
					(g.Team1.Team.Name == fromFirstTeam.Name || g.Team1.Team.Name == againstSecondTeam.Name) &&
					(g.Team2.Team.Name == fromFirstTeam.Name || g.Team2.Team.Name == againstSecondTeam.Name)
				select g;
		}
	}
}