using System;
using System.Collections.Generic;

namespace FetchMe.Service.Models
{
	public class Game
	{
		/// <summary>
		/// Required
		/// </summary>
		public DateTime Date { get; set; }
		/// <summary>
		/// At least zero
		/// </summary>
		public int Minutes { get; set; }
		/// <summary>
		/// Required
		/// </summary>
		public int Score1 { get; set; }
		/// <summary>
		/// Required
		/// </summary>
		public int Score2 { get; set; }
		/// <summary>
		/// Required
		/// </summary>
		public GameData Team1 { get; set; }
		/// <summary>
		/// Required
		/// </summary>
		public GameData Team2 { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public IEnumerable<Goal> Goals { get; set; }
	}
}