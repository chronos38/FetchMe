using System.Collections.Generic;

namespace FetchMe.Service.Models
{
	public class GameData
	{
		/// <summary>
		/// Required
		/// </summary>
		public string Team { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public IEnumerable<string> Lineup { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public IEnumerable<Replacement> Replacements { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public IEnumerable<string> YellowCards { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public IEnumerable<string> RedCards { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public string Trainer { get; set; }
	}
}