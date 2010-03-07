using System.Web.Mvc;
using Kona.App.Services;
using Kona.ViewModels;

namespace Kona.Controllers
{
    public class ProductController : Controller
    {
        IStoreService _service;

        public ProductController(IStoreService service)
        {
            _service = service;
        }

        public ActionResult Search(string query)
        {
            return Content("hook me up");
        }

        public ActionResult Index(int? id)
        {
            ProductListViewModel model = null;
            if (id.HasValue)
                model = _service.GetHomeModel(id.Value);
            else
                return RedirectToAction("Index", "Home");


            return View(model);
        }

        public ActionResult Details(string id)
        {
            var model = _service.GetDetails(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
