using System.ComponentModel.DataAnnotations;

namespace FetchMe.Data
{
	public class Replacement
	{
		[Key]
		public int Id { get; set; }
		public virtual TeamMember In { get; set; }
		public virtual TeamMember Out { get; set; }
		public int Minute { get; set; }
	}
}