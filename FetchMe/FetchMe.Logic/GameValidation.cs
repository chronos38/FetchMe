using System;
using System.Linq;
using FetchMe.Data.Interface;
using FetchMe.Dto;
using FetchMe.Logic.Interface;

namespace FetchMe.Logic
{
	public class GameValidation : IGameValidation
	{
		private ITeamSynonyms TeamSynonyms { get; }
		private IGameRepository GameRepository { get; }
		private ITeamRepository TeamRepository { get; }

		public GameValidation(ITeamSynonyms teamSynonyms, IGameRepository gameRepository, ITeamRepository teamRepository)
		{
			TeamSynonyms = teamSynonyms;
			GameRepository = gameRepository;
			TeamRepository = teamRepository;
		}

		public bool ValidateAndAdd(GameDto game)
		{
			try
			{
				if (!ValidateGame(game))
				{
					return false;
				}
				if (!TeamExists(game.Team1.Team))
				{
					TeamRepository.AddTeam(game.Team1.Team);
				}
				if (!TeamExists(game.Team2.Team))
				{
					TeamRepository.AddTeam(game.Team2.Team);
				}
				if (GameExists(game))
				{
					return true;
				}

				GameRepository.AddGame(game);
				return true;
			}
			catch (Exception exception)
			{
				throw new LogicException("Could not validate game", exception);
			}
		}

		private bool GameExists(GameDto game)
		{
			return GameRepository.GetGames(game.Team1.Team, game.Team2.Team).Contains(game);
		}

		private bool ValidateGame(GameDto game)
		{
			if (game.Minutes < 0)
			{
				return false;
			}
			if (game.Score == null)
			{
				return false;
			}
			if (game.Score.Score1 < 0)
			{
				return false;
			}
			if (game.Score.Score2 < 0)
			{
				return false;
			}
			if (game.Team1 == null || game.Team2 == null)
			{
				return false;
			}
			if (game.Team1.Team == null || game.Team2.Team == null)
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(game.Team1.Team.Name) || string.IsNullOrWhiteSpace(game.Team2.Team.Name))
			{
				return false;
			}

			return true;
		}

		private bool TeamExists(TeamDto team)
		{
			return TeamRepository.GetAllTeams().Select(t => t.Name).Contains(TeamSynonyms.ResolveSynonym(team.Name));
		}
	}
}