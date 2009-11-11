using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kona.App.Services;
using Kona.Model;
using NHibernate;

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

            var model = _service.GetHomeModel();
            //return Content("Success");
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
