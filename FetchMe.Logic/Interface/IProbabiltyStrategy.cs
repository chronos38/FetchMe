using FetchMe.Dto;
using System;

namespace FetchMe.Logic.Interface
{
	public interface IProbabiltyStrategy
	{
		float? Compute(TeamDto team1, TeamDto team2);
	}
}