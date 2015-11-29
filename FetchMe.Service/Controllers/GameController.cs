using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FetchMe.Service.Controllers
{
    public class GameController : ApiController
    {
	    public float ComputeProbability(string fromFirstTeam, string againstSecondTeam)
	    {
		    throw new NotImplementedException();
	    }

		public float ComputeProbability(string fromFirstTeam, string againstSecondTeam, DateTime startingFromDate)
		{
			throw new NotImplementedException();
		}

		public float ComputeProbability(string fromFirstTeam, string againstSecondTeam, DateTime startingFromDate, DateTime endOnDate)
		{
			throw new NotImplementedException();
		}
	}
}
