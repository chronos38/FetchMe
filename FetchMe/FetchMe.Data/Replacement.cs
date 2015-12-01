using System.ComponentModel.DataAnnotations;

namespace FetchMe.Data
{
	public class Replacement
	{
		[Key]
		public int Id { get; set; }
		public virtual string In { get; set; }
		public virtual string Out { get; set; }
		public int Minute { get; set; }
	}
}