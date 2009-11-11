using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kona.Model.Supply.Inventory {
    public class PreOrder:InventoryState {
        public override bool IsAvailable(){
            throw new NotImplementedException();
        }
    }
}
