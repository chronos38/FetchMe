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

		public TeamNameResolver(ITeamSynonyms teamSynonyms)
		{
			TeamSynonyms = teamSynonyms;
		}

		public string ResolveTeamName(string teamName)
		{
			try
			{
				return TeamSynonyms.ResolveSynonym(teamName);
			}
			catch (Exception exception)
			{
				throw new LogicException("Could not resolve team name", exception);
			}
		}
	}
}