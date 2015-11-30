using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FetchMe.Data.Interface;
using FetchMe.Dto;
using FetchMe.Logic.Interface;

namespace FetchMe.Logic
{
	public class ProbabilityStrategy : IProbabilityStrategy
	{
		private const float MaxPoints = 75.0f;
		private IGameRepository GameRepository { get; set; }

		public ProbabilityStrategy(IGameRepository gameRepository)
		{
			GameRepository = gameRepository;
		}

		public float Compute(TeamDto teamToCheck, TeamDto againstTeam)
		{
			var bothPoints = GetPointsForBothTeamsAsync(GameRepository.GetGames(teamToCheck, againstTeam));
			var singlePoints = GetPointsForSingleTeam(GameRepository.GetGames(teamToCheck));
			return (singlePoints + bothPoints.Result)/MaxPoints;
		}

		private async Task<float> GetPointsForSingleTeamAsync(IEnumerable<GameDto> games)
		{
			return GetPointsForSingleTeam(games);
		}

		private async Task<float> GetPointsForBothTeamsAsync(IEnumerable<GameDto> games)
		{
			return GetPointsForBothTeams(games);
		}

		private float GetPointsForSingleTeam(IEnumerable<GameDto> games)
		{
			throw new NotImplementedException();
		}

		private float GetPointsForBothTeams(IEnumerable<GameDto> games)
		{
			throw new NotImplementedException();
		}
	}
}