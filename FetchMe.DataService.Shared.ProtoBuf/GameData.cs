using System.Collections.Generic;
using ProtoBuf;

namespace FetchMe.DataService.Shared.ProtoBuf
{
	[ProtoContract]
	public class GameData
	{
		[ProtoMember(1)]
		public string ClubName { get; set; }
		[ProtoMember(2)]
		public IEnumerable<TeamMember> Lineup { get; set; }
		[ProtoMember(3)]
		public IEnumerable<Replacement> Replacements { get; set; }
		[ProtoMember(4)]
		public IEnumerable<TeamMember> YellowCards { get; set; }
		[ProtoMember(5)]
		public IEnumerable<TeamMember> RedCards { get; set; }
		[ProtoMember(6)]
		public string Trainer { get; set; }
	}
}
