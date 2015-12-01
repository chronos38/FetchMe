using System;
using System.Collections.Generic;
using System.Linq;
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
				return Mapper.Map(TeamRepository.GetTeam(team));
			}
			catch (Exception exception)
			{
				throw new LogicException("Could not resolve team name", exception);
			}
		}

		public IEnumerable<TeamDto> AvailableTeams()
		{
			try
			{
				return TeamRepository.GetAllTeams().ToArray().Select(Mapper.Map);
			}
			catch (Exception exception)
			{
				throw new LogicException("Could not resolve team name", exception);
			}
		} 
	}
}