using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace FetchMe.Service.Tests
{
	public static class Global
	{
		private static readonly Lazy<UnityContainer> _container = new Lazy<UnityContainer>(); 
		public static IUnityContainer Container => _container.IsValueCreated ? _container.Value : _container.Value.LoadConfiguration();
	}
}