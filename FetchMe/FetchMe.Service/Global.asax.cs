﻿using System.Web;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace FetchMe.Service
{
    public class Application : HttpApplication
    {
		public static IUnityContainer Container { get; set; }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
	        Container = new UnityContainer().LoadConfiguration();
        }
    }
}
