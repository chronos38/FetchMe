namespace FetchMe.Service.Models
{
	public class Replacement
	{
		public TeamMember In { get; set; }
		public TeamMember Out { get; set; }
		public int Minute { get; set; }
	}
}