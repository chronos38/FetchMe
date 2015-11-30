﻿using System;
using System.Collections.Generic;
using System.Linq;
using FetchMe.Dto;
using FetchMe.Service.Models;

namespace FetchMe.Service
{
	public static class Mapper
	{
		public static void Configure()
		{
			AutoMapper.Mapper.CreateMap<Game, GameDto>();
			AutoMapper.Mapper.CreateMap<GameData, GameDataDto>();
			AutoMapper.Mapper.CreateMap<Score, ScoreDto>();
			AutoMapper.Mapper.CreateMap<TeamMember, TeamMemberDto>();
			AutoMapper.Mapper.CreateMap<Replacement, ReplacementDto>();
			AutoMapper.Mapper.CreateMap<Team, TeamDto>();
		}

		public static GameDto Map(Game game)
		{
			try
			{
				return AutoMapper.Mapper.Map<GameDto>(game);
			}
			catch (Exception exception)
			{
				throw new ServiceException("AutoMapper failed to map type Game to type GameDto", exception);
			}
		}
	}
}