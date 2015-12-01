using System;
using FetchMe.Data;
using FetchMe.Data.Interface;
using FetchMe.Dto;
using FetchMe.Logic.Interface;

namespace FetchMe.Logic
{
	public class TeamNameResolver : ITeamNameResolver
	{
		private ITeamSynonyms TeamSynonyms { get; }
		private ITeamRepository TeamRepository { get; }

		public TeamNameResolver(ITeamSynonyms teamSynonyms, ITeamRepository repository)
		{
			TeamSynonyms = teamSynonyms;
			TeamRepository = repository;
		}

		public TeamDto ResolveTeamName(string teamName)
		{
			try
			{
				var team = TeamSynonyms.ResolveSynonym(teamName);
				var result = TeamRepository.GetTeam(team);

				if (result == null)
				{
					throw new NullReferenceException("Return value is null");
				}

				return Mapper.Map(result);
			}
			catch (Exception exception)
			{
				throw new LogicException("Could not resolve team name", exception);
			}
		}
	}
}