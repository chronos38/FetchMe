using System.ComponentModel.DataAnnotations;
using FetchMe.Dto;

namespace FetchMe.Data
{
	public class TeamMember
	{
		[Key]
		public int Id { get; set; }
		public virtual Team Team { get; set; }
		public string Name { get; set; }
	}
}