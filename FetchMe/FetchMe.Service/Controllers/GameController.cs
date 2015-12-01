using System;
using System.Web.Http;
using FetchMe.Logic.Interface;
using Microsoft.Practices.Unity;

namespace FetchMe.Service.Controllers
{
    public class GameController : ApiController
    {
		// GET: api/game?fromFirstTeam=...&againstSecondTeam=...
	    public IHttpActionResult Get(string fromFirstTeam, string againstSecondTeam)
	    {
		    if (string.IsNullOrEmpty(fromFirstTeam) || string.IsNullOrEmpty(againstSecondTeam))
		    {
			    return BadRequest();
		    }

		    try
			{
				var teamNameResolver = Application.Container.Resolve<ITeamNameResolver>();

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

				var probabilityUnit = Application.Container.Resolve<IProbabilityStrategy>();
				var result = probabilityUnit.Compute(team1, team2);
				return Ok(result);
			}
		    catch (Exception exception)
		    {
			    return InternalServerError(exception);
		    }
	    }
	}
}
