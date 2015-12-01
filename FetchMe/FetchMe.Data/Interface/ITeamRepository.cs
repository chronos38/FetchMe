using System.Collections.Generic;
using FetchMe.Dto;

namespace FetchMe.Data.Interface
{
	public interface ITeamRepository
	{
		void AddTeam(TeamDto team);
		TeamDto GetTeam(int id);
		TeamDto GetTeam(string name);
		IEnumerable<TeamDto> GetTeams(string country);
		IEnumerable<TeamDto> GetAllTeams();
	}
}