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
		public string Team1 { get; set; }
		/// <summary>
		/// Required
		/// </summary>
		public string Team2 { get; set; }
	}
}