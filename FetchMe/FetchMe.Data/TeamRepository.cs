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

		public void AddTeam(Team team)
		{
			Model.Teams.Add(team);
		}

		public Team GetTeam(int id)
		{
			return (from t in Model.Teams where t.Id == id select t).FirstOrDefault();
		}

		public Team GetTeam(string name)
		{
			return (from t in Model.Teams where t.Name == name select t).FirstOrDefault();
		}

		public IEnumerable<Team> GetTeams(string country)
		{
			return from t in Model.Teams where t.Country == country select t;
		}

		public IEnumerable<Team> GetAllTeams()
		{
			return from t in Model.Teams select t;
		}
	}
}