using System;
using System.Collections.Generic;

namespace FetchMe.Dto
{
	[Serializable]
	public class GameDto
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int Minutes { get; set; }
		public string EndResult { get; set; }
		public IEnumerable<GoalDto> Goals { get; set; }
		public IEnumerable<GameDataDto> Data { get; set; }
	}
}
