using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FetchMe.Data
{
	public class GameData
	{
		[Key]
		public int Id { get; set; }
		public virtual string Team { get; set; }
		public virtual IEnumerable<string> Lineup { get; set; }
		public virtual IEnumerable<Replacement> Replacements { get; set; }
		public virtual IEnumerable<string> YellowCards { get; set; }
		public virtual IEnumerable<string> RedCards { get; set; }
		public string Trainer { get; set; }
	}
}