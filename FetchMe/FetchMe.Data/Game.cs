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
		public int Minutes { get; set; }
		public virtual Score Score { get; set; }
		public virtual IEnumerable<Goal> Goals { get; set; }
		public virtual GameData Team1 { get; set; }
		public virtual GameData Team2 { get; set; }
	}
}