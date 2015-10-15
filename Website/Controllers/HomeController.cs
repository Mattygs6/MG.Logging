namespace Website.Controllers
{
	using System.Web.Mvc;

	using MG.Logging;

	public class HomeController : Controller
	{
		private readonly ILoggingManager loggingManager;

		public HomeController(ILoggingManager loggingManager)
		{
			this.loggingManager = loggingManager;
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			this.loggingManager.Info(this, "User clicked on contact {0}", HttpContext.Request.UserHostAddress);
			return View();
		}

		public ActionResult Index()
		{
			return View();
		}
	}
}