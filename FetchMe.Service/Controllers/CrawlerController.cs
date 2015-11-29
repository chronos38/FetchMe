using System;
using System.Web.Http;
using FetchMe.Logic.Interface;
using FetchMe.Service.Models;
using Microsoft.Practices.Unity;

namespace FetchMe.Service.Controllers
{
    public class CrawlerController : ApiController
    {
	    public IHttpActionResult AddGame([FromBody]Game game)
	    {
		    if (game == null)
		    {
			    return BadRequest();
		    }

		    try
		    {
			    var gameValidator = WebApiApplication.Container.Resolve<IGameValidation>();
			    var gameDto = Mapper.Map(game);
			    return gameValidator.ValidateAndAdd(gameDto)
				    ? Ok() as IHttpActionResult
				    : BadRequest();
		    }
		    catch (ServiceException exception)
		    {
			    return BadRequest(exception.Message);
		    }
		    catch (Exception exception)
		    {
				return InternalServerError(exception);
		    }
	    }
    }
}
