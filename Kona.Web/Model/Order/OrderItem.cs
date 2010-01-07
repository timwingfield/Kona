using System;

namespace Kona.Model {
    public class OrderItem {

        public virtual Order Order { get; set; }
        public virtual Product Product {get;set;}
        public virtual int Quantity { get; set; }
        public virtual DateTime DateAdded { get; set; }

        public virtual decimal LineTotal
        {
            get
            {
                return Quantity*(Product.DiscountedPrice);

            }
        }
        public virtual decimal ItemsWeight
        {
            get
            {
                return Quantity * (Product.WeightInPounds);

            }
        }


        public virtual void AdjustQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }


        #region Object overrides
        public override bool Equals(object obj) {
            if (obj is OrderItem) {
                OrderItem compareTo = (OrderItem)obj;
                return compareTo.Product.SKU == Product.SKU;
            } else {
                return base.Equals(obj);
            }
        }

        public override string ToString() {
            return Product.Name+" ("+Quantity+")";
        }
        public override int GetHashCode() {
            return Product.SKU.GetHashCode();
        }
        #endregion
    }
}
