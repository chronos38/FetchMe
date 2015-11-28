using System;
using System.Collections.Generic;

namespace FetchMe.DataService.Shared.Interface
{
	public interface IGameRepository
	{
		GameDto GetGame(string fromTeam);
		GameDto GetGame(string firstTeam, string secondTeam);
		IEnumerable<GameDto> GetGames(string fromTeam);
		IEnumerable<GameDto> GetGames(string fromTeam, DateTime startingFromDate);
		IEnumerable<GameDto> GetGames(string fromTeam, DateTime fromDate, DateTime toDate);
		IEnumerable<GameDto> GetGames(DateTime startinFromDate);
		IEnumerable<GameDto> GetGames(DateTime fromDate, DateTime toDate);
		IEnumerable<GameDto> GetGames(string firstTeam, string secondTeam);
		IEnumerable<GameDto> GetGames(string firstTeam, string secondTeam, DateTime startingFromDate);
		IEnumerable<GameDto> GetGames(string firstTeam, string secondTeam, DateTime fromDate, DateTime toDate);
		int InsertGame(GameDto game);
		void UpdateGAme(GameDto game);
		void DeleteGame(GameDto game);
	}
}
