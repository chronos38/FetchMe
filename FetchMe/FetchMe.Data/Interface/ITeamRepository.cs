using System.Collections.Generic;
using FetchMe.Dto;

namespace FetchMe.Data.Interface
{
	public interface ITeamRepository
	{
		void AddTeam(Team team);
		Team GetTeam(int id);
		Team GetTeam(string name);
		IEnumerable<Team> GetTeams(string country);
		IEnumerable<Team> GetAllTeams();
	}
}