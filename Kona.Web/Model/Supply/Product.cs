using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;
using Kona.Model.Supply.Inventory;

namespace Kona.Model {
    


    public enum DeliveryMethod
    {
        Shipped = 1,
        Download = 2
    }

    
    public class Product {
        public virtual string SKU { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal DiscountPercent { get; set; }
        public virtual string Manufacturer { get; set; }
        public virtual DeliveryMethod Delivery { get; set; }
        public virtual decimal WeightInPounds { get; set; }
        public virtual bool IsTaxable { get; set; }
        public virtual bool AllowBackOrder { get; set; }
        public virtual bool AllowPreOrder { get; set; }
        public virtual string EstimatedDelivery { get; set; }
        public virtual string DefaultImage { get; set; }
        public virtual DateTime DateAvailable { get; set; }
        public virtual int AmountOnHand { get; set; }
        public virtual InventoryState Inventory { get; set; }
        public virtual decimal DiscountedPrice
        {
            get { return Price * (1.0M - DiscountPercent); } 
        }


        public virtual ICollection<Descriptor> Descriptors { get; set; }
        public virtual ICollection<Image> Images { get; set; }
       
        public virtual ISet<Category> Categories { get; set; }
        
        #region Object overrides
        public override bool Equals(object obj) {
            if (obj is Product) {
                Product compareTo = (Product)obj;
                return compareTo.SKU == SKU;
            } else {
                return base.Equals(obj);
            }
        }

        public override string ToString() {
            return Name;
        }
        public override int GetHashCode() {
            return SKU.GetHashCode();
        }
        #endregion
    }
}
