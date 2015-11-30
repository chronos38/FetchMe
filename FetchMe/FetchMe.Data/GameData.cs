using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FetchMe.Data
{
	public class GameData
	{
		[Key]
		public int Id { get; set; }
		public virtual Team Team { get; set; }
		public virtual IEnumerable<TeamMember> Lineup { get; set; }
		public virtual IEnumerable<Replacement> Replacements { get; set; }
		public virtual IEnumerable<TeamMember> YellowCards { get; set; }
		public virtual IEnumerable<TeamMember> RedCards { get; set; }
		public string Trainer { get; set; }
	}
}