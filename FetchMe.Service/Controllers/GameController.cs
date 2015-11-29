using System;
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

		    try
			{
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
				return result == null
					? NotFound() as IHttpActionResult
					: Ok(result.Value);
			}
		    catch (Exception exception)
		    {
			    return InternalServerError(exception);
		    }
	    }
	}
}
