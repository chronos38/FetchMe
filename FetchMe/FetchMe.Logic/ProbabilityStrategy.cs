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

		public float Compute(string teamToCheck, string againstTeam)
		{
			Task<float> bothPointsTask;
			float singlePoints;

			try
			{
				// Use divide and conquer for efficiency
				bothPointsTask = GetPointsAsync(teamToCheck, againstTeam, Double, GameRepository.GetGames);
				singlePoints = GetPoints(teamToCheck, Single, GameRepository.GetGames(teamToCheck).ToArray().Select(Mapper.Map));
				bothPointsTask.Wait();
			}
			catch (AggregateException exception)
			{
				throw new LogicException("Task threw an exception", exception);
			}

			var bothPoints = bothPointsTask.Result;
			return (singlePoints + bothPoints)/MaxPoints;
		}

		private Task<float> GetPointsAsync(string teamToCheck, string againstTeam, Points points, Func<string, string, IEnumerable<Game>> getGames)
		{
			// Return a task which calculates the probability of a LINQ to SQL query for performance optimization
			return
				Task.Run(
					() =>
						GetPoints(teamToCheck, points,
							getGames(teamToCheck, againstTeam).ToArray().Select(Mapper.Map)));
		}

		private Task<float> GetPointsAsync(string teamToCheck, Points pointsToAdd, IEnumerable<GameDto> gameDtos)
		{
			return Task.Run(() => GetPoints(teamToCheck, pointsToAdd, gameDtos));
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
				var scoreToCheck = game.Team1 == teamToCheck
					? game.Score1
					: game.Score2;
				var scoreToCheckAgainst = game.Team2 == teamToCheck
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