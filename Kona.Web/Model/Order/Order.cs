using System;
using System.Collections.Generic;
using System.Linq;

namespace Kona.Model
{

    [Serializable]
    public enum OrderStatus
    {
        NotCheckoutOut=1,
        Submitted=2,
        Verified=3,
        Charged=4,
        Packaging=5,
        Shipped=6,
        Returned=7,
        Cancelled=8,
        Refunded=9
    }

    [Serializable]
    public class Order {

        public virtual Guid ID { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string UserName { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual IList<OrderItem> Items { get; set; }
        public virtual IList<Transaction> Transactions { get; set; }
        public virtual string UserLanguageCode { get; set; }

        public virtual OrderStatus Status { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual ShippingMethod ShippingMethod { get; set; }
        public virtual decimal TaxAmount { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual DateTime? DateShipped { get; set; }
        public virtual DateTime? EstimatedDelivery { get; set; }
        public virtual string TrackingNumber { get; set; }
        public virtual TaxRate TaxRate { get; set; }
        //public LazyList<IIncentive> IncentivesUsed { get; set; }

        //public Order():this("","") {
        //}
        //public Order(string userName)
        //    : this("",userName) {
        //}
        //public Order(string orderNumber, string userName) {
        //    this.OrderNumber = orderNumber;
        //    this.UserName = userName;
        //    this.Status = OrderStatus.NotCheckoutOut;
        //    this.Items=new LazyList<OrderItem>();
        //    this.IncentivesUsed = new LazyList<IIncentive>();
        //    this.ID = Guid.NewGuid();
        //    this.DiscountAmount = 0;
        //    this.DiscountReason = "--";
        //}

        /// <summary>
        /// Adds a product to the cart
        /// </summary>
        public virtual void AddItem(Product product)
        {
            AddItem(product, 1);
        }


        /// <summary>
        /// Removes all items from cart
        /// </summary>
        public virtual void ClearItems()
        {
            Items.Clear();
        }

        /// <summary>
        /// Adds a product to the cart
        /// </summary>
        public virtual void AddItem(Product product, int quantity)
        {

            //see if this item is in the cart already
            OrderItem item = FindItem(product);

            if (quantity != 0) {
                if (item != null) {
                    //if the passed in amount is 0, do nothing
                    //as we're assuming "add 0 of this item" means
                    //do nothing
                    if (quantity != 0)
                        AdjustQuantity(product, item.Quantity + quantity);
                } else {
                    if (quantity > 0) {
                        item = new OrderItem();
                        item.Product = product;
                        item.Quantity = quantity;
                        
                        //add to list
                        Items.Add(item);
                    }
                }

            }

        }

        /// <summary>
        /// Adjusts the quantity of an item in the cart
        /// </summary>
        public virtual void AdjustQuantity(Product product, int newQuantity)
        {
            OrderItem itemToAdjust = FindItem(product);
            if (itemToAdjust != null) {
                if (newQuantity <= 0) {
                    RemoveItem(product);
                } else {
                    itemToAdjust.AdjustQuantity(newQuantity);
                }

            }

        }

        /// <summary>
        /// Remmoves a product from the cart
        /// </summary>
        public virtual void RemoveItem(Product product)
        {
            RemoveItem(product.SKU);
        }

        /// <summary>
        /// Remmoves a product from the cart
        /// </summary>
        public virtual void RemoveItem(string sku)
        {
            var itemToRemove = FindItem(sku);
            if (itemToRemove != null) {
                Items.Remove(itemToRemove);
            }
        }


        /// <summary>
        /// Finds an item in the cart
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public virtual OrderItem FindItem(Product product)
        {
            OrderItem result = null;
            if (product != null) {
                //see if this item is in the cart already
                return FindItem(product.SKU);
            }
            return result;

        }

        /// <summary>
        /// Finds an item in the cart
        /// </summary>
        /// <param name="productID">The product id to find</param>
        /// <returns></returns>
        public virtual OrderItem FindItem(string sku)
        {

            Items = Items ?? new List<OrderItem>();
            //see if this item is in the cart already
            return (from si in Items
                    where si.Product.SKU == sku
                    select si).SingleOrDefault();

        }


        public virtual void ValidateForCheckout()
        {

            //Must have 1 or more items
            if (Items.Count <= 0)
                throw new InvalidOperationException("Order must have one or more items");

            //every order must have a shipping address - used for tax calcs
            if (ShippingAddress == null)
                throw new InvalidOperationException("All orders must have a shipping address specified.");


            //make sure there's a payment method
            if (PaymentMethod == null)
                throw new InvalidOperationException("No payment method is set for this order");


            if (PaymentMethod is CreditCard) {
                CreditCard cc = PaymentMethod as CreditCard;

                if (!cc.IsValid())
                    throw new InvalidOperationException("This credit card is invalid. Please check the expiration and card number.");

            }


            if (HasShippableGoods) {

                //All orders with shippable goods must have shipping method 
                if (ShippingMethod == null)
                    throw new InvalidOperationException("Must have a shipping method selected when ordering shippable goods");

            }
        }


        public virtual decimal TaxableGoodsSubtotal
        {
            get
            {
                //one of the many reasons to love LINQ :)
                return Items.Where(x => x.Product.IsTaxable)
                    .Sum(x => x.LineTotal);
            }
        }

        public virtual decimal TotalWeightInPounds
        {
            get
            {
                return Items.Sum(x => x.ItemsWeight);
            }
        }

        public virtual bool HasShippableGoods
        {
            get
            {

                return Items.Where(x => x.Product.Delivery == DeliveryMethod.Shipped).Count()>0;
            }
        }


        public virtual string DiscountReason { get; set; }
        public virtual decimal DiscountAmount { get; set; }


        public virtual decimal SubTotal
        {
            get
            {

                return Items.Sum(x => x.LineTotal)-DiscountAmount;

            }
        }

        public virtual decimal Total
        {
            get
            {
                decimal total= SubTotal + TaxAmount;
                if(ShippingMethod!=null)
                    total += ShippingMethod.Cost;

                return total;
            }
        }

        public virtual decimal TotalPaid
        {
            get
            {
                decimal paid = 0;
                if (Transactions.Count > 0)
                    paid = Transactions.Sum(x => x.Amount);
                return paid;

            }
        }

        /// <summary>
        /// Returns the sum of the item quantity in the cart. 
        /// </summary>
        public virtual int TotalItemQuantity
        {
            get
            {
                int numItems = 0;
                if (Items.Count > 0)
                {
                    numItems = (from i in Items
                                select i.Quantity).Sum();
                }
                return numItems; 
            }
        }

        /// <summary>
        /// Reprices all items in the cart to reflect update item prices. 
        /// </summary>
        /// <returns>
        /// True if the operation resulted in a change in the 
        /// total price of the order.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Throws an InvalidOperationException if the cart 
        /// has been checked out. 
        /// </exception>
        public virtual bool RepriceItems()
        {
            if (Status != OrderStatus.NotCheckoutOut)
            {
                throw new InvalidOperationException("Order may not be repriced once checked out."); 
            }

            decimal startingTotal = Total; 
            return startingTotal != Total; 
        }


        #region Object overrides
        public override bool Equals(object obj) {
            if (obj is Order) {
                Order compareTo = (Order)obj;
                return compareTo.ID == ID;
            } else {
                return base.Equals(obj);
            }
        }

        public override string ToString() {
            return UserName + "'s Cart: " + Items.Count.ToString() + " items";
        }
        public override int GetHashCode() {
            return ID.GetHashCode();
        }
        #endregion
   }
}
