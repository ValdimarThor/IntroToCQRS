using System.Web.Mvc;
using Core.Messaging;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceBus _bus;

        public HomeController(IServiceBus bus)
        {
            _bus = bus;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
