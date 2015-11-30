using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			GameRepository = gameRepository;
			SetGameCount(10);
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

		public float Compute(TeamDto teamToCheck, TeamDto againstTeam)
		{
			// Use divide and conquer for efficiency
			var bothPointsTask = GetPointsAsync(teamToCheck, Double, GameRepository.GetGames(teamToCheck, againstTeam));
			var singlePoints = GetPoints(teamToCheck, Single, GameRepository.GetGames(teamToCheck));

			try
			{
				bothPointsTask.Wait();
			}
			catch (AggregateException exception)
			{
				throw new LogicException("Task threw an exception", exception);
			}

			var bothPoints = bothPointsTask.Result;
			return (singlePoints + bothPoints)/MaxPoints;
		}

		private Task<float> GetPointsAsync(TeamDto teamToCheck, Points pointsToAdd, IEnumerable<GameDto> gameDtos)
		{
			return Task.Run(() => GetPoints(teamToCheck, pointsToAdd, gameDtos));
		}

		private float GetPoints(TeamDto teamToCheck, Points pointsToAdd, IEnumerable<GameDto> gameDtos)
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
				var scoreToCheck = game.Team1.Team.Name == teamToCheck.Name
					? game.Score.Score1
					: game.Score.Score2;
				var scoreToCheckAgainst = game.Team2.Team.Name == teamToCheck.Name
					? game.Score.Score1
					: game.Score.Score2;

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