using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class TeamMemberDto
	{
		public int Id { get; set; }
		public string Club { get; set; }
		public string Name { get; set; }
	}
}