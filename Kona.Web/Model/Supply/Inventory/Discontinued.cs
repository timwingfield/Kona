using System;

namespace Kona.Model.Supply.Inventory{
    public class Discontinued:InventoryState{
        public override bool IsAvailable(){
            throw new NotImplementedException();
        }
    }
}