using System;
using System.ServiceModel;

namespace FetchMe.Service.Interface
{
	[ServiceContract]
	public interface IGameService
	{
		[OperationContract]
		float GetWinningProbability(string fromTeam, string againstTeam);
		[OperationContract]
		float GetWinningProbability(string fromTeam, string againstTeam, DateTime gamesBeginningFrom);
		[OperationContract]
		float GetWinningProbability(string fromTeam, string againstTeam, DateTime gamesBeginningFrom, DateTime gamesEndingIn);
	}
}