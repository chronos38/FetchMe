using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FetchMe.Service.Interface
{
	[DataContract]
	public class Game
	{
		[DataMember]
		public string ClubName { get; set; }
		[DataMember]
		public DateTime Date { get; set; }
		[DataMember]
		public int Minutes { get; set; }
		[DataMember]
		public string EndResult { get; set; }
		[DataMember]
		public IEnumerable<Goal> Goals { get; set; }
		[DataMember]
		public IEnumerable<GameData> Data { get; set; }
	}
}