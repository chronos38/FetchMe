using System.Collections.Generic;
using ProtoBuf;

namespace FetchMe.DataService.Shared.ProtoBuf
{
	[ProtoContract]
	public class Game
	{
		[ProtoMember(1)]
		public string Date { get; set; }
		[ProtoMember(2)]
		public int Minutes { get; set; }
		[ProtoMember(3)]
		public string EndResult { get; set; }
		[ProtoMember(4)]
		public IEnumerable<Goal> Goals { get; set; }
		[ProtoMember(5)]
		public IEnumerable<GameData> Data { get; set; }
	}
}
