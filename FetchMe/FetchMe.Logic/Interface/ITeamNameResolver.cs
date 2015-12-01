using System.Collections.Generic;
using FetchMe.Dto;

namespace FetchMe.Logic.Interface
{
	public interface ITeamNameResolver
	{
		TeamDto ResolveTeamName(string teamName);
		IEnumerable<TeamDto> AvailableTeams();
	}
}