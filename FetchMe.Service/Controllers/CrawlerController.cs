using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FetchMe.Service.Models;

namespace FetchMe.Service.Controllers
{
    public class CrawlerController : ApiController
    {
	    public void AddGame([FromBody]Game game)
	    {
			throw new NotImplementedException();
	    }
    }
}
