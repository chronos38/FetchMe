using System.ComponentModel.DataAnnotations;

namespace FetchMe.Data
{
	public class Score
	{
		[Key]
		public int Id { get; set; }
		public int Score1 { get; set; }
		public int Score2 { get; set; }
	}
}