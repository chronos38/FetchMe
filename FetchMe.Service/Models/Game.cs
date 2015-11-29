using System;
using System.Collections.Generic;

namespace FetchMe.Service.Models
{
	public class Game
	{
		public string ClubName { get; set; }
		public DateTime Date { get; set; }
		public int Minutes { get; set; }
		public string EndResult { get; set; }
		public IEnumerable<Goal> Goals { get; set; }
		public IEnumerable<GameData> Data { get; set; }
	}
}