using System;
using System.Linq;
using Kona.Helpers;
using Kona.Model;
using Kona.ViewModels;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;

namespace Kona.App.Services {
    public interface IStoreService{
        ProductListViewModel GetHomeModel();
    }

    public class StoreService : IStoreService{

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

            //categories
            result.Categories = _session
                .CreateCriteria<Category>()
                .Future<Category>();


            var featuredProduct = _session
                .CreateCriteria<Product>()
                .SetFetchMode<Product>(x=>x.Descriptors,FetchMode.Join)
                .CreateCriteria<Product>(x=>x.Categories)
                .Add<Category>(x=>x.ID==33)                 
                .Future<Product>();

            result.FeaturedProduct = featuredProduct.First();
            result.FeaturedProducts = featuredProduct.Skip(1).Take(3).ToList();



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
