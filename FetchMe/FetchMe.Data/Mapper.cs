using FetchMe.Dto;

namespace FetchMe.Data
{
	public static class Mapper
	{
		static Mapper()
		{
			AutoMapper.Mapper.CreateMap<GameDto, Game>().ReverseMap();
		}

		public static GameDto Map(Game data)
		{
			return AutoMapper.Mapper.Map<GameDto>(data);
		}

		public static Game Map(GameDto dto)
		{
			return AutoMapper.Mapper.Map<Game>(dto);
		}
	}
}