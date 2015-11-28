using ProtoBuf;

namespace FetchMe.DataService.Shared.ProtoBuf
{
	[ProtoContract]
	public class Goal
	{
		[ProtoMember(1)]
		public TeamMember Goalscrorer { get; set; }
		[ProtoMember(2)]
		public int Minute { get; set; }
	}
}