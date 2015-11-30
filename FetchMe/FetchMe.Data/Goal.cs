using System.ComponentModel.DataAnnotations;

namespace FetchMe.Data
{
	public class Goal
	{
		[Key]
		public int Id { get; set; }
		public virtual TeamMember Goalscrorer { get; set; }
		public int Minute { get; set; }
	}
}