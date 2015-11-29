using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class TeamMemberDto
	{
		public int Id { get; set; }
		public TeamDto Team { get; set; }
		public string Name { get; set; }
	}
}