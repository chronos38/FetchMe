using System;
using System.Collections.Generic;
using System.Linq;
using FetchMe.Data.Interface;
using FetchMe.Dto;

namespace FetchMe.Data
{
	public class GameRepository : IGameRepository
	{
		private FetchMeModel Model { get; }

		public GameRepository(FetchMeModel model)
		{
			Model = model;
		}

		public void AddGame(GameDto game)
		{
			game.Id = Model.Games.Add(Mapper.Map(game)).Id;
		}

		public IEnumerable<GameDto> GetGames(TeamDto fromTeam)
		{
			var validator =
				new Func<Team, bool>(t => string.Equals(t.Name, fromTeam.Name, StringComparison.CurrentCultureIgnoreCase));
			return from g in Model.Games where validator(g.Team1.Team) || validator(g.Team2.Team) select Mapper.Map(g);
		}

		public IEnumerable<GameDto> GetGames(TeamDto fromFirstTeam, TeamDto againstSecondTeam)
		{
			var validator =
				new Func<Team, bool>(
					t =>
						string.Equals(t.Name, fromFirstTeam.Name, StringComparison.CurrentCultureIgnoreCase) ||
						string.Equals(t.Name, againstSecondTeam.Name, StringComparison.CurrentCultureIgnoreCase));
			return from g in Model.Games where validator(g.Team1.Team) && validator(g.Team2.Team) select Mapper.Map(g);
		}
	}
}