using System.Runtime.Serialization;

namespace FetchMe.Service.Interface
{
	[DataContract]
	public class Goal
	{
		[DataMember]
		public TeamMember Goalscrorer { get; set; }
		[DataMember]
		public int Minute { get; set; }
	}
}