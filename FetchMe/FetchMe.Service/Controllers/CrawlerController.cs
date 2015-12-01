using System;
using System.Web.Http;
using System.Web.Script.Serialization;
using FetchMe.Logic.Interface;
using FetchMe.Service.Models;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;

namespace FetchMe.Service.Controllers
{
    public class CrawlerController : ApiController
    {
		// POST: api/crawler
	    public IHttpActionResult Post([FromBody]Game game)
	    {
		    if (game == null)
		    {
			    return BadRequest();
		    }

		    try
		    {
			    var gameValidator = Application.Container.Resolve<IGameValidation>();
			    var gameDto = Mapper.Map(game);
			    return gameValidator.ValidateAndAdd(gameDto)
				    ? Ok() as IHttpActionResult
				    : BadRequest();
		    }
		    catch (Exception exception)
		    {
				return InternalServerError(exception);
		    }
	    }
    }
}
