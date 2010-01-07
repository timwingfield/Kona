namespace Kona.Model.Supply.Inventory {
    public class InStock : InventoryState {
        public override bool CanAddToBasket {
            get {  return true; }
        }

        public override bool CanBeDisplayed {
            get {  return false; }
        }
        public override void AddToBasket(Product p) {
            p.AmountOnHand--;
            if (p.AmountOnHand == 0)
                p.Inventory = new BackOrdered();
        }

        public override void RemoveFromBasket(Product p) {
            p.AmountOnHand++;
        
        }
        public override string ToString() {
            return "In Stock";
        }

        public override Kona.Infrastructure.InventoryStatus Status {
            get { return Kona.Infrastructure.InventoryStatus.InStock; }
        }
    }
}
