namespace FetchMe.DataService.Shared.Interface
{
	public class ReplacementDto
	{
		public int Id { get; set; }
		public TeamMemberDto In { get; set; }
		public TeamMemberDto Out { get; set; }
		public int Minute { get; set; }
	}
}