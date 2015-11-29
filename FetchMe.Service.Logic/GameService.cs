using System;
using System.ServiceModel.Web;
using FetchMe.Service.Interface;

namespace FetchMe.Service.Logic
{
	public class GameService : IGameService
	{
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "{fromTeam}/{againstTeam}")]
		public float GetWinningProbability(string fromTeam, string againstTeam)
		{
			throw new NotImplementedException();
		}

		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "{fromTeam}/{againstTeam}/{gamesBeginningFrom}")]
		public float GetWinningProbability(string fromTeam, string againstTeam, DateTime gamesBeginningFrom)
		{
			throw new NotImplementedException();
		}

		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "{fromTeam}/{againstTeam}/{gamesBeginningFrom}/{gamesEndingIn}")]
		public float GetWinningProbability(string fromTeam, string againstTeam, DateTime gamesBeginningFrom, DateTime gamesEndingIn)
		{
			throw new NotImplementedException();
		}
	}
}