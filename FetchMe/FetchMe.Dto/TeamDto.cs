using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class TeamDto
	{
		public int Id { get; set; }
		public string Name { get; set; } 
		public string Country { get; set; }
	}
}