using System;
using FetchMe.Data.Interface;
using FetchMe.Dto;
using FetchMe.Logic.Interface;

namespace FetchMe.Logic
{
	public class TeamNameResolver : ITeamNameResolver
	{
		private ITeamRepository TeamRepository { get; }

		public TeamNameResolver(ITeamRepository repository)
		{
			TeamRepository = repository;
		}

		public TeamDto ResolveTeamName(string teamName)
		{
			try
			{
				return TeamRepository.GetTeam(teamName);
			}
			catch (Exception exception)
			{
				throw new LogicException("Could not resolve team name", exception);
			}
		}
	}
}