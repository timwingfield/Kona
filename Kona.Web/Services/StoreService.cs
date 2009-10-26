using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kona.Model;
using Kona.ViewModels;
using NHibernate;
using NHibernate.Linq;

namespace Kona.App.Services {
    public class StoreService {

        ISession _session;
        public StoreService(ISession session) {
            _session = session;
        }
        
//        IStoreRepository _repo;
//        public StoreService(IStoreRepository repo){
//            _repo = repo;
//        }

//        public ProductListViewModel GetCategoryModel(int categoryID) {
//            var result = new ProductListViewModel();

//            //add the featured product
//            result.FeaturedProducts = _repo.GetProducts(categoryID);

//            //categories
//            result.Categories = _repo.GetCategories();
//            result.SelectedCategory = _repo.GetCategories().SingleOrDefault(x => x.ID == categoryID);

//            //organize them
//            result.Categories.ToList().ForEach(x => x.SubCategories = result.Categories.Where(y => y.ParentID == x.ID).ToList());


//            return result;


//        }
        public ProductListViewModel GetHomeModel() {
            var result = new ProductListViewModel();

            //add the featured product
            result.FeaturedProducts = _session.Linq<Product>()
                .Where(x => x.Categories.Any(c => c.ID == 33));

                //_session.CreateQuery("select p from Category c join c.Products p where c.Id = :categoryID")
                //.SetParameter("categoryID", 33).List<Product>();

            //categories
            result.Categories = _session.Linq<Category>();


            return result;


        }

//        public DetailsViewModel GetDetails(string sku) {
//            var result = new DetailsViewModel();
//            //categories
//            result.Categories = _repo.GetCategories();

//            //organize them
//            result.Categories.ToList().ForEach(x => x.SubCategories = result.Categories.Where(y => y.ParentID == x.ID).ToList());

//            result.SelectedProduct = _repo.GetProduct(sku);

//            return result;

//        }
   }
}
