namespace FetchMe.DataService.Shared.Interface
{
	public class GoalDto
	{
		public int Id { get; set; }
		public TeamMemberDto Goalscrorer { get; set; }
		public int Minute { get; set; }
	}
}