using System;
using System.Linq;
using FetchMe.Data;
using FetchMe.Data.Interface;
using FetchMe.Dto;
using FetchMe.Logic.Interface;

namespace FetchMe.Logic
{
	public class GameValidation : IGameValidation
	{
		private ITeamSynonyms TeamSynonyms { get; }
		private IGameRepository GameRepository { get; }

		public GameValidation(ITeamSynonyms teamSynonyms, IGameRepository gameRepository)
		{
			TeamSynonyms = teamSynonyms;
			GameRepository = gameRepository;
		}

		public bool ValidateAndAdd(GameDto game)
		{
			try
			{
				if (!ValidateGame(game))
				{
					return false;
				}
				if (GameExists(game))
				{
					return true;
				}

				GameRepository.AddGame(Mapper.Map(game));
				return true;
			}
			catch (Exception exception)
			{
				throw new LogicException("Could not validate game", exception);
			}
		}

		private bool GameExists(GameDto game)
		{
			return
				GameRepository.GetGames(game.Team1.Team, game.Team2.Team)
					.ToArray()
					.Select(Mapper.Map)
					.Contains(game);
		}

		private static bool ValidateGame(GameDto game)
		{
			if (game.Minutes < 0)
			{
				return false;
			}
			if (game.Score1 < 0)
			{
				return false;
			}
			if (game.Score2 < 0)
			{
				return false;
			}
			if (game.Team1 == null || game.Team2 == null)
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(game.Team1.Team) || string.IsNullOrWhiteSpace(game.Team2.Team))
			{
				return false;
			}

			return true;
		}
	}
}