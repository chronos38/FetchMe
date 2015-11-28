using ProtoBuf;

namespace FetchMe.DataService.Shared.ProtoBuf
{
	[ProtoContract]
	public class Replacement
	{
		[ProtoMember(1)]
		public TeamMember In { get; set; }
		[ProtoMember(2)]
		public TeamMember Out { get; set; }
		[ProtoMember(3)]
		public int Minute { get; set; }
	}
}