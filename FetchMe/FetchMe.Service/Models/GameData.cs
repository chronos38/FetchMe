using System.Collections.Generic;

namespace FetchMe.Service.Models
{
	public class GameData
	{
		/// <summary>
		/// Required
		/// </summary>
		public Team Team { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public IEnumerable<TeamMember> Lineup { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public IEnumerable<Replacement> Replacements { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public IEnumerable<TeamMember> YellowCards { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public IEnumerable<TeamMember> RedCards { get; set; }
		/// <summary>
		/// Optional
		/// </summary>
		public string Trainer { get; set; }
	}
}