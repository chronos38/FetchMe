using System;
using System.Collections.Generic;
using FetchMe.Dto;

namespace FetchMe.Data.Interface
{
	public interface IGameRepository
	{
		int AddGame(GameDto game);
		IEnumerable<GameDto> GetGames(string fromTeam);
		IEnumerable<GameDto> GetGames(string fromFirstTeam, string againstSecondTeam);
	}
}