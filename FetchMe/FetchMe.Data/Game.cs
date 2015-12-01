using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FetchMe.Data
{
	public class Game
	{
		[Key]
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int Score1 { get; set; }
		public int Score2 { get; set; }
		public string Team1 { get; set; }
		public string Team2 { get; set; }
	}
}