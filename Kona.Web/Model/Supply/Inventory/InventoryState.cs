using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kona.Infrastructure;

namespace Kona.Model.Supply.Inventory {
    public abstract class InventoryState {
        public abstract bool CanAddToBasket { get; }
        public abstract bool CanBeDisplayed { get; }
        public abstract void AddToBasket(Product p);
        public abstract void RemoveFromBasket(Product p);

        public abstract InventoryStatus Status { get; }
        public static InventoryState Create(InventoryStatus status) {
            switch (status) {
                
                case InventoryStatus.InStock:
                    return new InStock();
                case InventoryStatus.BackOrder:
                    return new BackOrdered();

                default:
                    throw new NotImplementedException("boom!");
            }
        }

    }
}
