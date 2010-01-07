namespace Kona.Model.Supply.Inventory {
    public class BackOrdered : InventoryState {

        public override bool CanAddToBasket {
            get { return false; }
        }

        public override bool CanBeDisplayed {
            get { return true; }
        }

        public override void AddToBasket(Product p) {
            
        }

        public override void RemoveFromBasket(Product p) {
        }
        public override string ToString() {
            return "Back Ordered";
        }
                public override Kona.Infrastructure.InventoryStatus Status {
            get { return Kona.Infrastructure.InventoryStatus.BackOrder; }
        }

    }
}
