using System;
using System.Collections.Generic;
using FetchMe.Dto;

namespace FetchMe.Data.Interface
{
	public interface IGameRepository
	{
		void AddGame(Game game);
		IEnumerable<Game> GetGames(string fromTeam);
		IEnumerable<Game> GetGames(string fromFirstTeam, string againstSecondTeam);
	}
}