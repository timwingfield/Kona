using System;
using System.Linq;
using Kona.Helpers;
using Kona.Model;
using Kona.ViewModels;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Transform;

namespace Kona.App.Services {
    public interface IStoreService{
        ProductListViewModel GetHomeModel();
        DetailsViewModel GetDetails(string sku);
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

            //categories
            result.Categories = _session
                .CreateCriteria<Category>()
                .Future<Category>();

            
            var featuredProduct = _session
                .CreateCriteria<Product>()
                .SetFetchMode<Product>(x=>x.Descriptors,FetchMode.Join)
                .CreateCriteria<Product>(x=>x.Categories)
                .Add<Category>(x=>x.ID==33) 
                .SetResultTransformer(Transformers.DistinctRootEntity)
                .Future<Product>();

            result.FeaturedProduct = featuredProduct.First();
            result.FeaturedProducts = featuredProduct
                .Skip(1)
                .Take(3)
                .ToList();
            
            return result;

        }

        public DetailsViewModel GetDetails(string sku)
        {
            var result = new DetailsViewModel();
            
            //categories
            result.Categories = _session
                .CreateCriteria<Category>()
                .Future<Category>();
            

            //selected product
            result.SelectedProduct = _session.Get<Product>(sku);
            
            var orderIDsContainingCurrentSku=DetachedCriteria.For<OrderItem>()
                        .Add<OrderItem>(x=>x.Product.SKU==sku)
                        .SetProjection(Projections.Property("Order.id"));

            var skusOfProductsAppearingInOrdersContainingCurrentSku = 
                DetachedCriteria.For<OrderItem>()
                .SetProjection(Projections.GroupProperty("Product.id"))
                .AddOrder(NHibernate.Criterion.Order.Desc(Projections.Count("Order.id")))
                .Add<OrderItem>(x=>x.Product.SKU!=sku)
                .Add(Subqueries.PropertyIn("Order.id", orderIDsContainingCurrentSku))
                .SetMaxResults(15);
                
            result.Recommended = _session.CreateCriteria<Product>()
                .SetFetchMode<Product>(x => x.Descriptors, FetchMode.Join)
                .Add(Subqueries.PropertyIn("id", skusOfProductsAppearingInOrdersContainingCurrentSku))
                .SetResultTransformer(Transformers.DistinctRootEntity)
                .List<Product>();


            return result;

        }
    }
}
