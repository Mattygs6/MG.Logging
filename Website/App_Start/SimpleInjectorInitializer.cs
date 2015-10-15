namespace Website
{
	using System.Reflection;
	using System.Web.Mvc;

	using MG.Logging;
	using MG.Logging.NLog;

	using SimpleInjector;
	using SimpleInjector.Integration.Web;
	using SimpleInjector.Integration.Web.Mvc;

	public static class SimpleInjectorManager
	{
		public static readonly Container Container = new Container();
	}

	public static class SimpleInjectorInitializer
	{
		/// <summary>Initialize the container and register it as Dependency Resolver.</summary>
		public static void Initialize()
		{
			SimpleInjectorWebInitializer.Initialize();

			InitializeContainer(SimpleInjectorManager.Container);

			SimpleInjectorManager.Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

			SimpleInjectorManager.Container.RegisterMvcIntegratedFilterProvider();

			SimpleInjectorManager.Container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(SimpleInjectorManager.Container));
		}

		private static void InitializeContainer(Container container)
		{
			// Logging manager
			container.Register(
				typeof(ILoggingManager),
				() => new LoggingManager(new ILoggingProvider[] { new NLogLoggingProvider() }),
				Lifestyle.Singleton);
		}
	}
}