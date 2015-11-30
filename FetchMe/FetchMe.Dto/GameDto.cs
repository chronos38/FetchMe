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
		public ScoreDto Score { get; set; }
		public IEnumerable<GoalDto> Goals { get; set; }
		public GameDataDto Team1 { get; set; }
		public GameDataDto Team2 { get; set; }
	}
}
