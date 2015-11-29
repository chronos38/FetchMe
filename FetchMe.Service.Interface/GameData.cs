using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FetchMe.Service.Interface
{
	[DataContract]
	public class GameData
	{
		[DataMember]
		public string ClubName { get; set; }
		[DataMember]
		public IEnumerable<TeamMember> Lineup { get; set; }
		[DataMember]
		public IEnumerable<Replacement> Replacements { get; set; }
		[DataMember]
		public IEnumerable<TeamMember> YellowCards { get; set; }
		[DataMember]
		public IEnumerable<TeamMember> RedCards { get; set; }
		[DataMember]
		public string Trainer { get; set; }
	}
}