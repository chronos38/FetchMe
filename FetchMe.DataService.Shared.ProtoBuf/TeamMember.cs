using ProtoBuf;

namespace FetchMe.DataService.Shared.ProtoBuf
{
	[ProtoContract]
	public class TeamMember
	{
		[ProtoMember(1)]
		public string Club { get; set; }
		[ProtoMember(2)]
		public string Name { get; set; }
	}
}