using System.Runtime.Serialization;

namespace FetchMe.Service.Interface
{
	[DataContract]
	public class Replacement
	{
		[DataMember]
		public TeamMember In { get; set; }
		[DataMember]
		public TeamMember Out { get; set; }
		[DataMember]
		public int Minute { get; set; }
	}
}