using System;
using FetchMe.Dto;
using FetchMe.Logic.Interface;

namespace FetchMe.Logic
{
	public class ProbabilityStrategy : IProbabilityStrategy
	{
		public float? Compute(TeamDto lhs, TeamDto rhs)
		{
			throw new NotImplementedException();
		}
	}
}