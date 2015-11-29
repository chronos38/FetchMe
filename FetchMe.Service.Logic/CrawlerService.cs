using System.ServiceModel.Web;
using FetchMe.Service.Interface;

namespace FetchMe.Service.Logic
{
	public class CrawlerService : ICrawlerService
	{
		[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json)]
		public void AddGame(Game game)
		{
			throw new System.NotImplementedException();
		}
	}
}