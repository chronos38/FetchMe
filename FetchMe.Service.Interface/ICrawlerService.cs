using System.ServiceModel;

namespace FetchMe.Service.Interface
{
	[ServiceContract]
	public interface ICrawlerService
	{
		[OperationContract]
		void AddGame(Game game);
	}
}