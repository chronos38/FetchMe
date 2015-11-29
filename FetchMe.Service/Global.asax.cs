using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace FetchMe.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
		public static IUnityContainer Container { get; set; }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
	        Container = new UnityContainer().LoadConfiguration();
        }
    }
}
