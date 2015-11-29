using System.Runtime.Serialization;

namespace FetchMe.Service.Interface
{
	[DataContract]
	public class TeamMember
	{
		[DataMember]
		public string Club { get; set; }
		[DataMember]
		public string Name { get; set; }
	}
}