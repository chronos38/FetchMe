using System;
using System.Collections.Generic;

namespace FetchMe.Dto
{
	[Serializable]
	public class GameDataDto
	{
		public int Id { get; set; }
		public TeamDto Team { get; set; }
		public IEnumerable<TeamMemberDto> Lineup { get; set; }
		public IEnumerable<ReplacementDto> Replacements { get; set; }
		public IEnumerable<TeamMemberDto> YellowCards { get; set; }
		public IEnumerable<TeamMemberDto> RedCards { get; set; }
		public string Trainer { get; set; }
	}
}