using System.Web.Mvc;
using Kona.App.Services;

namespace Kona.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        IStoreService _service;

        public HomeController(IStoreService service) {
            _service = service;
        }

        public ActionResult Index()
        {
            var model = _service.GetHomeModel(33);
            //return Content("Success");
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
