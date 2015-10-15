using Microsoft.Owin;

using Website;

[assembly: OwinStartup(typeof(Startup))]

namespace Website
{
	using MG.Logging.Owin.Logging;

	using Owin;

	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
			app.UseLoggingManager();
		}
	}
}