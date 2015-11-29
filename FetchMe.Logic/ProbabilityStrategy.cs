using System;
using FetchMe.Dto;
using FetchMe.Logic.Interface;

namespace FetchMe.Logic
{
	public class ProbabilityStrategy : IProbabilityStrategy
	{
		public float? Compute(TeamDto team1, TeamDto team2)
		{
			throw new NotImplementedException();
		}
	}
}