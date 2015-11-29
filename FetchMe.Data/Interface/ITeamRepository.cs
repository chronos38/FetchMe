using System.Collections.Generic;
using FetchMe.Dto;

namespace FetchMe.Data.Interface
{
	public interface ITeamRepository
	{
		int AddTeam(TeamDto team);
		TeamDto GetTeam(int id);
		TeamDto GetTeam(string name);
		IEnumerable<TeamDto> GetTeams(string country);
	}
}