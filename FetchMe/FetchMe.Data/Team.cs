using System.ComponentModel.DataAnnotations;

namespace FetchMe.Data
{
	public class Team
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
	}
}