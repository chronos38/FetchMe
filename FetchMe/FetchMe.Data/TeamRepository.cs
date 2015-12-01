using System;
using System.Collections.Generic;
using System.Linq;
using FetchMe.Data.Interface;
using FetchMe.Dto;

namespace FetchMe.Data
{
	public class TeamRepository : ITeamRepository
	{
		private FetchMeContext Model { get; }

		public TeamRepository(FetchMeContext model)
		{
			Model = model;
		}

		public void AddTeam(TeamDto teamDto)
		{
			teamDto.Id = Model.Teams.Add(Mapper.Map(teamDto)).Id;
		}

		public TeamDto GetTeam(int id)
		{
			return (from t in Model.Teams where t.Id == id select Mapper.Map(t)).FirstOrDefault();
		}

		public TeamDto GetTeam(string name)
		{
			return
				(from t in Model.Teams
					where string.Equals(t.Name, name, StringComparison.CurrentCultureIgnoreCase)
					select Mapper.Map(t)).FirstOrDefault();
		}

		public IEnumerable<TeamDto> GetTeams(string country)
		{
			return from t in Model.Teams
				where string.Equals(t.Country, country, StringComparison.CurrentCultureIgnoreCase)
				select Mapper.Map(t);
		}

		public IEnumerable<TeamDto> GetAllTeams()
		{
			return from t in Model.Teams select Mapper.Map(t);
		}
	}
}