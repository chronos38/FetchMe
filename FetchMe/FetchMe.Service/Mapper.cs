using System;
using System.Collections.Generic;
using System.Linq;
using FetchMe.Dto;
using FetchMe.Service.Models;

namespace FetchMe.Service
{
	public static class Mapper
	{
		static Mapper()
		{
			AutoMapper.Mapper.CreateMap<Game, GameDto>();
		}

		public static GameDto Map(Game game)
		{
			return AutoMapper.Mapper.Map<GameDto>(game);
		}
	}
}