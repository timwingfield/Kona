using System.Collections.Generic;
using System.Linq;
using Kona.Model;

namespace Kona.ViewModels {
    public class DetailsViewModel {

        public Product SelectedProduct { get; set; }
        public IEnumerable<Category> ParentCategories {
            get {
                return Categories.Where(x => x.Parent==null);
            }
        }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Recent { get; set; }
        public IEnumerable<Product> Favorite { get; set; }
        public IEnumerable<Product> Recommended { get; set; }
        public Category HomeCategory
        {
            get {
                return Categories.SingleOrDefault(x => x.IsDefault);
            }
        }
    }
}
