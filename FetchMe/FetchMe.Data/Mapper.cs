using FetchMe.Dto;

namespace FetchMe.Data
{
	public static class Mapper
	{
		static Mapper()
		{
			AutoMapper.Mapper.CreateMap<GameDto, Game>().ReverseMap();
			AutoMapper.Mapper.CreateMap<GameDataDto, GameData>().ReverseMap();
			AutoMapper.Mapper.CreateMap<ScoreDto, Score>().ReverseMap();
			AutoMapper.Mapper.CreateMap<TeamMemberDto, TeamMember>().ReverseMap();
			AutoMapper.Mapper.CreateMap<ReplacementDto, Replacement>().ReverseMap();
			AutoMapper.Mapper.CreateMap<TeamDto, Team>().ReverseMap();
			AutoMapper.Mapper.CreateMap<GoalDto, Goal>().ReverseMap();
		}

		public static GameDto Map(Game data)
		{
			return AutoMapper.Mapper.Map<GameDto>(data);
		}

		public static GameDataDto Map(GameData data)
		{
			return AutoMapper.Mapper.Map<GameDataDto>(data);
		}

		public static ScoreDto Map(Score data)
		{
			return AutoMapper.Mapper.Map<ScoreDto>(data);
		}

		public static TeamMemberDto Map(TeamMember data)
		{
			return AutoMapper.Mapper.Map<TeamMemberDto>(data);
		}

		public static ReplacementDto Map(Replacement data)
		{
			return AutoMapper.Mapper.Map<ReplacementDto>(data);
		}

		public static TeamDto Map(Team data)
		{
			return AutoMapper.Mapper.Map<TeamDto>(data);
		}

		public static GoalDto Map(Goal data)
		{
			return AutoMapper.Mapper.Map<GoalDto>(data);
		}

		public static Game Map(GameDto dto)
		{
			return AutoMapper.Mapper.Map<Game>(dto);
		}

		public static GameData Map(GameDataDto dto)
		{
			return AutoMapper.Mapper.Map<GameData>(dto);
		}

		public static Score Map(ScoreDto dto)
		{
			return AutoMapper.Mapper.Map<Score>(dto);
		}

		public static TeamMember Map(TeamMemberDto dto)
		{
			return AutoMapper.Mapper.Map<TeamMember>(dto);
		}

		public static Replacement Map(ReplacementDto dto)
		{
			return AutoMapper.Mapper.Map<Replacement>(dto);
		}

		public static Team Map(TeamDto dto)
		{
			return AutoMapper.Mapper.Map<Team>(dto);
		}

		public static Goal Map(GoalDto dto)
		{
			return AutoMapper.Mapper.Map<Goal>(dto);
		}
	}
}