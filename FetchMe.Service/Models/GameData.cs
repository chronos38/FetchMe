using System.Collections.Generic;

namespace FetchMe.Service.Models
{
	public class GameData
	{
		public string ClubName { get; set; }
		public IEnumerable<TeamMember> Lineup { get; set; }
		public IEnumerable<Replacement> Replacements { get; set; }
		public IEnumerable<TeamMember> YellowCards { get; set; }
		public IEnumerable<TeamMember> RedCards { get; set; }
		public string Trainer { get; set; }
	}
}