using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kona.Model.Supply.Inventory {
    public abstract class InventoryState {
        InventoryState _internal;

        public abstract bool IsAvailable();



    }
}
