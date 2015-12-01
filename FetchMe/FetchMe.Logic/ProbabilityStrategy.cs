using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FetchMe.Data;
using FetchMe.Data.Interface;
using FetchMe.Dto;
using FetchMe.Logic.Interface;

namespace FetchMe.Logic
{
	public class ProbabilityStrategy : IProbabilityStrategy
	{
		private struct Points
		{
			public float Victory { get; set; }
			public float Streak { get; set; }
		}

		private Points Single { get; } = new Points {Victory = 1.0f, Streak = 2.0f};
		private Points Double { get; } = new Points {Victory = 1.5f, Streak = 3.0f};
		private float MaxPoints { get; set; }
		private IGameRepository GameRepository { get; }
		public int GameCount { get; private set; }

		public ProbabilityStrategy(IGameRepository gameRepository)
		{
			// TODO: Add variable game count
			GameRepository = gameRepository;
			SetGameCount(2);
		}

		public ProbabilityStrategy SetGameCount(int value)
		{
			if (value <= 0)
			{
				throw new ArgumentException("Value must be greater than zero", nameof(value));
			}

			GameCount = value;
			MaxPoints = (Single.Victory + Single.Streak + Double.Victory + Double.Streak)*value;
			return this;
		}

		public float Compute(string teamToCheck, string againstTeam)
		{
			float bothPoints;
			float singlePoints;

			try
			{
				// Use divide and conquer for efficiency
				bothPoints = GetPoints(teamToCheck, Double, GameRepository.GetGames(teamToCheck, againstTeam).ToArray().Select(Mapper.Map));
				singlePoints = GetPoints(teamToCheck, Single, GameRepository.GetGames(teamToCheck).ToArray().Select(Mapper.Map));
			}
			catch (Exception exception)
			{
				throw new LogicException("Could not compute probability", exception);
			}
			
			return (singlePoints + bothPoints)/MaxPoints;
		}

		private float GetPoints(string teamToCheck, Points pointsToAdd, IEnumerable<GameDto> gameDtos)
		{
			var result = .0f;
			var streak = 0;
			var games = gameDtos.OrderByDescending(g => g.Date).Take(GameCount).ToArray();

			// Check if enough data exists
			if (games.Length < GameCount)
			{
				throw new LogicException("Not enough games for both teams");
			}

			foreach (var game in games)
			{
				var scoreToCheck = string.Equals(game.Team1, teamToCheck, StringComparison.CurrentCultureIgnoreCase)
					? game.Score1
					: game.Score2;
				var scoreToCheckAgainst = string.Equals(game.Team2, teamToCheck, StringComparison.CurrentCultureIgnoreCase)
					? game.Score1
					: game.Score2;

				// Team won a single game
				if (scoreToCheck > scoreToCheckAgainst)
				{
					// Add winning game
					result += pointsToAdd.Victory;
					streak += 1;
				}
				// Team lost a single game
				else
				{
					// Add winning streak
					result += streak*pointsToAdd.Streak;
					streak = 0;
				}
			}

			// Add remaining streaks
			return result + streak*pointsToAdd.Streak;
		}
	}
}