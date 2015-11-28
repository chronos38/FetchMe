using System.Collections.Generic;

namespace FetchMe.DataService.Shared.Interface
{
	public class GameDataDto
	{
		public int Id { get; set; }
		public string ClubName { get; set; }
		public IEnumerable<TeamMemberDto> Lineup { get; set; }
		public IEnumerable<ReplacementDto> Replacements { get; set; }
		public IEnumerable<TeamMemberDto> YellowCards { get; set; }
		public IEnumerable<TeamMemberDto> RedCards { get; set; }
		public string Trainer { get; set; }
	}
}