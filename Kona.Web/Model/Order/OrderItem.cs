using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                return this.Quantity*(this.Product.DiscountedPrice);

            }
        }
        public virtual decimal ItemsWeight
        {
            get
            {
                return this.Quantity * (this.Product.WeightInPounds);

            }
        }


        public virtual void AdjustQuantity(int newQuantity)
        {
            this.Quantity = newQuantity;
        }


        #region Object overrides
        public override bool Equals(object obj) {
            if (obj is OrderItem) {
                OrderItem compareTo = (OrderItem)obj;
                return compareTo.Product.SKU == this.Product.SKU;
            } else {
                return base.Equals(obj);
            }
        }

        public override string ToString() {
            return this.Product.Name+" ("+Quantity+")";
        }
        public override int GetHashCode() {
            return this.Product.SKU.GetHashCode();
        }
        #endregion
    }
}
