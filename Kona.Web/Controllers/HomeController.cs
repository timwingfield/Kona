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
        StoreService _service;
        ISession _session;

        public HomeController(ISession session) {
            _session = session;
            _service = new StoreService(session);
        }

        public ActionResult Index()
        {

            var stuff = _session.CreateCriteria<Category>()
                .List<Category>();
            
            foreach (var cat in stuff) {
                var products = cat.Products.Count;
            }


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
