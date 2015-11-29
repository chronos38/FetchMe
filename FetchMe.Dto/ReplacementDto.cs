using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class ReplacementDto
	{
		public int Id { get; set; }
		public TeamMemberDto In { get; set; }
		public TeamMemberDto Out { get; set; }
		public int Minute { get; set; }
	}
}