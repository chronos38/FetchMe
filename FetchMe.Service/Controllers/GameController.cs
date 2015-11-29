using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FetchMe.Logic.Interface;
using Microsoft.Practices.Unity;

namespace FetchMe.Service.Controllers
{
    public class GameController : ApiController
    {
	    public IHttpActionResult ComputeProbability(string fromFirstTeam, string againstSecondTeam)
	    {
		    if (string.IsNullOrEmpty(fromFirstTeam) || string.IsNullOrEmpty(againstSecondTeam))
		    {
			    return BadRequest();
		    }

		    var teamNameResolver = WebApiApplication.Container.Resolve<ITeamNameResolver>();

		    var team1 = teamNameResolver.ResolveTeamName(fromFirstTeam);
		    if (team1 == null)
		    {
			    return NotFound();
		    }

		    var team2 = teamNameResolver.ResolveTeamName(againstSecondTeam);
		    if (team2 == null)
		    {
			    return NotFound();
		    }

			var probabilityUnit = WebApiApplication.Container.Resolve<IProbabiltyStrategy>();
		    var result = probabilityUnit.Compute(team1, team2);
		    return result == null ? (IHttpActionResult) NotFound() : Ok(result.Value);
	    }
	}
}
